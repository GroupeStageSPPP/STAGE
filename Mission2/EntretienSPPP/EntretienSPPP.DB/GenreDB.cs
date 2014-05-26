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
    public static class GenreDB
    {
        /// <summary>
        /// Récupère une liste de Genre à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Genre> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                               FROM Genre ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Genre> list = new List<Genre>();
            while (dataReader.Read())
            {

                //1 - Créer un Genre à partir des donner de la ligne du dataReader
                Genre genre = new Genre();
                genre.Identifiant = dataReader.GetInt32(0);
                genre.libelle = dataReader.GetString(1);


                //2 - Ajouter ce Genre à la list de client
                list.Add(genre);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Genre à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Genre</param>
        /// <returns>Un Genre </returns>
        public static Genre Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle 
                                FROM Genre
                                WHERE Identifiant = @Identifiant ;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Genre
            Genre genre = new Genre();

            genre.Identifiant = dataReader.GetInt32(0);
            genre.libelle = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return genre;
        }



        public static void Insert(Genre genre)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Genre(Libelle) 
                               VALUES (@Libelle);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres
            commande.Parameters.AddWithValue("Libelle", genre.libelle);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Genre genre)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE genre 
                                SET Libelle = @Libelle, 
                                WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", genre.Identifiant);
            commande.Parameters.AddWithValue("Libelle", genre.libelle);


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
            String requete = @"DELETE FROM Genre 
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

