using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace HW12
{
    class ShowImage : Form
    {
        PictureBox pct;

        public ShowImage(string imgPath)
        {
            this.Text = Path.GetFileName(imgPath);
            this.Size = new Size(500, 500);
            pct = new PictureBox();
            pct.Image = Image.FromFile(imgPath);
            pct.SizeMode = PictureBoxSizeMode.Zoom;
            pct.Dock = DockStyle.Fill;

            this.Controls.Add(pct);
        }
    }
}
