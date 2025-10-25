using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW7
{
    class PhoneNumber : TextBox
    {
        public PhoneNumber()
        {
            Width = 210;
            Multiline = true;
            Height = 30;
            Font = new Font("Arial", 14, FontStyle.Bold);
            KeyPress += NumOnly_KeyPress;
            KeyDown += PhoneNumber_KeyDown;
            TextChanged += FormatText;

            Text = "00967 ";
            MaxLength = 17; 
            SelectionStart = Text.Length;
        }

        private void PhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText())
                {
                    string numbersOnly = FilterNumbers(Clipboard.GetText());
                    this.Text = "00967 " + numbersOnly;
                    this.SelectionStart = this.Text.Length;
                    e.SuppressKeyPress = true;
                }
            }
        }

        string FilterNumbers(string text)
        {
            string str = "";

            for (int i =0;i<text.Length;i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    str += text[i];
                    if (str.Length == 3 || str.Length == 7)
                        str += " ";
                }
            }
            return str;
        }

        void NumOnly_KeyPress(object s,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 57) && (e.KeyChar != 8))
                e.Handled = true;

            if (SelectionStart <= "00967 ".Length - 1)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 8 && Text[SelectionStart - 1] == ' ')
                e.Handled = true;
        }

        void FormatText(object s,EventArgs e)
        {
            if (SelectionStart == 9 || SelectionStart == 13)
                SelectionStart += 1;
        }

    }
}
