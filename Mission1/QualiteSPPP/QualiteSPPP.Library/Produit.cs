using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.Library
{
    public class Produit
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string PositionGD { get; set; }
        public string PositionAVAR { get; set; }
        public Piece piece { get; set; }
        public Peinture peinture { get; set; }

        #endregion

        #region Constructeurs
        public Produit()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
