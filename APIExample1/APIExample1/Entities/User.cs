using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace APIExample1.Entities
{
    public class User
    {
        public string DocumentId { get; set; }
        [Phone(ErrorMessage ="Formato de número de teléfono incorrecto")]
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
