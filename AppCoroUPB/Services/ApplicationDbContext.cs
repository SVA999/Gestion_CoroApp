using AppCoroUPB.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCoroUPB.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ensayo> Ensayos { get; set; } = null!;
		public DbSet<LugarEnsayo> LugaresEnsayo { get; set; }

        public DbSet<Integrante> Integrantes { get; set; } = null!;

	}

}
