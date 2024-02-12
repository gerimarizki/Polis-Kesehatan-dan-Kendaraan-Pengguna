using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCity { get; set; }

        public string Job { get; set; }

        public string Gender { get; set; }
     
        public virtual void PrintBiodata()
        {
            Console.WriteLine($"{this.FirstName}, {this.LastName} {this.Gender}, {InsertData.FormattingDate(BirthDate)}, {this.Job}");
        }
    }
}
