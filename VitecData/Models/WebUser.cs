using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class WebUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        public string LastName { get; set; }

        [ProtectedPersonalData]
        public string Address { get; set; }

        [ProtectedPersonalData]
        public int ZIP { get; set; }
        //public ZipCity ZIP { get; set; }
        //public ICollection<UserCards> UserCards { get; set; }
    }
}
