using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DelegateHW2
{
    public delegate long factdel(int x);
    delegate void del2(string s);
    delegate bool check(int x);

    class Program : Form
    {
        TextBox t1;
        Button[] arrb;
        del2 msg = (s) => MessageBox.Show(s.ToString());

        Program()
        {
            this.Text = "DELEGATE";
            this.Size = new Size(450, 250);
            this.ResumeLayout(false);

            t1 = new TextBox();
            t1.Bounds = new Rectangle(100, 50, 100, 40);
            Controls.Add(t1);
            t1.KeyPress += (s, e) =>
              {
                  if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != '-'))
                  {
                      e.Handled = true;
                  }
              };
            string[] str = { "فردي", "زوجي", "تربيع", "القيمة المطلقة", "المضروب" };
            arrb = new Button[5];
            for (int i = 0;i<arrb.Length;i++)
            {
                arrb[i] = new Button();
                arrb[i].Bounds = new Rectangle((80 * i) + 10, 100, 70, 40);
                arrb[i].Text = str[i];
                arrb[i].Click += call;
                Controls.Add(arrb[i]);
            }
        }
        public long fact (int n)
        {
            return (n > 2) ? n * fact(n - 1) : 2;
        }

        public long abs(int n)
        {
            return (n >= 0) ? n : n * -1;
        }

        public void call(object sender , EventArgs e)
        {
            Button b = (Button)sender;
            check checkv;
            factdel fd;

            if (t1.Text.Trim()!="")
            {
                if (b.Text == "المضروب")
                {
                    fd = new factdel(fact);
                    msg(fd(int.Parse(t1.Text)).ToString());
                }
                else if (b.Text=="القيمة المطلقة")
                {
                    fd = new factdel(abs);
                    msg(fd(int.Parse(t1.Text)).ToString());
                }
                else if (b.Text=="تربيع")
                {
                    Func<int, int> f = ((int a) => a * a);
                    msg(f(int.Parse(t1.Text)).ToString());
                }
                else if (b.Text=="زوجي")
                {
                    checkv = (x) => x % 2 == 0;
                    msg(checkv(Convert.ToInt32(t1.Text)).ToString());
                }
                else if (b.Text=="فردي")
                {
                    checkv = (x) => x % 2 != 0;
                    msg(checkv(Convert.ToInt32(t1.Text)).ToString());
                }
            }
        }

        static int count (int []l,check ch)
        {
            int c = 0;
            foreach(int x in l)
            {
                if (ch(x))
                {
                    c++;
                }
            }
            return c;
        }
        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
    }
}
