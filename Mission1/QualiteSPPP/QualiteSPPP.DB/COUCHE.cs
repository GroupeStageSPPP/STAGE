//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QualiteSPPP.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class COUCHE
    {
        public COUCHE()
        {
            this.COUCHE_PEINTURE = new HashSet<COUCHE_PEINTURE>();
        }
    
        public int Identifiant { get; set; }
        public string Libelle { get; set; }
        public string TypeCouche { get; set; }
        public string DocRef { get; set; }
        public Nullable<int> IdentifiantFournisseur { get; set; }
    
        public virtual FOURNISSEUR FOURNISSEUR { get; set; }
        public virtual ICollection<COUCHE_PEINTURE> COUCHE_PEINTURE { get; set; }
    }
}