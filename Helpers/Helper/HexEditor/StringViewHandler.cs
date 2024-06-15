using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper.HexEditor
{
    public class StringViewHandler
    {
        private Rectangle _recStringView;

        private StringFormat _stringFormat;

        private HexEditor _editor;

        public int MaxWidth => this._recStringView.X + this._recStringView.Width;

        public StringViewHandler(HexEditor editor)
        {
            this._editor = editor;
            this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
            this._stringFormat.Alignment = StringAlignment.Center;
            this._stringFormat.LineAlignment = StringAlignment.Center;
        }

        public void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                this.HandleUserInput(e.KeyChar);
            }
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
            {
                if (e.KeyCode == Keys.Up && this._editor.CaretIndex - this._editor.BytesPerLine >= 0)
                {
                    int num;
                    num = this._editor.CaretIndex - this._editor.BytesPerLine;
                    if (num % this._editor.BytesPerLine == 0 && this._editor.CaretPosX >= this._recStringView.X + this._recStringView.Width)
                    {
                        Point location;
                        location = new Point(this._editor.CaretPosX, this._editor.CaretPosY - this._recStringView.Height);
                        if (num == 0)
                        {
                            location = new Point(this._editor.CaretPosX, this._editor.CaretPosY);
                            num = this._editor.BytesPerLine;
                        }
                        if (e.Shift)
                        {
                            this._editor.SetCaretEnd(num, location);
                        }
                        else
                        {
                            this._editor.SetCaretStart(num, location);
                        }
                    }
                    else
                    {
                        this.HandleArrowKeys(num, e.Shift);
                    }
                }
                else if (e.KeyCode == Keys.Down && (this._editor.CaretIndex - 1) / this._editor.BytesPerLine < this._editor.HexTableLength / this._editor.BytesPerLine)
                {
                    int num2;
                    num2 = this._editor.CaretIndex + this._editor.BytesPerLine;
                    if (num2 > this._editor.HexTableLength)
                    {
                        this.HandleArrowKeys(this._editor.HexTableLength, e.Shift);
                        return;
                    }
                    Point location2;
                    location2 = new Point(this._editor.CaretPosX, this._editor.CaretPosY + this._recStringView.Height);
                    if (e.Shift)
                    {
                        this._editor.SetCaretEnd(num2, location2);
                    }
                    else
                    {
                        this._editor.SetCaretStart(num2, location2);
                    }
                }
                else if (e.KeyCode == Keys.Left && this._editor.CaretIndex - 1 >= 0)
                {
                    this.HandleArrowKeys(this._editor.CaretIndex - 1, e.Shift);
                }
                else if (e.KeyCode == Keys.Right && this._editor.CaretIndex + 1 <= this._editor.LastVisibleByte)
                {
                    this.HandleArrowKeys(this._editor.CaretIndex + 1, e.Shift);
                }
            }
            else if (this._editor.SelectionLength > 0)
            {
                this.HandleUserRemove();
                int caretIndex;
                caretIndex = this._editor.CaretIndex;
                Point caretLocation;
                caretLocation = this.GetCaretLocation(caretIndex);
                this._editor.SetCaretStart(caretIndex, caretLocation);
            }
            else if (this._editor.CaretIndex < this._editor.LastVisibleByte && e.KeyCode == Keys.Delete)
            {
                this._editor.RemoveByteAt(this._editor.CaretIndex);
                Point caretLocation2;
                caretLocation2 = this.GetCaretLocation(this._editor.CaretIndex);
                this._editor.SetCaretStart(this._editor.CaretIndex, caretLocation2);
            }
            else if (this._editor.CaretIndex > 0 && e.KeyCode == Keys.Back)
            {
                int index;
                index = this._editor.CaretIndex - 1;
                this._editor.RemoveByteAt(index);
                Point caretLocation3;
                caretLocation3 = this.GetCaretLocation(index);
                this._editor.SetCaretStart(index, caretLocation3);
            }
        }

        public void HandleArrowKeys(int index, bool isShiftDown)
        {
            Point caretLocation;
            caretLocation = this.GetCaretLocation(index);
            if (isShiftDown)
            {
                this._editor.SetCaretEnd(index, caretLocation);
            }
            else
            {
                this._editor.SetCaretStart(index, caretLocation);
            }
        }

        public void OnMouseDown(int x, int y)
        {
            int num;
            num = (x - this._recStringView.X) / (int)this._editor.CharSize.Width;
            int num2;
            num2 = (y - this._recStringView.Y) / this._recStringView.Height;
            num = ((num > this._editor.BytesPerLine) ? this._editor.BytesPerLine : num);
            num = ((num >= 0) ? num : 0);
            num2 = ((num2 > this._editor.MaxBytesV) ? this._editor.MaxBytesV : num2);
            num2 = ((num2 >= 0) ? num2 : 0);
            if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine <= num2)
            {
                if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine <= num)
                {
                    num = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine;
                }
                num2 = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine;
            }
            int index;
            index = Math.Min(this._editor.LastVisibleByte, this._editor.FirstVisibleByte + num + num2 * this._editor.BytesPerLine);
            int x2;
            x2 = num * (int)this._editor.CharSize.Width + this._recStringView.X;
            int num3;
            num3 = num2 * this._recStringView.Height;
            int y2;
            y2 = this._recStringView.Y;
            this._editor.SetCaretStart(index, new Point(x2, num3 + y2));
        }

        public void OnMouseDragged(int x, int y)
        {
            int num;
            num = (x - this._recStringView.X) / (int)this._editor.CharSize.Width;
            int num2;
            num2 = (y - this._recStringView.Y) / this._recStringView.Height;
            num = ((num > this._editor.BytesPerLine) ? this._editor.BytesPerLine : num);
            num = ((num >= 0) ? num : 0);
            num2 = ((num2 > this._editor.MaxBytesV) ? this._editor.MaxBytesV : num2);
            num2 = ((this._editor.FirstVisibleByte <= 0) ? ((num2 >= 0) ? num2 : 0) : ((num2 < 0) ? (-1) : num2));
            if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine <= num2)
            {
                if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine <= num)
                {
                    num = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine;
                }
                num2 = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine;
            }
            int index;
            index = Math.Min(this._editor.LastVisibleByte, this._editor.FirstVisibleByte + num + num2 * this._editor.BytesPerLine);
            int x2;
            x2 = num * (int)this._editor.CharSize.Width + this._recStringView.X;
            int num3;
            num3 = num2 * this._recStringView.Height;
            int y2;
            y2 = this._recStringView.Y;
            this._editor.SetCaretEnd(index, new Point(x2, num3 + y2));
        }

        public void OnMouseDoubleClick()
        {
            if (this._editor.CaretIndex < this._editor.LastVisibleByte)
            {
                int index;
                index = this._editor.CaretIndex + 1;
                Point caretLocation;
                caretLocation = this.GetCaretLocation(index);
                this._editor.SetCaretEnd(index, caretLocation);
            }
        }

        public void Focus()
        {
            int caretIndex;
            caretIndex = this._editor.CaretIndex;
            Point caretLocation;
            caretLocation = this.GetCaretLocation(caretIndex);
            this._editor.SetCaretStart(caretIndex, caretLocation);
        }

        public void Update(int startPositionX, Rectangle area)
        {
            this._recStringView = new Rectangle(startPositionX, area.Y, (int)(this._editor.CharSize.Width * (float)this._editor.BytesPerLine), (int)this._editor.CharSize.Height - 2);
            this._recStringView.X += this._editor.EntityMargin;
        }

        public void Paint(Graphics g, int index, int startIndex)
        {
            Point byteColumnAndRow;
            byteColumnAndRow = this.GetByteColumnAndRow(index);
            if (this._editor.IsSelected(index + startIndex))
            {
                this.PaintByteAsSelected(g, byteColumnAndRow, index + startIndex);
            }
            else
            {
                this.PaintByte(g, byteColumnAndRow, index + startIndex);
            }
        }

        private void PaintByteAsSelected(Graphics g, Point point, int index)
        {
            SolidBrush brush;
            brush = new SolidBrush(this._editor.SelectionBackColor);
            SolidBrush brush2;
            brush2 = new SolidBrush(this._editor.SelectionForeColor);
            RectangleF bound;
            bound = this.GetBound(point);
            char byteAsChar;
            byteAsChar = this._editor.GetByteAsChar(index);
            string s;
            s = (char.IsControl(byteAsChar) ? "." : byteAsChar.ToString());
            g.FillRectangle(brush, bound);
            g.DrawString(s, this._editor.Font, brush2, bound, this._stringFormat);
        }

        private void PaintByte(Graphics g, Point point, int index)
        {
            SolidBrush brush;
            brush = new SolidBrush(this._editor.ForeColor);
            RectangleF bound;
            bound = this.GetBound(point);
            char byteAsChar;
            byteAsChar = this._editor.GetByteAsChar(index);
            g.DrawString(char.IsControl(byteAsChar) ? "." : byteAsChar.ToString(), this._editor.Font, brush, bound, this._stringFormat);
        }

        private Point GetCaretLocation(int index)
        {
            return new Point(this._recStringView.X + (int)this._editor.CharSize.Width * (index % this._editor.BytesPerLine), this._recStringView.Y + this._recStringView.Height * ((index - (this._editor.FirstVisibleByte + index % this._editor.BytesPerLine)) / this._editor.BytesPerLine));
        }

        private void HandleUserRemove()
        {
            int selectionStart;
            selectionStart = this._editor.SelectionStart;
            Point caretLocation;
            caretLocation = this.GetCaretLocation(selectionStart);
            this._editor.RemoveSelectedBytes();
            this._editor.SetCaretStart(selectionStart, caretLocation);
        }

        private void HandleUserInput(char key)
        {
            if (this._editor.CaretFocused)
            {
                this.HandleUserRemove();
                byte item;
                item = Convert.ToByte(key);
                if (this._editor.HexTableLength <= 0)
                {
                    this._editor.AppendByte(item);
                }
                else
                {
                    this._editor.InsertByte(this._editor.CaretIndex, item);
                }
                int index;
                index = this._editor.CaretIndex + 1;
                Point caretLocation;
                caretLocation = this.GetCaretLocation(index);
                this._editor.SetCaretStart(index, caretLocation);
            }
        }

        private Point GetByteColumnAndRow(int index)
        {
            return new Point(index % this._editor.BytesPerLine, index / this._editor.BytesPerLine);
        }

        private RectangleF GetBound(Point point)
        {
            return new RectangleF(this._recStringView.X + point.X * (int)this._editor.CharSize.Width, this._recStringView.Y + point.Y * this._recStringView.Height, this._editor.CharSize.Width, this._recStringView.Height);
        }
    }
}
