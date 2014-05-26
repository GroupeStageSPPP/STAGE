using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntretienSPPP.library;

namespace EntretienSPPP.DB
{
    public static class FormationDB
    {
        /// <summary>
        /// Récupère une liste de Formation à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Formation> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, IdentifiantOrganisme, Titre, Objectif, Interne, Externe 
                                FROM Formation ;";

            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Formation> list = new List<Formation>();
            while (dataReader.Read())
            {

                //1 - Créer un Formation à partir des donner de la ligne du dataReader
                Formation formation = new Formation();
                formation.Identifiant = dataReader.GetInt32(0);
                formation.organisme.Identifiant = dataReader.GetInt32(1);
                formation.Titre = dataReader.GetString(2);
                formation.Objectif = dataReader.GetString(3);
                formation.Interne = dataReader.GetChar(4);
                formation.Externe = dataReader.GetChar(5);


                //2 - Ajouter ce Formation à la list de client
                list.Add(formation);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Formation à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Formation</param>
        /// <returns>Un Formation </returns>
        public static Formation Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, IdentifiantOrganisme, Titre, Objectif, Interne, Externe 
                                FROM Formation 
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Formation
            Formation formation = new Formation();

            formation.Identifiant = dataReader.GetInt32(0);
            dataReader.Close();
            connection.Close();
            return formation;
        }

        public static void Insert(Formation_Personne formationPersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO EvalutationMoi(Annee, Contenu, Documentation, Formateur, AvisResponsable, IdentifiantFormation, IdentifiantPersonne,IdentifiantOrganisme) 
                                VALUES (@Annee, @Contenu, @Documentation, @Formateur, @AvisResponsable, @IdentifiantFormation, @IdentifiantPersonne, @IdentifiantOrganisme);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres
            commande.Parameters.AddWithValue("Annee", formationPersonne.Annee);
            commande.Parameters.AddWithValue("Contenu", formationPersonne.Contenu);
            commande.Parameters.AddWithValue("Documentation", formationPersonne.Documentation);
            commande.Parameters.AddWithValue("Formateur", formationPersonne.Formateur);
            commande.Parameters.AddWithValue("AvisResponsable", formationPersonne.AvisResponsable);
            commande.Parameters.AddWithValue("IdentifiantFormation", formationPersonne.formation.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", formationPersonne.personne.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantOrganisme", formationPersonne.organisme.Identifiant);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Formation_Personne formationPersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Formation_Personne set Annee = @Annee, Contenu = @Contenu, Documentation = @Documentation, Formateur = @Formateur, AvisResponsable =@AvisResponsable, IdentifiantFormation = @IdentifiantFormation, IdentifiantPersonne = @IdentifiantPersonne, IdentifiantOrganisme = @IdentifiantOrganisme WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Annee", formationPersonne.Annee);
            commande.Parameters.AddWithValue("Contenu", formationPersonne.Contenu);
            commande.Parameters.AddWithValue("Documentation", formationPersonne.Documentation);
            commande.Parameters.AddWithValue("Formateur", formationPersonne.Formateur);
            commande.Parameters.AddWithValue("AvisResponsable", formationPersonne.AvisResponsable);
            commande.Parameters.AddWithValue("IdentifiantFormation", formationPersonne.formation.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", formationPersonne.personne.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantOrganisme", formationPersonne.organisme.Identifiant);
            commande.Parameters.AddWithValue("Identifiant", formationPersonne.Identifiant);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"DELETE FROM Formation_Personne 
                               WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}

