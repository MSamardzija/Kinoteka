namespace ProjekatPPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [Key]
        public int RedniBroj { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Email adresa može da sadrži najviše 30 karaktera")]
        [EmailAddress(ErrorMessage ="Email nije validan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Ime može da sadrži najviše 30 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Prezime može da sadrži najviše 30 karaktera")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Adresa može da sadrži najviše 30 karaktera")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Šifra može da sadrži najviše 30 karaktera")]
        [DataType(DataType.Password)]
        public string Šifra { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [DisplayName("Potvrda šifre")]
        [Compare("Šifra", ErrorMessage = "Šifre se ne poklapaju")]
        public string PotvrdaŠifre { get; set; }

        [StringLength(10)]
        public string TipKorisnika { get; set; }
    }
}
