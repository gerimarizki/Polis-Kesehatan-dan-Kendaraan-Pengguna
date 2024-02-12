using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using VitaBona;

namespace Library
{
    public class Customer : Person
    {
        public Prospect Prospect { get; set; }

        public string CustomerID { get; set; }

        public string CustomerIDCard { get; set; }

        public FamilyStatus FamilyStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public List<IPolis> Polis { get; set; } = new List<IPolis>();

        public override void PrintBiodata()
        {
            Console.WriteLine($"No: {this.GetCustomerID()}, " +
                $"{this.Prospect.FirstName}, {this.Prospect.LastName}," +
                $" {this.Prospect.Gender}, {InsertData.FormattingDate(this.Prospect.BirthDate)}," +
                $" {this.Prospect.BirthCity} {this.Prospect.Job}\n" +
                $"No KTP: {this.CustomerIDCard}, Status di KK:" +
                $" {this.GetFullFamilyStatus()}, Payment Method: {this.GetFullPaymentMethod()}");
        }

        private string GetCustomerID()
        {
            DateTime startDate = DateTime.Today;
            CustomerID = startDate.ToString($"MM/yyyy/{Prospect.ProspectID}");
            return CustomerID;
        }

        public void GetFamilyStatus()
        {
            Console.Write("Status KK : ");
            string status = Console.ReadLine().ToUpper();
            switch (status)
            {
                case "KEPALA KELUARGA":
                    this.FamilyStatus = FamilyStatus.KepalaKeluarga;
                    break;
                case "IBU":
                    this.FamilyStatus = FamilyStatus.Ibu;
                    break;
                case "ANAK":
                    this.FamilyStatus = FamilyStatus.Anak;
                    break;
                default:
                    Console.WriteLine("Input salah");
                    GetFamilyStatus();
                    break;
            }
        }

        private string GetFullFamilyStatus()
        {
            switch(this.FamilyStatus)
            {
                case FamilyStatus.KepalaKeluarga:
                    return "Kepala Keluarga";
                case FamilyStatus.Ibu:
                    return "Ibu";
                case FamilyStatus.Anak:
                    return "Anak";
                default:
                    return "Unknown";
            }
        }

        public void GetPaymentMethod()
        {
            Console.Write("Payment Method (CC/AC/VP) : ");
            string payment = Console.ReadLine().ToUpper();
            switch (payment)
            {
                case "CC":
                    this.PaymentMethod = PaymentMethod.CC;
                    break;
                case "AC":
                    this.PaymentMethod = PaymentMethod.AC;
                    break;
                case "VP":
                    this.PaymentMethod = PaymentMethod.VP;
                    break;
                default:
                    Console.WriteLine("Input salah");
                    GetPaymentMethod();
                    break;
            }
        }
        private string GetFullPaymentMethod()
        {
            switch (this.PaymentMethod)
            {
                case PaymentMethod.CC:
                    return "Credit Card";
                case PaymentMethod.AC:
                    return "Auto Debit/Collection";
                case PaymentMethod.VP:
                    return "Voucher Prabayar";
                default:
                    return "Unknown";
            }
        }

        public void AddPolis(IPolis polis)
        {
            this.Polis.Add(polis);
        }
    }
}
