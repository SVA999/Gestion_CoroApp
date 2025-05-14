using AppCoroUPB.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCoroUPB.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Tablas Principales
        public DbSet<Ensayo> Ensayos { get; set; } = null!;

        public DbSet<Integrante> Integrantes { get; set; } = null!;

        //Tablas Auxiliares
        public DbSet<LugarEnsayo> LugaresEnsayo { get; set; }
        public DbSet<TipoVinculo> TipoVinculo { get; set; }
        public DbSet<Carrera_Dependencia> Carrera_Dependencia { get; set; }
        public DbSet<ClasificacionVoz> ClasificacionVoz { get; set; }
        public DbSet<EstadoInt> Estados { get; set; }

    }

}
