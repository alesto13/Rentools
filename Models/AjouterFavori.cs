using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class AjouterFavori
    {
        public int MembreidMembre { get; set; }
        public int AnnonceidAnnonce { get; set; }
        public DateTime DateAjouter { get; set; }

        public virtual Annonce AnnonceidAnnonceNavigation { get; set; }
        public virtual Membre MembreidMembreNavigation { get; set; }
    }
}
