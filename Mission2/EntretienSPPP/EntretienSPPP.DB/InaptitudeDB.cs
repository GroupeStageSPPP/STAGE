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
    public static class InaptitudeDB
    {
        /// <summary>
        /// Récupère une liste de Inaptitude à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Inaptitude> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Descriptif 
                                FROM Inaptitude ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Inaptitude> list = new List<Inaptitude>();
            while (dataReader.Read())
            {

                //1 - Créer un Inaptitude à partir des donner de la ligne du dataReader
                Inaptitude inaptitude = new Inaptitude();
                inaptitude.Identifiant = dataReader.GetInt32(0);
                inaptitude.Descriptif = dataReader.GetString(1);


                //2 - Ajouter ce Inaptitude à la list de client
                list.Add(inaptitude);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Inaptitude à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Inaptitude</param>
        /// <returns>Un Inaptitude </returns>
        public static Inaptitude Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Descriptif 
                                FROM Inaptitude
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Inaptitude
            Inaptitude inaptitude = new Inaptitude();

            inaptitude.Identifiant = dataReader.GetInt32(0);
            inaptitude.Descriptif = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return inaptitude;
        }
        public static void Insert(Inaptitude inaptitude)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Inaptitude(Descriptif) 
                                VALUES (@Descriptif);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres

            commande.Parameters.AddWithValue("Definitif", inaptitude.Descriptif);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Inaptitude inaptitude)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Inaptitude 
                               SET Descriptif = @Descriptif 
                               WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", inaptitude.Identifiant);
            commande.Parameters.AddWithValue("DateFin", inaptitude.Descriptif);


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
            String requete = @"DELETE FROM Inaptitude 
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
