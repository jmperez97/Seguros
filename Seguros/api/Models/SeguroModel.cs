namespace api.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SeguroModel : DbContext
	{
		public SeguroModel()
			: base("name=SeguroModel")
		{
		}

		public  DbSet<Poliza> Polizas { get; set; }
		public  DbSet<PolizasXTipos> PolizasXTipos { get; set; }
		public  DbSet<Riesgo> Riesgoes { get; set; }
		public  DbSet<TipoCubrimiento> TipoCubrimientos { get; set; }
		public  DbSet<usuario> usuarios { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Poliza>()
				.Property(e => e.nombre)
				.IsUnicode(false);

			modelBuilder.Entity<Poliza>()
				.Property(e => e.descripcion)
				.IsUnicode(false);

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
