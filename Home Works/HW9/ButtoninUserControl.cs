using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW9
{
    class ButtoninUserControl : UserControl
    {
        Button btn;
        Panel pnl;

        public ButtoninUserControl()
        {
            Width = 150;
            Height = 100;
            btn = new Button();
            btn.Text = "IN USER CONTROL";
            btn.Size = new Size(80, 40);
            btn.Click += (s, e) =>
            {
                OnClick(e);
            };

            Click += (s, e) =>
            {
                MessageBox.Show("Click on User Control");
            };

            pnl = new Panel();
            pnl.Width = 100;
            pnl.Height = 50;
            //pnl.Click += (s, e) =>
            //  {
            //      MessageBox.Show("Click on Panel");
            //  };

            pnl.Controls.Add(btn);

            Controls.Add(pnl);
        }
    }
}
