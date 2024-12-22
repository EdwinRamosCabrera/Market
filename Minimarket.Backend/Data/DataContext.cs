using Microsoft.EntityFrameworkCore;
using Minimarket.Shared.Entities;

namespace Minimarket.Backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ }

		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Producto> Productos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Venta> Ventas { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<DetalleVenta> DetalleVentas { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Categoria>().HasIndex(c => c.Nombre).IsUnique();
			modelBuilder.Entity<Producto>().HasIndex(p => p.codigo).IsUnique();
			modelBuilder.Entity<Usuario>().HasIndex(u => u.DNI).IsUnique();
		}
	}
}
