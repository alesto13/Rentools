using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Annonce
    {
        public Annonce()
        {
            AjouterFavori = new HashSet<AjouterFavori>();
            CategorieAnnonce = new HashSet<CategorieAnnonce>();
            Detail = new HashSet<Detail>();
            Plainte = new HashSet<Plainte>();
        }

        public int IdAnnonce { get; set; }
        public int MembreidMembre { get; set; }
        public string Emplacement { get; set; }

        public virtual Membre MembreidMembreNavigation { get; set; }
        public virtual ICollection<AjouterFavori> AjouterFavori { get; set; }
        public virtual ICollection<CategorieAnnonce> CategorieAnnonce { get; set; }
        public virtual ICollection<Detail> Detail { get; set; }
        public virtual ICollection<Plainte> Plainte { get; set; }
    }
}
