using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Prospect : Person
    {
        public int ProspectID {  get; set; }
        
        public string Status { get; set; }

        public Prospect(int prospectID, string firstName, string lastName, DateTime birthDate, string birhtPlace, string gender, string job)
        {
            ProspectID = prospectID;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            BirthCity = birhtPlace;
            Gender = gender;
            Job = job;
            Status = "Prospect";
        }

        public override void PrintBiodata()
        {
            Console.WriteLine($"No : {this.ProspectID}, {this.FirstName}, {this.LastName} ,{this.Gender}, {InsertData.FormattingDate(this.BirthDate)}, {this.Job}, {this.Status}");        
        }



    }
}
