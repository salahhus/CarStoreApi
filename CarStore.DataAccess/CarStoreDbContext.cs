using CarStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarStore.DataAccess
{
    public class CarStoreDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CarStoreDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
        }

        public DbSet<CarEntity> Cars { get; set; }
    }
}
