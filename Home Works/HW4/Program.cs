using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW3
{
    internal class Program : Form
    {
        TextBox txtNumber;
        Label lblNum, lblEven, lblOdd, lblPrime;
        Button btnAdd;
        ListBox lstEven, lstOdd, lstPrime;

        public Program()
        {
            this.AutoSize = true;
            this.CenterToParent();
            txtNumber = new TextBox();
            lblNum = new Label();
            lblEven = new Label();
            lblOdd = new Label();
            lblPrime = new Label();
            btnAdd = new Button();
            lstEven = new ListBox();
            lstOdd = new ListBox();
            lstPrime = new ListBox();

            lblNum.Top = txtNumber.Top = 20;
            btnAdd.Top = txtNumber.Bottom + 10;
            lblEven.Top = lblOdd.Top = lblPrime.Top = btnAdd.Bottom + 20;
            lstEven.Top = lstOdd.Top = lstPrime.Top = lblEven.Bottom + 5;

            txtNumber.Left = 175;
            lblNum.Left = txtNumber.Right + 25;
            btnAdd.Left = 188;
            lblPrime.Left = 70;
            lblOdd.Left = lblPrime.Right + 40;
            lblEven.Left = lblOdd.Right + 40;
            lstPrime.Left = 20;
            lstOdd.Left = lstPrime.Right + 20;
            lstEven.Left = lstOdd.Right + 20;

            lblNum.Text = "الرقم";
            btnAdd.Text = "إضافة";
            lblEven.Text = "زوجي";
            lblOdd.Text = "فردي";
            lblPrime.Text = "أولي";
            txtNumber.TextAlign = HorizontalAlignment.Center;

            btnAdd.Click += AddNumberClick;
            txtNumber.KeyPress += NumberOnly;

            lblEven.ForeColor = Color.Red;
            lblOdd.ForeColor = Color.Green;
            lblPrime.ForeColor = Color.Blue;

            this.Controls.AddRange(new Control[] { txtNumber, lblNum, btnAdd, lblEven, lblOdd, lblPrime, lstEven, lstOdd, lstPrime });
        }

        private void NumberOnly(object s,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 57) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void AddNumberClick(object s, EventArgs e)
        {

            if (txtNumber.Text != "")
            {
                int n = Convert.ToInt32(txtNumber.Text);

                if (!(lstEven.Items.Contains(n) || lstOdd.Items.Contains(n) || lstPrime.Items.Contains(n)))
                {
                    if (n % 2 == 0)
                    {
                        lstEven.Items.Add(n);
                        txtNumber.Text = "";
                    }
                    if (n % 2 != 0)
                    {
                        lstOdd.Items.Add(n);
                        txtNumber.Text = "";
                    }
                    bool flag = true;
                    for (int i = 2; i < n; i++)
                        if (n % i == 0)
                        {
                            flag = false;
                            break;
                        }
                    if (flag)
                    {
                        lstPrime.Items.Add(n);
                        txtNumber.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("العدد قد تمت اضافتة في القوائم");
                    txtNumber.Text = "";
                    txtNumber.Focus();
                }
            }
            else
            {
                MessageBox.Show("الصندوق فارغ ، أدخل الرقم");
                txtNumber.Focus();
            } 
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }
    }
}
