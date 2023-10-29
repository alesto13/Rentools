using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            CategorieAnnonce = new HashSet<CategorieAnnonce>();
        }

        public int IdCategorie { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategorieAnnonce> CategorieAnnonce { get; set; }
    }
}
