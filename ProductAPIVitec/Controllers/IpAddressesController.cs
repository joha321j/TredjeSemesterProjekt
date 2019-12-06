using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIVitec.Models;

namespace ProductAPIVitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpAddressesController : ControllerBase
    {
        private readonly ProductAPIVitecContext _context;

        public IpAddressesController(ProductAPIVitecContext context)
        {
            _context = context;
        }

        // GET: api/IpAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpAddress>>> GetIpAddress()
        {
            return await _context.IpAddress.ToListAsync();
        }

        // GET: api/IpAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpAddress>> GetIpAddress(int id)
        {
            var ipAddress = await _context.IpAddress.FindAsync(id);

            if (ipAddress == null)
            {
                return NotFound();
            }

            return ipAddress;
        }

        // PUT: api/IpAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpAddress(int id, IpAddress ipAddress)
        {
            if (id != ipAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IpAddresses
        [HttpPost]
        public async Task<ActionResult<IpAddress>> PostIpAddress(IpAddress ipAddress)
        {
            _context.IpAddress.Add(ipAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpAddress", new { id = ipAddress.Id }, ipAddress);
        }

        // DELETE: api/IpAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpAddress>> DeleteIpAddress(int id)
        {
            var ipAddress = await _context.IpAddress.FindAsync(id);
            if (ipAddress == null)
            {
                return NotFound();
            }

            _context.IpAddress.Remove(ipAddress);
            await _context.SaveChangesAsync();

            return ipAddress;
        }

        private bool IpAddressExists(int id)
        {
            return _context.IpAddress.Any(e => e.Id == id);
        }
    }
}
