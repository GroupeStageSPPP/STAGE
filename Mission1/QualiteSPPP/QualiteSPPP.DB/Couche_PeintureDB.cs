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
    public static class Couche_PeintureDB
    {
        /// <summary>
        /// Récupère une liste de couche_Peinture à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Couche_Peinture> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Min, Max, Moy, IdentifiantCouche, IdentifiantPeinture Libelle FROM Couche_Peinture";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Couche_Peinture> list = new List<Couche_Peinture>();
            while (dataReader.Read())
            {

                //1 - Créer un couche_Peinture à partir des donner de la ligne du dataReader
                Couche_Peinture couchePeinture = new Couche_Peinture();
                couchePeinture.Identifiant = dataReader.GetInt32(0);
                couchePeinture.Min = dataReader.GetString(1);
                couchePeinture.Max = dataReader.GetString(2);
                couchePeinture.Moy = dataReader.GetString(4);
                couchePeinture.couche.Identifiant = dataReader.GetInt32(5);
                couchePeinture.peinture.Identifiant = dataReader.GetInt32(6);

                //2 - Ajouter ce couche_Peinture à la list de client
                list.Add(couchePeinture);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }


        /// <summary>
        /// Récupère une couche_Peinture à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de couche_Peinture</param>
        /// <returns>Un couche_Peinture </returns>
        public static Couche_Peinture Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Min, Max, Moy, IdentifiantCouche, IdentifiantPeinture FROM Couche_Peinture
                                WHERE Identifiant=@Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du couche_Peinture
            Couche_Peinture couchePeinture = new Couche_Peinture();

            couchePeinture.Identifiant = dataReader.GetInt32(0);
            couchePeinture.Min = dataReader.GetString(1);
            couchePeinture.Max = dataReader.GetString(2);
            couchePeinture.Moy = dataReader.GetString(4);
            couchePeinture.couche.Identifiant = dataReader.GetInt32(5);
            couchePeinture.peinture.Identifiant = dataReader.GetInt32(6);

            dataReader.Close();
            connection.Close();
            return couchePeinture;
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

            String requete = "DELETE Couche_Peinture WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Couche_Peinture couchePeinture)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Couche_Peinture(Min, Moy, Max, IdentifiantCouche, IdentifiantPeinture) VALUES(@Min, @Moy, @Max, IdentifiantCouche, IdentifiantPeinture)";
            commande.Parameters.AddWithValue("Min", couchePeinture.Min);
            commande.Parameters.AddWithValue("Max", couchePeinture.Moy);
            commande.Parameters.AddWithValue("Max", couchePeinture.Max);
            commande.Parameters.AddWithValue("IdentifiantCouche", couchePeinture.couche.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", couchePeinture.peinture.Identifiant);
            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Couche_Peinture couchePeinture)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Couche_Peinture  SET Min=@Min, Moy=@Moy, Max=@Max, IdentifiantCouche=@IdentifiantCouche, IdentifiantPeinture=@IdentifiantPeinture  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", couchePeinture.Identifiant);
            commande.Parameters.AddWithValue("Min", couchePeinture.Min);
            commande.Parameters.AddWithValue("Max", couchePeinture.Moy);
            commande.Parameters.AddWithValue("Max", couchePeinture.Max);
            commande.Parameters.AddWithValue("IdentifiantCouche", couchePeinture.couche.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", couchePeinture.peinture.Identifiant);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
