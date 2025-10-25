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
    enum Shape { Triangle, Circle , Pentagonal}
    class ShapeButton : Button
    {
        private Shape shapetype = Shape.Triangle;

        public Shape ShapeType
        {
            set
            {
                if (value != shapetype)
                {
                    shapetype = value;
                    Invalidate();
                }
            }
            get { return shapetype; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpth = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Point[] p1 = { new Point(Width / 2, 0), new Point(0, Height), new Point(Width, Height) };
            Point[] p2 = {new Point(Width/2,0),new Point(0,Height/2),new Point(0,Height),
            new Point(Width,Height),new Point(Width,Height/2)};

            switch (shapetype)
            {
                case Shape.Triangle:
                    gpth.AddPolygon(p1);
                    break;
                case Shape.Circle:
                    gpth.AddEllipse(rect);
                    break;
                case Shape.Pentagonal:
                    gpth.AddPolygon(p2);
                    break;
                default:
                    break;
            }
            Region = new Region(gpth);

            using (SolidBrush bursh = new SolidBrush(this.BackColor))
            {
                g.FillPath(bursh, gpth);
            }

            using (Pen pen = new Pen(this.ForeColor, 2))
            {
                g.DrawPath(pen, gpth);
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(Text, Font, Brushes.White, ClientRectangle, sf);
        }

    }
}
