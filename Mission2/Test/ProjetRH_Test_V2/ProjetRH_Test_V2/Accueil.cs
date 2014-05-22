using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetRH_Test_V2.Data.DB;

namespace ProjetRH_Test_V2
{
    public partial class Accueil : Form
    {
        #region DeclarationVariables

        private List<string> RequestRows;
        int RecupResultat; //si ordre "tout" => 2 ; sinon 1 (2 colonnes ou 1 seule)
        string ListBoxCible; //pour choisir quelle listbox affichera le résultat dans "ResultatRecherche"
        private int compteurTout; //compte le nb d'ordre "Tout" ; si > 2 => erreur

        private string TableSource;
        private string ButOrdre;

        private string TableCibleAS1; //ex : Civilite
        private string ChampCibleAS1; //ex : Libelle
        private string ValeurCibleAS1; //ex : Homme

        private string TableCibleAS2;
        private string ChampCibleAS2; 
        private string ValeurCibleAS2; 

        private string TableCibleAS3; 
        private string ChampCibleAS3; 
        private string ValeurCibleAS3;

        #endregion

        public Accueil()
        {
            InitializeComponent();

            #region InitialisationDesVariables

            RequestRows = new List<string>();
            RecupResultat = 0;
            ListBoxCible = "";
            compteurTout = 0;

            TableSource = "Personne";
            ButOrdre = "";

            TableCibleAS1 = "";
            ChampCibleAS1 = "";
            ValeurCibleAS1 = "";

            TableCibleAS2 = "";
            ChampCibleAS2 = "";
            ValeurCibleAS2 = "";

            TableCibleAS3 = "";
            ChampCibleAS3 = "";
            ValeurCibleAS3 = "";

            #endregion
        }

        //permet de vider une comboBox et de la rendre (ou non) visible
        private void CleanseComboBox(ComboBox comboBox, Boolean isVisible)
        {
            if (!isVisible)
            {
                comboBox.Visible = false;
            }
            else
            {
                comboBox.Visible = true;
            }
            comboBox.Items.Clear();
            comboBox.Text = "";
        }

        //permet de remplir une comboBox
        private void FillComboBoxes(ComboBox comboBox, List<string> listeCB)
        {
            CleanseComboBox(comboBox, true);

            foreach (string chaine in listeCB)
            {
                comboBox.Items.Add(chaine);
            }
        }

        #region ComboBoxes_AxePrincipal

        private void comboBoxAP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAP_1.SelectedItem;
            switch (indexChoisi)
            {
                case "Statistique" :
                    FillComboBoxes(comboBoxAP_2, new List<string>() { "Moyenne", "Maximum", "Minimum", "Compter" });
                    break;
                case "Personne" :
                    ButOrdre = "Personne.Identifiant";
                    break;
                case "Entretien" :
                    ButOrdre = "Entretien.Identifiant";
                    break;
                default:
                    CleanseComboBox(comboBoxAP_2, false);
                    break;
            }

            CleanseComboBox(comboBoxAP_3, false);
        }

