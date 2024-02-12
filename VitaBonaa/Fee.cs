using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaBona
{
    public class Fee
    {
        public decimal TotalFee { get; set; }
        public DateTime PaymentDate { get; set; }

        public Fee(decimal totalFee, DateTime paymentDate)
        {
            TotalFee = totalFee;
            PaymentDate = paymentDate;
        }

        public void GetFeeInformation()
        {
            Console.WriteLine($"{InsertData.FormattingDate(PaymentDate)}, {InsertData.FormattingCurrency(TotalFee)}");
        }
    }
}
