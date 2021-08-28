using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBank.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string NumberAccount { get; set; }
        public string NameProduct { get; set; }
        public double AmountAvailable { get; set; }
        public string TypeAccount { get; set; }
        public Person person { get; set; }
        public int PersonId { get; set; }
        public List<Movement> Movements{ get; set; }
    }
}
