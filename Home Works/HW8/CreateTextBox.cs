using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    enum ChooseColor { RED, GREEN, BLUE };
    class CreateTextBox : TextBox
    {
        private ChooseColor bkcolor;

        private int NumberOfTextBox;

        public ChooseColor bkColor
        {
            set { bkcolor = value; }
            get { return bkcolor; }
        }

        public int NumberOfTextBoxes
        {
            set { NumberOfTextBox = value; }
            get { return NumberOfTextBox; } 
        }


        Random r = new Random();
        public CreateTextBox ()
        {
            Width = 150;
            MouseHover += Create;
        }

        void Create (object s,EventArgs e)
        {
            if (NumberOfTextBox > 0)
            {
                if (bkcolor == ChooseColor.GREEN)
                {
                    TextBox[] t = new TextBox[NumberOfTextBoxes];
                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i] = new TextBox();
                        t[i].BackColor = Color.Green;
                        t[i].Location = new Point(r.Next(FindForm().Width), r.Next(FindForm().Height));
                        FindForm().Controls.Add(t[i]);
                    }
                }
                else if (bkcolor == ChooseColor.BLUE)
                {
                    TextBox[] t = new TextBox[NumberOfTextBoxes];
                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i] = new TextBox();
                        t[i].BackColor = Color.Blue;
                        t[i].Location = new Point(r.Next(FindForm().Width), r.Next(FindForm().Height));
                        FindForm().Controls.Add(t[i]);
                    }
                }
                else if (bkcolor == ChooseColor.RED)
                {
                    TextBox[] t = new TextBox[NumberOfTextBoxes];
                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i] = new TextBox();
                        t[i].BackColor = Color.Red;
                        t[i].Location = new Point(r.Next(FindForm().Width), r.Next(FindForm().Height));
                        FindForm().Controls.Add(t[i]);
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى تحديد العدد الذي يتم انشائة");
            }
        }


    }
}
