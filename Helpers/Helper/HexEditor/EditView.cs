using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper.HexEditor
{
    public class EditView : IKeyMouseEventHandler
    {
        private HexViewHandler _hexView;

        private StringViewHandler _stringView;

        private HexEditor _editor;

        public EditView(HexEditor editor)
        {
            this._editor = editor;
            this._hexView = new HexViewHandler(editor);
            this._stringView = new StringViewHandler(editor);
        }

        public void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.InHexView(this._editor.CaretPosX))
            {
                this._hexView.OnKeyPress(e);
            }
            else
            {
                this._stringView.OnKeyPress(e);
            }
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            if (this.InHexView(this._editor.CaretPosX))
            {
                this._hexView.OnKeyDown(e);
            }
            else
            {
                this._stringView.OnKeyDown(e);
            }
        }

        public void OnKeyUp(KeyEventArgs e)
        {
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.InHexView(e.X))
                {
                    this._hexView.OnMouseDown(e.X, e.Y);
                }
                else
                {
                    this._stringView.OnMouseDown(e.X, e.Y);
                }
            }
        }

        public void OnMouseDragged(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.InHexView(e.X))
                {
                    this._hexView.OnMouseDragged(e.X, e.Y);
                }
                else
                {
                    this._stringView.OnMouseDragged(e.X, e.Y);
                }
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
        }

        public void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.InHexView(e.X))
                {
                    this._hexView.OnMouseDoubleClick();
                }
                else
                {
                    this._stringView.OnMouseDoubleClick();
                }
            }
        }

        public void OnGotFocus(EventArgs e)
        {
            if (this.InHexView(this._editor.CaretPosX))
            {
                this._hexView.Focus();
            }
            else
            {
                this._stringView.Focus();
            }
        }

        public void SetLowerCase()
        {
            this._hexView.SetLowerCase();
        }

        public void SetUpperCase()
        {
            this._hexView.SetUpperCase();
        }

        public void Update(int startPositionX, Rectangle area)
        {
            this._hexView.Update(startPositionX, area);
            this._stringView.Update(this._hexView.MaxWidth, area);
        }

        public void Paint(Graphics g, int startIndex, int endIndex)
        {
            for (int i = 0; i + startIndex < endIndex; i++)
            {
                this._hexView.Paint(g, i, startIndex);
                this._stringView.Paint(g, i, startIndex);
            }
        }

        private bool InHexView(int x)
        {
            return x < this._hexView.MaxWidth + this._editor.EntityMargin - 2;
        }
    }
}
