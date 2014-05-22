using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualiteSPPP.Library;

namespace QualiteSPPP.DB
{
    public static class CategorieDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la base de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Categorie> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle FROM Categorie";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Categorie> list = new List<Categorie>();
            while (dataReader.Read())
            {
                
                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Categorie categorie = new Categorie();
                categorie.Identifiant = dataReader.GetInt32(0);
                categorie.Libelle = dataReader.GetString(1);


                //2 - Ajouter cette civilité à la list de civilité
                list.Add(categorie);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une catégorie à partir d'un identifiant de catégorie
        /// </summary>
        /// <param name="Identifiant">Identifant de catégorie</param>
        /// <returns>Une catégorie</returns>
        public static Categorie Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle FROM Categorie
                                WHERE Identifiant=@Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création de la civilite
            Categorie categorie = new Categorie();

            categorie.Identifiant = dataReader.GetInt32(0);
            categorie.Libelle = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return categorie;

        }


        public static void Delete(Int32 identifiant)
        {
            //Connexion 

            SqlConnection connection = new SqlConnection("LaboSPPPConnectionString");

            connection.Open();

            //Commande 

            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;

            //Création d'une chaine de caractère contenant la requete a executer;

            String requete = "DELETE Categorie WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Categorie categorie)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Categorie(Libelle) VALUES(@Libelle)";
            commande.Parameters.AddWithValue("Libelle", categorie.Libelle);

            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Categorie categorie)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Categorie  SETLibelle=@Libelle  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", categorie.Identifiant);
            commande.Parameters.AddWithValue("Libelle", categorie.Libelle);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
