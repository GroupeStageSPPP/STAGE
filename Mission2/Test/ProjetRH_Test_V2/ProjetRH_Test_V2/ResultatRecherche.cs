using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetRH_Test_V2
{
    public partial class ResultatRecherche : Form
    {
        public ResultatRecherche()
        {
            InitializeComponent();
        }

        private void ResultatRecherche_Load(object sender, EventArgs e)
        {
            //test du passage des strings => fonctionne parfaitement
            //TestPassageRequest test = new TestPassageRequest(_ReqAP, _ReqAS1, _ReqAS2, _ReqAS3);
            //test.ShowDialog();

            //chargement des listBoxes à faire


            //exemple de requête
//            select Personne.Identifiant
//from Personne
//where Identifiant in 
//    (
//    select Personne.Identifiant--, Civilite.Libelle
//    from Personne
//    inner join Civilite
//    on Civilite.Identifiant = Personne.ID_Civilite
//    where Civilite.Libelle = 'Femme'
//    )
//and Identifiant in 
//    (
//    select Entretien.ID_Personne
//    from Entretien_NN_SouhaitFormation
//    inner join Entretien
//    on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
//    inner join SouhaitFormation
//    on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
//    where SouhaitFormation.Lieu = 'Nogent le Rotrou'
//    )
//and Identifiant in 
//    (
//    select ID_Personne
//    from Personne_NN_Diplome 
//    inner join Diplome 
//    on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
//    inner join Personne
//    on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
//    where Diplome.Niveau = 'I' 
//    )
        }
    }
}
