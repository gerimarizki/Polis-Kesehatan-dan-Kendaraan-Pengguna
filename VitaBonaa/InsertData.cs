using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaBona;

namespace Library
{
    public static class InsertData
    {
        public static Dictionary<int, Prospect> listProspect = new Dictionary<int, Prospect>();
        public static Dictionary<string, Customer> listCustomer = new Dictionary<string, Customer>();
        public static Dictionary<string, Product> listProduct = new Dictionary<string, Product>();

        public static void IntitializeProduct()
        {
            Product sb = new Product("Sehat Bersama", ProductType.Kesehatan, "Bulanan", "Claim perawatan kelas 1", "Bisa menanggung keluarga atau diri sendiri dari data Customer.");
            Product se = new Product("Sehat Extra", ProductType.Kesehatan, "Bulanan", "Claim perawatan kelas VIP", "Hanya bisa menanggung diri sendiri.");
            Product lk = new Product("Life Keluarga", ProductType.Jiwa, "Bulanan", "Mendapatkan 500.000.000 apabila terjadi sesuatu pada tertanggung.", "Bisa menanggung keluarga atau diri sendiri dari data nasabah.");
            Product ls = new Product("life Special", ProductType.Jiwa, "Tahunan ", "Mendapatkan 800.000.000 apabila terjadi sesuatu pada tertanggung.", "Hanya bisa menanggung diri sendiri.");
            Product pr = new Product("Protection", ProductType.Kendaraan, "Tahunan ", "Mendapat ganti rugi sampai 100.000.000 bila terjadi sesuatu.", "Hanya bisa menanggung kendaraan.", 2_000_000);
            Product pp = new Product("Protection Plus", ProductType.Kendaraan, "Tahunan ", "Mendapat ganti rugi total lost apa bila terjadi sesuatu..", "Hanya bisa menanggung kendaraan.", 2_500_000);

            listProduct.Add(sb.ProductName, sb);
            listProduct.Add(se.ProductName, se);
            listProduct.Add(lk.ProductName, lk);
            listProduct.Add(ls.ProductName, ls);
            listProduct.Add(pr.ProductName, pr);
            listProduct.Add(pp.ProductName, pp);
        }
        public static string FormattingCurrency(decimal currency)
        {
            return currency.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
        }
        public static string FormattingDate(DateTime date)
        {
            return date.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"));
        }

        public static int NumberValidation()
        {
            int input = 0;
            bool cekAngka = int.TryParse(Console.ReadLine(), out input);
            if (!cekAngka)
            {
                Console.WriteLine("Masukkan angka!");
                NumberValidation();
            }
            return input;
        }
        public static DateTime DateValidation()
        {
            DateTime tanggalLahir;
            Console.Write("Tanggal Lahir (mm/dd/yyyy) : ");
            bool cekValid = DateTime.TryParse(Console.ReadLine(), out tanggalLahir);
            if (!cekValid)
            {
                Console.WriteLine("Tanggal salah, masukkan ulang!");
                DateValidation();
            }
            return tanggalLahir;
        }



        public static void AddProspect()
        {
            Console.Write("Nama Depan : ");
            string firstName = Console.ReadLine();
            Console.Write("Nama Belakang : ");
            string lastName = Console.ReadLine();
            DateTime birthDate = DateValidation();
            Console.Write("Tempat Lahir : ");
            string birthCity = Console.ReadLine();
            Console.Write("Jenis Kelamin (P/L) : ");
            string _gender = Console.ReadLine().ToUpper();
            string gender = (_gender == "P") ? "Perempuan" : "Laki-laki";
            Console.Write("Pekerjaan : ");
            string job = Console.ReadLine();

            int prospectID = listProspect.Count + 1;
            Prospect addProspect = new Prospect(prospectID, firstName, lastName, birthDate, birthCity, gender, job);
            listProspect.Add(addProspect.ProspectID, addProspect);
            Console.WriteLine();
            Console.WriteLine("Menambahkan Prospek Baru");
        }
        public static void ProspectToCustomer()
        {
            PrintAllProspect();
            Customer newCustomer = new Customer();
            Console.Write("Ketik nomor prospek yang ingin dijadikan nasabah : ");
            int prospectID = NumberValidation();
            if (listProspect.ContainsKey(prospectID))
            {
                if (listProspect[prospectID].Status == "Nasabah")
                {
                    Console.WriteLine("\nNomor prospect sudah menjadi nasabah\n");
                    ProspectToCustomer();
                }
                else if (listProspect[prospectID].Status == "Prospect")
                {
                    Console.Write("Nomor KTP : ");
                    string customerIDCard = Console.ReadLine();
                    newCustomer.GetFamilyStatus();
                    newCustomer.GetPaymentMethod();
                    newCustomer.CustomerID = $"{DateTime.Today.ToString("MM/yyyy")}/{listProspect[prospectID].ProspectID}";
                    newCustomer.CustomerIDCard = customerIDCard;
                    newCustomer.Prospect = listProspect[prospectID];
                    listProspect[prospectID].Status = "Nasabah";
                    listCustomer.Add(newCustomer.CustomerID, newCustomer);
                }
            }
            else
            {
                Console.WriteLine("Data tidak tersedia");
            }
        }

