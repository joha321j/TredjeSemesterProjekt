using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vitec.Models
{
    public class UserSubscriptions
    {
        public int UserID { get; set; }
        public int SubscriptionID { get; set; }
        public DateTime SignUpDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool AutomaaticBilling { get; set; }
    }
}
