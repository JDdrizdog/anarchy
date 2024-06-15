using System.Collections;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper
{
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;

        public int SortColumn
        {
            get
            {
                return this.ColumnToSort;
            }
            set
            {
                this.ColumnToSort = value;
            }
        }

        public SortOrder Order
        {
            get
            {
                return this.OrderOfSort;
            }
            set
            {
                this.OrderOfSort = value;
            }
        }

        public ListViewColumnSorter()
        {
            this.ColumnToSort = 0;
            this.OrderOfSort = SortOrder.None;
            this.ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listViewItem;
            listViewItem = (ListViewItem)x;
            ListViewItem obj;
            obj = (ListViewItem)y;
            int num;
            num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, obj.SubItems[this.ColumnToSort].Text);
            if (this.OrderOfSort == SortOrder.Ascending)
            {
                return num;
            }
            if (this.OrderOfSort == SortOrder.Descending)
            {
                return -num;
            }
            return 0;
        }
    }
}
