using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.Library
{
    public class Piece
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string Libelle { get; set; }
        public Client client { get; set; }
        public Vehicule vehicule { get; set; }
        public TypeP type { get; set; }

        #endregion

        #region Constructeurs
        public Piece()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
