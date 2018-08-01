namespace api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoCubrimientos")]
    public partial class TipoCubrimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoCubrimiento()
        {
            PolizasXTipos = new HashSet<PolizasXTipos>();
        }

        [Key]
        public int idTipoCubirmiento { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        public int porcentage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolizasXTipos> PolizasXTipos { get; set; }
    }
}
