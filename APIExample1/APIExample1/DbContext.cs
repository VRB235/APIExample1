using APIExample1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExample1
{
    public static class DbContext
    {
        public static List<User> FillUsers()
        {
            return new List<User>
            {
                new User
                {
                    DocumentId = "V24000001",
                    Password = "Hola1234*"
                },
                new User
                {
                    DocumentId = "V24000002",
                    Password = "Hola1234*"
                }
            };
        }
    }
}
