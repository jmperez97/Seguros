namespace Seguros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PolizasXTipos
    {
        [Key]
        public int idPolizasXRiesgos { get; set; }

        public int? idPoliza { get; set; }

        public int? idTipoCubirmiento { get; set; }

        public virtual Poliza Poliza { get; set; }

        public virtual TipoCubrimiento TipoCubrimiento { get; set; }
    }
}
