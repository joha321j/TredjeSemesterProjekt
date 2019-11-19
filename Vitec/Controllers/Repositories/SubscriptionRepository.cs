using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VitecData.Models;
using VitecData;

namespace Vitec.Controllers.Repositories
{
    public class SubscriptionRepository
    {
        public List<Subscription> Subscriptions { get; set; }

        public SubscriptionRepository(string connectionString)
        {
            APICommunicationHelper.GetData(connectionString, out List<Subscription> tempSubscriptions);
            Subscriptions = tempSubscriptions;
        }
    }
}
