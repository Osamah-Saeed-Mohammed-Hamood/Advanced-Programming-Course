using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    class GoLabel : Label
    {
        private int Goto;

        public int GoTo
        {
            set { Goto = value; }
            get { return Goto; }    
        }

        public GoLabel()
        {
            Font = new Font("Arial", 14);
            MouseDoubleClick += MoveLabel;
        }

        void MoveLabel(object s,MouseEventArgs e)
        {
            if (Goto > 0)
            {
                Left += Goto;
            }
            else
            {
                MessageBox.Show("يرجى تحديد عدد مرات القفز");
            }
        }
    }
}
