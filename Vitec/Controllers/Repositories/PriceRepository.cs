using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecData;
using VitecData.Models;

namespace Vitec.Controllers.Repositories
{
    public class PriceRepository
    {
        public List<Price> Prices { get; set; }

        public PriceRepository(string connectionString)
        {
            APICommunicationHelper.GetData(connectionString, out List<Price> tempPrices);
            Prices = tempPrices;
        }
    }
}
