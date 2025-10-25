using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW9
{
    class ButtoninPanel : Panel
    {
        Button btn;

        public ButtoninPanel()
        {
            Width = 150;
            Height = 100;
            btn = new Button();
            btn.Text = "IN PANEL";
            btn.Size = new Size(100, 50);

            btn.Click += (s, e) =>
              {
                  OnClick(e);
  
              };

            Click += (s, e) =>
            {
                MessageBox.Show("Click on Panel");
            };

            Controls.Add(btn);
        }
    }
}
