namespace Seguros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            ClientesXpolizas = new HashSet<ClientesXpoliza>();
        }

        [Key]
        public int idCliente { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(12)]
        public string Cedula { get; set; }

        [StringLength(13)]
        public string Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientesXpoliza> ClientesXpolizas { get; set; }
    }
}
