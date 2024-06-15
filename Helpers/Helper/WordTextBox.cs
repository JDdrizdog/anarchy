using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Anarchy.Helpers.Helper
{
    public class WordTextBox : TextBox
    {
        public enum WordType
        {
            DWORD = 0,
            QWORD = 1
        }

        private bool isHexNumber;

        private WordType type;

        private IContainer components;

        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
            }
        }

        public bool IsHexNumber
        {
            get
            {
                return this.isHexNumber;
            }
            set
            {
                if (this.isHexNumber == value)
                {
                    return;
                }
                if (value)
                {
                    if (this.Type == WordType.DWORD)
                    {
                        this.Text = this.UIntValue.ToString("x");
                    }
                    else
                    {
                        this.Text = this.ULongValue.ToString("x");
                    }
                }
                else if (this.Type == WordType.DWORD)
                {
                    this.Text = this.UIntValue.ToString();
                }
                else
                {
                    this.Text = this.ULongValue.ToString();
                }
                this.isHexNumber = value;
                this.UpdateMaxLength();
            }
        }

        public WordType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    this.UpdateMaxLength();
                }
            }
        }

        public uint UIntValue
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        return 0u;
                    }
                    if (this.IsHexNumber)
                    {
                        return uint.Parse(this.Text, NumberStyles.HexNumber);
                    }
                    return uint.Parse(this.Text);
                }
                catch (Exception)
                {
                    return uint.MaxValue;
                }
            }
        }

        public ulong ULongValue
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        return 0uL;
                    }
                    if (this.IsHexNumber)
                    {
                        return ulong.Parse(this.Text, NumberStyles.HexNumber);
                    }
                    return ulong.Parse(this.Text);
                }
                catch (Exception)
                {
                    return ulong.MaxValue;
                }
            }
        }

        public bool IsConversionValid()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                return true;
            }
            if (!this.IsHexNumber)
            {
                return this.ConvertToHex();
            }
            return true;
        }

        public WordTextBox()
        {
            this.InitializeComponent();
            base.MaxLength = 8;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = !this.IsValidChar(e.KeyChar);
        }

        private bool IsValidChar(char ch)
        {
            if (!char.IsControl(ch) && !char.IsDigit(ch))
            {
                if (this.IsHexNumber && char.IsLetter(ch))
                {
                    return char.ToLower(ch) <= 'f';
                }
                return false;
            }
            return true;
        }

        private void UpdateMaxLength()
        {
            if (this.Type == WordType.DWORD)
            {
                if (this.IsHexNumber)
                {
                    base.MaxLength = 8;
                }
                else
                {
                    base.MaxLength = 10;
                }
            }
            else if (this.IsHexNumber)
            {
                base.MaxLength = 16;
            }
            else
            {
                base.MaxLength = 20;
            }
        }

        private bool ConvertToHex()
        {
            try
            {
                if (this.Type == WordType.DWORD)
                {
                    uint.Parse(this.Text);
                }
                else
                {
                    ulong.Parse(this.Text);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        }
    }
}
