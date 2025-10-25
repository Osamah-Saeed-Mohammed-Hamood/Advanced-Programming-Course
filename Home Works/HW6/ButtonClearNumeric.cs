using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class ButtonClearNumeric : Button
    {
        public ButtonClearNumeric()
        {
            Text = "Clear Numeric";
            BackColor = Color.Cyan;

            Click += ClearNumeric;
        }

        private void ClearNumeric(object s,EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                ClearTextBoxes(parentForm);
            }
        }

        private void ClearTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    if (isNumeric(textBox.Text))
                        textBox.Clear();
                }
                else if (ctrl.HasChildren)
                {
                    ClearTextBoxes(ctrl);
                }
            }
        }

        bool isNumeric(string text)
        {
            if (text == "")
                return false;

            for (int i =0; i< text.Length; i++)
            {
                if (text[i] < 48 || text[i] > 57)
                    return false;
            }
            return true;
        }
    }
}
