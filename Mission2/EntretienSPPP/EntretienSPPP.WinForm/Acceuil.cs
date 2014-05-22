using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntretienSPPP.DB;
using EntretienSPPP.library;



namespace EntretienSPPP.WinForm
{
    public partial class Acceuil : Form
    {
        public Identification Status { get; set; }

        public Acceuil(Identification entreUtilisateur)
        {
            InitializeComponent();

            Status = new Identification();

            Status.AdminAcess = entreUtilisateur.AdminAcess;
            Status.Identifiant = entreUtilisateur.Identifiant;
            Status.Status = entreUtilisateur.Status;

            if (Status.AdminAcess == true)
            {
                administrationToolStripMenuItem.Enabled = true;
            }
            else
            {
                administrationToolStripMenuItem.Enabled = false;
            }
        }
        private void Acceuil_Load(object sender, EventArgs e)
        {
            ouvrirEcran("Acceuil");
        }

        #region Fonctions
            private void ouvrirEcran(string nonEcran)
            {
                //Ajouter un employe
                if (nonEcran == "Ajouter_un_employe")
                {
                    panelAjoutemploye.Visible = true;
                }
                else
                {
                    panelAjoutemploye.Visible = false;
                }
                //Ajouter un poste
                if (nonEcran == "Ajouter_un_poste")
                {
                    panelAjoutPoste.Visible = true;
                }
                else
                {
                    panelAjoutPoste.Visible = false;
                }
                //Ajouter une formation
                if (nonEcran == "Ajouter_une_formation")
                {
                    panelAjoutFormation.Visible = true;
                }
                else
                {
                    panelAjoutFormation.Visible = false;
                }
                //Acceuil
                if (nonEcran == "Acceuil")
                {
                    panelAcceuil.Visible = true;
                }
                else
                {
                    panelAcceuil.Visible = false;
                }
                //Nouvel entretien
                if (nonEcran == "Nouvel_Entretien")
                {
                    panelNouvelEntretien.Visible = true;
                }
                else
                {
                    panelNouvelEntretien.Visible = false;
                }
            }
        #endregion

        #region ToolStripMenu
        //Couleur ToolStripMenuItem
            private void optionToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
            {
                optionToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            }
            private void optionToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
            {
                optionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            }
            private void administrationToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
            {
                administrationToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            }
            private void administrationToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
            {
                administrationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            }
            private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
            {
                toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            }
            private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
            {
                toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            }
            private void entretienToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
            {
                entretienToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            }
            private void entretienToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
            {
                entretienToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            }

