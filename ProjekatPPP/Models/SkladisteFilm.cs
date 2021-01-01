namespace ProjekatPPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkladisteFilm")]
    public partial class SkladisteFilm
    {
        [Key]
        [Column(Order = 0)]
        public int RedniBrojSkladista { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SifraFilma { get; set; }

        public int Stanje { get; set; }
    }
}
