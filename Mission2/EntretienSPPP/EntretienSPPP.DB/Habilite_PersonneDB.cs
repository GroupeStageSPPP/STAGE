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
    public static class Habilite_PersonneDB
    {
        /// <summary>
        /// Récupère une liste de Habilite_Personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Habilite_Personne> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, IdentifiantOrganisme, DateFin, IdentifiantPersonne, IdentifiantHabilite 
                                FROM Habilite_Personne";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Habilite_Personne> list = new List<Habilite_Personne>();
            while (dataReader.Read())
            {

                //1 - Créer un Habilite_Personne à partir des donner de la ligne du dataReader
                Habilite_Personne habilitePersonne = new Habilite_Personne();
                habilitePersonne.Identifiant = dataReader.GetInt32(0);
                habilitePersonne.organisme.Identifiant = dataReader.GetInt32(1);
                habilitePersonne.DateFin = dataReader.GetDateTime(2);
                habilitePersonne.personne.Identifiant = dataReader.GetInt32(3);
                habilitePersonne.habilite.Identifiant = dataReader.GetInt32(3);



                //2 - Ajouter ce Habilite_Personne à la list de client
                list.Add(habilitePersonne);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Habilite_Personne à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Habilite_Personne</param>
        /// <returns>Un Habilite_Personne </returns>
        public static Habilite_Personne Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, IdentifiantOrganisme, DateFin, IdentifiantPersonne, IdentifiantHabilite 
                                FROM Habilite_Personne
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Habilite_Personne
            Habilite_Personne habilitePersonne = new Habilite_Personne();

            habilitePersonne.Identifiant = dataReader.GetInt32(0);
            habilitePersonne.organisme.Identifiant = dataReader.GetInt32(1);
            habilitePersonne.DateFin = dataReader.GetDateTime(2);
            habilitePersonne.personne.Identifiant = dataReader.GetInt32(3);
            habilitePersonne.habilite.Identifiant = dataReader.GetInt32(3);
            dataReader.Close();
            connection.Close();
            return habilitePersonne;
        }


        public static void Insert(Habilite_Personne habilitePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Habilite_Personne(IdentifiantOrganisme, DateFin, IdentifiantPersonne, IdentifiantHabilite) 
                                VALUES (@IdentifiantOrganisme, @DateFin, @IdentifiantPersonne, @IdentifiantHabilite);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres
            commande.Parameters.AddWithValue("IdentifiantOrganisme", habilitePersonne.organisme.Identifiant);
            commande.Parameters.AddWithValue("DateFin", habilitePersonne.DateFin);
            commande.Parameters.AddWithValue("IdentifiantPersonne", habilitePersonne.personne.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantHabilite", habilitePersonne.habilite.Identifiant);



            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Habilite_Personne habilitePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Habilite_Personne 
                               SET Libelle = @IdentifiantOrganisme, DateFin = @DateFin, IdentifiantPersonne = @IdentifiantPersonne, IdentifiantHabilite = @IdentifiantHabilite 
                               WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", habilitePersonne.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantOrganisme", habilitePersonne.organisme.Identifiant);
            commande.Parameters.AddWithValue("DateFin", habilitePersonne.DateFin);
            commande.Parameters.AddWithValue("IdentifiantPersonne", habilitePersonne.personne.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantHabilite", habilitePersonne.habilite.Identifiant);


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
            String requete = @"DELETE FROM Habilite_Personne 
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
