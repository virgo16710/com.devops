using Microsoft.EntityFrameworkCore;

namespace com.devops.persistencia
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Producto> Productos { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        //public DbSet<Proveedor> Proveedores { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Rol> Roles { get; set; }
        //public DbSet<Permiso> Permisos { get; set; }
    }

}
