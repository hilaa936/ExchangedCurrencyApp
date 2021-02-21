using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Currency> CurrencyExchange { get; set; }
    }
}