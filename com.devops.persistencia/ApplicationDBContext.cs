using com.devops.modelos;
using Microsoft.EntityFrameworkCore;

namespace com.devops.persistencia
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Usuario> DBUsuario { get; set; }
        public DbSet<Comuna> DBComuna { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Region> Region { get; set; }
        //public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        //public DbSet<Proveedor> Proveedores { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Rol> Roles { get; set; }
        //public DbSet<Permiso> Permisos { get; set; }
    }

}
