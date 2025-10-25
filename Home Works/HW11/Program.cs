using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW11
{
    internal class Program : Form
    {
        Pentagonal pgl = new Pentagonal();
        private Pentagonal pentagonal1;
        private ShapeButton shapeButton1;
        private StarLabel starLabel1;
        StarLabel str = new StarLabel();

        public Program()
        {
            pgl.Location = new Point((this.Width / 2) - pgl.Width, (this.Height / 2) - pgl.Height);
            str.Location = new Point(20, 20);

            str.BackColor = Color.Red;
            Controls.AddRange(new Control[] { pgl, str });
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.pentagonal1 = new HW11.Pentagonal();
            this.shapeButton1 = new HW11.ShapeButton();
            this.starLabel1 = new HW11.StarLabel();
            this.SuspendLayout();
            // 
            // pentagonal1
            // 
            this.pentagonal1.Location = new System.Drawing.Point(171, 43);
            this.pentagonal1.Name = "pentagonal1";
            this.pentagonal1.Size = new System.Drawing.Size(75, 74);
            this.pentagonal1.TabIndex = 0;
            this.pentagonal1.Text = "pentagonal1";
            this.pentagonal1.UseVisualStyleBackColor = true;
            // 
            // shapeButton1
            // 
            this.shapeButton1.Location = new System.Drawing.Point(61, 163);
            this.shapeButton1.Name = "shapeButton1";
            this.shapeButton1.ShapeType = HW11.Shape.Triangle;
            this.shapeButton1.Size = new System.Drawing.Size(75, 45);
            this.shapeButton1.TabIndex = 1;
            this.shapeButton1.Text = "shapeButton1";
            this.shapeButton1.UseVisualStyleBackColor = true;
            // 
            // starLabel1
            // 
            this.starLabel1.AutoSize = true;
            this.starLabel1.Location = new System.Drawing.Point(58, 72);
            this.starLabel1.Name = "starLabel1";
            this.starLabel1.Size = new System.Drawing.Size(70, 16);
            this.starLabel1.TabIndex = 2;
            this.starLabel1.Text = "starLabel1";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.starLabel1);
            this.Controls.Add(this.shapeButton1);
            this.Controls.Add(this.pentagonal1);
            this.Name = "Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
