using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleFun
    {
        public void Fun(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormFun formFun;
                formFun = (FormFun)Application.OpenForms["fun:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                if (formFun != null && formFun.Client == null)
                {
                    formFun.Client = client;
                    formFun.timer1.Enabled = true;
                }
            }
            catch
            {
            }
        }
    }
}
