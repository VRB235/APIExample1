using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBank.Models
{
    public class Movement
    {
        public int Reference { get; set; }
        public string Concept { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public string DocumentIdBeneficiary { get; set; }
        public string PersonId { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }   
}
