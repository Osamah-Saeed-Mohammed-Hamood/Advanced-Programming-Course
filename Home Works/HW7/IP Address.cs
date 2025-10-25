using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW7
{
    class IP_Address : TextBox
    {
        bool flag = true;
        public IP_Address()
        {
            Text = " ___ . ___ . ___ . ___ ";
            MaxLength = 23;

            Width = 210;

            Multiline = true;
            Height = 30;
            Font = new Font("Arial", 14, FontStyle.Bold);

            KeyPress += NumEnsert;

            TextChanged += AddIP;

            MouseDoubleClick += selectthree;

        }

        void NumEnsert(object s, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                return;
            }

            if (SelectionStart == 0)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 8 && SelectionStart == 1)
            {
                e.Handled = true;
                return;
            }
            if (SelectionStart != 0 && SelectionStart != 1)
            {
                if (e.KeyChar == 8 && Text[SelectionStart - 1] == ' ')
                    e.Handled = true;
                if (e.KeyChar == 8 && Text[SelectionStart - 1] == '.')
                    e.Handled = true;
            }
            if (SelectionStart >= 24)
            {
                e.Handled = true;
                return;
            }

        }

        void AddIP(object s, EventArgs e)
        {
            if (flag)
            {
                int n = SelectionStart;
                int m;

                if (n < 23)
                {
                    if (n == 4 || n == 10 || n == 16)
                    {
                        // SelectionStart = n + 3;
                        SelectionStart -= 3;
                        SelectionLength = 3;
                        m = Convert.ToInt32(SelectedText);
                        if (m < 0 || m > 255)
                        {
                            MessageBox.Show("عنوان IP غير صالح ، المدى المحدد من 0 - 255");
                            flag = false;
                            Focus();
                            return;
                        }
                        SelectionStart += 6;
                    }
                    else if (n == 22)
                    {
                        SelectionStart -= 3;
                        SelectionLength = 3;
                        m = Convert.ToInt32(SelectedText);
                        if (m < 0 || m > 255)
                        {
                            MessageBox.Show("عنوان IP غير صالح ، المدى المحدد من 0 - 255");
                            Focus();
                            flag = false;
                            return;
                        }
                    }
                }
            }
            flag = true;
        }
        void selectthree(object s, MouseEventArgs e)
        {
            int index = SelectionStart;

            int start = Text.LastIndexOf("_", index);
            if (start == -1)
            {
                start = Text.IndexOf("_", index);
            }

            if (start != -1)
            {
                SelectionStart = start;
                SelectionLength = 3;
            }
        }
    }
}
