using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class PeriodeLocation
    {
        public PeriodeLocation()
        {
            Detail = new HashSet<Detail>();
        }

        public int IdPeriode { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Detail> Detail { get; set; }
    }
}
