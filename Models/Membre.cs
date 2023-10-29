using System;
using System.Collections.Generic;

namespace Rentools.Models
{
    public partial class Membre
    {
        public Membre()
        {
            AjouterFavori = new HashSet<AjouterFavori>();
            Annonce = new HashSet<Annonce>();
            MessageMembreidMembreEnvoyerNavigation = new HashSet<Message>();
            MessageMembreidMembreRecevoirNavigation = new HashSet<Message>();
            Plainte = new HashSet<Plainte>();
        }

        public int IdMembre { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int? Telephone { get; set; }
        public string Email { get; set; }
        public bool EstActive { get; set; }

        public virtual ICollection<AjouterFavori> AjouterFavori { get; set; }
        public virtual ICollection<Annonce> Annonce { get; set; }
        public virtual ICollection<Message> MessageMembreidMembreEnvoyerNavigation { get; set; }
        public virtual ICollection<Message> MessageMembreidMembreRecevoirNavigation { get; set; }
        public virtual ICollection<Plainte> Plainte { get; set; }
    }
}
