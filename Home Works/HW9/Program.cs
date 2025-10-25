using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW9 
{
    class Program : Form
    {

        ButtoninPanel buttoninPanel;
        ButtoninUserControl userControl;

        public Program()
        {
            Width = 300;
            Height = 150;

            buttoninPanel = new ButtoninPanel();
            userControl = new ButtoninUserControl();

            buttoninPanel.Location = new Point(20, 20);
            userControl.Location = new Point(buttoninPanel.Right + 20, 20);

            Controls.AddRange(new Control[] { buttoninPanel, userControl });
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }
    }
}
