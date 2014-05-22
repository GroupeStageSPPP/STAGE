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
    public static class EchantillonDB
    {
        /// <summary>
        /// Récupère une liste de Echantillon à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Echantillon> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, NumLot, DatePeinture, IdentifiantProduit FROM Echantillon";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Echantillon> list = new List<Echantillon>();
            while (dataReader.Read())
            {

                //1 - Créer un Echantillon à partir des donner de la ligne du dataReader
                Echantillon echantillon = new Echantillon();
                echantillon.Identifiant = dataReader.GetInt32(0);
                echantillon.NumLot = dataReader.GetString(1);
                echantillon.DatePeinture = dataReader.GetDateTime(2);
                echantillon.produit.Identifiant = dataReader.GetInt32(3);

                //2 - Ajouter ce Echantillon à la list de client
                list.Add(echantillon);
            }

            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Echantillon à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Echantillon</param>
        /// <returns>Un Echantillon </returns>
        public static Echantillon Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, NumLot, DatePeinture, IdentifiantProduit FROM Echantillon
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Echantillon
            Echantillon echantillon = new Echantillon();
            echantillon.Identifiant = dataReader.GetInt32(0);
            echantillon.NumLot = dataReader.GetString(1);
            echantillon.DatePeinture = dataReader.GetDateTime(2);
            echantillon.produit.Identifiant = dataReader.GetInt32(3);

            dataReader.Close();
            connection.Close();
            return echantillon;
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

            String requete = "DELETE Echantillon WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande
            commande.ExecuteNonQuery();

            commande.CommandText = requete;
            connection.Close();
        }


        public static void Insert(Echantillon echantillon)
        {

            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Echantillon( NumLot, DatePeinture, IdentifiantProduit) VALUES(@NumLot, @DatePeinture, @IdentifiantProduit)";
            commande.Parameters.AddWithValue("Libelle", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("IdentifiantProduit", echantillon.produit.Identifiant);
            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Echantillon echantillon)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Echantillon  SET Libelle=@Libelle  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", echantillon.Identifiant);
            commande.Parameters.AddWithValue("Libelle", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("IdentifiantProduit", echantillon.produit.Identifiant);

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }

    }
}
