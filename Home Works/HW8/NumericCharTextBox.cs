using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    enum Languages { Arabic,English};
    class NumericCharTextBox : TextBox
    {
        Languages l;

        public Languages Language
        {
            set { l = value; }
            get { return l; }
        }

        public NumericCharTextBox()
        {
            Multiline = true;
            Width = 150;
            Height = 50;
            Font = new Font("Arial", 14);
            KeyPress += WhatLang;
        }

        void WhatLang (object s,KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 32)
                return;

            if (l == Languages.English)
            {
                if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||
                      (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                      (e.KeyChar >= 48 && e.KeyChar <= 57)))
                {
                    e.Handled = true;
                }
            }
            else if (l == Languages.Arabic)
            {
                if (!((e.KeyChar >= 0x0600 && e.KeyChar <= 0x06FF) ||
                      (e.KeyChar >= 0x0660 && e.KeyChar <= 0x0669))) 
                {
                    e.Handled = true;
                }
            }
        }

    }
}
