using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VitecData.Models;
using VitecData;
using VitecServices;

namespace Vitec.Controllers.Repositories
{
    public class ProductRepository
    {
        public List<Product> Products { get; set; }

        public ProductRepository(string connectionString)
        {
            APICommunicationHelper.GetData(connectionString, out List<Product> tempProducts);
            Products = tempProducts;
        }
    }
}
