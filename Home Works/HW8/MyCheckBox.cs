using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    class MyCheckBox : CheckBox
    {
        public string IsCheckedText
        {
            get
            {
                return this.Checked ? "نعم" : "لا";
            }
        }

        public MyCheckBox()
        {
            CheckedChanged += showche;
        }

        void showche(object s,EventArgs e)
        {
            MessageBox.Show(IsCheckedText);
        }
    }
}
