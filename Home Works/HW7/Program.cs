using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW7
{
     class Program : Form
    {
        pnlTypesOfNumbers num = new pnlTypesOfNumbers();
        IP_Address ip = new IP_Address();
        Label lblIP = new Label();
        PhoneNumber phnum = new PhoneNumber();
        Label lblPhone = new Label();

        public Program()
        {
            AutoSize = true;
            num.Location = new Point(10, 10);
            ip.Location = new Point(150, 250);
            Size = new Size(num.Width, num.Height + 200);
            lblIP.Text = "IP Adress";
            lblIP.Location = new Point(50, 257);
            lblPhone.Text = "رقم الهاتف : ";
            lblPhone.Location = new Point(50, 307);
            phnum.Location = new Point(150, 300);
            lblIP.Font = lblPhone.Font = new Font("Arial", 12);

            Controls.AddRange(new Control[] { ip, num, lblIP, lblPhone, phnum });
        }
        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }
    }
}