        private void comboBoxAP_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAP_2.SelectedItem;
            switch (indexChoisi)
            {
                case "Compter" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Personnes", "Entretiens" });
                    ButOrdre = "count(";
                    break;
                case "Moyenne" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                    ButOrdre = "avg(";
                    break;
                case "Minimum" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                    ButOrdre = "min(";
                    break;
                case "Maximum" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                    ButOrdre = "max(";
                    break;
                default:
                    break;
            }
        }

        private void comboBoxAP_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAP_3.SelectedItem;
            switch (indexChoisi)
            {
                case "Personnes" :
                    ButOrdre += "Personne.Identifiant)";
                    break;
                case "Entretiens" :
                    ButOrdre += "Entretien.Identifiant)";
                    break;
                case "Relation" :
                    ButOrdre += "Evaluation.Relation)";
                    break;
                case "Qualité" :
                    ButOrdre += "Evaluation.Qualite)";
                    break;
                case "Assiduité" :
                    ButOrdre += "Evaluation.Assiduite)";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region ComboBoxes_AxeSecondaire_1

        private void comboBoxAS1_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAS1_1.SelectedItem;
            switch (indexChoisi)
            {
                case "Personne" :
                    FillComboBoxes(comboBoxAS1_2, new List<string>() { "Informations personnelles", "Poste", "Diplôme" });
                    break;
                case "Entretien" :
                    FillComboBoxes(comboBoxAS1_2, new List<string>() { "Informations diverses", "Evaluation", "Souhait de formation" });
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS1_3, false);
            CleanseComboBox(comboBoxAS1_4, false);
            textBoxAS1.Visible = false;
            buttonAjouterCondition2.Visible = false;
        }

        private void comboBoxAS1_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS1_1.SelectedItem;
            string indexChoisi = (string)comboBoxAS1_2.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexChoisi)
	                {
                        case "Informations personnelles":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Âge", "Civilité", "Code postal" });                
                            break;
                        case "Poste":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Libelle", "Date de début", "Date de fin", "Responsable" });
                            break;
                        case "Diplôme":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Libelle", "Niveau" });
                            break;
                        default:
                            break;
	                }
                    break;
                case "Entretien" :
                    switch (indexChoisi)
	                {
                        case "Informations diverses":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Date", "Responsable", "Heure de début", "Heure de fin" });
                            break;
                        case "Evaluation":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                            break;
                        case "Souhait de formation":
                            FillComboBoxes(comboBoxAS1_3, new List<string>() { "Lieu", "Avis" });
                            break;
                        default:
                            break;
	                }
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS1_4, false);
            textBoxAS1.Visible = false;
            buttonAjouterCondition2.Visible = false;
        }

        private void comboBoxAS1_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS1_1.SelectedItem;
            string indexSecond = (string)comboBoxAS1_2.SelectedItem;
            string indexChoisi = (string)comboBoxAS1_3.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexSecond)
                    {
                        case "Informations personnelles":
                            switch (indexChoisi)
	                        {
                                case "Âge" :
                                    textBoxAS1.Visible = true;
                                    textBoxAS1.Text = "";
                                    CleanseComboBox(comboBoxAS1_4, false);
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Civilité" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, CiviliteDB.GetListeLibelles());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Code postal" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, PersonneDB.GetListeCodesPostaux());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
	                        }
                            break;
                        case "Poste":
                            switch (indexChoisi)
                            {
                                case "Libelle" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, PosteDB.GetListeLibelles());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Date de début" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, PosteDB.GetListeDatesDeb());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Date de fin" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, PosteDB.GetListeDatesFin());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Responsable" :
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, PosteDB.GetListeResponsables());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Diplôme": 
                            switch (indexChoisi)
                            {
                                case "Libelle":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, DiplomeDB.GetListeLibelles());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Niveau":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, DiplomeDB.GetListeNiveaux());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "Entretien":
                    switch (indexSecond)
                    {
                        case "Informations diverses": 
                            switch (indexChoisi)
                            {
                                case "Date":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, EntretienDB.GetListeDates());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Responsable":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, EntretienDB.GetListeResponsables());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Heure de début":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, EntretienDB.GetListeHeuresDeb());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Heure de fin":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, EntretienDB.GetListeHeuresFin());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Evaluation":
                            switch (indexChoisi)
                            {
                                case "Relation":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Qualité":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Assiduité":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Souhait de formation": 
                            switch (indexChoisi)
                            {
                                case "Lieu":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, SouhaitFormationDB.GetListeLieux());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Avis":
                                    textBoxAS1.Visible = false;
                                    CleanseComboBox(comboBoxAS1_4, true);
                                    FillComboBoxes(comboBoxAS1_4, SouhaitFormationDB.GetListeAvisResponsable());
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonAjouterCondition2_Click(object sender, EventArgs e)
        {
            comboBoxAS2_1.Visible = true;
        }

        #endregion

        #region ComboBoxes_AxeSecondaire_2

        private void comboBoxAS2_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAS2_1.SelectedItem;
            switch (indexChoisi)
            {
                case "Personne":
                    FillComboBoxes(comboBoxAS2_2, new List<string>() { "Informations personnelles", "Poste", "Diplôme" });
                    break;
                case "Entretien":
                    FillComboBoxes(comboBoxAS2_2, new List<string>() { "Informations diverses", "Evaluation", "Souhait de formation" });
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS2_3, false);
            CleanseComboBox(comboBoxAS2_4, false);
            textBoxAS2.Visible = false;
            buttonAjouterCondition3.Visible = false;
        }

        private void comboBoxAS2_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS2_1.SelectedItem;
            string indexChoisi = (string)comboBoxAS2_2.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexChoisi)
                    {
                        case "Informations personnelles":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Âge", "Civilité", "Code postal" });
                            break;
                        case "Poste":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Libelle", "Date de début", "Date de fin", "Responsable" });
                            break;
                        case "Diplôme":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Libelle", "Niveau" });
                            break;
                        default:
                            break;
                    }
                    break;
                case "Entretien":
                    switch (indexChoisi)
                    {
                        case "Informations diverses":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Date", "Responsable", "Heure de début", "Heure de fin" });
                            break;
                        case "Evaluation":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                            break;
                        case "Souhait de formation":
                            FillComboBoxes(comboBoxAS2_3, new List<string>() { "Lieu", "Avis" });
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS2_4, false);
            textBoxAS2.Visible = false;
            buttonAjouterCondition3.Visible = false;
        }

        private void comboBoxAS2_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS2_1.SelectedItem;
            string indexSecond = (string)comboBoxAS2_2.SelectedItem;
            string indexChoisi = (string)comboBoxAS2_3.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexSecond)
                    {
                        case "Informations personnelles":
                            switch (indexChoisi)
                            {
                                case "Âge":
                                    textBoxAS2.Visible = true;
                                    textBoxAS2.Text = "";
                                    CleanseComboBox(comboBoxAS2_4, false);
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Civilité":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, CiviliteDB.GetListeLibelles());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Code postal":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, PersonneDB.GetListeCodesPostaux());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Poste":
                            switch (indexChoisi)
                            {
                                case "Libelle":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, PosteDB.GetListeLibelles());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Date de début":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, PosteDB.GetListeDatesDeb());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Date de fin":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, PosteDB.GetListeDatesFin());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Responsable":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, PosteDB.GetListeResponsables());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Diplôme":
                            switch (indexChoisi)
                            {
                                case "Libelle":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, DiplomeDB.GetListeLibelles());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Niveau":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, DiplomeDB.GetListeNiveaux());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "Entretien":
                    switch (indexSecond)
                    {
                        case "Informations diverses":
                            switch (indexChoisi)
                            {
                                case "Date":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, EntretienDB.GetListeDates());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Responsable":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, EntretienDB.GetListeResponsables());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Heure de début":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, EntretienDB.GetListeHeuresDeb());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Heure de fin":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, EntretienDB.GetListeHeuresFin());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Evaluation":
                            switch (indexChoisi)
                            {
                                case "Relation":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Qualité":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Assiduité":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Souhait de formation":
                            switch (indexChoisi)
                            {
                                case "Lieu":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, SouhaitFormationDB.GetListeLieux());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                case "Avis":
                                    textBoxAS2.Visible = false;
                                    CleanseComboBox(comboBoxAS2_4, true);
                                    FillComboBoxes(comboBoxAS2_4, SouhaitFormationDB.GetListeAvisResponsable());
                                    buttonAjouterCondition3.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonAjouterCondition3_Click(object sender, EventArgs e)
        {
            comboBoxAS3_1.Visible = true;
        }

        #endregion

        #region ComboBoxes_AxeSecondaire_3

        private void comboBoxAS3_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAS3_1.SelectedItem;
            switch (indexChoisi)
            {
                case "Personne":
                    FillComboBoxes(comboBoxAS3_2, new List<string>() { "Informations personnelles", "Poste", "Diplôme" });
                    break;
                case "Entretien":
                    FillComboBoxes(comboBoxAS3_2, new List<string>() { "Informations diverses", "Evaluation", "Souhait de formation" });
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS3_3, false);
            CleanseComboBox(comboBoxAS3_4, false);
            textBoxAS3.Visible = false;
            buttonAjouterCondition4.Visible = false;
        }

        private void comboBoxAS3_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS3_1.SelectedItem;
            string indexChoisi = (string)comboBoxAS3_2.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexChoisi)
                    {
                        case "Informations personnelles":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Âge", "Civilité", "Code postal" });
                            break;
                        case "Poste":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Libelle", "Date de début", "Date de fin", "Responsable" });
                            break;
                        case "Diplôme":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Libelle", "Niveau" });
                            break;
                        default:
                            break;
                    }
                    break;
                case "Entretien":
                    switch (indexChoisi)
                    {
                        case "Informations diverses":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Date", "Responsable", "Heure de début", "Heure de fin" });
                            break;
                        case "Evaluation":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Relation", "Qualité", "Assiduité" });
                            break;
                        case "Souhait de formation":
                            FillComboBoxes(comboBoxAS3_3, new List<string>() { "Lieu", "Avis" });
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            CleanseComboBox(comboBoxAS3_4, false);
            textBoxAS3.Visible = false;
            buttonAjouterCondition4.Visible = false;
        }

        private void comboBoxAS3_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexPremier = (string)comboBoxAS3_1.SelectedItem;
            string indexSecond = (string)comboBoxAS3_2.SelectedItem;
            string indexChoisi = (string)comboBoxAS3_3.SelectedItem;

            switch (indexPremier)
            {
                case "Personne":
                    switch (indexSecond)
                    {
                        case "Informations personnelles":
                            switch (indexChoisi)
                            {
                                case "Âge":
                                    textBoxAS3.Visible = true;
                                    textBoxAS3.Text = "";
                                    CleanseComboBox(comboBoxAS3_4, false);
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Civilité":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, CiviliteDB.GetListeLibelles());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Code postal":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, PersonneDB.GetListeCodesPostaux());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Poste":
                            switch (indexChoisi)
                            {
                                case "Libelle":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, PosteDB.GetListeLibelles());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Date de début":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, PosteDB.GetListeDatesDeb());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Date de fin":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, PosteDB.GetListeDatesFin());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Responsable":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, PosteDB.GetListeResponsables());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Diplôme":
                            switch (indexChoisi)
                            {
                                case "Libelle":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, DiplomeDB.GetListeLibelles());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Niveau":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, DiplomeDB.GetListeNiveaux());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "Entretien":
                    switch (indexSecond)
                    {
                        case "Informations diverses":
                            switch (indexChoisi)
                            {
                                case "Date":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, EntretienDB.GetListeDates());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Responsable":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, EntretienDB.GetListeResponsables());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Heure de début":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, EntretienDB.GetListeHeuresDeb());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Heure de fin":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, EntretienDB.GetListeHeuresFin());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Evaluation":
                            switch (indexChoisi)
                            {
                                case "Relation":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Qualité":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Assiduité":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Souhait de formation":
                            switch (indexChoisi)
                            {
                                case "Lieu":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, SouhaitFormationDB.GetListeLieux());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                case "Avis":
                                    textBoxAS3.Visible = false;
                                    CleanseComboBox(comboBoxAS3_4, true);
                                    FillComboBoxes(comboBoxAS3_4, SouhaitFormationDB.GetListeAvisResponsable());
                                    buttonAjouterCondition4.Visible = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonAjouterCondition4_Click(object sender, EventArgs e)
        {
            //à implémenter plus tard
        }

        #endregion

        private void buttonLancerRecherche_Click(object sender, EventArgs e)
        {
            //vérifie si l'axe principal est renseigné
            if (comboBoxAP_1.Text != "")
            {
                //s'il s'agit de "Satistique", vérifie si les champs suivants (2 et 3) sont renseignés
                if (comboBoxAP_1.Text == "Statistique")
                {
                    if (comboBoxAP_2.Text != "" && comboBoxAP_3.Text != "")
                    {
                        //AP.Add(comboBoxAP_1.Text);
                        //AP.Add(comboBoxAP_2.Text);
                        //AP.Add(comboBoxAP_3.Text);

                        //vérifie si au moins le premier axe secondaire est renseigné
                        if (comboBoxAS1_1.Text != "" &&
                            comboBoxAS1_2.Text != "" &&
                            comboBoxAS1_3.Text != "" &&
                            (comboBoxAS1_4.Text != "" || textBoxAS1.Text != ""))
                        {
                            //AS1.Add(comboBoxAS1_1.Text);
                            //AS1.Add(comboBoxAS1_2.Text);
                            //AS1.Add(comboBoxAS1_3.Text);
                            if (comboBoxAS1_4.Visible)
                            {
                                //AS1.Add(comboBoxAS1_4.Text);   
                            }
                            else
                            {
                                //AS1.Add(textBoxAS1.Text);
                            }

                            //vérifie le second axe secondaire
                            if (comboBoxAS2_1.Text != "" &&
                            comboBoxAS2_2.Text != "" &&
                            comboBoxAS2_3.Text != "" &&
                            (comboBoxAS2_4.Text != "" || textBoxAS2.Text != ""))
                            {
                                //AS2.Add(comboBoxAS2_1.Text);
                                //AS2.Add(comboBoxAS2_2.Text);
                                //AS2.Add(comboBoxAS2_3.Text);
                                if (comboBoxAS2_4.Visible)
                                {
                                    //AS2.Add(comboBoxAS2_4.Text);
                                }
                                else
                                {
                                    //AS2.Add(textBoxAS2.Text);
                                }

                                //vérifie le 3eme axe secondaire
                                if (comboBoxAS3_1.Text != "" &&
                                comboBoxAS3_2.Text != "" &&
                                comboBoxAS3_3.Text != "" &&
                                (comboBoxAS3_4.Text != "" || textBoxAS2.Text != ""))
                                {
                                    //AS3.Add(comboBoxAS3_1.Text);
                                    //AS3.Add(comboBoxAS3_2.Text);
                                    //AS3.Add(comboBoxAS3_3.Text);
                                    if (comboBoxAS3_4.Visible)
                                    {
                                        //AS3.Add(comboBoxAS3_4.Text);
                                    }
                                    else
                                    {
                                        //AS3.Add(textBoxAS3.Text);
                                    }

                                    LaunchRequest("AS3");
                                }
                                else
                                {
                                    //si l'AS3 n'est pas valide, on s'en préoccupe pas
                                    LaunchRequest("AS2");
                                }
                            }
                            else
                            {
                                //si l'AS2 n'est pas valide, on ne s'en occupe pas
                                LaunchRequest("AS1");
                            }                         
                        }
                        else
                        {
                            MessageBox.Show("Premier axe secondaire non renseigné.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Axe principal non renseigné.");
                    }
                }
                else //sinon l'AP est "Personne" ou "Entretien"
                {
                    //AP.Add(comboBoxAP_1.Text);
                    //vérifie si au moins le premier axe secondaire est renseigné
                    if (comboBoxAS1_1.Text != "" &&
                        comboBoxAS1_2.Text != "" &&
                        comboBoxAS1_3.Text != "" &&
                        (comboBoxAS1_4.Text != "" || textBoxAS1.Text != ""))
                    {
                        //AS1.Add(comboBoxAS1_1.Text);
                        //AS1.Add(comboBoxAS1_2.Text);
                        //AS1.Add(comboBoxAS1_3.Text);
                        if (comboBoxAS1_4.Visible)
                        {
                            //AS1.Add(comboBoxAS1_4.Text);
                        }
                        else
                        {
                            //AS1.Add(textBoxAS1.Text);
                        }
                        
                        //vérifie le second axe secondaire
                        if (comboBoxAS2_1.Text != "" &&
                        comboBoxAS2_2.Text != "" &&
                        comboBoxAS2_3.Text != "" &&
                        (comboBoxAS2_4.Text != "" || textBoxAS2.Text != ""))
                        {
                            //AS2.Add(comboBoxAS2_1.Text);
                            //AS2.Add(comboBoxAS2_2.Text);
                            //AS2.Add(comboBoxAS2_3.Text);
                            if (comboBoxAS2_4.Visible)
                            {
                                //AS2.Add(comboBoxAS2_4.Text);
                            }
                            else
                            {
                                //AS2.Add(textBoxAS2.Text);
                            }

                            //vérifie le 3eme axe secondaire
                            if (comboBoxAS3_1.Text != "" &&
                            comboBoxAS3_2.Text != "" &&
                            comboBoxAS3_3.Text != "" &&
                            (comboBoxAS3_4.Text != "" || textBoxAS2.Text != ""))
                            {
                                //AS3.Add(comboBoxAS3_1.Text);
                                //AS3.Add(comboBoxAS3_2.Text);
                                //AS3.Add(comboBoxAS3_3.Text);
                                if (comboBoxAS3_4.Visible)
                                {
                                    //AS3.Add(comboBoxAS3_4.Text);
                                }
                                else
                                {
                                    //AS3.Add(textBoxAS3.Text);
                                }

                                LaunchRequest("AS3");
                            }
                            else
                            {
                                //si l'AS3 n'est pas valide, on s'en préoccupe pas
                                LaunchRequest("AS2");
                            }
                        }
                        else
                        {
                            //si l'AS2 n'est pas valide, on ne s'en occupe pas
                            LaunchRequest("AS1");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Premier axe secondaire non renseigné.");
                    }
                } 
            }
            else
            {
                MessageBox.Show("Axe principal non renseigné.");
            }    

            
        }

        private void LaunchRequest(string a)
        {
            //juste en attendant
        }

        #region ComboBoxes_ASX_4

        private void comboBoxAS1_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAS1_4.Text == "Tout")
            {
                compteurTout++;
                if (compteurTout > 1)
                {
                    comboBoxAS1_4.Text = "";
                    comboBoxAS1_4.SelectedIndex = 0;
                    MessageBox.Show("Erreur : un seul \"Tout\" peut être choisi");
                }
            }
        }

        private void comboBoxAS2_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAS2_4.Text == "Tout")
            {
                compteurTout++;
                if (compteurTout > 1)
                {
                    comboBoxAS2_4.Text = "";
                    comboBoxAS2_4.SelectedIndex = 0;
                    MessageBox.Show("Erreur : un seul \"Tout\" peut être choisi");
                }
            }
        }

        private void comboBoxAS3_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAS3_4.Text == "Tout")
            {
                compteurTout++;
                if (compteurTout > 1)
                {
                    comboBoxAS3_4.Text = "";
                    comboBoxAS3_4.SelectedIndex = 0;
                    MessageBox.Show("Erreur : un seul \"Tout\" peut être choisi");
                }
            }
        }

        #endregion


    }
}
