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
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
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

        private void comboBoxAP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexChoisi = (string)comboBoxAP_1.SelectedItem;
            switch (indexChoisi)
            {
                case "Statistique" :
                    FillComboBoxes(comboBoxAP_2, new List<string>() { "Moyenne", "Maximum", "Minimum", "Compter" });
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
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Personnes", "Entretiens", "Hommes", "Femmes" });
                    break;
                case "Moyenne" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Âge", "Relation", "Qualité", "Assiduité" });
                    break;
                case "Minimum" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Âge", "Relation", "Qualité", "Assiduité" });
                    break;
                case "Maximum" :
                    FillComboBoxes(comboBoxAP_3, new List<string>() { "Âge", "Relation", "Qualité", "Assiduité" });
                    break;
                default:
                    break;
            }
        }

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
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Civilité" :
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list civilite
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Code postal" :
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list code postaux
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
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list libelle
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Date de début" :
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list dateDeb
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Date de fin" :
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list dateFin
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Responsable" :
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list responsable
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
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list diplome
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Niveau":
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list niveau
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
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list dates
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Responsable":
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list responsable
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Heure de début":
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list heure deb
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Heure de fin":
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list heure fin
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
                                    FillComboBoxes(comboBoxAS1_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Qualité":
                                    FillComboBoxes(comboBoxAS1_4, new List<string>() { "1", "2", "3", "4", "5" });
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Assiduité":
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
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list lieu
                                    buttonAjouterCondition2.Visible = true;
                                    break;
                                case "Avis":
                                    comboBoxAS1_4.Visible = true;
                                    comboBoxAS1_4.Items.Clear();
                                    //get list avisResponsable
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

        
    }
}
