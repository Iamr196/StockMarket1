using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StockMarket.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Stock> Stocks { get; set; }
    }
}
