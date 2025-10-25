using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW7
{
    class pnlTypesOfNumbers : Panel
    {
        Label[] Types = new Label[4];
        Button btnAdd = new Button();
        TextBox txtNum = new TextBox();
        ListBox[] lstTypeOfNum = new ListBox[3];

        public pnlTypesOfNumbers()
        {
            for (int i =0;i<Types.Length;i++)
            {
                Types[i] = new Label();
            }

            Types[0].Text = "أدخل العدد";
            Types[0].Location = new Point(200, 10);

            txtNum.Location = new Point(170, Types[0].Bottom + 5);
            txtNum.TextAlign = HorizontalAlignment.Center;

            btnAdd.Text = "إضافة";
            btnAdd.Location = new Point(txtNum.Left + 125, txtNum.Top - 3);

            for (int i =0;i<lstTypeOfNum.Length;i++)
            {
                lstTypeOfNum[i] = new ListBox();
            }

            lstTypeOfNum[0].Location = new Point(10, btnAdd.Bottom + 20);
            lstTypeOfNum[1].Location = new Point(lstTypeOfNum[0].Left + 150, lstTypeOfNum[0].Top);
            lstTypeOfNum[2].Location = new Point(lstTypeOfNum[1].Left + 150, lstTypeOfNum[1].Top);

            Types[1].Text = "الأعداد الأولية";
            Types[1].Location = new Point(lstTypeOfNum[0].Left + 30, lstTypeOfNum[0].Bottom + 10);

            Types[2].Text = "الأعداد الفردية";
            Types[2].Location = new Point(lstTypeOfNum[1].Left + 30, lstTypeOfNum[1].Bottom + 10);

            Types[3].Text = "الأعداد الزوجية";
            Types[3].Location = new Point(lstTypeOfNum[2].Left + 30, lstTypeOfNum[2].Bottom + 10);

            txtNum.KeyPress += NumEnsert;
            txtNum.TextChanged += btnEnable;
            btnAdd.Click += Add;

            ClientSize = new Size(450, 220);

            Controls.AddRange(new Control[] {Types[0],Types[1],Types[2],Types[3],txtNum,btnAdd,lstTypeOfNum[0],lstTypeOfNum[1],
            lstTypeOfNum[2]});

        }

        void NumEnsert(object s,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 57) && (e.KeyChar != 8))
                e.Handled = true;
        }

        void btnEnable (object s,EventArgs e)
        {
            if (txtNum.Text.Trim() != "")
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        void Add(object s,EventArgs e)
        {
            if (txtNum.Text != "")
            {
                int n = Convert.ToInt32(txtNum.Text);

                if (!(lstTypeOfNum[0].Items.Contains(n) || lstTypeOfNum[1].Items.Contains(n) || lstTypeOfNum[2].Items.Contains(n)))
                {
                    if (n % 2 == 0)
                    {
                        lstTypeOfNum[2].Items.Add(n);
                        txtNum.Text = "";
                    }
                    if (n % 2 != 0)
                    {
                        lstTypeOfNum[1].Items.Add(n);
                        txtNum.Text = "";
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
                        lstTypeOfNum[0].Items.Add(n);
                        txtNum.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("العدد قد تمت اضافتة في القوائم");
                    txtNum.Text = "";
                    txtNum.Focus();
                }
            }
            else
            {
                MessageBox.Show("الصندوق فارغ ، أدخل الرقم");
                txtNum.Focus();
            }
        }
    }
}
