using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIVitec.Models;
using ProductAPIVitec.ViewModels;

namespace ProductAPIVitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ProductAPIVitecContext _context;

        // GET: api/Subscriptions/
        public SubscriptionsController(ProductAPIVitecContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscription()
        {
            return await _context.Subscription.Include(subscription => subscription.Price).Include(subscription => subscription.Product).ToListAsync();
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            var subscription = await _context.Subscription.FindAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return subscription;
        }

        // PUT: api/Subscriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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

        // POST: api/Subscriptions
        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {
            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscription", new { id = subscription.Id }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subscription>> DeleteSubscription(int id)
        {
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscription.Remove(subscription);
            await _context.SaveChangesAsync();

            return subscription;
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscription.Any(e => e.Id == id);
        }
    }
}
