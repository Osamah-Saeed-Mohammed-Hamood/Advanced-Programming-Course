using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OsamaSaeedMohammed
{
    internal class Program : Form
    {
        private MyTool myTool1;
        private MyTool myTool2;
        private MyTool myTool3;

        public Program()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.myTool3 = new OsamaSaeedMohammed.MyTool();
            this.myTool2 = new OsamaSaeedMohammed.MyTool();
            this.myTool1 = new OsamaSaeedMohammed.MyTool();
            this.SuspendLayout();
            // 
            // myTool3
            // 
            this.myTool3.AllowDrop = true;
            this.myTool3.Available = true;
            this.myTool3.BackColor = System.Drawing.Color.White;
            this.myTool3.ImgURL = "D:\\Osama Al-Jabali\\Osama.jpg";
            this.myTool3.Location = new System.Drawing.Point(790, 41);
            this.myTool3.Name = "myTool3";
            this.myTool3.Price = 2000;
            this.myTool3.Rating = 3;
            this.myTool3.Size = new System.Drawing.Size(330, 393);
            this.myTool3.TabIndex = 10;
            this.myTool3.Title = "jgjfygjghj";
            // 
            // myTool2
            // 
            this.myTool2.AllowDrop = true;
            this.myTool2.Available = true;
            this.myTool2.BackColor = System.Drawing.Color.White;
            this.myTool2.ImgURL = "D:\\Osama Al-Jabali\\Osama2.jpg";
            this.myTool2.Location = new System.Drawing.Point(406, 41);
            this.myTool2.Name = "myTool2";
            this.myTool2.Price = 2000;
            this.myTool2.Rating = 2;
            this.myTool2.Size = new System.Drawing.Size(340, 393);
            this.myTool2.TabIndex = 1;
            this.myTool2.Title = "331313131";
            // 
            // myTool1
            // 
            this.myTool1.AllowDrop = true;
            this.myTool1.Available = false;
            this.myTool1.BackColor = System.Drawing.Color.White;
            this.myTool1.ImgURL = "D:\\Osama Al-Jabali\\osama.jpg";
            this.myTool1.Location = new System.Drawing.Point(40, 41);
            this.myTool1.Name = "myTool1";
            this.myTool1.Price = 66666;
            this.myTool1.Rating = 3;
            this.myTool1.Size = new System.Drawing.Size(323, 393);
            this.myTool1.TabIndex = 0;
            this.myTool1.Title = "jgjfygjghj";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(1155, 543);
            this.Controls.Add(this.myTool3);
            this.Controls.Add(this.myTool2);
            this.Controls.Add(this.myTool1);
            this.Name = "Program";
            this.ResumeLayout(false);

        }
    }
}
