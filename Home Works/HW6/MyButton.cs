using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
     class MyButton : Button
    {
        public MyButton(int w,int h,Control tool)
        {
            Width = w;
            Height = h;
            Text = "My Button";
            if (tool != null)
            {
                Left = tool.Left + 15;
                Top = tool.Bottom + 5;
            }
        }
    }
}
