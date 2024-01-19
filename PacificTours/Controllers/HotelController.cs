using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using PacificTours.Data;
using PacificTours.Models;
using System.Drawing.Text;

namespace PacificTours.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public HotelController(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Hotel>>> GetAllHotels()
        {
            var list = await _context.Hotels.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Hotel>>> GetById(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<List<Hotel>>> AddBooking(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return await GetAllHotels();
        }
    }
}