        public static void BuyProduct()
        {
            PrintAllCustomer();
            Console.WriteLine();
            Console.Write("Pilih Nomor Customer : ");
            string customerID = Console.ReadLine();
            bool cekContains = listCustomer.ContainsKey(customerID);
            if (!cekContains)
            {
                Console.WriteLine("\nNomor Nasabah tidak tersedia!\n");
                BuyProduct();
            }
            ChooseProduct(customerID);
        }
        public static void ChooseProduct(string customerID)
        {
            decimal totalFee;
            DateTime paymentDate;
            Console.WriteLine();
            foreach (Product product in listProduct.Values)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.Write("Pilih Nama Product : ");
            string productName = Console.ReadLine().ToLower();
            Customer customer = listCustomer[customerID];
            if (productName == "sehat bersama" || productName == "sehat extra" || productName == "life keluarga" || productName == "life special")
            {
                Fee firstMonth, secondMonth, thirdMonth, firstYear;
                Console.Write("Pilih Nomor Customer Tertanggung: ");
                string insuredCustomerID = Console.ReadLine();
                Customer insured = listCustomer[insuredCustomerID];
                PolisHealthAndLife customerPolis = new PolisHealthAndLife(customer, insured);

                switch (productName)
                {
                    case "sehat bersama":
                        totalFee = FeeBaseOnAge(200_000, 400_000, listCustomer[insuredCustomerID].Prospect.BirthDate);

                        paymentDate = DateTime.Today.AddMonths(1);
                        firstMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(firstMonth);
                        paymentDate = DateTime.Today.AddMonths(2);
                        secondMonth = new Fee(totalFee, paymentDate);
                        customerPolis.Fee.Add(secondMonth);
                        paymentDate = DateTime.Today.AddMonths(3);
                        thirdMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(thirdMonth);

                        customerPolis.Product = listProduct["Sehat Bersama"];
                        customer.AddPolis(customerPolis);
                        break;
                    case "sehat extra":
                        totalFee = FeeBaseOnAge(300_000, 500_000, listCustomer[insuredCustomerID].Prospect.BirthDate);
                        if (customerID != insuredCustomerID)
                        {
                            Console.WriteLine("Hanya bisa menanggung diri sendiri!");
                            Menu.MenuCustomer();
                        }
               
                        paymentDate = DateTime.Today.AddMonths(1);
                        firstMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(firstMonth);
                        paymentDate = DateTime.Today.AddMonths(2);
                        secondMonth = new Fee(totalFee, paymentDate);
                        customerPolis.Fee.Add(secondMonth);
                        paymentDate = DateTime.Today.AddMonths(3);
                        thirdMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(thirdMonth);

                        customerPolis.Product = listProduct["Sehat Extra"];
                        customer.AddPolis(customerPolis);
                        break;
                    case "life keluarga":
                        totalFee = FeeBaseOnAge(250_000, 450_000, listCustomer[insuredCustomerID].Prospect.BirthDate);

                        paymentDate = DateTime.Today.AddMonths(1);
                        firstMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(firstMonth);
                        paymentDate = DateTime.Today.AddMonths(2);
                        secondMonth = new Fee(totalFee, paymentDate);
                        customerPolis.Fee.Add(secondMonth);
                        paymentDate = DateTime.Today.AddMonths(3);
                        thirdMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(thirdMonth);

                        customerPolis.Product = listProduct["Life Keluarga"];
                        customer.AddPolis(customerPolis);
                        break;
                    case "life Special":
                        totalFee = FeeBaseOnAge(3_600_000, 4_800_000, listCustomer[insuredCustomerID].Prospect.BirthDate);
                        if (customerID != insuredCustomerID)
                        {
                            Console.WriteLine("Hanya bisa menanggung diri sendiri!");
                            Menu.MenuCustomer();
                        }
                        paymentDate = DateTime.Today.AddMonths(1);
                        firstMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(firstMonth);
                        paymentDate = DateTime.Today.AddMonths(2);
                        secondMonth = new Fee(totalFee, paymentDate);
                        customerPolis.Fee.Add(secondMonth);
                        paymentDate = DateTime.Today.AddMonths(3);
                        thirdMonth = new Fee(totalFee, paymentDate);
                        customerPolis.AddFee(thirdMonth);

                        customerPolis.Product = listProduct["Life Special"];
                        customer.AddPolis(customerPolis);
                        break;
                }
            }
            else if (productName == "protection" || productName == "protection plus")
            {
                Fee firstYear, secondYear, thirdYear;
                Console.WriteLine("Input data Kendaraan : ");
                Console.Write("Jenis Kendaraan (Mobil/Motor) : ");
                string vehicleType = Console.ReadLine();
                Console.Write("Nomor Polisi : ");
                string policeNumber = Console.ReadLine();
                Console.Write("Nomor STNK : ");
                string vehicleCertificateNumber = Console.ReadLine();
                Console.Write("Merek Kendaraan : ");
                string brand = Console.ReadLine();
                Console.Write("Model Kendaraan : ");
                string model = Console.ReadLine();
                Console.Write("Warna Kendaraan : ");
                string color = Console.ReadLine();

                Vehicle vehicle = new Vehicle(vehicleType, policeNumber, vehicleCertificateNumber, brand,  model , color);
                PolisVehicle polisVehicle = new PolisVehicle(customer, vehicle);
                switch (productName)
                {
                    case "protection":
                        totalFee = listProduct["Protection"].Fee;
                        firstYear = new Fee(totalFee, DateTime.Today);
                        polisVehicle.AddFee(firstYear);
                        paymentDate = DateTime.Today.AddYears(1);
                        secondYear = new Fee(totalFee, paymentDate);
                        polisVehicle.AddFee(secondYear);
                        paymentDate = DateTime.Today.AddYears(2);
                        thirdYear = new Fee(totalFee, paymentDate);
                        polisVehicle.AddFee(thirdYear);
                        polisVehicle.Product = listProduct["Protection"];

                        customer.AddPolis(polisVehicle);
                        break;
                    case "protection plus":
                        totalFee = listProduct["Protection"].Fee;
                        firstYear = new Fee(totalFee, DateTime.Today);
                        polisVehicle.AddFee(firstYear);
                        paymentDate = DateTime.Today.AddYears(1);
                        secondYear = new Fee(totalFee, paymentDate);
                        polisVehicle.AddFee(secondYear);
                        paymentDate = DateTime.Today.AddYears(2);
                        thirdYear = new Fee(totalFee, paymentDate);
                        polisVehicle.AddFee(thirdYear);
                        polisVehicle.Product = listProduct["Protection Plus"];

                        customer.AddPolis(polisVehicle);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Data product tidak ditemukan");
                ChooseProduct(customerID);
            }
        }
        public static decimal FeeBaseOnAge(decimal under20, decimal above20, DateTime tanggalLahir)
        {
            decimal iuran;
            int age = ((DateTime.Today - tanggalLahir).Days) / 365;
            if (age <= 20)
            {
                iuran = under20;
            }
            else
            {
                iuran = above20;
            }
            return iuran;
        }

        public static void PrintAllProspect()
        {
            foreach (Prospect prospect in listProspect.Values)
            {
                prospect.PrintBiodata();
            }
        }
        public static void PrintAllCustomer()
        {
            foreach (Customer customer in listCustomer.Values)
            {
                customer.PrintBiodata();
                Console.WriteLine("========================================================================================");
            }
        }

        public static void DetailPolicy()
        {
            PrintAllCustomer();
            Console.WriteLine();
            Console.Write("Pilih Nomor Customer : ");
            string customerID = Console.ReadLine();
            bool checkCustomerID = listCustomer.ContainsKey(customerID);
            if (!checkCustomerID)
            {
                Console.WriteLine("Data nasabah tidak ditemukan");
                DetailPolicy();
            }
            else
            {
                PrintPolicyInfo(customerID);
            }
        }
        public static void PrintPolicyInfo(string customerID)
        {
            Console.WriteLine("======================================================CUSTOMER INFO====================================================");
            listCustomer[customerID].PrintBiodata();
            foreach (IPolis polis in listCustomer[customerID].Polis)
            {
                Console.WriteLine("=======================================================================================================================");
                Console.WriteLine("======================================================POLICY INFO======================================================");
                polis.PrintPolicy();
            }
        }

       
    }
}