        //Fonction de navigation : ToolStripMenuItem
            private void employésToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Ajouter_un_employe
                ouvrirEcran("Ajouter_un_employe");
            }
            private void formationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Ajouter_une_formation
                ouvrirEcran("Ajouter_une_formation");
            }
            private void posteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Ajouter_un_poste
                ouvrirEcran("Ajouter_un_poste");
            }
            private void toolStripMenuItem2_Click(object sender, EventArgs e)
            {
                //  --> OPTION/Acceuil
                ouvrirEcran("Acceuil");
            }
            private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ENTRETIEN/Nouveau
                ouvrirEcran("Nouvel_Entretien");
            }
        #endregion

        #region Fonction de l'onglet : ENTRETIEN

        #endregion

        #region Fonction de l'onglet : RECHERCHE

        #endregion

        #region Fonction de l'onglet : ADMINISTRATION
            #region Employé
            #region ChargementPAge
            private void ChargementTermine(object sender, EventArgs e)
            {
                //this.RefreshListeBoxHabilite();
                //this.RefreshListBoxAncienEmploi();
                //this.RefreshListeDiplomePersonne();
                //this.RefreshLanguePersonne();
                //this.RefreshInaptitudePersonne();
                //this.RefreshPosteActuel();
                //this.refreshCompetencePersonne();
            }

            #endregion
            #region RafraichissementListBox
            private void RefreshListeBoxHabilite()
            {
                List<Habilite_Personne> listHabilitePersonne = Habilite_PersonneDB.List();

                this.listBoxHabilite.DataSource = listHabilitePersonne;
                this.listBoxHabilite.DisplayMember = "habilite";
                this.listBoxHabilite.DisplayMember = "organisme";
                this.listBoxHabilite.ValueMember = "Identifiant";

            }

            private void RefreshListBoxAncienEmploi()
            {
                List<CV> listAncienEmploi = CVDB.List();
                this.listBoxAcienEmplois.DataSource = listAncienEmploi;
                this.listBoxAcienEmplois.DisplayMember = "Entreprise";
                this.listBoxAcienEmplois.DisplayMember = "Poste";
                this.listBoxAcienEmplois.ValueMember = "Identifiant";
            }

            private void RefreshListeDiplomePersonne()
            {
                List<Diplome_Personne> ListDIplomePersonne = Diplome_PersonneDB.List();
                this.listBoxDiplomes.DataSource = ListDIplomePersonne;
                this.listBoxDiplomes.DisplayMember = "diplome";
                this.listBoxDiplomes.DisplayMember = "DateObtention";
                this.listBoxDiplomes.ValueMember = "Identifiant";
            }

            private void RefreshLanguePersonne()
            {
                List<Langue_Personne> listLanguePersonne = Langue_PersonneDB.List();
                this.listBoxLangue.DataSource = listLanguePersonne;
                this.listBoxLangue.DisplayMember = "langue";
                this.listBoxLangue.DisplayMember = "niveau";
                this.listBoxLangue.ValueMember = "Identifiant";
            }

            private void RefreshInaptitudePersonne()
            {
                List<Inaptitude_Personne> listInaptitudePersonne = Inaptitude_PersonneDB.List();
                this.listBoxInaptitude.DataSource = listInaptitudePersonne;
                this.listBoxInaptitude.DisplayMember = "inaptitude";
                this.listBoxInaptitude.DisplayMember = "Definitif";
                this.listBoxInaptitude.DisplayMember = "DateFin";
                this.listBoxInaptitude.ValueMember = "Identifiant";
            }

            private void RefreshPosteActuel()
            {
                List<Poste_Personne> ListPostePersonne = Poste_PersonneDB.List();
                this.listBoxPosteActuel.DataSource = ListPostePersonne;
                this.listBoxPosteActuel.DisplayMember = "Contrat";
                this.listBoxPosteActuel.DisplayMember = "poste";
                this.listBoxPosteActuel.DisplayMember = "Coefficient";
                this.listBoxPosteActuel.DisplayMember = "site";
                this.listBoxPosteActuel.ValueMember = "Identifiant";
            }

            private void refreshCompetencePersonne()
            {
                List<Competence> competencePersonne = CompetenceDB.List();
                this.listBoxCompetence.DataSource = competencePersonne;
                this.listBoxCompetence.DisplayMember = "Libelle";
                this.listBoxCompetence.ValueMember = "Identifiant";
            }



            #endregion
            #region fonctionsButtonAjouter
                    private void buttonAjouterAncienEmploi_Click(object sender, EventArgs e)
                    {
                        AjouterAncienEmplois ancienEmplois = new AjouterAncienEmplois();
                        ancienEmplois.ShowDialog();
                    }
                    private void buttonAjouterHabilite_Click(object sender, EventArgs e)
                    {
                        AjouterHabilite habilite = new AjouterHabilite();
                        habilite.ShowDialog();
                    }
                    private void buttonAjouterDiplome_Click(object sender, EventArgs e)
                    {
                        AjouterDiplome diplome = new AjouterDiplome();
                        diplome.ShowDialog();
                    }
                    private void buttonAjouterLangue_Click(object sender, EventArgs e)
                    {
                        AjouterLangue langue = new AjouterLangue();
                        langue.ShowDialog();
                    }
                    private void buttonAjouterFormation_Click(object sender, EventArgs e)
                    {
                        AjouterFormation formation = new AjouterFormation();
                        formation.ShowDialog();
                    }
                    private void buttonAjouterCompétence_Click(object sender, EventArgs e)
                    {
                        AjouterCompetence competence = new AjouterCompetence();
                        competence.ShowDialog();
                    }
                    private void buttonAjouterPoste_Click(object sender, EventArgs e)
                    {
                        AjouterPoste poste = new AjouterPoste();
                        poste.ShowDialog();
                    }
                    private void buttonAJouterInaptitude_Click(object sender, EventArgs e)
                    {
                        AjouterInaptitude inaptitude = new AjouterInaptitude();
                        inaptitude.ShowDialog();
                    }
                #endregion
            #endregion
            #region Formation

            #endregion
            #region Postes

            #endregion
        #endregion

        #region Fonction de l'onglet : OPTION
            private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
            {
                QuitterComfirmation quitter = new QuitterComfirmation();
                quitter.ShowDialog();
            }
            private void pleinÉcranToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                pleinÉcranToolStripMenuItem.Checked = true;
                fenêtréToolStripMenuItem.Checked = false;
            }
            private void fenêtréToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
                pleinÉcranToolStripMenuItem.Checked = false;
                fenêtréToolStripMenuItem.Checked = true;
            }
        #endregion

            private void statistiquesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                GraphiqueMOI graphMoi = new GraphiqueMOI();
                graphMoi.ShowDialog();

                GraphiqueMOD graphMOd = new GraphiqueMOD();
                graphMOd.ShowDialog();

                GraphiqueHierarchie graphHi = new GraphiqueHierarchie();
                graphHi.ShowDialog();

                GraphiqueSatisfaction graphSatisf = new GraphiqueSatisfaction();
                graphSatisf.ShowDialog();
            }
    }
}