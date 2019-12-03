using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecData.Models;

namespace Vitec.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
