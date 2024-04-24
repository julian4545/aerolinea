using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.dbcontext
{
    public class AgriversoDbcontext: DbContext
    {
        public AgriversoDbcontext(DbContextOptions<AgriversoDbcontext> options) : base(options)
        {
        }
        public DbSet<Asiento> Asiento { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Pasajero> Pasajero { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Tripulacion> Tripulacion { get; set; }
        public DbSet<Vuelo> Vuelo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // para crear relaciones posiblemente no se implementa 
            //modelBuilder.Entity<Crew>().HasKey(e => e.Id);
            //nodelBuilder.Entity<Crew>().Haskey(e = e.UserTypeld);

        }





    }
}
