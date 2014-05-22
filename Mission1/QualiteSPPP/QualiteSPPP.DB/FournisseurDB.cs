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
    public static class FournisseurDB
    {
                /// <summary>
        /// Récupère une liste de Fournisseur à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Fournisseur> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle FROM Fournisseur";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Fournisseur> list = new List<Fournisseur>();
            while (dataReader.Read())
            {

                //1 - Créer un Fournisseur à partir des donner de la ligne du dataReader
                Fournisseur fournisseur = new Fournisseur();
                fournisseur.Identifiant = dataReader.GetInt32(0);
                fournisseur.Libelle = dataReader.GetString(1);



                //2 - Ajouter ce Fournisseur à la list de client
                list.Add(fournisseur);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Fournisseur à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Fournisseur</param>
        /// <returns>Un Fournisseur </returns>
        public static Fournisseur Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle FROM Fournisseur
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Fournisseur
            Fournisseur fournisseur = new Fournisseur();

            fournisseur.Identifiant = dataReader.GetInt32(0);
            fournisseur.Libelle = dataReader.GetString(1);
            dataReader.Close();
            connection.Close();
            return fournisseur;
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

            String requete = "DELETE Fournisseur WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();


            connection.Close();
        }


        public static void Insert(Fournisseur fournisseur)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Fournisseur(Libelle) VALUES(@Libelle)";
            commande.Parameters.AddWithValue("Libelle", fournisseur.Libelle);

            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Fournisseur fournisseur)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Fournisseur  SET Libelle=@Libelle  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", fournisseur.Identifiant);
            commande.Parameters.AddWithValue("Libelle", fournisseur.Libelle);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
