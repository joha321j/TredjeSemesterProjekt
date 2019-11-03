using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class User : IdentityUser
    {
        //public int ID { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string Address { get; set; }
        public ZipCity ZIP { get; set; }
        //public int PhoneNumber { get; set; }
        public string Salt { get; set; }
        //public string HashedPassword { get; set; }
        public ICollection<UserCards> UserCards { get; set; }
    }
}
