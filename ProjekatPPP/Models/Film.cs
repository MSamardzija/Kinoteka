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
        [StringLength(50, ErrorMessage = "Du�ina naziva mora biti najvi�e 50 karaktera.")]
        public string Naziv { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Du�ina imena Rezisera mo�e biti najvi�e 30 karaktera")]
        public string Reziser { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Du�ina naziva producije mo�e biti najvi�e 30 karaktera")]
        [Display(Name = "Produkcija")]
        public string Produkcija { get; set; }
    }
}
