using Microsoft.EntityFrameworkCore;
using PacificTours.Models;

namespace PacificTours.Data
{
    public class TourDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TourDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultDbConnection"));
        }

        public DbSet<Tour> Tours { get; set; }
    }
}
