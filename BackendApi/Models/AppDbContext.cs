using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //clases de Models con las tablas de SQL
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
        //public DbSet<Servicio> Servicios { get; set; }
        //public DbSet<Producto> Productos { get; set; }
    }
}