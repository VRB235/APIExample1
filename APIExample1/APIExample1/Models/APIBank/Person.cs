using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBank.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string DocumentID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
