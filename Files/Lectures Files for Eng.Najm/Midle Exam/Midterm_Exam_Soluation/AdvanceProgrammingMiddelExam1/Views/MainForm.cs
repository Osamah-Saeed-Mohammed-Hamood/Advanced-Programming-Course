using AdvanceProgrammingMiddelExam1.Controlles;
using System.Windows.Forms;
using System.Drawing;
namespace AdvanceProgrammingMiddelExam1.Views
{
    public partial class MainForm : Form
    {
        private Label lblTitle;
        
        private NumericTextBox numCount;
        private Button btnStart;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(400, 200);
            this.Text = "نظام سداد رسوم الطلاب";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;//ملاحظة/حساب مواقع الادوات يكون من اليمين
            this.BackColor = Color.WhiteSmoke;

            lblTitle = new Label
            {
                Text = "عدد الطلاب الذين سيتم إدخال بياناتهم:",
                Location = new Point(50, 50),
               AutoSize = true
            };
            lblTitle. Width = lblTitle.Width +70;
            numCount = new NumericTextBox();
            numCount.Left = lblTitle.Right ;
            numCount.Top = lblTitle.Top;
            numCount.MaximumValue = 4;
            btnStart = new Button
            {
                Text = "بدء الإدخال",
                Location = new Point(numCount.Left, numCount.Top+ numCount.Height*2),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnStart.Click += (s, e) =>
            {
                PaymentForm form = new PaymentForm(numCount.Value);
                form.Show();
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(numCount);
            this.Controls.Add(btnStart);
        }
    }
}
