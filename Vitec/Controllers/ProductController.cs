using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vitec.Models;
using VitecData;
using VitecData.Models;

namespace Vitec.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly VitecContext _context;
        private readonly ProductViewModel _productViewModel = new ProductViewModel();
        private readonly string _connectionString = "http://vitecapi.azurewebsites.net/";

        public ProductController(ILogger<ProductController> logger, VitecContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogDebug("User has accessed /Product/Index");

            InitializeApi();

            return View(_productViewModel);
        }

        private void InitializeApi()
        {
            string data;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_connectionString + "api/products");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                data = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<List<Product>>(data);

            _productViewModel.Products = model;
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
