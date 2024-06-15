using System;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper
{
    internal class listview1 : ListView
    {
        private const uint WM_CHANGEUISTATE = 295u;

        private const short UIS_SET = 1;

        private const short UISF_HIDEFOCUS = 1;

        private readonly IntPtr _removeDots = new IntPtr(listview1.MakeWin32Long(1, 1));

        private ListViewColumnSorter LvwColumnSorter { get; set; }

        public static int MakeWin32Long(short wLow, short wHigh)
        {
            return (wLow << 16) | wHigh;
        }

        public listview1()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            this.LvwColumnSorter = new ListViewColumnSorter();
            base.ListViewItemSorter = this.LvwColumnSorter;
            base.View = View.Details;
            base.FullRowSelect = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                _ = Environment.OSVersion.Version.Major;
            }
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                _ = Environment.OSVersion.Version.Major;
            }
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            if (e.Column == this.LvwColumnSorter.SortColumn)
            {
                this.LvwColumnSorter.Order = ((this.LvwColumnSorter.Order != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
            }
            else
            {
                this.LvwColumnSorter.SortColumn = e.Column;
                this.LvwColumnSorter.Order = SortOrder.Ascending;
            }
            if (!base.VirtualMode)
            {
                base.Sort();
            }
        }
    }
}
