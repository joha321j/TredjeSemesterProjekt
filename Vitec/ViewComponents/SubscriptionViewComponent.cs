using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vitec.Models;
using VitecData.Models;

namespace Vitec.ViewComponents
{
    public class SubscriptionViewComponent : ViewComponent
    {
        public SubscriptionViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(
            Product product,
            List<Subscription> subscriptions)
        {
            var productDetailsViewModel = new ProductDetailsViewModel
            {
                Product = product,
                Subscriptions = subscriptions,
            };

            return View(productDetailsViewModel);
        }
    }
}
