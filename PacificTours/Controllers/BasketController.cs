using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using PacificTours.Data;
using PacificTours.Models;
using System.Drawing.Text;

namespace PacificTours.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketDbContext _context;

        public BasketController(BasketDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Basket>>> GetAllBaskets()
        {
            var list = await _context.Baskets.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Basket>>> GetById(int id)
        {
            var basket = await _context.Baskets.FindAsync(id);
            return Ok(basket);
        }

        [HttpGet("User/{userId}")]
        public ActionResult<List<Basket>> GetEntitiesByParameter(string userId)
        {
            IEnumerable<Basket> basketItems = _context.Baskets.Where(b => b.CustomerId == userId).ToList();

            List<Basket> basketList = basketItems.ToList();

            return Ok(basketList);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> AddToBasket(Basket basketitem)
        {
            _context.Baskets.Add(basketitem);
            await _context.SaveChangesAsync();
            var newbasketitem = await _context.Baskets.FindAsync(basketitem.Id);
            return Ok(newbasketitem);
        }

        [HttpDelete("Delete/{basketItemId}")]
        public async Task<ActionResult> DeleteFromBasket(int basketItemId)
        {
            // additional if statement for if Baskets table is empty
            if (_context.Baskets == null)
            {
                return NotFound();
            }
            var dbItem = await _context.Baskets.FindAsync(basketItemId);
            if (dbItem == null)
            {
                return NotFound();
            }

            _context.Baskets.Remove(dbItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
