using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW5
{
    class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            Text = "0";
            Multiline = true;
            Top = 10;
            Left = 100;
            Width = Width - 50;
            Height = Height + 5;
            ForeColor = Color.Blue;
            TextAlign = HorizontalAlignment.Center;
            KeyPress += new KeyPressEventHandler(KeyNum);
        }

        void KeyNum(object s,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.KeyChar = (char)0;
        }
    }
}
