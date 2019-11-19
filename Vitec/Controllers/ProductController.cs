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
using Vitec.Controllers.Repositories;
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
        private readonly string _connectionString = "http://vitecapi.azurewebsites.net";
        private readonly ProductRepository _productRepository;
        private readonly SubscriptionRepository _subscriptionRepository;
        private readonly PriceRepository _priceRepository;

        public ProductController(ILogger<ProductController> logger, VitecContext context)
        {
            _logger = logger;
            _context = context;
            _productRepository = new ProductRepository(_connectionString+ "/api/products");
            _subscriptionRepository = new SubscriptionRepository(_connectionString + "/api/subscriptions");
            _priceRepository = new PriceRepository(_connectionString + "/api/prices");

        }

        public async Task<IActionResult> Index()
        {
            _logger.LogDebug("User has accessed /Product/Index");

            _productViewModel.Products = _productRepository.Products;

            return View(_productViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int Id) // TO DO: Make this actually work.
        {
            ProductDetailsViewModel productDetailsViewModel = new  ProductDetailsViewModel();

            productDetailsViewModel.Product = _productRepository.Products.FirstOrDefault(p => p.ID == Id);
            productDetailsViewModel.Subscriptions = _subscriptionRepository.Subscriptions.Where(s => s.ID == Id).ToList();


            return View(productDetailsViewModel);
        }
    }
}
