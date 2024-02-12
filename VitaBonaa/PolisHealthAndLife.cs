using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaBona
{
    public class PolisHealthAndLife : IPolis
    {
        public Customer PemilikPolis { get; set; }
        public Customer Insured { get; set; }
        public DateTime PolisDate { get; set; }
        public List<Fee> Fee { get; set; } = new List<Fee>();
        public Product Product { get; set; }

        public PolisHealthAndLife(Customer pemilikPolis, Customer insured)
        {
            PemilikPolis = pemilikPolis;
            Insured = insured;
            PolisDate = DateTime.Today;
        }

        public void AddFee (Fee fee)
        {
            this.Fee.Add(fee);
        }
        public void PrintPolicy()
        {
            
            Console.WriteLine($"Tertanggung : {this.Insured.Prospect.FirstName} {this.Insured.Prospect.LastName}");
            Console.WriteLine($"Product : {this.Product.ProductName}");
            Console.WriteLine($"Tanggal mulai dijalankan : {this.PolisDate}");
            Console.WriteLine($"Manfaat : {this.Product.Benefit}");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("========================================================PAYMENT========================================================");
            foreach(Fee fee in Fee)
            {
                fee.GetFeeInformation();
            }

        }
    }
}
