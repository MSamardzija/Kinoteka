using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjekatPPP.Models
{
    public class KinotekaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public KinotekaContext() : base("name=KinotekaContext")
        {
        }

        public System.Data.Entity.DbSet<ProjekatPPP.Models.Film> Films { get; set; }

        public System.Data.Entity.DbSet<ProjekatPPP.Models.Korisnik> Korisniks { get; set; }

        public System.Data.Entity.DbSet<ProjekatPPP.Models.IznajmljeneFilm> IznajmljeneFilms { get; set; }
    }
}
