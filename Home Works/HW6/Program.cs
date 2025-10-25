using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class Program : Form
    {
        Label[] lab = new Label[8];
        public Program()
        {
            Start();
        }

        void Start()
        {
            for (int i =0;i<lab.Length;i++)
            {
                lab[i] = new Label();
            }

            Width = 800;
            Height = 400;
            Text = "HW 6";

            lab[0].Text = "زر تغيير اللون";
            lab[0].Top = this.Top + 15;
            lab[0].Left = this.Right - 110;
            buttonColorChange bColor = new buttonColorChange();
            bColor.Top = lab[0].Bottom + 5; ;
            bColor.Left = this.Right - 125;

            lab[1].Text = "مربع النص لادخال الحروف كبيرة";
            lab[1].Width = 130;
            lab[1].Top = bColor.Bottom + 40;
            lab[1].Left = this.Right - 150;
            TextBoxUpperLetter txt = new TextBoxUpperLetter();
            txt.Top = lab[1].Bottom + 5;
            txt.Left = this.Right - 135;

            lab[2].Text = "قائمة تغيير لون الحاوية";
            lab[2].Top = txt.Bottom + 40;
            lab[2].Left = this.Right - 125;
            ComboBoxColor cmb = new ComboBoxColor();
            cmb.Top = lab[2].Bottom + 5;
            cmb.Left = this.Right - 140;

            lab[3].Text = "زر استقبال الحجم عن طريق المشيد";
            lab[3].Top = lab[0].Top;
            lab[3].Left = lab[0].Right -400;
            lab[3].Width = 140;
            MyButton btn = new MyButton(100, 30, lab[3]);

            Panel p = new Panel();
            GroupBox grp = new GroupBox();

            grp.Top = 10;
            grp.Left = 10;
            p.Top = grp.Bottom + 10;
            p.Left = 10;
            p.Width = grp.Width;

            TextBox t1 = new TextBox(), t2 = new TextBox();  // عشان نجرب buttontextbox
            t2.Top = t1.Top = 40;
            t2.Left = t1.Left = 50;
            p.Controls.Add(t1);
            grp.Controls.Add(t2);
            grp.Text = "تجربة زر ButtonClearNumeric";

            lab[4].Text = "زر حذف الارقام في الحاويات";
            lab[4].Top = lab[1].Top;
            lab[4].Left = lab[1].Right - 380;
            lab[4].Width = 130;
            ButtonClearNumeric btnClearNumeric = new ButtonClearNumeric();
            btnClearNumeric.Top = lab[1].Bottom + 5;
            btnClearNumeric.Left = 420;

            lab[5].Text = "مربع نص لا يقبل الفراغات عند الادخال مباشرة";
            lab[5].Width = 180;
            lab[5].Top = lab[2].Top;
            lab[5].Left = lab[2].Left - 300;
            TextBoxCleanExtraSpace txtCleanSpace = new TextBoxCleanExtraSpace();
            txtCleanSpace.Top = lab[5].Bottom + 5;
            txtCleanSpace.Left = 410;

            lab[6].Text = "مربع نص يقبل اي مدخل ،عند الضفط على مفتاح الكود 100 يحذف الفراغات الزائدة";
            lab[6].Width = 320;
            lab[6].Top = txtCleanSpace.Bottom + 40;
            lab[6].Left = lab[5].Left - 70;
            SmartTextBox text1 = new SmartTextBox();
            text1.Top = this.Bottom - 80;
            text1.Left = 410;

            lab[7].Text = "زر يعمل على غلق النموذج بدون الاعتماد على الدالة FindForm()";
            lab[7].Top = lab[6].Top;
            lab[7].Left = 30;
            lab[7].Width = 260;
            closeButton bclose = new closeButton();
            bclose.Top = this.Bottom - 80;
            bclose.Left = 110;

            Controls.AddRange(new Control[] { bclose, bColor, txt, cmb, btn,p, grp, btnClearNumeric, txtCleanSpace, text1,
            lab[0],lab[1],lab[2],lab[3],lab[4],lab[5],lab[6],lab[7]});
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }
    }
}
