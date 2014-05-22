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
    public static class ProduitDB
    {
        /// <summary>
        /// Récupère une liste de Produit à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Produit> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, PositionGD, PositionAVAR , IdentifiantPiece, IdentifiantPeinture FROM Produit";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Produit> list = new List<Produit>();
            while (dataReader.Read())
            {

                //1 - Créer un Produit à partir des donner de la ligne du dataReader
                Produit produit = new Produit();
                produit.Identifiant = dataReader.GetInt32(0);
                produit.PositionGD = dataReader.GetString(1);
                produit.PositionAVAR = dataReader.GetString(2);
                produit.piece.Identifiant = dataReader.GetInt32(3);
                produit.peinture.Identifiant = dataReader.GetInt32(4);


                //2 - Ajouter ce Produit à la list de client
                list.Add(produit);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Produit à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Produit</param>
        /// <returns>Un Produit </returns>
        public static Produit Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, PositionGD, PositionAVAR, IdentifiantPiece, IdentifiantPeinture FROM Produit
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Produit
            Produit produit = new Produit();

            produit.Identifiant = dataReader.GetInt32(0);
            produit.PositionGD = dataReader.GetString(1);
            produit.PositionAVAR = dataReader.GetString(2);
            produit.piece.Identifiant = dataReader.GetInt32(3);
            produit.peinture.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return produit;
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

            String requete = "DELETE Produit WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            connection.Close();
        }


        public static void Insert(Produit produit)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Produit(PositionGD, PositionAVAR, IdentifiantPiece, IdentifiantPeinture) VALUES(@PositionGD, @PositionAVAR ,@IdentifiantPiece ,@IdentifiantPeinture)";
            commande.Parameters.AddWithValue("PositionGD", produit.PositionGD);
            commande.Parameters.AddWithValue("PositionAVAR", produit.PositionAVAR);
            commande.Parameters.AddWithValue("IdentifiantPiece", produit.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", produit.peinture.Identifiant);


            //Execution de la commande
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Produit produit)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Produit  SET PositionGD=@PositionGD, PositionAVAR=@PositionAVAR ,IdentifiantPiece=@IdentifiantPiece ,IdentifiantPeinture=@IdentifiantPeinture  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", produit.Identifiant);
            commande.Parameters.AddWithValue("PositionGD", produit.PositionGD);
            commande.Parameters.AddWithValue("PositionAVAR", produit.PositionAVAR);
            commande.Parameters.AddWithValue("IdentifiantPiece", produit.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", produit.peinture.Identifiant);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
