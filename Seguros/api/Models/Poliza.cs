namespace api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Poliza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poliza()
        {
            PolizasXTipos = new HashSet<PolizasXTipos>();
        }

        [Key]
        public int idPoliza { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InicioVigencia { get; set; }

        public int? periodo { get; set; }

        public int? idRiesgo { get; set; }

        public virtual Riesgo Riesgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolizasXTipos> PolizasXTipos { get; set; }
    }
}
