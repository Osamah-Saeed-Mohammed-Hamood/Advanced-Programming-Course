using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab8
{
    internal class InsertInfo : Form
    {
        Label lbl;
        public static int n;
        StudentInfo f;
        public InsertInfo(string s)
        {
            Text = "إدخال بيانات السداد";
            Size = new Size(400, 300);
            n = Convert.ToInt32(s);
            lbl = new Label();
            lbl.Width = 150;
            lbl.Text = "عدد السجلات المتبقية : " + s;
            lbl.Location = new Point(250, 10);
            f = new StudentInfo();
            f.Location = new Point(30, 40);
            Controls.AddRange(new Control[] { lbl, f });
        }
    }
}
