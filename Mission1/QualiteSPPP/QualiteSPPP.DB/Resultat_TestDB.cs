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
    public static class Resultat_TestDB
    {
        /// <summary>
        /// Récupère une liste de Resultat_Test à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Resultat_Test> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Valeur, IdentifiantEchantillon, IdentifiantTest Libelle FROM Resultat_Test";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Resultat_Test> list = new List<Resultat_Test>();
            while (dataReader.Read())
            {

                //1 - Créer un Resultat_Test à partir des donner de la ligne du dataReader

                string Value = dataReader.GetValue(1).ToString();
                bool BoolValue = false;
                if ( Value == "1")
                {
                    BoolValue = true;

                }
                else
                {
                    BoolValue = true;
                }
                Resultat_Test resultatTest = new Resultat_Test();
                resultatTest.Identifiant = dataReader.GetInt32(0);
                resultatTest.Valeur = BoolValue;
                resultatTest.echantillon.Identifiant = dataReader.GetInt32(2);
                resultatTest.test.Identifiant = dataReader.GetInt32(3);


                //2 - Ajouter ce Resultat_Test à la list de client
                list.Add(resultatTest);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Resultat_Test à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Resultat_Test</param>
        /// <returns>Un Resultat_Test </returns>
        public static Resultat_Test Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Valeur, IdentifiantEchantillon, IdentifiantTest FROM Resultat_Test
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Resultat_Test
            Resultat_Test resultatTest = new Resultat_Test();
            string Value = dataReader.GetValue(1).ToString();
            bool BoolValue = false;
            if (Value == "1")
            {
                BoolValue = true;

            }
            else
            {
                BoolValue = true;
            }
            resultatTest.Identifiant = dataReader.GetInt32(0);
            resultatTest.Valeur = BoolValue;
            resultatTest.echantillon.Identifiant = dataReader.GetInt32(2);
            resultatTest.test.Identifiant = dataReader.GetInt32(3);
            dataReader.Close();
            connection.Close();
            return resultatTest;
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

            String requete = "DELETE Resultat_Test WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Resultat_Test resultatTest)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Resultat_Test(Valeur, IdentifiantEchantillon, IdentifiantTest) VALUES(@Valeur, @IdentifiantEchantillon, @IdentifiantTest )";
            commande.Parameters.AddWithValue("Valeur", resultatTest.Valeur);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", resultatTest.echantillon.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantTest", resultatTest.test.Identifiant);

            //Execution de la commande
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Resultat_Test resultatTest)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Resultat_Test  SET Valeur=@Valeur, IdentifiantEchantillon=@IdentifiantEchantillon, IdentifiantTest=@IdentifiantTest  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", resultatTest.Identifiant);
            commande.Parameters.AddWithValue("Valeur", resultatTest.Valeur);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", resultatTest.echantillon.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantTest", resultatTest.test.Identifiant);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
