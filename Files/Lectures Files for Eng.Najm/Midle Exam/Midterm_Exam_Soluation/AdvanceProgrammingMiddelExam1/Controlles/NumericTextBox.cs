using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvanceProgrammingMiddelExam1.Controlles
{
   

    public class NumericTextBox : UserControl
    {
        private TextBox textBox;
        private TriangleButton btnUp;
        private TriangleButton btnDown;

        public int MaximumValue { get; set; } = 100;  // القيمة الافتراضية للحد الأعلى
        public int Value
        {
            get
            {
                if (int.TryParse(textBox.Text, out int value))
                    return value;
                return 1;
            }
            set
            {
                if (value < 1)
                    textBox.Text = "1";
                else if (value > MaximumValue)
                    textBox.Text = MaximumValue.ToString();
                else
                    textBox.Text = value.ToString();
            }
        }
        public NumericTextBox()
        {
            this.Height = 20;
            this.Width = 140;

            textBox = new TextBox();
            textBox.Location = new Point(0, 0);
            textBox.Width = this.Width - 30;
            textBox.Height = this.Height ;
            textBox.Text = "1";
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };
            textBox.MouseLeave += (s, e) =>
            {
                if (!int.TryParse(textBox.Text, out int value) || value < 1)
                    textBox.Text = "1";
                else if (value > MaximumValue)
                {
                    textBox.Text = MaximumValue.ToString();
                    MessageBox.Show($"القيمة للحد الاعلى {MaximumValue}");
                }
            };

            btnUp = new TriangleButton(TriangleDirection.Up);
            btnUp.Size = new Size(15, this.Height / 2);
            btnUp.Location = new Point(this.Width - 30, 0);
            btnUp.Click += (s, e) =>
            {
                if (int.TryParse(textBox.Text, out int value) && value < MaximumValue)
                    textBox.Text = (value + 1).ToString();
            };

            btnDown = new TriangleButton(TriangleDirection.Down);
            btnDown.Size = new Size(15, this.Height / 2);
            btnDown.Location = new Point(this.Width - 30, this.Height / 2);
            btnDown.Click += (s, e) =>
            {
                if (int.TryParse(textBox.Text, out int value) && value > 1)
                    textBox.Text = (value - 1).ToString();
            };

            this.Controls.Add(textBox);
            this.Controls.Add(btnUp);
            this.Controls.Add(btnDown);
        }
    }

    public enum TriangleDirection { Up, Down }

    public class TriangleButton : Button
    {
        private TriangleDirection direction;

        public TriangleButton(TriangleDirection dir)
        {
            direction = dir;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.LightGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                if (direction == TriangleDirection.Up)
                {
                    path.AddPolygon(new Point[] {
                        new Point(this.Width / 2, 2),
                        new Point(2, this.Height - 2),
                        new Point(this.Width - 2, this.Height - 2)
                    });
                }
                else
                {
                    path.AddPolygon(new Point[] {
                        new Point(2, 2),
                        new Point(this.Width - 2, 2),
                        new Point(this.Width / 2, this.Height - 2)
                    });
                }

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
    }
}


