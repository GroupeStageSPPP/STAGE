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
    public static class Inaptitude_PersonneDB
    {
        /// <summary>
        /// Récupère une liste de Inaptitude_Personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Inaptitude_Personne> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, DateFin, Definitif, IdentifiantInaptitude, IdentifiantPersonne FROM Inaptitude_Personne";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Inaptitude_Personne> list = new List<Inaptitude_Personne>();
            while (dataReader.Read())
            {

                //1 - Créer un Inaptitude_Personne à partir des donner de la ligne du dataReader
                Inaptitude_Personne inaptitudePersonne = new Inaptitude_Personne();
                inaptitudePersonne.Identifiant = dataReader.GetInt32(0);
                inaptitudePersonne.DateFin = dataReader.GetDateTime(1);
                inaptitudePersonne.Definitif  = dataReader.GetChar(2);
                inaptitudePersonne.inaptitude.Identifiant = dataReader.GetInt32(3);
                inaptitudePersonne.personne.Identifiant = dataReader.GetInt32(4);




                //2 - Ajouter ce Inaptitude_Personne à la list de client
                list.Add(inaptitudePersonne);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Inaptitude_Personne à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Inaptitude_Personne</param>
        /// <returns>Un Inaptitude_Personne </returns>
        public static Inaptitude_Personne Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, DateFin, Definitif, IdentifiantInaptitude, IdentifiantPersonne 
                                FROM Inaptitude_Personne
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Inaptitude_Personne
            Inaptitude_Personne inaptitudePersonne = new Inaptitude_Personne();
            inaptitudePersonne.Identifiant = dataReader.GetInt32(0);
            inaptitudePersonne.DateFin = dataReader.GetDateTime(1);
            inaptitudePersonne.Definitif = dataReader.GetChar(2);
            inaptitudePersonne.inaptitude.Identifiant = dataReader.GetInt32(3);
            inaptitudePersonne.personne.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return inaptitudePersonne;
        }

        public static void Insert(Inaptitude_Personne inaptitudePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Inaptitude_Personne(DateFin, Definitif, IdentifiantInaptitude, IdentifiantPersonne)                                  VALUES (@DateFin, @Definitif, @IdentifiantInaptitude, @IdentifiantPersonne);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres
            commande.Parameters.AddWithValue("DateFin", inaptitudePersonne.DateFin);
            commande.Parameters.AddWithValue("Definitif", inaptitudePersonne.Definitif);
            commande.Parameters.AddWithValue("IdentifiantInaptitude", inaptitudePersonne.inaptitude.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", inaptitudePersonne.personne.Identifiant);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Inaptitude_Personne inaptitudePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Inaptitude_Personne 
                               SET DateFin = @DateFin, Definitif = @Definitif, IdentifiantInaptitude = @IdentifiantInaptitude, IdentifiantPersonne = @IdentifiantPersonne
                               WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", inaptitudePersonne.Identifiant);
            commande.Parameters.AddWithValue("DateFin", inaptitudePersonne.DateFin);
            commande.Parameters.AddWithValue("Definitif", inaptitudePersonne.Definitif);
            commande.Parameters.AddWithValue("IdentifiantInaptitude", inaptitudePersonne.inaptitude.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", inaptitudePersonne.personne.Identifiant);


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
            String requete = @"DELETE FROM Inaptitude_Personne 
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
