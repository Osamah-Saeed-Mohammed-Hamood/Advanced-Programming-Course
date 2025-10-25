using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW5
{
    class OpArrTextBox : Form
    {
        NumericTextBox[,] darr;
        Button[] b = new Button[7];
        RadioButton rdo;
        NumericTextBox numt;
        int x = 0;
        int sum = 0;

        public OpArrTextBox()
        {
            Start();
        }

        void Start()
        {
            Width = 400;
            Height = 250;
            Text = "التعامل مع المصفوفات";
            this.RightToLeft = RightToLeft.Yes;

            rdo = new RadioButton();
            rdo.Text = "المجموع";
            rdo.Top = 5;
            rdo.Left = this.Width - rdo.Width - 20;
            rdo.Enabled = false;
            rdo.CheckedChanged += Add;
            Controls.Add(rdo);

            numt = new NumericTextBox();
            numt.Text = "";
            numt.Left = this.Width - numt.Width - 20;
            numt.Top = rdo.Bottom;
            numt.ReadOnly = true;
            Controls.Add(numt);

            Color[] color = { Color.Red, Color.White, Color.Black, Color.Green, Color.Gray, Color.Gold, Color.Yellow };
            for (int i=0;i<b.Length;i++)
            {
                b[i] = new Button();
                b[i].Text = "Create  " + (i + 1);
                b[i].Left = i * b[i].Width;
                b[i].Top = Bottom - b[i].Height - 70;
                b[i].BackColor = color[i];
                b[i].ForeColor = Color.Blue;
                b[i].Click += createTextBox;
                Controls.Add(b[i]);
                if (i > 3)
                {
                    b[i].Left = ((i - 4) * b[i].Width) + (b[i].Width / 2);
                    b[i].Top = Bottom - b[i].Height - 40;
                }
            }
        }
        void createTextBox(object s,EventArgs e)
        {
            Button b = (Button)s;
            sum = 0;
            if (darr != null)
            {
                for (int i=0;i< darr.GetLength(0);i++)
                {
                    for (int j=0;j<darr.GetLength(1);j++)
                    {
                        darr[i, j].Dispose();
                    }
                }
            }
            darr = new NumericTextBox[5, 5];
            Random r = new Random();
            rdo.Enabled = true;
            for (int i=0;i<darr.GetLength(0);i++)
            {
                for (int j=0;j< darr.GetLength(1);j++)
                {
                    darr[i, j] = new NumericTextBox();
                    darr[i, j].Text = r.Next(0, 100).ToString();
                    darr[i, j].Left = j * darr[i, j].Width;
                    darr[i, j].Top = i * darr[i, j].Height;
                    if (b.Text == "Create  1")
                    {
                        Controls.Add(darr[i, j]);
                        x = 1;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  2" && (i == j))
                    {
                        Controls.Add(darr[i, j]);
                        x = 2;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  3" && (i < j))
                    {
                        Controls.Add(darr[i, j]);
                        x = 3;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  4" && (i > j))
                    {
                        Controls.Add(darr[i, j]);
                        x = 4;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  5" && (i+j == 4))
                    {
                        Controls.Add(darr[i, j]);
                        x = 5;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  6" && (i+j < 4))
                    {
                        Controls.Add(darr[i, j]);
                        x = 6;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                    else if (b.Text == "Create  7" && (i+j > 4))
                    {
                        Controls.Add(darr[i, j]);
                        x = 7;
                        sum += Convert.ToInt32(darr[i, j].Text);
                    }
                }
                rdo.Checked = false;
                numt.Text = "";
            }
        }

        void Add(object s, EventArgs e)
        {
            //int sum = 0;
            //if (darr != null)
            //{
            //    for (int i = 0;i<darr)
            //}
            if (rdo.Checked)
                numt.Text = sum.ToString() + "";
            else
                numt.Text = "";
        }
    }
}
