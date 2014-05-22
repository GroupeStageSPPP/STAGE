using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.Library
{
    public class Couche
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string Libelle { get; set; }
        public string TypeCouche { get; set; }
        public string DocRef { get; set; }
        public Fournisseur fournisseur { get; set; }
        #endregion

        #region Constructeurs
        public Couche()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
