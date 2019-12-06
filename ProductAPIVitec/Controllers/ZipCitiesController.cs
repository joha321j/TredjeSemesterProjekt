using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIVitec.Models;

namespace ProductAPIVitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCitiesController : ControllerBase
    {
        private readonly ProductAPIVitecContext _context;

        public ZipCitiesController(ProductAPIVitecContext context)
        {
            _context = context;
        }

        // GET: api/ZipCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZipCity>>> GetZipCities()
        {
            /*var range = await UpdateZips();
            foreach (ZipCity city in range)
            {
                if (!_context.ZipCities.Any(c => c.Zip == city.Zip))
                {
                    _context.ZipCities.Add(city);
                    await _context.SaveChangesAsync();
                }
            }*/
            
            return await _context.ZipCities.ToListAsync();
        }

        private async Task<IEnumerable<ZipCity>> UpdateZips()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = new List<ZipCity>();
                var response = await client.GetAsync("http://skilsmis.se/img/zips.csv");
                var message = await response.Content.ReadAsStringAsync();

                var rows = message.Split("\r\n");

                for (int i = 2; i < rows.Length - 2; i++)
                {
                    var field = rows[i].Split(";");
                    int.TryParse(field[0], out int zip);

                    result.Add(new ZipCity
                    {
                        Zip = zip,
                        CityName = field[1]
                    });
                }

                return result;
            }
        }
    }
}
