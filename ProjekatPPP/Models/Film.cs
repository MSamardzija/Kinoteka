namespace ProjekatPPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [Key]
        public int SifraFilma { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Dužina naziva mora biti najviše 50 karaktera.")]
        public string Naziv { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Dužina imena Rezisera može biti najviše 30 karaktera")]
        public string Reziser { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Dužina naziva producije može biti najviše 30 karaktera")]
        [Display(Name = "Produkcija")]
        public string Produkcija { get; set; }
    }
}
