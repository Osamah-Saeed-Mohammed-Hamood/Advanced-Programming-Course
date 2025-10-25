using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW5
{
    class Movement : Form
    {
        Button[] btn = new Button[5];
        PictureBox pct;
        GroupBox grp;
        Timer t;
        bool isChooseImage = false;

        public Movement()
        {
            Start();
        }

        void Start()
        {
            this.Width = 350;
            this.Height = 350;
            this.Text = "Movement";

            grp = new GroupBox();
            grp.Text = "Button Menue";
            grp.Height = 100;
            grp.Width = 100;
            grp.Top = 5;
            grp.Left = this.Width - grp.Width - 20;

            pct = new PictureBox();
            pct.SizeMode = PictureBoxSizeMode.StretchImage;
            pct.BorderStyle = BorderStyle.FixedSingle;
            pct.Width = pct.Height = 50;
            pct.Top = 5;
            pct.Left = this.Width / 3;

            t = new Timer();
            t.Interval = 100;
            t.Tick += Move;

            string[] btnText = { "Choose Image", "Start", "Stop", "Player", "Close" };
            for (int i=0;i<btn.Length;i++)
            {
                btn[i] = new Button();
                btn[i].Text = btnText[i];
                btn[i].Top = i * btn[i].Height + 20;
                btn[i].Left = (grp.Width / 2) - (btn[i].Width / 2);

                if (i<3)
                {
                    grp.Controls.Add(btn[i]);
                }
            }
            btn[3].Left = btn[3].Top = btn[4].Left = 5;
            btn[4].Top = this.Bottom - btn[4].Height - 40;
            btn[0].Click += chooseImage;
            btn[1].Click += (s, e) =>
              {
                  if (isChooseImage)
                  {
                      t.Start();
                  }
                  else
                  {
                      MessageBox.Show("Please Choose Image !");
                  }
              };
            btn[2].Click += (s, e) =>
              {
                  t.Stop();
              };
            btn[4].Click += (s, e) =>
              {
                  this.Close();
              };
            btn[4].BackColor = Color.Red;
            btn[4].ForeColor = Color.White;

            Controls.AddRange(new Control[] { grp, pct, btn[3], btn[4] });
        }

        void chooseImage(object s,EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            try
            {
                op.ShowDialog();
                pct.Image = Image.FromFile(op.FileName);
                isChooseImage = true;
                op.Dispose();
            }
            catch (Exception ex)
            {
                isChooseImage = false;
                MessageBox.Show("File is not an Image");
            }
        }
        void Move(object s,EventArgs e)
        {
            Random r = new Random();
            btn[3].Top += 10;
            pct.Top += 20;
            if (btn[3].Top>this.Height)
            {
                btn[3].Top = 0;
                btn[3].Left = r.Next(0, this.Width - grp.Width - btn[3].Width);
            }
            if (pct.Top>this.Height)
            {
                pct.Top = 0;
                pct.Left = r.Next(0, this.Width - grp.Width - btn[3].Width);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Movement
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Movement";
            this.ResumeLayout(false);

        }
    }
}
