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
    public static class CoucheDB
    {
        /// <summary>
        /// Récupère une liste de Couche à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Couche> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, TypeCouche, DocRef, IdentifiantFournisseur FROM Couche";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Couche> list = new List<Couche>();
            while (dataReader.Read())
            {

                //1 - Créer un Couche à partir des donner de la ligne du dataReader
                Couche couche = new Couche();
                couche.Identifiant = dataReader.GetInt32(0);
                couche.Libelle = dataReader.GetString(1);
                couche.TypeCouche = dataReader.GetString(2);
                couche.DocRef = dataReader.GetString(3);
                couche.Identifiant = dataReader.GetInt32(4);


                //2 - Ajouter ce Couche à la list de client
                list.Add(couche);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Couche à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Couche</param>
        /// <returns>Un Couche </returns>
        public static Couche Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, TypeCouche, DocRef, IdentifiantFournisseur FROM Couche
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Couche
            Couche couche = new Couche();

            couche.Identifiant = dataReader.GetInt32(0);
            couche.Libelle = dataReader.GetString(1);
            couche.TypeCouche = dataReader.GetString(2);
            couche.DocRef = dataReader.GetString(3);
            couche.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return couche;
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

            String requete = "DELETE Couche WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande
            SqlDataReader dataReader = commande.ExecuteReader();

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Couche couche)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Couche(Libelle, TypeCouche, DocRef, IdentifiantFournisseur) VALUES(@Libelle, @TypeCouche, @DocRef, @IdentifiantFournisseur)";
            SqlDataReader dataReader = commande.ExecuteReader();

            commande.Parameters.AddWithValue("Libelle", couche.Libelle);
            commande.Parameters.AddWithValue("TypeCouche", couche.TypeCouche);
            commande.Parameters.AddWithValue("DocRef", couche.DocRef);
            commande.Parameters.AddWithValue("IdentifiantFournisseur", couche.fournisseur.Identifiant);

            //Execution de la commande
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Couche couche)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Couche  SET Libelle='@Libelle' TypeCouche=@TypeCouche, DocRef=@DocRef, IdentifiantFournisseur=@IdentifiantFournisseur) WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", couche.Identifiant);
            commande.Parameters.AddWithValue("Libelle", couche.Libelle);
            commande.Parameters.AddWithValue("TypeCouche", couche.TypeCouche);
            commande.Parameters.AddWithValue("DocRef", couche.DocRef);
            commande.Parameters.AddWithValue("IdentifiantFournisseur", couche.fournisseur.Identifiant);

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
