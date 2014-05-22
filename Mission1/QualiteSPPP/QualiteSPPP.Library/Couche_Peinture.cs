using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.Library
{
    public class Couche_Peinture
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Moy { get; set; }
        public Couche couche { get; set; }
        public Peinture peinture { get; set; }
        #endregion

        #region Constructeurs
        public Couche_Peinture()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
