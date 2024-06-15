using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Anarchy.Properties;
using Anarchy.StreamLibrary;
using Anarchy.StreamLibrary.UnsafeCodecs;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormRemoteDesktop : Form
{
    public int FPS;

    public Stopwatch sw = Stopwatch.StartNew();

    public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

    public Size rdSize;

    private bool isMouse;

    private bool isKeyboard;

    public object syncPicbox = new object();

    private readonly List<Keys> _keysPressed;

    private const int cGrip = 16;

    private const int cCaption = 32;

    private IContainer components;

    public PictureBox pictureBox1;

    public System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.Timer timerSave;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    private Guna2DragControl guna2DragControl1;

    private Guna2ResizeForm guna2ResizeForm1;

    private Guna2Panel guna2Panel1;

    internal Guna2CircleProgressBar Guna2CircleProgressBar2;

    private Guna2Button guna2Button8;

    private Guna2Elipse guna2Elipse1;

    private Guna2Elipse guna2Elipse2;

    public Guna2Button button1;

    public Guna2NumericUpDown numericUpDown1;

    public Guna2Button btnSave;

    public Guna2Button btnMouse;

    public Guna2Button btnKeyboard;

    public Guna2NumericUpDown numericUpDown2;

    private Label label1;

    private SiticoneControlBox siticoneControlBox1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public Form1 F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public Image GetImage { get; set; }

    public FormRemoteDesktop()
    {
        this._keysPressed = new List<Keys>();
        this.InitializeComponent();
        base.SetStyle(ControlStyles.ResizeRedraw, value: true);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 132)
        {
            Point p;
            p = new Point(m.LParam.ToInt32());
            p = base.PointToClient(p);
            if (p.Y < 32)
            {
                m.Result = (IntPtr)2;
                return;
            }
            if (p.X >= base.ClientSize.Width - 16 && p.Y >= base.ClientSize.Height - 16)
            {
                m.Result = (IntPtr)17;
                return;
            }
        }
        base.WndProc(ref m);
    }

    private void timer1_Tick(object sender, EventArgs e)
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

    private void FormRemoteDesktop_Load(object sender, EventArgs e)
    {
        try
        {
            this.button1.Tag = "stop";
        }
        catch
        {
        }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.button1.Tag == "play")
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
            msgPack.ForcePathObject("Option").AsString = "capture";
            msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(this.numericUpDown1.Value.ToString());
            msgPack.ForcePathObject("Screen").AsInteger = Convert.ToInt32(this.numericUpDown2.Value.ToString());
            this.decoder = new UnsafeStreamCodec(Convert.ToInt32(this.numericUpDown1.Value));
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            this.numericUpDown1.Enabled = false;
            this.numericUpDown2.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnMouse.Enabled = true;
            this.btnKeyboard.Enabled = true;
            this.button1.Tag = "stop";
            this.button1.Image = Resources.stop;
        }
        else
        {
            this.button1.Tag = "play";
            try
            {
                MsgPack msgPack2;
                msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack2.ForcePathObject("Option").AsString = "stop";
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack2.Encode2Bytes());
            }
            catch
            {
            }
            this.numericUpDown1.Enabled = true;
            this.numericUpDown2.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnMouse.Enabled = false;
            this.btnKeyboard.Enabled = false;
            this.button1.Image = Resources.play;
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (this.button1.Tag != "stop")
        {
            return;
        }
        if (this.timerSave.Enabled)
        {
            this.timerSave.Stop();
            this.btnSave.Image = Resources.FVrOS;
            return;
        }
        this.timerSave.Start();
        this.btnSave.Image = Resources.OfJJFYeDS;
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
    }

    private void TimerSave_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(this.FullPath))
            {
                Directory.CreateDirectory(this.FullPath);
            }
            Encoder quality;
            quality = Encoder.Quality;
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            EncoderParameter encoderParameter;
            encoderParameter = new EncoderParameter(quality, 50L);
            encoderParameters.Param[0] = encoderParameter;
            ImageCodecInfo encoder;
            encoder = this.GetEncoder(ImageFormat.Jpeg);
            this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", encoder, encoderParameters);
            encoderParameters?.Dispose();
            encoderParameter?.Dispose();
        }
        catch
        {
        }
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] imageDecoders;
        imageDecoders = ImageCodecInfo.GetImageDecoders();
        int num;
        num = 0;
        ImageCodecInfo imageCodecInfo;
        while (true)
        {
            if (num < imageDecoders.Length)
            {
                imageCodecInfo = imageDecoders[num];
                if (imageCodecInfo.FormatID == format.Guid)
                {
                    break;
                }
                num++;
                continue;
            }
            return null;
        }
        return imageCodecInfo;
    }

    private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
            {
                Point point;
                point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                int num;
                num = 0;
                if (e.Button == MouseButtons.Left)
                {
                    num = 2;
                }
                if (e.Button == MouseButtons.Right)
                {
                    num = 8;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "mouseClick";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                msgPack.ForcePathObject("Button").AsInteger = num;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
            {
                Point point;
                point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                int num;
                num = 0;
                if (e.Button == MouseButtons.Left)
                {
                    num = 4;
                }
                if (e.Button == MouseButtons.Right)
                {
                    num = 16;
                }
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "mouseClick";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                msgPack.ForcePathObject("Button").AsInteger = num;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
            {
                Point point;
                point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "mouseMove";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        if (this.isMouse)
        {
            this.isMouse = false;
            this.btnMouse.Image = Resources.icons8_undefined_24__1_;
        }
        else
        {
            this.isMouse = true;
            this.btnMouse.Image = Resources.mouse_off;
        }
        this.pictureBox1.Focus();
    }

    private void FormRemoteDesktop_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            this.GetImage?.Dispose();
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.Client?.Disconnected();
            });
        }
        catch
        {
        }
    }

    private void btnKeyboard_Click(object sender, EventArgs e)
    {
        if (this.isKeyboard)
        {
            this.isKeyboard = false;
            this.btnKeyboard.Image = Resources.keyboard_24;
        }
        else
        {
            this.isKeyboard = true;
            this.btnKeyboard.Image = Resources.icons8_keyboard_24__2_;
        }
        this.pictureBox1.Focus();
    }

    private void FormRemoteDesktop_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isKeyboard)
        {
            if (!this.IsLockKey(e.KeyCode))
            {
                e.Handled = true;
            }
            if (!this._keysPressed.Contains(e.KeyCode))
            {
                this._keysPressed.Add(e.KeyCode);
                MsgPack msgPack;
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "keyboardClick";
                msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
                msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: true);
                ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            }
        }
    }

    private void FormRemoteDesktop_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && base.ContainsFocus && this.isKeyboard)
        {
            if (!this.IsLockKey(e.KeyCode))
            {
                e.Handled = true;
            }
            this._keysPressed.Remove(e.KeyCode);
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
            msgPack.ForcePathObject("Option").AsString = "keyboardClick";
            msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
            msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: false);
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
        }
    }

    private bool IsLockKey(Keys key)
    {
        if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
        {
            return (key & Keys.Scroll) == Keys.Scroll;
        }
        return true;
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemoteDesktop));
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.timerSave = new System.Windows.Forms.Timer(this.components);
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.label1 = new System.Windows.Forms.Label();
        this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
        this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        this.numericUpDown2 = new Guna.UI2.WinForms.Guna2NumericUpDown();
        this.btnKeyboard = new Guna.UI2.WinForms.Guna2Button();
        this.btnMouse = new Guna.UI2.WinForms.Guna2Button();
        this.btnSave = new Guna.UI2.WinForms.Guna2Button();
        this.numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
        this.button1 = new Guna.UI2.WinForms.Guna2Button();
        this.Guna2CircleProgressBar2 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.guna2Panel2.SuspendLayout();
        this.guna2Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.timer1.Interval = 2000;
        this.timer1.Tick += new System.EventHandler(timer1_Tick);
        this.timerSave.Interval = 1500;
        this.timerSave.Tick += new System.EventHandler(TimerSave_Tick);
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.label1);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox1);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(48, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(637, 23);
        this.guna2Panel2.TabIndex = 29;
        this.label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(6, 3);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(105, 18);
        this.label1.TabIndex = 23;
        this.label1.Text = "Remote Desktop";
        this.siticoneControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox1.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox1.BorderRadius = 10;
        this.siticoneControlBox1.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MaximizeBox;
        this.siticoneControlBox1.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
        this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox1.Location = new System.Drawing.Point(592, 3);
        this.siticoneControlBox1.Name = "siticoneControlBox1";
        this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
        this.siticoneControlBox1.Size = new System.Drawing.Size(18, 18);
        this.siticoneControlBox1.TabIndex = 22;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(568, 3);
        this.siticoneControlBox4.Name = "siticoneControlBox4";
        this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.Size = new System.Drawing.Size(18, 18);
        this.siticoneControlBox4.TabIndex = 21;
        this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.BorderRadius = 10;
        this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox3.Location = new System.Drawing.Point(616, 3);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(18, 18);
        this.siticoneControlBox3.TabIndex = 20;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Panel1.Controls.Add(this.numericUpDown2);
        this.guna2Panel1.Controls.Add(this.btnKeyboard);
        this.guna2Panel1.Controls.Add(this.btnMouse);
        this.guna2Panel1.Controls.Add(this.btnSave);
        this.guna2Panel1.Controls.Add(this.numericUpDown1);
        this.guna2Panel1.Controls.Add(this.button1);
        this.guna2Panel1.Controls.Add(this.Guna2CircleProgressBar2);
        this.guna2Panel1.Controls.Add(this.guna2Button8);
        this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
        this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel1.Name = "guna2Panel1";
        this.guna2Panel1.Size = new System.Drawing.Size(48, 387);
        this.guna2Panel1.TabIndex = 30;
        this.numericUpDown2.BackColor = System.Drawing.Color.Transparent;
        this.numericUpDown2.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.numericUpDown2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.numericUpDown2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.numericUpDown2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.numericUpDown2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.numericUpDown2.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
        this.numericUpDown2.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
        this.numericUpDown2.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.numericUpDown2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.numericUpDown2.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
        this.numericUpDown2.Location = new System.Drawing.Point(2, 324);
        this.numericUpDown2.Name = "numericUpDown2";
        this.numericUpDown2.Size = new System.Drawing.Size(45, 22);
        this.numericUpDown2.TabIndex = 131;
        this.numericUpDown2.UpDownButtonFillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.numericUpDown2.Visible = false;
        this.btnKeyboard.Animated = true;
        this.btnKeyboard.BackColor = System.Drawing.Color.Transparent;
        this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.btnKeyboard.BorderRadius = 4;
        this.btnKeyboard.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.btnKeyboard.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.btnKeyboard.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnKeyboard.ForeColor = System.Drawing.Color.White;
        this.btnKeyboard.Image = (System.Drawing.Image)resources.GetObject("btnKeyboard.Image");
        this.btnKeyboard.Location = new System.Drawing.Point(3, 222);
        this.btnKeyboard.Name = "btnKeyboard";
        this.btnKeyboard.Size = new System.Drawing.Size(40, 47);
        this.btnKeyboard.TabIndex = 130;
        this.btnKeyboard.Click += new System.EventHandler(btnKeyboard_Click);
        this.btnMouse.Animated = true;
        this.btnMouse.BackColor = System.Drawing.Color.Transparent;
        this.btnMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.btnMouse.BorderRadius = 4;
        this.btnMouse.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.btnMouse.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.btnMouse.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnMouse.ForeColor = System.Drawing.Color.White;
        this.btnMouse.Image = Resources.icons8_undefined_24__1_;
        this.btnMouse.Location = new System.Drawing.Point(3, 169);
        this.btnMouse.Name = "btnMouse";
        this.btnMouse.Size = new System.Drawing.Size(41, 47);
        this.btnMouse.TabIndex = 129;
        this.btnMouse.Click += new System.EventHandler(Button3_Click);
        this.btnSave.Animated = true;
        this.btnSave.BackColor = System.Drawing.Color.Transparent;
        this.btnSave.BackgroundImage = Resources.stop;
        this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.btnSave.BorderRadius = 4;
        this.btnSave.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.btnSave.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Image = Resources.FVrOS;
        this.btnSave.Location = new System.Drawing.Point(3, 116);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(40, 47);
        this.btnSave.TabIndex = 128;
        this.btnSave.Click += new System.EventHandler(BtnSave_Click);
        this.numericUpDown1.BackColor = System.Drawing.Color.Transparent;
        this.numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
        this.numericUpDown1.BorderRadius = 3;
        this.numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.numericUpDown1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.numericUpDown1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.numericUpDown1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.numericUpDown1.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
        this.numericUpDown1.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
        this.numericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.numericUpDown1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
        this.numericUpDown1.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
        this.numericUpDown1.Location = new System.Drawing.Point(2, 275);
        this.numericUpDown1.Minimum = new decimal(new int[4] { 20, 0, 0, 0 });
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.ShadowDecoration.BorderRadius = 4;
        this.numericUpDown1.ShadowDecoration.Color = System.Drawing.Color.Silver;
        this.numericUpDown1.ShadowDecoration.Depth = 7;
        this.numericUpDown1.ShadowDecoration.Enabled = true;
        this.numericUpDown1.Size = new System.Drawing.Size(43, 25);
        this.numericUpDown1.TabIndex = 127;
        this.numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.Plum;
        this.numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.numericUpDown1.Value = new decimal(new int[4] { 50, 0, 0, 0 });
        this.button1.Animated = true;
        this.button1.BackColor = System.Drawing.Color.Transparent;
        this.button1.BackgroundImage = Resources.stop;
        this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.button1.BorderRadius = 4;
        this.button1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.button1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Image = Resources.stop;
        this.button1.Location = new System.Drawing.Point(3, 63);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(42, 47);
        this.button1.TabIndex = 55;
        this.button1.Click += new System.EventHandler(Button1_Click);
        this.Guna2CircleProgressBar2.Animated = true;
        this.Guna2CircleProgressBar2.FillColor = System.Drawing.Color.FromArgb(30, 32, 50);
        this.Guna2CircleProgressBar2.FillThickness = 10;
        this.Guna2CircleProgressBar2.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.Guna2CircleProgressBar2.ForeColor = System.Drawing.Color.White;
        this.Guna2CircleProgressBar2.Location = new System.Drawing.Point(8, 3);
        this.Guna2CircleProgressBar2.Minimum = 0;
        this.Guna2CircleProgressBar2.Name = "Guna2CircleProgressBar2";
        this.Guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Magenta;
        this.Guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(126, 106, 231);
        this.Guna2CircleProgressBar2.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
        this.Guna2CircleProgressBar2.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
        this.Guna2CircleProgressBar2.ProgressThickness = 10;
        this.Guna2CircleProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.Guna2CircleProgressBar2.Size = new System.Drawing.Size(36, 36);
        this.Guna2CircleProgressBar2.TabIndex = 22;
        this.Guna2CircleProgressBar2.Value = 70;
        this.guna2Button8.Animated = true;
        this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button8.BorderRadius = 4;
        this.guna2Button8.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.guna2Button8.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2Button8.ForeColor = System.Drawing.Color.White;
        this.guna2Button8.Image = (System.Drawing.Image)resources.GetObject("guna2Button8.Image");
        this.guna2Button8.Location = new System.Drawing.Point(16, 421);
        this.guna2Button8.Name = "guna2Button8";
        this.guna2Button8.Size = new System.Drawing.Size(24, 28);
        this.guna2Button8.TabIndex = 54;
        this.guna2Button8.UseTransparentBackground = true;
        this.guna2Button8.Visible = false;
        this.guna2Elipse1.TargetControl = this.guna2Panel2;
        this.guna2Elipse2.TargetControl = this.guna2Panel1;
        this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.pictureBox1.Location = new System.Drawing.Point(48, 24);
        this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(634, 361);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 0;
        this.pictureBox1.TabStop = false;
        this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(PictureBox1_MouseDown);
        this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
        this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(PictureBox1_MouseUp);
        this.guna2BorderlessForm1.AnimateWindow = true;
        this.guna2BorderlessForm1.BorderRadius = 6;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.HasFormShadow = false;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Honeydew;
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(685, 387);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.pictureBox1);
        base.Controls.Add(this.guna2Panel1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.KeyPreview = true;
        base.Margin = new System.Windows.Forms.Padding(2);
        this.MinimumSize = new System.Drawing.Size(442, 300);
        base.Name = "FormRemoteDesktop";
        this.Text = "Remote Desktop";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormRemoteDesktop_FormClosed);
        base.Load += new System.EventHandler(FormRemoteDesktop_Load);
        base.KeyDown += new System.Windows.Forms.KeyEventHandler(FormRemoteDesktop_KeyDown);
        base.KeyUp += new System.Windows.Forms.KeyEventHandler(FormRemoteDesktop_KeyUp);
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}