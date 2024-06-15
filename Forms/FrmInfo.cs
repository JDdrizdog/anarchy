using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Anarchy.Forms;

public class FrmInfo : Form
{
    private IContainer components;

    private RichTextBox textBox1;

    private Guna2Panel guna2Panel2;

    private SiticoneControlBox siticoneControlBox4;

    private SiticoneControlBox siticoneControlBox3;

    internal Label Label22;

    private Guna2Elipse guna2Elipse1;

    private Guna2DragControl guna2DragControl1;

    private Guna2VScrollBar guna2VScrollBar1;

    public FrmInfo(string path)
    {
        this.InitializeComponent();
        string obj;
        obj = File.ReadAllText(path);
        this.textBox1.Text = obj;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
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
        this.textBox1 = new System.Windows.Forms.RichTextBox();
        this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        this.Label22 = new System.Windows.Forms.Label();
        this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.siticoneControlBox3 = new Siticone.UI.WinForms.SiticoneControlBox();
        this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
        this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
        this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
        this.guna2Panel2.SuspendLayout();
        base.SuspendLayout();
        this.textBox1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBox1.ForeColor = System.Drawing.Color.DarkSeaGreen;
        this.textBox1.Location = new System.Drawing.Point(0, 41);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(692, 405);
        this.textBox1.TabIndex = 4;
        this.textBox1.Text = "";
        this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
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
        this.guna2Panel2.Size = new System.Drawing.Size(692, 41);
        this.guna2Panel2.TabIndex = 29;
        this.Label22.AutoSize = true;
        this.Label22.BackColor = System.Drawing.Color.Transparent;
        this.Label22.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.Label22.ForeColor = System.Drawing.Color.White;
        this.Label22.Location = new System.Drawing.Point(6, 10);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(165, 21);
        this.Label22.TabIndex = 22;
        this.Label22.Text = "|\\| System Information";
        this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.BorderRadius = 10;
        this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
        this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
        this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
        this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
        this.siticoneControlBox4.Location = new System.Drawing.Point(593, 5);
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
        this.siticoneControlBox3.Location = new System.Drawing.Point(644, 5);
        this.siticoneControlBox3.Name = "siticoneControlBox3";
        this.siticoneControlBox3.PressedColor = System.Drawing.Color.DarkRed;
        this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
        this.siticoneControlBox3.Size = new System.Drawing.Size(45, 29);
        this.siticoneControlBox3.TabIndex = 20;
        this.guna2Elipse1.BorderRadius = 9;
        this.guna2Elipse1.TargetControl = this;
        this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
        this.guna2DragControl1.TargetControl = this.guna2Panel2;
        this.guna2DragControl1.UseTransparentDrag = true;
        this.guna2VScrollBar1.BindingContainer = this.textBox1;
        this.guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(24, 24, 24);
        this.guna2VScrollBar1.InUpdate = false;
        this.guna2VScrollBar1.LargeChange = 10;
        this.guna2VScrollBar1.Location = new System.Drawing.Point(674, 41);
        this.guna2VScrollBar1.Name = "guna2VScrollBar1";
        this.guna2VScrollBar1.ScrollbarSize = 18;
        this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 405);
        this.guna2VScrollBar1.TabIndex = 30;
        this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
        base.ClientSize = new System.Drawing.Size(692, 446);
        base.Controls.Add(this.guna2VScrollBar1);
        base.Controls.Add(this.textBox1);
        base.Controls.Add(this.guna2Panel2);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Name = "FrmInfo";
        base.Opacity = 0.97;
        this.Text = "Information";
        this.guna2Panel2.ResumeLayout(false);
        this.guna2Panel2.PerformLayout();
        base.ResumeLayout(false);
    }
}