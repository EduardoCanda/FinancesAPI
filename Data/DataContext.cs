using FinancesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Finance> Finances { get; set; }
    }
}