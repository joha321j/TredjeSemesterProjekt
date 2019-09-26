using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vitec.Models;
using VitecData;
using VitecData.Models;

namespace Vitec.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly VitecContext _context;

        public ProductController(ILogger<ProductController> logger, VitecContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogDebug("User has accessed /Product/Index");

            var products = from p in _context.Products select p;

            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = await products.ToListAsync()
            };

            return View(productViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
