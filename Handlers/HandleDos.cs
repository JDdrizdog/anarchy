using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    internal class HandleDos
    {
        public void Add(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormDOS formDOS;
                formDOS = (FormDOS)Application.OpenForms["DOS"];
                if (formDOS != null)
                {
                    lock (formDOS.sync)
                    {
                        formDOS.PlguinClients.Add(client);
                        return;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
