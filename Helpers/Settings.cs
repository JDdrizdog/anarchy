using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Anarchy.Networking;

namespace Anarchy.Helpers;

public static class Settings
{
    public static class XmrSettings
    {
        public static string Pool = "";

        public static string Wallet = "";

        public static string Pass = "";

        public static string InjectTo = "";

        public static string Hash = "";
    }

    public static List<string> Blocked = new List<string>();

    public static object LockBlocked = new object();

    public static object LockReceivedSendValue = new object();

    public static string CertificatePath = Application.StartupPath + "\\Usrs.p12";

    public static X509Certificate2 ServerCertificate;

    public static readonly string Version = "";

    public static object LockListviewClients = new object();

    public static object LockListviewLogs = new object();

    public static object LockListviewThumb = new object();

    public static bool ReportWindow = false;

    public static List<Clients> ReportWindowClients = new List<Clients>();

    public static object LockReportWindowClients = new object();

    public static long SentValue { get; set; }

    public static long ReceivedValue { get; set; }
}