using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Detail
    {
        public int AnnonceidAnnonce { get; set; }
        public int PeriodeLocationidPeriode { get; set; }
        public int Prix { get; set; }

        public virtual Annonce AnnonceidAnnonceNavigation { get; set; }
        public virtual PeriodeLocation PeriodeLocationidPeriodeNavigation { get; set; }
    }
}
