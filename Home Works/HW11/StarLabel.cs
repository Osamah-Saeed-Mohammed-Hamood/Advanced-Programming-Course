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
    class StarLabel : Label
    {

        public StarLabel()
        {
            Height = 150;
            Width = 150;
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (value == Color.Red || value == Color.Blue || value == Color.White)
                {
                    base.BackColor = value;
                }
                else
                {
                    MessageBox.Show("غير مسموح بهذا اللون");
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Point[] points = {new Point(Width/2,0),new Point(Width/3,Height/3+10),new Point(0,Height/3+10),
            new Point(Width/3,Height - (Height/3)),new Point(Width/3-10,Height),new Point(Width/2,Height-(Height/3)+15),
            new Point(Width-(Width/3)+10,Height),new Point(Width - (Width/3),Height-(Height/3)),
                new Point(Width,Height/3+10),new Point(Width-(Width/3),Height/3+10)};

            path.AddPolygon(points);
            this.Region = new Region(path);

            using (SolidBrush bursh = new SolidBrush(this.BackColor))
            {
                g.FillPath(bursh, path);
            }

            using (Pen pen = new Pen(this.ForeColor, 2))
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
    }
}
