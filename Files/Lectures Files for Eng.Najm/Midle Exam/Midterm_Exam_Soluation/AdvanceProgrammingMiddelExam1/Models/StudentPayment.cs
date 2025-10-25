using System;
namespace AdvanceProgrammingMiddelExam1.Models

{
    /// يمثل بيانات سداد طالب
    public class/*struct*/ StudentPayment
    {//لان البيانات مرتبطة بكائن اي كل كائن يتمثل من هذه البيانات   
        public string StudentName { get; set; }//تكافى تعريف خاصية وعمل دالة ست وجت
        public double TotalFees { get; set; }//++
        public double RemainingFees { get; set; }//++
        public DateTime PaymentDate { get; set; }//++

        public override string ToString()
        {
            return $"الطالب: {StudentName}, المدفوع: {TotalFees - RemainingFees}, المتبقي: {RemainingFees}, التاريخ: {PaymentDate.ToShortDateString()}";
        }
    }
}
 