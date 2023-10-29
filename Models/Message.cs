using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public DateTime DateContact { get; set; }
        public string DetailMessage { get; set; }
        public int MembreidMembreEnvoyer { get; set; }
        public int MembreidMembreRecevoir { get; set; }

        public virtual Membre MembreidMembreEnvoyerNavigation { get; set; }
        public virtual Membre MembreidMembreRecevoirNavigation { get; set; }
    }
}
