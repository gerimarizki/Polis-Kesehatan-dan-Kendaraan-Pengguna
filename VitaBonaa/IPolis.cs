using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaBona
{
    public interface IPolis
    {
        public Customer PemilikPolis { get; set; }
        public Product Product { get; set; }
        public DateTime PolisDate { get; set; }
        public List<Fee> Fee { get; set; } 

        public void AddFee(Fee fee);
        public void PrintPolicy();
    }
}
