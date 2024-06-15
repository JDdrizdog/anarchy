using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Anarchy.Forms;

public class notify : Form
{
    private bool areWeClosing;

    public const int WM_NCLBUTTONDOWN = 161;

    public const int HT_CAPTION = 2;

    private IContainer components;

    private Label label1;

    private Guna2BorderlessForm guna2BorderlessForm1;

    private Guna2Button webhookCheck;

    [DllImport("Gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    public notify(string message, bool exHmmm = false)
    {
        this.InitializeComponent();
        this.label1.Text = message;
        base.Region = Region.FromHrgn(notify.CreateRoundRectRgn(0, 0, base.Width, base.Height, 25, 25));
        if (exHmmm)
        {
            this.areWeClosing = true;
        }
        else
        {
            this.areWeClosing = false;
        }
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            notify.ReleaseCapture();
            notify.SendMessage(base.Handle, 161, 2, 0);
        }
    }

    private void notify_Load(object sender, EventArgs e)
    {
    }

    private void webhookCheck_Click(object sender, EventArgs e)
    {
        base.Hide();
        if (this.areWeClosing)
        {
            Environment.Exit(0);
        }
    }

    private void webhookCheck_MouseHover(object sender, EventArgs e)
    {
    }

    private void webhookCheck_MouseLeave(object sender, EventArgs e)
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
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notify));
        this.label1 = new System.Windows.Forms.Label();
        this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
        this.webhookCheck = new Guna.UI2.WinForms.Guna2Button();
        base.SuspendLayout();
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(5, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(344, 87);
        this.label1.TabIndex = 5;
        this.label1.Text = "Webhook, cannot be empty!";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.guna2BorderlessForm1.BorderRadius = 8;
        this.guna2BorderlessForm1.ContainerControl = this;
        this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
        this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Red;
        this.guna2BorderlessForm1.TransparentWhileDrag = true;
        this.webhookCheck.BackColor = System.Drawing.Color.Transparent;
        this.webhookCheck.BorderRadius = 8;
        this.webhookCheck.FillColor = System.Drawing.Color.FromArgb(30, 32, 37);
        this.webhookCheck.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.webhookCheck.ForeColor = System.Drawing.Color.White;
        this.webhookCheck.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.webhookCheck.Location = new System.Drawing.Point(5, 99);
        this.webhookCheck.Name = "webhookCheck";
        this.webhookCheck.PressedColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.webhookCheck.ShadowDecoration.BorderRadius = 10;
        this.webhookCheck.ShadowDecoration.Color = System.Drawing.Color.MediumSlateBlue;
        this.webhookCheck.ShadowDecoration.Depth = 20;
        this.webhookCheck.Size = new System.Drawing.Size(344, 39);
        this.webhookCheck.TabIndex = 198;
        this.webhookCheck.Text = "OK";
        this.webhookCheck.Click += new System.EventHandler(webhookCheck_Click);
        this.webhookCheck.MouseLeave += new System.EventHandler(webhookCheck_MouseLeave);
        this.webhookCheck.MouseHover += new System.EventHandler(webhookCheck_MouseHover);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 32, 37);
        base.ClientSize = new System.Drawing.Size(355, 144);
        base.Controls.Add(this.webhookCheck);
        base.Controls.Add(this.label1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "notify";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        base.Load += new System.EventHandler(notify_Load);
        base.MouseDown += new System.Windows.Forms.MouseEventHandler(Form1_MouseDown);
        base.ResumeLayout(false);
    }
}