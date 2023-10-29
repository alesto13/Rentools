using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class CategorieAnnonce
    {
        public int CategorieidCategorie { get; set; }
        public int AnnonceidAnnonce { get; set; }

        public virtual Annonce AnnonceidAnnonceNavigation { get; set; }
        public virtual Categorie CategorieidCategorieNavigation { get; set; }
    }
}
