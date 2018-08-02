namespace Seguros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientesXpoliza")]
    public partial class ClientesXpoliza
    {
        [Key]
        public int idUsuariosXpoliza { get; set; }

        public int? idPoliza { get; set; }

        public int? idCliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InicioVigencia { get; set; }

        public bool? estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Poliza Poliza { get; set; }
    }
}
