using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW5
{
    namespace MyNameSpace
    {
        class MyClass
        {
            public void showMessage()
            {
                MessageBox.Show("Hello from MyNameSpace !");
            }

            //static void Main()
            //{
            //    MyClass obj = new MyClass();
            //    obj.showMessage();
            //}
        }
    }
    namespace MyNameSpace2
    {
        class Program : Form
        {
            [STAThread]
            static void Main(string[] args)
            {
                //MyNameSpace.MyClass myClass = new MyNameSpace.MyClass();
                // myClass.showMessage();

                Application.EnableVisualStyles();
                //Movement m = new Movement();
                //m.ShowDialog();

                OpArrTextBox op = new OpArrTextBox();
                Application.Run(op);
            }
        }
    }
}