using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PacificTours.Models;

namespace PacificTours.Data
{
    public class HotelDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public HotelDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultDbConnection"));
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
