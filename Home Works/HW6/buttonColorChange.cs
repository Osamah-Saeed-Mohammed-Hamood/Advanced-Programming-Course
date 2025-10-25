using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class buttonColorChange : Button
    {
        public buttonColorChange()
        {
            this.Click += isLight;

            lite = true;
            this.Text = "ColorChange";
            Width = 80;
        }
        private bool lite;
        Random r;

        public bool Lite
        {
            get { return lite; }
            set 
            {
                lite = value;
            }
        }

        void isLight(object sender ,EventArgs e)
        {
            if (lite)
            {
                r = new Random();
                this.BackColor = Color.FromArgb(r.Next(100, 256), r.Next(100, 256), r.Next(100, 256));
            }
        }
    }
}
