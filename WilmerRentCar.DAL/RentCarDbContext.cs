using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilmerRentCar.BOL;

namespace WilmerRentCar.DAL
{
    public class RentCarDbContext : DbContext
    {
        public RentCarDbContext() : base("RentCarWeb") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<RentaDevolucion> RentaDevolucion { get; set; }
        public DbSet<Vehículo> Vehículo { get; set; }



    }
}
