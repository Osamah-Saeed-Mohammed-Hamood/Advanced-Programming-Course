using System;
using System.Drawing;
using System.Windows.Forms;
using AdvanceProgrammingMiddelExam1.Models;

namespace AdvanceProgrammingMiddelExam1.Views
{
    public partial class PaymentForm : Form
    {
        private TextBox[] textBoxes;
        private Label[] labels;
        private Button[] buttons;
        private DateTimePicker dtPayment;
        private Label lblRemainingCount;
        private HistoryForm historyForm;
        private int remainingCount;

        public PaymentForm(int count)
        {
            remainingCount = count;
            InitializeComponents();
            historyForm = new HistoryForm(this);
        }

        private void InitializeComponents()
        {
            this.Text = "إدخال بيانات السداد";
            this.Size = new Size(450, 300);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.BackColor = Color.White;

            // إنشاء مصفوفة النصوص
            string[] labelTexts = { "اسم الطالب:", "الرسوم الكلية:", "الرسوم المتبقية:", "تاريخ السداد:" };
            labels = new Label[labelTexts.Length];

            // إنشاء مصفوفة مربعات النص
            textBoxes = new TextBox[labelTexts.Length - 1]; // ناقص 1 لأن التاريخ ليس TextBox
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
              //  this.Controls.Add(labels[i]);
              //  this.Controls.Add(textBoxes[i]);
            }

            // إنشاء اداة  التاريخ
            dtPayment = new DateTimePicker
            {
                Location = new Point(140, labels[labels.Length - 1].Location.Y + 3),
                Width = 200
            };

            // إنشاء  العداد
            lblRemainingCount = new Label
            {
                Text = $"عدد السجلات المتبقية: {remainingCount}",
                Location = new Point(50, 2),
                AutoSize = true
            };

            // إنشاء مصفوفة الأزرار
            string[] buttonTexts = { "حفظ السجل", "عرض السجلات" };
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
                //  this.Controls.Add( buttons[i]);

            }

            // ربط الأحداث
            buttons[0].Click += BtnSave_Click;
            buttons[1].Click += btnShowDitals_Click;

            // إضافة جميع العناصر إلى النموذج
            this.Controls.AddRange(labels);
            this.Controls.AddRange(textBoxes);
            this.Controls.Add(dtPayment);
            this.Controls.Add(lblRemainingCount);
            this.Controls.AddRange(buttons);
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.')
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
        private void btnShowDitals_Click(object sender, EventArgs e)
        {
            if (historyForm==null || historyForm.IsDisposed)
            {//يجب معالجة اشكالية عند غلق نموذج عرض البيانات وفتجة من جديد تتهيا البيانات وتعود من الصفر
                historyForm = new HistoryForm(this);
            }
            else
                historyForm.Show();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (remainingCount <= 0)
            {
                MessageBox.Show("لقد انتهيت من عدد الإدخالات المحددة.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxes[0].Text) || !double.TryParse(textBoxes[1].Text, out double total) || !double.TryParse(textBoxes[2].Text, out double remaining))
            {
                MessageBox.Show("الرجاء إدخال بيانات صحيحة.");
                return;
            }

            var payment = new StudentPayment
            {
                StudentName = textBoxes[0].Text,
                TotalFees = total,
                RemainingFees = remaining,
                PaymentDate = dtPayment.Value.Date
            };

            historyForm.AddRecord(payment);
            remainingCount--;
            lblRemainingCount.Text = $"عدد السجلات المتبقية: {remainingCount}";
            textBoxes[0].Clear(); textBoxes[1].Clear(); textBoxes[2].Clear();
        }

        public void IncrementCount()
        {
            remainingCount++;
            lblRemainingCount.Text = $"عدد السجلات المتبقية: {remainingCount}";
        }
    }

}
