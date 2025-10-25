using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab8
{
    class StudentInfo : UserControl
    {
        Label[] lbl = new Label[4];
        TextBox[] txt = new TextBox[3];
        DateTimePicker time = new DateTimePicker();
        Button []btn = new Button[2];

        int studentnum;
        public StudentInfo()
        {
            RightToLeft = RightToLeft.Yes;
            Size = new Size(300, 200);
            for (int i = 0; i < 4; i++)
            {
                lbl[i] = new Label();
                if (i < 3)
                {
                    txt[i] = new TextBox();
                    txt[i].Width = time.Width;
                }
                if (i < 2)
                {
                    btn[i] = new Button();
                    btn[i].BackColor = Color.LightGreen;
                }
            }
            lbl[0].Location = new Point(200, 10);
            txt[0].Location = new Point(20, 10);
            lbl[1].Location = new Point(200, 50);
            txt[1].Location = new Point(20, 50);
            lbl[2].Location = new Point(200, 80);
            txt[2].Location = new Point(20, 80);
            lbl[3].Location = new Point(200, 120);
            time.Location = new Point(20, 120);
            lbl[0].Text = "اسم الطالب : ";
            lbl[1].Text = "الرسوم الكلية : ";
            lbl[2].Text = "الرسوم المتبقية : ";
            lbl[3].Text = "تاريخ السداد : ";
            btn[1].Text = "حفظ السجل";
            btn[0].Text = "عرض السجلات";

            btn[0].Location = new Point(70, 160);
            btn[1].Location = new Point(170, 160);

            Controls.AddRange(new Control[] { lbl[0], lbl[1], lbl[2], lbl[3], txt[0], txt[1], txt[2], time, btn[0], btn[1] });

        }
    }
}
