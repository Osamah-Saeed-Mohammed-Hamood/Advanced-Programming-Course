using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    class MyTextBox : TextBox
    {

        public int Length
        {
            set
            {
                this.MaxLength = value;
            }
            get
            {
                return this.MaxLength;
            }
        }

        public int TextLength
        {
            get { return Text.Length; }
        }

        public MyTextBox()
        {
            Multiline = true;
            Width = 150;
            Height = 50;
            Font = new Font("Arial", 14);
            KeyPress += Check;
        }

        void Check(object s, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                BackColor = Color.White;
                return;
            }
            if (MaxLength > 0)
            {
                if (Text.Length >= MaxLength)
                {
                    e.Handled = true;
                    BackColor = Color.Red;
                    MessageBox.Show(TextLength.ToString());
                }
                else
                {
                    e.Handled = false;
                    BackColor = Color.White;
                }
            }
            else
            {
                MessageBox.Show("حدد الحد الاقصى للنص المدخل");
            }
        }
    }
}
