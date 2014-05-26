﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntretienSPPP.library
{
    public class Evaluation
    {
        #region Attributs
        #endregion

        #region Propriétés
        public int Identifiant { get; set; }
        public Int16 Relation { get; set; }
        public Int16 Qualite { get; set; }
        public Int16 Realisation { get; set; }
        public Int16 Polyvalence { get; set; }
        public Int16 Assiduite { get; set; }
        public Int16 Motivation { get; set; }
        public Int16 Autonomie { get; set; }
        public Int16 RespectConsigne { get; set; }
        public string Commentaire { get; set; }


        #endregion

        #region Constructeurs
        public Evaluation()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
