using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRH_Test_V2.Data.Classes
{
    class Entretien
    {
        public int Identifiant;
        public DateTime Date;
        public string Responsable;
        public string HeureDeb;
        public string HeureFin;

        public SouhaitFormation souhaitFormation;
        public Evaluation evaluation;
        public Personne personne;
    }
}
