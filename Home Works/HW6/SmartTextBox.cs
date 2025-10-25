using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class SmartTextBox : TextBox
    {
        public SmartTextBox()
        {
            KeyPress += KeywordEnter;
        }
       
        void KeywordEnter(object s, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100)
                CleanExtraSpace();
        }

        void CleanExtraSpace()
        {
            for (int i =0;i< this.Text.Length - 1;i++)
            {
                if (i == 0 && this.Text[0] == ' ')
                {
                    this.Text = this.Text.Remove(0, 1);
                    i--;
                }
                else if (this.Text[i] == ' ' && this.Text[i + 1] == ' ')
                {
                    this.Text = this.Text.Remove(i, 1);
                    i--;
                }
            }
            this.Text = this.Text.Trim();
        }
    }
}
