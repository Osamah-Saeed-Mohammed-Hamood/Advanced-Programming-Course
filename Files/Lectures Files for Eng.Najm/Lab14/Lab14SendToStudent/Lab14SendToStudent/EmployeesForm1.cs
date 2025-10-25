using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Advance_Programming_Labs.lab14
{
    public partial class EmployeesForm1 : Form
    {
        public EmployeesForm1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadEmployees();
        }
        private void LoadEmployees()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id, name, email, salary, hire_date FROM employees";

            using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                conn.Open();
                adapter.Fill(dt);
              
            }
                dgvEmployees.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                  
        
            //try
            //{
            //   string query = "INSERT INTO employees (name, email, salary, hire_date) VALUES (@name, @email, @salary, @hireDate)";

            //    using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
            //    using (MySqlCommand cmd = new MySqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@name", txtName.Text);
            //        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            //        cmd.Parameters.AddWithValue("@salary", float.Parse(txtSalary.Text));
            //        cmd.Parameters.AddWithValue("@hireDate", dtpHireDate.Value);

            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //    }

            //    LoadEmployees(); // تحديث العرض
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex+"");
            //}


            
                 string query = $"INSERT INTO employees (name, email, salary, hire_date) " +
                           $"VALUES ('{txtName.Text}', '{txtEmail.Text}', {decimal.Parse(txtSalary.Text)}, '{dtpHireDate.Value:yyyy-MM-dd}')";

         
            using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
           
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
         
            }
             LoadEmployees(); // تحديث العرض

            //----------------

        }


        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvEmployees.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = dgvEmployees.SelectedRows[0];
            //    txtName.Text = row.Cells["name"].Value.ToString();
            //    txtEmail.Text = row.Cells["email"].Value.ToString();
            //    txtSalary.Text = row.Cells["salary"].Value.ToString();
            //    dtpHireDate.Value = Convert.ToDateTime(row.Cells["hire_date"].Value);
            //}
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد موظف للتعديل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // التحقق من صحة المدخلات
            if (!ValidateInput())
                return;

            try
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["colId"].Value);

                string query = @"UPDATE employees SET 
                        name = @name,
                        email = @email,
                        salary = @salary,
                        hire_date = @hireDate
                        WHERE id = @id";

                using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@hireDate", dtpHireDate.Value);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تم تحديث بيانات الموظف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees(); // تحديث الجدول
                        ClearForm(); // تنظيف الحقول
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد موظف للحذف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("هل أنت متأكد من حذف هذا الموظف؟", "تأكيد الحذف",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["colId"].Value);

                string query = "DELETE FROM employees WHERE id = @id";

                using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تم حذف الموظف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees(); // تحديث الجدول
                        ClearForm(); // تنظيف الحقول
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            dtpHireDate.Value = DateTime.Now;
            dgvEmployees.ClearSelection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            string query = "SELECT * FROM employees WHERE name LIKE @search OR email LIKE @search";

            using (MySqlConnection conn = new MySqlConnection(DbConection.GetConnection()))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //foreach (DataRow item in dt.Rows)//للمرور على بيانات الجدول صف صف عمود عمود خلية خلية
                //{
                //    MessageBox.Show(item["id"].ToString()+ item["name"]);
                //}
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم الموظف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("الرجاء إدخال بريد إلكتروني صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary <= 0)
            {
                MessageBox.Show("الرجاء إدخال راتب صحيح أكبر من الصفر", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalary.Focus();
                return false;
            }

            return true;
        }
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new EmployeesForm1());

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    }
