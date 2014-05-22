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
    public static class VehiculeDB
    {
        /// <summary>
        /// Récupère une liste de Vehicule à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Vehicule> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, IdentifiantConstructeur FROM Vehicule";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Vehicule> list = new List<Vehicule>();
            while (dataReader.Read())
            {

                //1 - Créer un Vehicule à partir des donner de la ligne du dataReader
                Vehicule vehicule = new Vehicule();
                vehicule.Identifiant = dataReader.GetInt32(0);
                vehicule.Libelle = dataReader.GetString(1);
                vehicule.constructeur.Identifiant = dataReader.GetInt32(2);
                //2 - Ajouter ce Vehicule à la list de client
                list.Add(vehicule);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Vehicule à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Vehicule</param>
        /// <returns>Un Vehicule </returns>
        public static Vehicule Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, IdentifiantConstructeur FROM Vehicule
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Vehicule
            Vehicule vehicule = new Vehicule();

            vehicule.Identifiant = dataReader.GetInt32(0);
            vehicule.Libelle = dataReader.GetString(1);
            vehicule.constructeur.Identifiant = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();
            return vehicule;
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

            String requete = "DELETE Vehicule WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            SqlDataReader dataReader = commande.ExecuteReader();
            connection.Close();
        }


        public static void Insert(Vehicule vehicule)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Vehicule(Libelle) VALUES(@Libelle)";
            commande.Parameters.AddWithValue("Libelle", vehicule.Libelle);
            
            //Execution de la commande

            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Vehicule vehicule)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Vehicule  SET Libelle= @Libelle  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", vehicule.Identifiant);
            commande.Parameters.AddWithValue("Libelle", vehicule.Libelle);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
