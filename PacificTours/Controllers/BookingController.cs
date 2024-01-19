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
    public class BookingController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingController(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Booking>>> GetAllBookings()
        {
            var list = await _context.Bookings.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Booking>>> GetById(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return Ok(booking);
        }

        [HttpGet("User/{userId}")]
        public ActionResult<List<Booking>> GetEntitiesByParameter(string userId)
        {
            IEnumerable<Booking> bookingItems = _context.Bookings.Where(b => b.BookingCustomerId == userId).ToList();

            List<Booking> bookingList = bookingItems.ToList();

            return Ok(bookingList);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking customerBooking)
        {
            _context.Bookings.Add(customerBooking);
            await _context.SaveChangesAsync();
            return Ok(customerBooking);
        }

        [HttpPost("Modify/")]
        public async Task<IActionResult> UpdateBooking(Booking updatedBooking)
        {
            _context.Entry(updatedBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Update Successful");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntity(int id, [FromBody] Booking updatedBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentBooking = _context.Bookings.Find(id);

            if (currentBooking == null)
            {
                return NotFound();
            }

            // Update price of existing booking
            var currentHotelcost = currentBooking.BookingPrice / (currentBooking.BookingEndDate - currentBooking.BookingStartDate).Days;
            currentBooking.BookingPrice = (currentHotelcost * (updatedBooking.BookingEndDate - updatedBooking.BookingStartDate).Days);
            
            //update date properties of existing booking
            currentBooking.BookingStartDate = updatedBooking.BookingStartDate;
            currentBooking.BookingEndDate = updatedBooking.BookingEndDate;
            // ... update other properties as needed

            try
            {
                // Save changes to the database
                _context.SaveChanges();
                return Ok(currentBooking);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues
                return Conflict();
            }
        }

        [HttpDelete("Delete/{bookingId}")]
        public async Task<ActionResult> DeleteFromBookings(int bookingId)
        {
            // additional if statement for if Bookings table is empty
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var dbItem = await _context.Bookings.FindAsync(bookingId);
            if (dbItem == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(dbItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
