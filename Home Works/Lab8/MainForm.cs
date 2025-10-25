using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab8
{
    class MainForm : Form
    {
        TraingaleButton bup, bdown;
        Panel plcontainbtn;
        Label lbltext;
        TextBox txtnum;
        Button btnAdd;
        public MainForm()
        {
            Text = "نظام تسديد رسوم الطلاب";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(400, 300);

            lbltext = new Label();
            bup = new TraingaleButton();
            bdown = new TraingaleButton();
            plcontainbtn = new Panel();
            txtnum = new TextBox();
            btnAdd = new Button();

            plcontainbtn.Size = new Size(15, 30);

            lbltext.Text = "عدد الطلاب الذين سيتم ادخال بياناتهم : ";
            lbltext.Size = new Size(150, 50);
            lbltext.Location = new Point(200, 80);

            plcontainbtn.Location = new Point(180, 75);
            txtnum.Location = new Point(70, 80);
            txtnum.TextAlign = HorizontalAlignment.Center;
            txtnum.MouseLeave += NumIn;

            bup.Direction = TraingaleButton.Directions.Up;
            bdown.Direction = TraingaleButton.Directions.Down;
            bup.Click += Incr;
            bdown.Click += decr;
            txtnum.KeyPress += NumOnly;
            txtnum.Text = "1";
            plcontainbtn.BackColor = Color.Gray;

            btnAdd.Text = "بدء الادخال";
            btnAdd.BackColor = Color.SkyBlue;
            btnAdd.Location = new Point(150, 150);
            btnAdd.Click += InsertInfo_Click;

            bup.Size = bdown.Size = new Size(10, 10);
            bup.Location = new Point(2, 3);
            bdown.Location = new Point(2, 15);
            plcontainbtn.Controls.AddRange(new Control[] { bup, bdown });
            Controls.AddRange(new Control[] { lbltext, plcontainbtn,txtnum ,btnAdd});
        }

        void Incr(object s ,EventArgs e)
        {
            int n = Convert.ToInt32(txtnum.Text);

            if (n >= 1 && n < 50 )
            {
                n++;
                txtnum.Text = n.ToString();
            }
        }
        void decr(object s,EventArgs e)
        {
            int n = Convert.ToInt32(txtnum.Text);

            if (n < 51 && n > 1)
            {
                n--;
                txtnum.Text = n.ToString();
            }
        }

        void NumOnly(object s,KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

        void NumIn(object s,EventArgs e)
        {
            int n = Convert.ToInt32(txtnum.Text);

            if (n > 50)
            {
                MessageBox.Show("العدد المسموح فقط هو 50");
                txtnum.Text = "50";
            }
            else if (n < 1)
            {
                MessageBox.Show("اقصى عدد للادخال هو طالب واحد");
                txtnum.Text = "1";
            }
        }
        void InsertInfo_Click(object s,EventArgs e)
        {
            InsertInfo f = new InsertInfo(txtnum.Text);
            f.ShowDialog();
        }
    }
}
