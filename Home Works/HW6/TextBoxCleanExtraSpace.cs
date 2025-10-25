using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class TextBoxCleanExtraSpace : TextBox
    {
        public TextBoxCleanExtraSpace()
        {
            KeyPress += CleanExtraSpace;
        }

        void CleanExtraSpace(object s,KeyPressEventArgs e)
        {
            int cursor = this.SelectionStart;

            if (e.KeyChar == ' ')
            {
                if (cursor == 0)
                {
                    e.Handled = true;
                }

                if (cursor > 0 && this.Text[cursor - 1] == ' ')
                {
                    e.Handled = true;
                }
            }
        }
    }
}
