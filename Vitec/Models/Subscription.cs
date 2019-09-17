using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vitec.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan BillingFrequency { get; set; }
        public Product Product { get; set; }
    }
}
