using System;
using System.Windows.Forms;
using Anarchy.Forms;

namespace Anarchy;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        MessageBox.Show("Cracked by @ReverseEngineeringLab");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        form1 = new Form1();
        Application.Run(form1);
    }

    public static Form1 form1;
}