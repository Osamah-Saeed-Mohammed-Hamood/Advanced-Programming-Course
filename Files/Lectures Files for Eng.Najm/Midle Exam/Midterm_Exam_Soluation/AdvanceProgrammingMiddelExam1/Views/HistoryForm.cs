using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AdvanceProgrammingMiddelExam1.Models;
 
namespace AdvanceProgrammingMiddelExam1.Views
{
    public partial class HistoryForm : Form
    {
        private List<StudentPayment> payments = new List<StudentPayment>();
        private Panel displayPanel;
        private Label lblCount;
        private PaymentForm paymentForm;

        public HistoryForm(Form form)
        {
            paymentForm =(PaymentForm/*why*/)form;//?!!!!
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            this.Text = "سجل السداد";
            this.Size = new Size(700, 400);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            displayPanel = new Panel
            {
                Location = new Point(20, 50),
                Size = new Size(650, 280),
                AutoScroll = true
            };

            lblCount = new Label
            {
                Text = "عدد السجلات: 0",
                Location = new Point(20, 20),
                AutoSize = true
            };

            this.Controls.Add(displayPanel);
            this.Controls.Add(lblCount);
        }
        public void AddRecord(StudentPayment payment)
        {
            payments.Add(payment);
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            displayPanel.Controls.Clear();
            int y = 10;
            
            AddLabel("تاريخ السداد", 20+120, y, true);
            AddLabel("المتبقي", 160+120, y, true);
            AddLabel("الرسوم الكلية", 280+120, y, true);
            AddLabel("اسم الطالب", 400+120, y, true);
            y += 30;

            foreach (StudentPayment p in payments)
            {
                
                AddLabel(p.PaymentDate.ToShortDateString(), 20+120, y);
                AddLabel(p.RemainingFees.ToString(), 160+120, y);
                AddLabel(p.TotalFees.ToString(), 280+120, y);
                AddLabel(p.StudentName, 400+120, y);

                Button btnEdit = CreateButton("تعديل", 15, y, () => EditRecord(p));//Lambada
                Button btnDelete = CreateButton("حذف", 70, y, () => DeleteRecord(p));//++
                displayPanel.Controls.Add(btnEdit);
                displayPanel.Controls.Add(btnDelete);
                y += 30;
            }

            lblCount.Text = $"عدد السجلات: {payments.Count}";
        }
        private void AddLabel(string text, int x, int y, bool bold = false)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = false,
                Font = bold ? new Font("Tahoma", 9, FontStyle.Bold) : this.Font,
                TextAlign=ContentAlignment.MiddleCenter
            };
            displayPanel.Controls.Add(lbl);
        }
        private Button CreateButton(string text, int x, int y, Action onClick/*Delegate*/)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(50, 25)
            };
            btn.Click += (s, e) => onClick();
            return btn;
        }

        private void DeleteRecord(StudentPayment p)
        {
       
           if (MessageBox.Show("هل أنت متأكد من عماية الحذف", "!تحذير", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                payments.Remove(p);
                paymentForm?.IncrementCount();
                UpdateDisplay();//عرض البيانات من جديد بعد اجراء التعديلات/التحديث-يفضل عد عرض البيانات من جديد بشكل كااامل  الافضل الصف الذي تم التحديث  عليه
            }
           
        }
        private void EditRecord(StudentPayment p)
        {
            EditStudentForm editForm = new EditStudentForm(p);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                int index = payments.IndexOf(p);
                if (index >= 0)
                {
                    payments[index] = editForm.EditedStudent;
                    UpdateDisplay();
                }
            }
        }
    }
}
