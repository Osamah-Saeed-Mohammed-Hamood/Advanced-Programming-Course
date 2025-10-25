using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OsamaSaeedMohammed
{
    internal class MyTool :Panel
    { 
        PictureBox p;
        Label lblTitle;
        Label lblprice;
        Label chk;
        PictureBox[] pctrating = new PictureBox[5];
        Button btnShow;

        bool available;
        int price;
        int rating;
        string title;
        string imgURL;

        public bool Available
        {
            get { return available; }
            set
            {
                available = value;
                if (available == true)
                    chk.Text = "متوفر";
                else
                    chk.Text = "غير متوفر";
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                lblprice.Text = " السعر : " + price.ToString();
            }
        }

        public int Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                for (int i = 1; i <= 5; i++)
                {
                    if (i < rating)
                        pctrating[i-1].BackColor = Color.Red;
                    else
                        pctrating[i-1].BackColor = Color.Gray;
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                lblTitle.Text = title;
            }
        }

        public string ImgURL
        {
            get { return imgURL; }
            set
            {
                imgURL = value;
                p.Image = Image.FromFile(imgURL);
            }
        }

        public MyTool()
        {
            Size = new Size(100, 300);
            this.BackColor = Color.White;

            p = new PictureBox();
            p.Size = new Size(this.Width - 20, this.Height / 3 - 30);
            p.Location = new Point(10, 5);
            p.BackColor = Color.Gray;

            lblTitle = new Label();
            lblTitle.Text = "";
            lblTitle.Location = new Point(p.Width - lblTitle.Width - 20, p.Height + 20);

            lblprice = new Label();
            lblprice.Location = new Point(p.Width - lblprice.Width - 20, p.Height + 60);

            chk = new Label();
            chk.Location = new Point(p.Width - chk.Width - 20, p.Height + 100);

            for (int i = 0; i < 5; i++)
            {
                pctrating[i] = new PictureBox();
                pctrating[i].BackColor = Color.Gray;
                pctrating[i].Size = new Size(30, 30);
                pctrating[i].Location = new Point(i * 10 + 50, p.Height + 140);
                Controls.Add(pctrating[i]);
            }

            btnShow = new Button();
            btnShow.Text = "التفاصيل";
            btnShow.Size = new Size(p.Width, 40);
            btnShow.Location = new Point(5, this.Height - 50);
            btnShow.Click += ShowInfo;

            AllowDrop = true;

            Resize += update;
            MouseDown += TakeData;
            DragEnter += EffectDrag;
            DragDrop += PutData;


            Controls.AddRange(new Control[] { p, btnShow, lblTitle, lblprice, chk });
        }

        void update(object s, EventArgs e)
        {
            p.Size = new Size(this.Width - 20, this.Height / 3 - 10);
            p.Location = new Point(10, 10);
            btnShow.Size = new Size(p.Width, 40);
            btnShow.Location = new Point(10, this.Height - 50);

            lblTitle.Location = new Point(p.Width - lblTitle.Width, p.Height + 20);
            lblprice.Location = new Point(p.Width - lblprice.Width, p.Height + 60);
            chk.Location = new Point(p.Width - chk.Width, p.Height + 100);
            for (int i = 0; i < 5; i++)
            {
                pctrating[i].Location = new Point(i * 10 + 100, p.Height + 140);
            }
        }

        void ShowInfo(object s,EventArgs e)
        {
            MessageBox.Show(lblTitle.Text + "\n" + lblprice.Text + "\n" + chk.Text + "\nالتقييم : " + rating.ToString());
        }

        void TakeData(object s,MouseEventArgs e)
        {

            DoDragDrop(this, DragDropEffects.Copy);
            
        }

        void EffectDrag(object s , DragEventArgs e)
        {
         
                e.Effect = DragDropEffects.Copy;
            
        }

        void PutData(object s,DragEventArgs e)
        {
            MyTool t = (MyTool)e.Data.GetData(typeof(MyTool));
            MessageBox.Show( t.Title + "~~" + lblTitle.Text);
        }
    }
}
