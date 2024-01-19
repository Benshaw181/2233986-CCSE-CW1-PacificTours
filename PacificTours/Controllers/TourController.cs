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
    public class TourController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourController(TourDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Tour>>> GetAllTours()
        {
            var list = await _context.Tours.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tour>>> GetById(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            return Ok(tour);
        }

        [HttpPost]
        public async Task<ActionResult<List<Tour>>> AddBooking(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
            return await GetAllTours();
        }
    }
}
