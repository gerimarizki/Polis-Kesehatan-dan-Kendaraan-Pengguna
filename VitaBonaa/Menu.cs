using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaBona
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Menu Prospect");
            Console.WriteLine("2. Menu Customer");
            Console.WriteLine("3. Exit Application\n");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Menu Prospect");
                        MenuProspect();
                        break;
                    case 2:
                        Console.WriteLine("2. Menu Customer");
                        MenuCustomer();
                        break;
                    case 3:
                        Console.WriteLine("4. Exit Application");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3!");
                MainMenu();
            }

        }

        public static void MenuProspect()
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Add Prospect");
            Console.WriteLine("2. Prospect To Customer");
            Console.WriteLine("3. Main Menu");
            Console.WriteLine("4. Exit Application\n");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Add Prospect");
                        InsertData.AddProspect();
                        MainMenu();
                        break;
                    case 2:
                        Console.WriteLine("2. Prospect To Customer");
                        InsertData.ProspectToCustomer();
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Main Menu");
                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("4. Exit Application");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-4");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-4!");
                MainMenu();
            }

        }

        public static void MenuCustomer()
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Buy Product");
            Console.WriteLine("2. Detail Policy");
            Console.WriteLine("3. Main Menu");
            Console.WriteLine("4. Exit Application\n");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Buy Product");
                        InsertData.BuyProduct();
                        MainMenu();
                        break;
                    case 2:
                        Console.WriteLine("2. Detail Policy");
                        InsertData.DetailPolicy();
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Main Menu");
                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("4. Exit Application");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-4");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Silahkan input nomor nasabah yang tersedia!");
                MainMenu();
            }

        }
    }
}
