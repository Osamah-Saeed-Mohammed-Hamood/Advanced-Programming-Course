using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab8
{
    class TraingaleButton : Button
    {
        public enum Directions { Up, Down }

        Directions direction;
        public Directions Direction
        {
            get { return direction; }
            set
            {
                if (value != direction)
                {
                    direction = value;
                    Invalidate();
                }
            }
        }

        public TraingaleButton()
        {
            BackColor = Color.Blue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpth = new GraphicsPath();
            Point[] p1 = { new Point(Width / 2, 0), new Point(0, Height), new Point(Width, Height) };
            Point[] p2 = { new Point(0, 0), new Point(Width, 0), new Point(Width / 2, Height) };

            switch (direction)
            {
                case Directions.Up:
                    gpth.AddPolygon(p1);
                    break;
                case Directions.Down:
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
