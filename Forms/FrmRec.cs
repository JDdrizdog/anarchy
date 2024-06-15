using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Anarchy.Forms;

public class FrmRec : Form
{
    private IContainer components;

    private TextBox txtPasswords;

    private TextBox txtCookies;

    private Guna2Panel guna2Panel1;

    public FrmRec(string pass, string cookies)
    {
        this.InitializeComponent();
        string obj;
        obj = File.ReadAllText(pass);
        this.txtPasswords.Text = obj;
        string obj2;
        obj2 = File.ReadAllText(cookies);
        this.txtCookies.Text = obj2;
    }

    [DllImport("user32.DLL")]
    private static extern void ReleaseCapture();

    [DllImport("user32.DLL")]
    private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

    private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
    {
        FrmRec.ReleaseCapture();
        FrmRec.SendMessage(base.Handle, 274, 61458, 0);
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
        this.txtPasswords = new System.Windows.Forms.TextBox();
        this.txtCookies = new System.Windows.Forms.TextBox();
        this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        base.SuspendLayout();
        this.txtPasswords.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.txtPasswords.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtPasswords.ForeColor = System.Drawing.Color.LightGray;
        this.txtPasswords.Location = new System.Drawing.Point(0, 66);
        this.txtPasswords.Multiline = true;
        this.txtPasswords.Name = "txtPasswords";
        this.txtPasswords.Size = new System.Drawing.Size(405, 372);
        this.txtPasswords.TabIndex = 1;
        this.txtCookies.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
        this.txtCookies.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtCookies.ForeColor = System.Drawing.Color.LightGray;
        this.txtCookies.Location = new System.Drawing.Point(411, 107);
        this.txtCookies.Multiline = true;
        this.txtCookies.Name = "txtCookies";
        this.txtCookies.Size = new System.Drawing.Size(383, 299);
        this.txtCookies.TabIndex = 2;
        this.guna2Panel1.Location = new System.Drawing.Point(517, 12);
        this.guna2Panel1.Name = "guna2Panel1";
        this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
        this.guna2Panel1.Size = new System.Drawing.Size(200, 100);
        this.guna2Panel1.TabIndex = 3;
        this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(800, 450);
        base.Controls.Add(this.guna2Panel1);
        base.Controls.Add(this.txtCookies);
        base.Controls.Add(this.txtPasswords);
        base.Name = "FrmRec";
        this.Text = "Form2";
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}