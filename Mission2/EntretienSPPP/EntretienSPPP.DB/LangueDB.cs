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
    public static class LangueDB
    {
        /// <summary>
        /// Récupère une liste de Langue à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Langue> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                                FROM Langue ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Langue> list = new List<Langue>();
            while (dataReader.Read())
            {

                //1 - Créer un Langue à partir des donner de la ligne du dataReader
                Langue langue = new Langue();
                langue.Identifiant = dataReader.GetInt32(0);
                langue.Libelle = dataReader.GetString(1);

                //2 - Ajouter ce Langue à la list de client
                list.Add(langue);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Langue à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Langue</param>
        /// <returns>Un Langue </returns>
        public static Langue Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                                FROM Langue
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Langue
            Langue langue = new Langue();

            langue.Identifiant = dataReader.GetInt32(0);
            langue.Libelle = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return langue;
        }

        public static void Insert(Langue languePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Langue(Libelle) 
                                VALUES (@Libelle);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres

            commande.Parameters.AddWithValue("Libelle", languePersonne.Libelle);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Langue languePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Langue 
                                SET Libelle = @Libelle 
                                WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", languePersonne.Identifiant);
            commande.Parameters.AddWithValue("Libelle", languePersonne.Libelle);



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
            String requete = @"DELETE FROM Langue 
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
