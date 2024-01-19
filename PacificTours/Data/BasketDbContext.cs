using Microsoft.EntityFrameworkCore;
using PacificTours.Models;

namespace PacificTours.Data
{
    public class BasketDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public BasketDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //base.OnConfiguring(options);
            options.UseSqlServer(Configuration.GetConnectionString("DefaultDbConnection"));
        }

        public DbSet<Basket> Baskets { get; set; }
    }
}