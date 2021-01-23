using Microsoft.EntityFrameworkCore;
using QueryApp.Models;

namespace QueryApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
    }
}