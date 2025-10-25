using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW8
{
    class Program : Form
    {
        private NumericCharTextBox numericCharTextBox1;
        private CreateTextBox createTextBox1;
        private GoLabel goLabel1;
        private MyTextBox myTextBox1;
        private MyCheckBox myCheckBox1;
        private ButtonLight buttonLight1;

        public Program()
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.buttonLight1 = new HW8.ButtonLight();
            this.numericCharTextBox1 = new HW8.NumericCharTextBox();
            this.createTextBox1 = new HW8.CreateTextBox();
            this.goLabel1 = new HW8.GoLabel();
            this.myTextBox1 = new HW8.MyTextBox();
            this.myCheckBox1 = new HW8.MyCheckBox();
            this.SuspendLayout();
            // 
            // buttonLight1
            // 
            this.buttonLight1.isLight = HW8.Light.True;
            this.buttonLight1.Location = new System.Drawing.Point(25, 22);
            this.buttonLight1.Name = "buttonLight1";
            this.buttonLight1.Size = new System.Drawing.Size(150, 50);
            this.buttonLight1.TabIndex = 0;
            this.buttonLight1.Text = "buttonLight1";
            this.buttonLight1.UseVisualStyleBackColor = true;
            // 
            // numericCharTextBox1
            // 
            this.numericCharTextBox1.Font = new System.Drawing.Font("Arial", 14F);
            this.numericCharTextBox1.Language = HW8.Languages.English;
            this.numericCharTextBox1.Location = new System.Drawing.Point(218, 22);
            this.numericCharTextBox1.Multiline = true;
            this.numericCharTextBox1.Name = "numericCharTextBox1";
            this.numericCharTextBox1.Size = new System.Drawing.Size(150, 50);
            this.numericCharTextBox1.TabIndex = 1;
            this.numericCharTextBox1.TextChanged += new System.EventHandler(this.numericCharTextBox1_TextChanged);
            // 
            // createTextBox1
            // 
            this.createTextBox1.bkColor = HW8.ChooseColor.RED;
            this.createTextBox1.Location = new System.Drawing.Point(206, 149);
            this.createTextBox1.Name = "createTextBox1";
            this.createTextBox1.NumberOfTextBoxes = 2;
            this.createTextBox1.Size = new System.Drawing.Size(150, 22);
            this.createTextBox1.TabIndex = 2;
            // 
            // goLabel1
            // 
            this.goLabel1.AutoSize = true;
            this.goLabel1.Font = new System.Drawing.Font("Arial", 14F);
            this.goLabel1.GoTo = 10;
            this.goLabel1.Location = new System.Drawing.Point(213, 218);
            this.goLabel1.Name = "goLabel1";
            this.goLabel1.Size = new System.Drawing.Size(111, 27);
            this.goLabel1.TabIndex = 3;
            this.goLabel1.Text = "goLabel1";
            // 
            // myTextBox1
            // 
            this.myTextBox1.Font = new System.Drawing.Font("Arial", 14F);
            this.myTextBox1.Length = 20;
            this.myTextBox1.Location = new System.Drawing.Point(206, 287);
            this.myTextBox1.MaxLength = 20;
            this.myTextBox1.Multiline = true;
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(150, 50);
            this.myTextBox1.TabIndex = 4;
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.AutoSize = true;
            this.myCheckBox1.Location = new System.Drawing.Point(380, 94);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(115, 20);
            this.myCheckBox1.TabIndex = 5;
            this.myCheckBox1.Text = "myCheckBox1";
            this.myCheckBox1.UseVisualStyleBackColor = true;
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(540, 429);
            this.Controls.Add(this.myCheckBox1);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.goLabel1);
            this.Controls.Add(this.createTextBox1);
            this.Controls.Add(this.numericCharTextBox1);
            this.Controls.Add(this.buttonLight1);
            this.Name = "Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void numericCharTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
