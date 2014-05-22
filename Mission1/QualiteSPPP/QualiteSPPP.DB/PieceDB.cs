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
    public static class PieceDB
    {
        /// <summary>
        /// Récupère une liste de Piece à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Piece> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, IdentifiantClient, IdentifiantVehicule, IdentifiantType FROM Piece";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Piece> list = new List<Piece>();
            while (dataReader.Read())
            {

                //1 - Créer un Piece à partir des donner de la ligne du dataReader
                Piece piece = new Piece();
                piece.Identifiant = dataReader.GetInt32(0);
                piece.Libelle = dataReader.GetString(1);
                piece.client.Identifiant = dataReader.GetInt32(2);
                piece.vehicule.Identifiant = dataReader.GetInt32(3);
                piece.type.Identifiant = dataReader.GetInt32(4);



                //2 - Ajouter ce Piece à la list de client
                list.Add(piece);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Piece à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Piece</param>
        /// <returns>Un Piece </returns>
        public static Piece Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, IdentifiantClient, IdentifiantVehicule, IdentifiantType FROM Piece
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Piece
            Piece piece = new Piece();

            piece.Identifiant = dataReader.GetInt32(0);
            piece.Libelle = dataReader.GetString(1);
            piece.client.Identifiant = dataReader.GetInt32(2);
            piece.vehicule.Identifiant = dataReader.GetInt32(3);
            piece.type.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return piece;
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

            String requete = "DELETE Piece WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Piece piece)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Piece(Libelle, IdentifiantClient, IdentifiantVehicule, IdentifiantType) VALUES(@Libelle, @IdentifiantClient, @IdentifiantVehicule, @IdentifiantType)";
            commande.Parameters.AddWithValue("Libelle", piece.Libelle);
            commande.Parameters.AddWithValue("IdentifiantClient", piece.client.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantVehicule", piece.vehicule.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantType", piece.type.Identifiant);
            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Piece piece)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Piece  SET Libelle=@Libelle, IdentifiantClient=@IdentifiantClient, IdentifiantVehicule=@IdentifiantVehicule, IdentifiantType=@IdentifiantType  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", piece.Identifiant);
            commande.Parameters.AddWithValue("Libelle", piece.Libelle);
            commande.Parameters.AddWithValue("IdentifiantClient", piece.client.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantVehicule", piece.vehicule.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantType", piece.type.Identifiant);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
