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
    public static class TypeDB
    {
        /// <summary>
        /// Récupère une liste de Type à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<TypeP> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, IdentifiantCategorie FROM Type";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<TypeP> list = new List<TypeP>();
            while (dataReader.Read())
            {

                //1 - Créer un Type à partir des donner de la ligne du dataReader
                TypeP type = new TypeP();
                type.Identifiant = dataReader.GetInt32(0);
                type.Libelle = dataReader.GetString(1);
                type.categorie.Identifiant = dataReader.GetInt32(2);


                //2 - Ajouter ce Type à la list de client
                list.Add(type);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Type à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Type</param>
        /// <returns>Un Type </returns>
        public static TypeP Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, IdentifiantCategorie FROM Type
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Type
            TypeP type = new TypeP();

            type.Identifiant = dataReader.GetInt32(0);
            type.Libelle = dataReader.GetString(1);
            type.categorie.Identifiant = dataReader.GetInt32(2);
            dataReader.Close();
            connection.Close();
            return type;
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

            String requete = "DELETE Type WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(TypeP type)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Type(Libelle, IdentifiantCategorie) VALUES(@Libelle, @IdentifiantCategorie )";
            commande.Parameters.AddWithValue("Libelle", type.Libelle);
            commande.Parameters.AddWithValue("IdentifiantCategorie", type.categorie.Identifiant);

            //Execution de la commande
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( TypeP type)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Type  SET Libelle=@Libelle IdentifiantCategorie=@IdentifiantCategorie  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", type.Identifiant);
            commande.Parameters.AddWithValue("Libelle", type.Libelle);
            commande.Parameters.AddWithValue("IdentifiantCategorie", type.categorie.Identifiant);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }

    }
}
