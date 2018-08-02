namespace Seguros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [StringLength(50)]
        public string login { get; set; }

        public string password { get; set; }
    }
}
