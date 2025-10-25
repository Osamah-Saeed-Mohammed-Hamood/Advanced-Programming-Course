using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    enum Light { True, False };
    class ButtonLight : Button
    {

        Light IsLight;

        public Light isLight
        {
            set { IsLight = value; }
            get { return IsLight; }
        }

        Timer t;
        Random r = new Random();
        public ButtonLight()
        {
            Name = "Hover on me";
            Text = "Hover on me";
            Width = 150;
            Height = 50;
            t = new Timer();

            t.Interval = 100;
            t.Tick += Change;

            MouseHover += ChangeColor;
            MouseLeave += StopChange;
        }


        void ChangeColor (object s,EventArgs e)
        {
            if (IsLight == Light.True)
            {
                t.Start();
            }
            else
            {
                t.Stop();
            }
        }

        void StopChange(object s,EventArgs e)
        {
            t.Stop();
        }

        void Change(object s,EventArgs e)
        {
            BackColor = Color.FromArgb(
            r.Next(256),
            r.Next(256),
            r.Next(256));
        }

    }
}
