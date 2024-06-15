using System;
using System.ComponentModel;
using System.Windows.Forms;
using Anarchy.Properties;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Anarchy.Forms;

public class FormSetting : Form
{
    private IContainer components;

    private System.Windows.Forms.CheckBox checkBox1;

    private TextBox textBox1;

    private TextBox textBox2;

    private Label label1;

    private Label label2;

    private HopeForm hopeForm1;

    private HopeButton button1;

    public FormSetting()
    {
        this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (this.checkBox1.Checked && (this.textBox1.Text == null || this.textBox2.Text == null))
        {
            MessageBox.Show("Input the WebHook and secret");
        }
        Settings.Default.DingDing = this.checkBox1.Checked;
        Settings.Default.WebHook = this.textBox1.Text;
        Settings.Default.Secret = this.textBox2.Text;
        Settings.Default.Save();
        base.Close();
    }

    private void FormSetting_Load(object sender, EventArgs e)
    {
        this.checkBox1.Checked = Settings.Default.DingDing;
        this.textBox1.Text = Settings.Default.WebHook;
        this.textBox2.Text = Settings.Default.Secret;
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
        this.checkBox1 = new System.Windows.Forms.CheckBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
        this.button1 = new ReaLTaiizor.Controls.HopeButton();
        base.SuspendLayout();
        this.checkBox1.AutoSize = true;
        this.checkBox1.Location = new System.Drawing.Point(12, 42);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.Size = new System.Drawing.Size(70, 17);
        this.checkBox1.TabIndex = 1;
        this.checkBox1.Text = "DingDing";
        this.checkBox1.UseVisualStyleBackColor = true;
        this.textBox1.Location = new System.Drawing.Point(71, 65);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(262, 20);
        this.textBox1.TabIndex = 2;
        this.textBox2.Location = new System.Drawing.Point(71, 101);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(262, 20);
        this.textBox2.TabIndex = 3;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 68);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(57, 13);
        this.label1.TabIndex = 4;
        this.label1.Text = "Webhook:";
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 104);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(41, 13);
        this.label2.TabIndex = 5;
        this.label2.Text = "Secret:";
        this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(228, 231, 237);
        this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(245, 108, 108);
        this.hopeForm1.ControlBoxColorN = System.Drawing.Color.Black;
        this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
        this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
        this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.hopeForm1.Image = null;
        this.hopeForm1.Location = new System.Drawing.Point(0, 0);
        this.hopeForm1.MaximizeBox = false;
        this.hopeForm1.MinimizeBox = false;
        this.hopeForm1.Name = "hopeForm1";
        this.hopeForm1.Size = new System.Drawing.Size(345, 40);
        this.hopeForm1.TabIndex = 6;
        this.hopeForm1.Text = "Settings";
        this.hopeForm1.ThemeColor = System.Drawing.Color.White;
        this.button1.BorderColor = System.Drawing.Color.FromArgb(220, 223, 230);
        this.button1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.DangerColor = System.Drawing.Color.FromArgb(245, 108, 108);
        this.button1.DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255);
        this.button1.Font = new System.Drawing.Font("Segoe UI", 12f);
        this.button1.HoverTextColor = System.Drawing.Color.FromArgb(48, 49, 51);
        this.button1.InfoColor = System.Drawing.Color.FromArgb(144, 147, 153);
        this.button1.Location = new System.Drawing.Point(9, 136);
        this.button1.Name = "button1";
        this.button1.PrimaryColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.button1.Size = new System.Drawing.Size(327, 29);
        this.button1.SuccessColor = System.Drawing.Color.FromArgb(103, 194, 58);
        this.button1.TabIndex = 15;
        this.button1.Text = "OK";
        this.button1.TextColor = System.Drawing.Color.White;
        this.button1.WarningColor = System.Drawing.Color.FromArgb(230, 162, 60);
        this.button1.Click += new System.EventHandler(button1_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(345, 170);
        base.Controls.Add(this.button1);
        base.Controls.Add(this.hopeForm1);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.textBox2);
        base.Controls.Add(this.textBox1);
        base.Controls.Add(this.checkBox1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1920, 1080);
        base.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(190, 40);
        base.Name = "FormSetting";
        base.ShowInTaskbar = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Setting";
        base.Load += new System.EventHandler(FormSetting_Load);
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}