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
    public static class FamilleDB
    {
        /// <summary>
        /// Récupère une liste de Famille à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Famille> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                                FROM Famille ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Famille> list = new List<Famille>();
            while (dataReader.Read())
            {

                //1 - Créer un Famille à partir des donner de la ligne du dataReader
                Famille famille = new Famille();
                famille.Identifiant = dataReader.GetInt32(0);
                famille.Libelle = dataReader.GetString(1);


                //2 - Ajouter ce Famille à la list de client
                list.Add(famille);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Famille à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Famille</param>
        /// <returns>Un Famille </returns>
        public static Famille Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                                FROM Famille
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Famille
            Famille famille = new Famille();

            famille.Identifiant = dataReader.GetInt32(0);
            famille.Libelle = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return famille;
        }

        public static void Insert(Famille famille)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Famille(Libelle) 
                                VALUES (@libelle);";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Libelle", famille.Libelle);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Famille famille)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Famille 
                                SET Libelle = @Libelle 
                                WHERE Identifiant = @Identifant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", famille.Identifiant);
            commande.Parameters.AddWithValue("Libelle", famille.Libelle);

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
            String requete = @"DELETE FROM Famille 
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

