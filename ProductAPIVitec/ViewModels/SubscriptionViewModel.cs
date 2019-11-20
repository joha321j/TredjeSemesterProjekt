using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPIVitec.Models;

namespace ProductAPIVitec.ViewModels
{
    public class SubscriptionViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public int BillingFrequency { get; set; }
        public Product Product { get; set; }
    }
}
