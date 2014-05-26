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
    public static class Formation_PersonneDB
    {
        /// <summary>
        /// Récupère une liste de Formation_Personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Formation_Personne> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Annee, Contenu, Documentation, Formateur, AvisResponsable, IdentifiantFormation, IdentifiantPersonne, IdentifiantOrganisme 
                                FROM Formation_Personne";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Formation_Personne> list = new List<Formation_Personne>();
            while (dataReader.Read())
            {

                //1 - Créer un Formation_Personne à partir des donner de la ligne du dataReader
                Formation_Personne formationPersonne = new Formation_Personne();
                formationPersonne.Identifiant = dataReader.GetInt32(0);
                formationPersonne.Annee = dataReader.GetDateTime(1);
                formationPersonne.Contenu = dataReader.GetString(2);
                formationPersonne.Documentation = dataReader.GetString(3);
                formationPersonne.Formateur = dataReader.GetString(4);
                formationPersonne.AvisResponsable = dataReader.GetString(5);
                formationPersonne.formation.Identifiant = dataReader.GetInt32(6);
                formationPersonne.personne.Identifiant = dataReader.GetInt32(7);
                formationPersonne.organisme.Identifiant = dataReader.GetInt32(8);


                //2 - Ajouter ce Formation_Personne à la list de client
                list.Add(formationPersonne);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Formation_Personne à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Formation_Personne</param>
        /// <returns>Un Formation_Personne </returns>
        public static Formation_Personne Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Annee, Contenu, Documentation, Formateur, AvisResponsable, IdentifiantFormation, IdentifiantPersonne,IdentifiantOrganisme FROM Formation_Personne
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Formation_Personne
            Formation_Personne formationPersonne = new Formation_Personne();

            formationPersonne.Identifiant = dataReader.GetInt32(0);
            formationPersonne.Annee = dataReader.GetDateTime(1);
            formationPersonne.Contenu = dataReader.GetString(2);
            formationPersonne.Documentation = dataReader.GetString(3);
            formationPersonne.Formateur = dataReader.GetString(4);
            formationPersonne.AvisResponsable = dataReader.GetString(5);
            formationPersonne.formation.Identifiant = dataReader.GetInt32(6);
            formationPersonne.personne.Identifiant = dataReader.GetInt32(7);
            formationPersonne.organisme.Identifiant = dataReader.GetInt32(8);
            dataReader.Close();
            connection.Close();
            return formationPersonne;
        }


        public static void Insert(Formation_Personne formationPersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"Insert INTO Formation_Personne(Annee, Contenu, Documentation, Formateur, AvisResponsable, IdentifiantFormation, IdentifiantPersonne,IdentifiantOrganisme) Values (@Annee, @Contenu, @Documentation, @Formateur, @AvisResponsable, @IdentifiantFormation, @IdentifiantPersonne, @IdentifiantOrganisme);";
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
            String requete = @"UPDATE Formation_Personne set Annee = @Annee, Contenu = @Contenu, Documentation = @Documentation, Formateur = @Formateur, AvisResponsable =@AvisResponsable, IdentifiantFormation = @IdentifiantFormation, IdentifiantPersonne = @IdentifiantPersonne, IdentifiantOrganisme = @IdentifiantOrganisme 
                                WHERE identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", formationPersonne.Identifiant);
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
