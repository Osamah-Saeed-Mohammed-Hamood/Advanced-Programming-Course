using System;
using System.Drawing;
using System.Windows.Forms;
using AdvanceProgrammingMiddelExam1.Models;

namespace AdvanceProgrammingMiddelExam1.Views
{
    public partial class EditStudentForm : Form
    {
        //لاااااحظ واجهة تعديل البيانات  لاتختلف عن واجة اضافة البيانات
        private StudentPayment _student;
        private TextBox[] textBoxes;
        private Label[] labels;
        private Button[] buttons;
        private DateTimePicker dtPayment;
        public StudentPayment EditedStudent { get; private set; }
        public EditStudentForm(StudentPayment student)
        {
            _student = student;
            InitializeComponents();
            LoadStudentData();
        }
        private void InitializeComponents()
        {
            // إعدادات النموذج الأساسية
            this.Text = "تعديل بيانات الطالب";
            this.Size = new Size(450, 300);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // بيانات الحقول
            string[] labelTexts = { "اسم الطالب:", "الرسوم الكلية:", "الرسوم المتبقية:", "تاريخ السداد:" };
            labels = new Label[labelTexts.Length];
            textBoxes = new TextBox[labelTexts.Length - 1]; // التاريخ ليس TextBox

            // إنشاء العناصر باستخدام الحلقات
            for (int i = 0; i < labelTexts.Length; i++)
            {
                int yPos = 30 + (i * 40);

                labels[i] = new Label
                {
                    Text = labelTexts[i],
                    Location = new Point(50, yPos),
                    AutoSize = true
                };

                // إنشاء مربعات النص (باستثناء التاريخ)
                if (i < labelTexts.Length - 1)
                {
                    textBoxes[i] = new TextBox
                    {
                        Location = new Point(140, yPos + 3),
                        Width = 200,
                    };

                    // إضافة أحداث التحقق من الصحة
                    if (i == 0) // حقل الاسم
                    {
                        textBoxes[i].KeyPress += ArabicTextBox_KeyPress;
                    }
                    else // حقلي الرسوم
                    {
                        textBoxes[i].KeyPress += NumericTextBox_KeyPress;
                    }
                }
            }

            // إنشاء اداة التاريخ
            dtPayment = new DateTimePicker
            {
                Location = new Point(140, labels[labels.Length - 1].Location.Y + 3),
                Width = 200,
                Format = DateTimePickerFormat.Short
            };

            // إنشاء الأزرار
            string[] buttonTexts = { "حفظ التعديلات", "إلغاء" };
            buttons = new Button[buttonTexts.Length];

            for (int i = 0; i < buttonTexts.Length; i++)
            {
                buttons[i] = new Button
                {
                    Text = buttonTexts[i],
                    Location = new Point(150 + (i * 90), 200),
                    Width = i == 1 ? 100 : 80,
                    BackColor = Color.Green,
                    ForeColor = Color.White
                };
            }

            // ربط الأحداث
            buttons[0].Click += BtnSave_Click;
            buttons[1].Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // إضافة  العناصر إلى النموذج
            this.Controls.AddRange(labels);
            this.Controls.AddRange(textBoxes);
            this.Controls.Add(dtPayment);
            this.Controls.AddRange(buttons);
        }

        private void LoadStudentData()
        {
            textBoxes[0].Text = _student.StudentName;
            textBoxes[1].Text = _student.TotalFees.ToString();
            textBoxes[2].Text = _student.RemainingFees.ToString();
            dtPayment.Value = _student.PaymentDate;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.'/* dot(.)يجب منعه من ادخال اكثر من */)
            {
                e.Handled = true;
            }
        }

        private void ArabicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'أ' || e.KeyChar > 'ي') &&
                e.KeyChar != 'ء' &&
                e.KeyChar != 8 &&
                e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxes[0].Text) ||
                !double.TryParse(textBoxes[1].Text, out double total) ||
                !double.TryParse(textBoxes[2].Text, out double remaining))
            {
                MessageBox.Show("الرجاء إدخال بيانات صحيحة.");
                return;
            }

            if (remaining > total)
            {
                MessageBox.Show("الرسوم المتبقية لا يمكن أن تكون أكثر من الرسوم الكلية");
                return;
            }

            EditedStudent = new StudentPayment
            {
                StudentName = textBoxes[0].Text,
                TotalFees = total,
                RemainingFees = remaining,
                PaymentDate = dtPayment.Value.Date
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}


