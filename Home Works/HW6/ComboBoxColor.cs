using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
     class ComboBoxColor : ComboBox
    {
        public ComboBoxColor()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Items.AddRange(new string[] { "Red", "Green", "Yellow", "White", "Pink", "Blue", "Black", "Gray" });
            SelectedIndexChanged += ChooseColor;
        }

        public void ChooseColor(object s,EventArgs e)
        {
            ComboBoxColor cmbc = (ComboBoxColor)s;
            if (cmbc.SelectedItem != null)
            {
                if (cmbc.SelectedItem == "Red")
                    FindForm().BackColor = Color.Red;
                else if (cmbc.SelectedItem == "Green")
                    FindForm().BackColor = Color.Green;
                else if (cmbc.SelectedItem == "Yellow")
                    FindForm().BackColor = Color.Yellow;
                else if (cmbc.SelectedItem == "White")
                    FindForm().BackColor = Color.White;
                else if (cmbc.SelectedItem == "Pink")
                    FindForm().BackColor = Color.Pink;
                else if (cmbc.SelectedItem == "Blue")
                    FindForm().BackColor = Color.Blue;
                else if (cmbc.SelectedItem == "Black")
                    FindForm().BackColor = Color.Black;
                else if (cmbc.SelectedItem == "Gray")
                    FindForm().BackColor = Color.Gray;
                else 
                    FindForm().BackColor = Color.Transparent;
            }
        }
    }
}
