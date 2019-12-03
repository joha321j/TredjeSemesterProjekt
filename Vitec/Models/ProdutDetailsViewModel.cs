using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecData.Models;

namespace Vitec.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
