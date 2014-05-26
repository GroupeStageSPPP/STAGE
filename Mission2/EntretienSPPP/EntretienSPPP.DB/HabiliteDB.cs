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
    public static class HabiliteDB
    {
        /// <summary>
        /// Récupère une liste de Habilite à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Habilite> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Type 
                                FROM Habilite ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Habilite> list = new List<Habilite>();
            while (dataReader.Read())
            {

                //1 - Créer un Habilite à partir des donner de la ligne du dataReader
                Habilite habilite = new Habilite();
                habilite.Identifiant = dataReader.GetInt32(0);
                habilite.Type = dataReader.GetString(1);



                //2 - Ajouter ce Habilite à la list de client
                list.Add(habilite);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Habilite à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Habilite</param>
        /// <returns>Un Habilite </returns>
        public static Habilite Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Type 
                                FROM Habilite
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Habilite
            Habilite habilite = new Habilite();

            habilite.Identifiant = dataReader.GetInt32(0);
            habilite.Type = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return habilite;
        }

        public static void Insert(Habilite habilite)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Habilite(Type) 
                                VALUES (@Type);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres
            commande.Parameters.AddWithValue("Type", habilite.Type);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Habilite habilite)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Habilite set Type = @Type, 
                                WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", habilite.Identifiant);
            commande.Parameters.AddWithValue("Type", habilite.Type);


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
            String requete = @"DELETE FROM Habilite 
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
