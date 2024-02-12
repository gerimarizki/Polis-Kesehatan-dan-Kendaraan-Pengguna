using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Vehicle
    {
        public string VehicleType { get; set; }

        public string PoliceNumber { get; set; }

        public string VehicleCertificateNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public Vehicle(string vehicleType, string policeNumber, string vehicleCertificateNumber, string brand, string model, string color)
        {
            VehicleType = vehicleType;
            PoliceNumber = policeNumber;
            VehicleCertificateNumber = vehicleCertificateNumber;
            Brand = brand;
            Model = model;
            Color = color;
        }
    }
}
