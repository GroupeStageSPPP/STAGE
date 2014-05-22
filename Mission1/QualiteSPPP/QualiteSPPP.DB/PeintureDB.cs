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
    public static class PeintureDB
    {
        /// <summary>
        /// Récupère une liste de Peinture à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Peinture> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Reference, BN, RV, JB FROM Peinture";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Peinture> list = new List<Peinture>();
            while (dataReader.Read())
            {

                //1 - Créer un Peinture à partir des donner de la ligne du dataReader
                Peinture peinture = new Peinture();
                peinture.Identifiant = dataReader.GetInt32(0);
                peinture.Reference = dataReader.GetString(1);
                peinture.BN = dataReader.GetInt16(2);
                peinture.RV = dataReader.GetInt16(3);
                peinture.JB = dataReader.GetInt16(4);


                //2 - Ajouter ce Peinture à la list de client
                list.Add(peinture);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Peinture à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifiant de Peinture</param>
        /// <returns>Un Peinture </returns>
        public static Peinture Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Reference, BN, RV, JB  FROM Peinture
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Peinture
            Peinture peinture = new Peinture();

            peinture.Identifiant = dataReader.GetInt32(0);
            peinture.Reference = dataReader.GetString(1);
            peinture.BN = dataReader.GetInt16(2);
            peinture.RV = dataReader.GetInt16(3);
            peinture.JB = dataReader.GetInt16(4);
            dataReader.Close();
            connection.Close();
            return peinture;
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

            String requete = "DELETE Peinture WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande
            

            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Peinture peinture)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Peinture(Reference, BN, RV, JB) VALUES(@Reference, @BN, @RV, @JB)";
            commande.Parameters.AddWithValue("Reference", peinture.Reference);
            commande.Parameters.AddWithValue("BN", peinture.BN);
            commande.Parameters.AddWithValue("RV", peinture.RV);
            commande.Parameters.AddWithValue("JB", peinture.JB);

            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Peinture peinture)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Peinture  SET Reference=@Reference, BN=@BN, RV=@RV, JB=@JB  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", peinture.Identifiant);
            commande.Parameters.AddWithValue("Reference", peinture.Reference);
            commande.Parameters.AddWithValue("BN", peinture.BN);
            commande.Parameters.AddWithValue("RV", peinture.RV);
            commande.Parameters.AddWithValue("JB", peinture.JB);
            commande.CommandText = requete;

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
