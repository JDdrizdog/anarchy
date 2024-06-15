using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Anarchy.HCS
{
    public class FrmTransfer : Form
    {
        public int int_0;

        private IContainer components;

        private ProgressBar DuplicateProgess;

        private Label FileTransferLabel;

        private Label PingTransform;

        public ProgressBar DuplicateProgesse
        {
            get
            {
                return this.DuplicateProgess;
            }
            set
            {
                this.DuplicateProgess = value;
            }
        }

        public Label FileTransferLabele
        {
            get
            {
                return this.FileTransferLabel;
            }
            set
            {
                this.FileTransferLabel = value;
            }
        }

        public Label PingTransfor
        {
            get
            {
                return this.PingTransform;
            }
            set
            {
                this.PingTransform = value;
            }
        }

        public FrmTransfer()
        {
            this.int_0 = 0;
            this.InitializeComponent();
        }

        private void FrmTransfer_Load(object sender, EventArgs e)
        {
        }

        public void DuplicateProfile(int int_1)
        {
            if (int_1 > this.int_0)
            {
                int_1 = this.int_0;
            }
            this.FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(this.int_0) + " MB";
            this.DuplicateProgess.Value = int_1;
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
            this.DuplicateProgess = new System.Windows.Forms.ProgressBar();
            this.FileTransferLabel = new System.Windows.Forms.Label();
            this.PingTransform = new System.Windows.Forms.Label();
            base.SuspendLayout();
            this.DuplicateProgess.Location = new System.Drawing.Point(12, 12);
            this.DuplicateProgess.Name = "DuplicateProgess";
            this.DuplicateProgess.Size = new System.Drawing.Size(453, 23);
            this.DuplicateProgess.TabIndex = 1;
            this.FileTransferLabel.AutoSize = true;
            this.FileTransferLabel.Location = new System.Drawing.Point(120, 44);
            this.FileTransferLabel.Name = "FileTransferLabel";
            this.FileTransferLabel.Size = new System.Drawing.Size(37, 13);
            this.FileTransferLabel.TabIndex = 4;
            this.FileTransferLabel.Text = "Status";
            this.PingTransform.AutoSize = true;
            this.PingTransform.Location = new System.Drawing.Point(255, 44);
            this.PingTransform.Name = "PingTransform";
            this.PingTransform.Size = new System.Drawing.Size(95, 13);
            this.PingTransform.TabIndex = 5;
            this.PingTransform.Text = "Ping: Measuring....";
            this.PingTransform.Visible = false;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(475, 66);
            base.Controls.Add(this.FileTransferLabel);
            base.Controls.Add(this.DuplicateProgess);
            base.Controls.Add(this.PingTransform);
            base.Name = "FrmTransfer";
            base.Opacity = 0.0;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.Load += new System.EventHandler(FrmTransfer_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
