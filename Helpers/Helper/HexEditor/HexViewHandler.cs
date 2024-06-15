using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper.HexEditor
{
    public class HexViewHandler
    {
        private bool _isEditing;

        private string _hexType = "X2";

        private Rectangle _recHexValue;

        private StringFormat _stringFormat;

        private HexEditor _editor;

        public int MaxWidth => this._recHexValue.X + this._recHexValue.Width * this._editor.BytesPerLine;

        public HexViewHandler(HexEditor editor)
        {
            this._editor = editor;
            this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
            this._stringFormat.Alignment = StringAlignment.Center;
            this._stringFormat.LineAlignment = StringAlignment.Center;
        }

        public void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.IsHex(e.KeyChar))
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
                    if (num % this._editor.BytesPerLine == 0 && this._editor.CaretPosX >= this._recHexValue.X + this._recHexValue.Width * this._editor.BytesPerLine)
                    {
                        Point location;
                        location = new Point(this._editor.CaretPosX, this._editor.CaretPosY - this._recHexValue.Height);
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
                        this._isEditing = false;
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
                    location2 = new Point(this._editor.CaretPosX, this._editor.CaretPosY + this._recHexValue.Height);
                    if (e.Shift)
                    {
                        this._editor.SetCaretEnd(num2, location2);
                    }
                    else
                    {
                        this._editor.SetCaretStart(num2, location2);
                    }
                    this._isEditing = false;
                }
                else if (e.KeyCode == Keys.Left && this._editor.CaretIndex - 1 >= 0)
                {
                    this.HandleArrowKeys(this._editor.CaretIndex - 1, e.Shift);
                }
                else if (e.KeyCode == Keys.Right && this._editor.CaretIndex + 1 <= this._editor.HexTableLength)
                {
                    this.HandleArrowKeys(this._editor.CaretIndex + 1, e.Shift);
                }
                return;
            }
            if (this._editor.SelectionLength > 0)
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
                if (this._isEditing)
                {
                    index = this._editor.CaretIndex;
                }
                this._editor.RemoveByteAt(index);
                Point caretLocation3;
                caretLocation3 = this.GetCaretLocation(index);
                this._editor.SetCaretStart(index, caretLocation3);
            }
            this._isEditing = false;
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
            this._isEditing = false;
        }

        public void OnMouseDown(int x, int y)
        {
            int num;
            num = (x - this._recHexValue.X) / this._recHexValue.Width;
            int num2;
            num2 = (y - this._recHexValue.Y) / this._recHexValue.Height;
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
            x2 = num * this._recHexValue.Width + this._recHexValue.X;
            int num3;
            num3 = num2 * this._recHexValue.Height;
            int y2;
            y2 = this._recHexValue.Y;
            this._editor.SetCaretStart(index, new Point(x2, num3 + y2));
            this._isEditing = false;
        }

        public void OnMouseDragged(int x, int y)
        {
            int num;
            num = (x - this._recHexValue.X) / this._recHexValue.Width;
            int num2;
            num2 = (y - this._recHexValue.Y) / this._recHexValue.Height;
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
            x2 = num * this._recHexValue.Width + this._recHexValue.X;
            int num3;
            num3 = num2 * this._recHexValue.Height;
            int y2;
            y2 = this._recHexValue.Y;
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

        public void Update(int startPositionX, Rectangle area)
        {
            this._recHexValue = new Rectangle(startPositionX, area.Y, (int)(this._editor.CharSize.Width * 3f), (int)this._editor.CharSize.Height - 2);
            this._recHexValue.X += this._editor.EntityMargin;
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
            string s;
            s = this._editor.GetByte(index).ToString(this._hexType);
            g.FillRectangle(brush, bound);
            g.DrawString(s, this._editor.Font, brush2, bound, this._stringFormat);
        }

        private void PaintByte(Graphics g, Point point, int index)
        {
            g.DrawString(brush: new SolidBrush(this._editor.ForeColor), layoutRectangle: this.GetBound(point), s: this._editor.GetByte(index).ToString(this._hexType), font: this._editor.Font, format: this._stringFormat);
        }

        public void SetLowerCase()
        {
            this._hexType = "x2";
        }

        public void SetUpperCase()
        {
            this._hexType = "X2";
        }

        public void Focus()
        {
            int caretIndex;
            caretIndex = this._editor.CaretIndex;
            Point caretLocation;
            caretLocation = this.GetCaretLocation(caretIndex);
            this._editor.SetCaretStart(caretIndex, caretLocation);
        }

        private Point GetCaretLocation(int index)
        {
            return new Point(this._recHexValue.X + this._recHexValue.Width * (index % this._editor.BytesPerLine), this._recHexValue.Y + this._recHexValue.Height * ((index - (this._editor.FirstVisibleByte + index % this._editor.BytesPerLine)) / this._editor.BytesPerLine));
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
            if (!this._editor.CaretFocused)
            {
                return;
            }
            this.HandleUserRemove();
            if (this._isEditing)
            {
                this._isEditing = false;
                byte @byte;
                @byte = this._editor.GetByte(this._editor.CaretIndex);
                byte num;
                num = Convert.ToByte(key.ToString(), 16);
                this._editor.SetByte(this._editor.CaretIndex, (byte)(@byte + num));
                int index;
                index = this._editor.CaretIndex + 1;
                Point caretLocation;
                caretLocation = this.GetCaretLocation(index);
                this._editor.SetCaretStart(index, caretLocation);
                return;
            }
            this._isEditing = true;
            byte item;
            item = Convert.ToByte(key + "0", 16);
            if (this._editor.HexTable.Length == 0)
            {
                this._editor.AppendByte(item);
            }
            else
            {
                this._editor.InsertByte(this._editor.CaretIndex, item);
            }
            int x;
            x = this._recHexValue.X + this._recHexValue.Width * (this._editor.CaretIndex % this._editor.BytesPerLine) + this._recHexValue.Width / 2;
            int y;
            y = this._recHexValue.Y;
            int height;
            height = this._recHexValue.Height;
            int num2;
            num2 = (this._editor.CaretIndex - (this._editor.FirstVisibleByte + this._editor.CaretIndex % this._editor.BytesPerLine)) / this._editor.BytesPerLine;
            this._editor.SetCaretStart(this._editor.CaretIndex, new Point(x, y + height * num2));
        }

        private Point GetByteColumnAndRow(int index)
        {
            return new Point(index % this._editor.BytesPerLine, index / this._editor.BytesPerLine);
        }

        private RectangleF GetBound(Point point)
        {
            return new RectangleF(this._recHexValue.X + point.X * this._recHexValue.Width, this._recHexValue.Y + point.Y * this._recHexValue.Height, this._recHexValue.Width, this._recHexValue.Height);
        }

        private bool IsHex(char c)
        {
            if ((c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))
            {
                return true;
            }
            return char.IsDigit(c);
        }
    }
}
