using System.Collections;
using System.Windows.Forms;

namespace Anarchy.Helpers;

public class ListViewColumnSorter : IComparer
{
    private readonly CaseInsensitiveComparer _objectCompare;

    public int SortColumn { get; set; }

    public SortOrder Order { get; set; }

    public ListViewColumnSorter()
    {
        this.SortColumn = 0;
        this.Order = SortOrder.None;
        this._objectCompare = new CaseInsensitiveComparer();
    }

    public int Compare(object x, object y)
    {
        ListViewItem listViewItem;
        listViewItem = (ListViewItem)x;
        ListViewItem listViewItem2;
        listViewItem2 = (ListViewItem)y;
        if (!(listViewItem.SubItems[0].Text == "..") && !(listViewItem2.SubItems[0].Text == ".."))
        {
            int num;
            num = this._objectCompare.Compare(listViewItem.SubItems[this.SortColumn].Text, listViewItem2.SubItems[this.SortColumn].Text);
            if (this.Order == SortOrder.Ascending)
            {
                return num;
            }
            if (this.Order != SortOrder.Descending)
            {
                return 0;
            }
            return -num;
        }
        return 0;
    }
}