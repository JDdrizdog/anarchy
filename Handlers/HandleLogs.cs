using System.Drawing;
using System.Windows.Forms;
using Anarchy.Auth;
using Anarchy.Helpers;

namespace Anarchy.Handlers
{
    public class HandleLogs
    {
        public void Addmsg(string Msg, Color color)
        {
            try
            {
                ListViewItem LV;
                LV = new ListViewItem();
                LV.SubItems.Add(Msg);
                LV.ForeColor = color;
                if (Login.form1.InvokeRequired)
                {
                    Login.form1.Invoke((MethodInvoker)delegate
                    {
                        lock (Settings.LockListviewLogs)
                        {
                            Login.form1.listView2.Items.Insert(0, LV);
                        }
                    });
                    return;
                }
                lock (Settings.LockListviewLogs)
                {
                    Login.form1.listView2.Items.Insert(0, LV);
                }
            }
            catch
            {
            }
        }
    }
}
