using Microsoft.EntityFrameworkCore;
using Tareas.Models;

namespace Tareas
{
    public class ConectionModels : DbContext
    {
        public ConectionModels(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Seller> seller { get; set; }
        public DbSet<City> city { get; set; }
    }
}
