using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaBona
{
    public class PolisVehicle : IPolis
    {
        public Customer PemilikPolis { get; set; }
        public Product Product { get; set; }
        public DateTime PolisDate { get; set; }
        public List<Fee> Fee { get; set; } = new List<Fee>();
        public Vehicle Vehicle { get; set; }

        public void AddFee(Fee fee)
        {
            this.Fee.Add(fee);
        }

        public PolisVehicle(Customer pemilikPolis, Vehicle vehicle)
        {
            PemilikPolis = pemilikPolis;
            Vehicle = vehicle;
            PolisDate = DateTime.Today;
        }
        public void PrintPolicy()
        {
            Console.WriteLine($"Product : {this.Product.ProductName}");
            Console.WriteLine($"Tanggal mulai dijalankan : {InsertData.FormattingDate(this.PolisDate)}");
            Console.WriteLine($"Jenis Kendaraan : {this.Vehicle.VehicleType}");
            Console.WriteLine($"Nomor Polisi : {this.Vehicle.PoliceNumber}");
            Console.WriteLine($"Nomor STNK : {this.Vehicle.VehicleCertificateNumber}");
            Console.WriteLine($"Merek Kendaraan : {this.Vehicle.Brand}");
            Console.WriteLine($"Model Kendaraan : {this.Vehicle.Model}");
            Console.WriteLine($"Warna Kendaraan : {this.Vehicle.Color}");
            Console.WriteLine("=============================================================================================================================");
            Console.WriteLine("===========================================================PAYMENT===========================================================");
            foreach (Fee fee in Fee)
            {
                fee.GetFeeInformation();
            }
        }
    }
}
