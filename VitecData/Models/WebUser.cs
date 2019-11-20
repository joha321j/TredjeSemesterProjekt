using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class WebUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        //public ZipCity ZIP { get; set; }
        //public ICollection<UserCards> UserCards { get; set; }
    }
}
