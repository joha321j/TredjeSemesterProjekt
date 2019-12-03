using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPIVitec.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public int BillingFrequency { get; set; }
        public Product Product { get; set; }
    }
}
