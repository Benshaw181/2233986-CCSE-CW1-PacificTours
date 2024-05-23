using Microsoft.EntityFrameworkCore;
using PacificTours.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace PacificTours.Data
{
    public class BookingDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public BookingDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //base.OnConfiguring(options);
            options.UseSqlite(Configuration.GetConnectionString("DefaultDbConnection"));
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}