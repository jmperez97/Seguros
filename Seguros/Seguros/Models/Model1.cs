namespace Seguros.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=ModelSeguros")
		{
		}

		public virtual DbSet<Cliente> Clientes { get; set; }
		public virtual DbSet<ClientesXpoliza> ClientesXpolizas { get; set; }
		public virtual DbSet<Poliza> Polizas { get; set; }
		public virtual DbSet<PolizasXTipos> PolizasXTipos { get; set; }
		public virtual DbSet<Riesgo> Riesgoes { get; set; }
		public virtual DbSet<TipoCubrimiento> TipoCubrimientos { get; set; }
		public virtual DbSet<usuario> usuarios { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cliente>()
				.Property(e => e.Nombre)
				.IsUnicode(false);

			modelBuilder.Entity<Cliente>()
				.Property(e => e.Cedula)
				.IsUnicode(false);

			modelBuilder.Entity<Cliente>()
				.Property(e => e.Telefono)
				.IsUnicode(false);

			modelBuilder.Entity<Poliza>()
				.Property(e => e.nombre)
				.IsUnicode(false);

			modelBuilder.Entity<Poliza>()
				.Property(e => e.descripcion)
				.IsUnicode(false);

			modelBuilder.Entity<Poliza>()
				.Property(e => e.precio)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Riesgo>()
				.Property(e => e.nivel)
				.IsUnicode(false);

			modelBuilder.Entity<TipoCubrimiento>()
				.Property(e => e.tipo)
				.IsUnicode(false);

			modelBuilder.Entity<usuario>()
				.Property(e => e.login)
				.IsUnicode(false);

			modelBuilder.Entity<usuario>()
				.Property(e => e.password)
				.IsUnicode(false);
		}
	}
}
