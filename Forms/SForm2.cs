using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace Anarchy.Forms
{
    public class SForm2 : Form
    {
        private IContainer components;

        private Label label1;

        internal Label Label23;

        internal Label label2;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl1;

        private PictureBox pictureBox1;

        private SiticoneControlBox siticoneControlBox2;

        private SiticoneControlBox siticoneControlBox1;

        public SForm2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Delete the system?", "Important!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            MessageBox.Show("This is a joke", "Important!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
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
            resources = new ComponentResourceManager(typeof(SForm2));
            label1 = new Label();
            Label23 = new Label();
            label2 = new Label();
            guna2Elipse1 = new Guna2Elipse(components);
            guna2DragControl1 = new Guna2DragControl(components);
            pictureBox1 = new PictureBox();
            siticoneControlBox2 = new SiticoneControlBox();
            siticoneControlBox1 = new SiticoneControlBox();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Honeydew;
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(82, 19);
            label1.TabIndex = 6;
            label1.Text = "Anarchy 3.1";
            Label23.BackColor = Color.Transparent;
            Label23.Font = new Font("Roboto", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label23.ForeColor = Color.White;
            Label23.Location = new Point(84, 27);
            Label23.Name = "Label23";
            Label23.Size = new Size(258, 31);
            Label23.TabIndex = 24;
            Label23.Text = "The creators are ANDRO";
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(96, 122);
            label2.Name = "label2";
            label2.Size = new Size(234, 19);
            label2.TabIndex = 25;
            label2.Text = "If you use it then you are ANDRO\r\n\r\n";
            guna2Elipse1.BorderRadius = 8;
            guna2Elipse1.TargetControl = this;
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(439, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += new EventHandler(pictureBox1_DoubleClick);
            siticoneControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            siticoneControlBox2.BorderRadius = 10;
            siticoneControlBox2.ControlBoxType = ControlBoxType.MinimizeBox;
            siticoneControlBox2.FillColor = Color.FromArgb(32, 32, 32);
            siticoneControlBox2.HoveredState.Parent = siticoneControlBox2;
            siticoneControlBox2.IconColor = Color.White;
            siticoneControlBox2.Location = new Point(347, -2);
            siticoneControlBox2.Name = "siticoneControlBox2";
            siticoneControlBox2.ShadowDecoration.Parent = siticoneControlBox2;
            siticoneControlBox2.Size = new Size(45, 29);
            siticoneControlBox2.TabIndex = 28;
            siticoneControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            siticoneControlBox1.BorderRadius = 10;
            siticoneControlBox1.FillColor = Color.FromArgb(32, 32, 32);
            siticoneControlBox1.HoveredState.FillColor = Color.FromArgb(232, 17, 35);
            siticoneControlBox1.HoveredState.IconColor = Color.White;
            siticoneControlBox1.HoveredState.Parent = siticoneControlBox1;
            siticoneControlBox1.IconColor = Color.White;
            siticoneControlBox1.Location = new Point(392, -2);
            siticoneControlBox1.Name = "siticoneControlBox1";
            siticoneControlBox1.ShadowDecoration.Parent = siticoneControlBox1;
            siticoneControlBox1.Size = new Size(45, 29);
            siticoneControlBox1.TabIndex = 27;
            siticoneControlBox1.Click += new EventHandler(siticoneControlBox1_Click);
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(437, 150);
            Controls.Add(siticoneControlBox2);
            Controls.Add(siticoneControlBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(Label23);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SForm2";
            Text = resources.GetString("$this.Text");
            Load += new EventHandler(Form2_Load);
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
