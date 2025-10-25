using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW6
{
    class closeButton : Button
    {
        public closeButton()
        {
            this.Text = "Close"; 
            this.Click += closeButton_Click;
            ForeColor = Color.White;
            BackColor = Color.Red;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.TopLevelControl as Form;

            DialogResult result = MessageBox.Show("Do You Want To Close Application ?",
               "Conform Close",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                parentForm.Close();
            }
        }
    }
}
