using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
     class TextBoxUpperLetter : TextBox
    {
        public TextBoxUpperLetter()
        {
            Text = "";
            KeyPress += UpperLetter;
        }

        public void UpperLetter(object sender,KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
