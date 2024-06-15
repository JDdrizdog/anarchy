using System.Windows.Forms;

namespace Anarchy.Helpers.Helper
{
    public class RegistryTreeView : TreeView
    {
        public RegistryTreeView()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        }
    }
}
