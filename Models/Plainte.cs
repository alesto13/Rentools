using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Plainte
    {
        public int MembreidMembre { get; set; }
        public int AnnonceidAnnonce { get; set; }
        public DateTime DatePlainte { get; set; }
        public string DetailPlainte { get; set; }

        public virtual Annonce AnnonceidAnnonceNavigation { get; set; }
        public virtual Membre MembreidMembreNavigation { get; set; }
    }
}
