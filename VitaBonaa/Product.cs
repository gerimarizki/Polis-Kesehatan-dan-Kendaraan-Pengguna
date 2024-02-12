using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Product
    {
        public string ProductName { get; set; }

        public ProductType ProductType { get; set; }

        public string Benefit { get; set; }

        public decimal Fee { get; set; }

        public string Frequency { get; set; }

        public string Requirement { get; set; }


        public Product(string productName, ProductType productType, string frequency, string benefit, string requirement)
        {
            ProductName = productName;
            ProductType = productType;
            Frequency = frequency;
            Benefit = benefit;
            Requirement = requirement;
        }
        public Product(string productName, ProductType productType, string frequency, string benefit, string requirement, decimal fee)
        {
            ProductName = productName;
            ProductType = productType;
            Frequency = frequency;
            Benefit = benefit;
            Requirement = requirement;
            Fee = fee;
        }
    }
}
