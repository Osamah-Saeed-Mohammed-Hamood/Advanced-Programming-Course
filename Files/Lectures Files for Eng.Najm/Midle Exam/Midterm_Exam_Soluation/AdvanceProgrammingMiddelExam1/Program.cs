using AdvanceProgrammingMiddelExam1.Views;
using System;
using System.Windows.Forms;

namespace AdvanceProgrammingMiddelExam1
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
