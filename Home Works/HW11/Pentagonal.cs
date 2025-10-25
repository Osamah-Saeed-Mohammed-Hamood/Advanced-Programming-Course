using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HW11
{
    class Pentagonal : Button
    {
        Random r;
        Timer t;
        public Pentagonal()
        {
            MouseHover += Size_Color_Change;
            MouseLeave += StopChangeColor;
            r = new Random();
            t = new Timer();
            t.Tick += ChangeColor;
            t.Interval = 100;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Point[] points = {new Point(Width/2,0),new Point(0,Height/2),new Point(0,Height),
            new Point(Width,Height),new Point(Width,Height/2)};

            path.AddPolygon(points);
            this.Region = new Region(path);

            using (SolidBrush bursh = new SolidBrush(this.BackColor))
            {
                g.FillPath(bursh, path);
            }

            using (Pen pen = new Pen(this.ForeColor,2))
            {
                g.DrawPath(pen, path);
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(Text, Font, Brushes.White, ClientRectangle, sf);
        }

        void Size_Color_Change(object s,EventArgs e)
        {
            if (Width < FindForm().Width && Height < FindForm().Height)
            {
                Width += 100;
                Height += 100;
            }
            else if (Width > FindForm().Width && Height > FindForm().Height)
            {
                FindForm().Width += 2;
                FindForm().Height += 2;
                Width += 2;
                Height += 2;
            }
            else if (Width > FindForm().Width && Height < FindForm().Height)
            {
                FindForm().Width += 2;
                Width += 2;
                Height += 2;
            }
            else if (Width < FindForm().Width && Height > FindForm().Height)
            {
                FindForm().Height += 2;
                Width += 2;
                Height += 2;
            }
            t.Start();
        }

        void ChangeColor(object s,EventArgs e)
        {
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }
        void StopChangeColor(object s,EventArgs e)
        {
            t.Stop();
        }
    }
}
