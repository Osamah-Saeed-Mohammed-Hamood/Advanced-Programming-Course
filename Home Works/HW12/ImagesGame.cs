using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW12
{
    class ImagesGame : Form
    {
        PictureBox[] sourcePics = new PictureBox[2];
        PictureBox[] targetSlots = new PictureBox[2];

        public ImagesGame()
        {
            Text = "لعبة مطابقة الصور";
            Size = new Size(450, 300);
            string[] images = { "Qasaam.png", "osama.jpg" }; 
            for (int i = 0; i < 2; i++)
            {
                sourcePics[i] = new PictureBox();
                sourcePics[i].Size = new Size(100, 100);
                sourcePics[i].Location = new Point(30, 30 + i * 120);
                sourcePics[i].Image = Image.FromFile(images[i]);
                sourcePics[i].SizeMode = PictureBoxSizeMode.StretchImage;
                sourcePics[i].Tag = images[i];
                sourcePics[i].MouseDown += StartDrag;

                Controls.Add(sourcePics[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                targetSlots[i] = new PictureBox();
                targetSlots[i].Size = new Size(100, 100);
                targetSlots[i].Location = new Point(300, 30 + i * 120);
                targetSlots[i].BorderStyle = BorderStyle.FixedSingle;
                targetSlots[i].SizeMode = PictureBoxSizeMode.StretchImage;
                targetSlots[i].AllowDrop = true;
                targetSlots[i].Tag = images[i]; 

                targetSlots[i].DragEnter += DragEnterPic;
                targetSlots[i].DragDrop += DropPic;

                Controls.Add(targetSlots[i]);
            }
        }


        void StartDrag(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                DoDragDrop(pic, DragDropEffects.Copy);
            }
        }

        void DragEnterPic(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        void DropPic(object sender, DragEventArgs e)
        {
            PictureBox target = sender as PictureBox;
            PictureBox dragged = (PictureBox)e.Data.GetData(typeof(PictureBox));

            if (target != null && dragged != null)
            {
                if ((string)target.Tag == (string)dragged.Tag)
                {
                    target.Image = dragged.Image;
                    MessageBox.Show("✅ صحيح! مطابقة ناجحة");
                }
                else
                {
                    MessageBox.Show("❌ خطأ! حاول مرة أخرى");
                }
            }
        }
    }
}
