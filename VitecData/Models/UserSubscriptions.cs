using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class UserSubscriptions
    {
        public User User { get; set; }
        public Subscription Subscription { get; set; }
        public DateTime SignUpDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool AutomaticBilling { get; set; }
    }
}
