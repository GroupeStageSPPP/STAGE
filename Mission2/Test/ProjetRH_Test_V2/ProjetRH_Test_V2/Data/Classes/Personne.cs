using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRH_Test_V2.Data.Classes
{
    class Personne
    {
        public int Identifiant;
        public string Nom;
        public string Prenom;
        public DateTime DateNais;
        public int CodePostal;
        public string Email;

        public Diplome diplome;
        public Poste poste;
        public Civilite civilite;
    }
}
