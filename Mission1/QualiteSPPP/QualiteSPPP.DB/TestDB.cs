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
    public static class TestDB
    {
        /// <summary>
        /// Récupère une liste de Test à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Test> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, Description, IsNumerique FROM Test";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Test> list = new List<Test>();
            while (dataReader.Read())
            {

                //1 - Créer un Test à partir des donner de la ligne du dataReader
                string Value = dataReader.GetValue(3).ToString();
                bool BoolValue = false;
                if (Value == "1")
                {
                    BoolValue = true;

                }
                else
                {
                    BoolValue = true;
                }
                Test test = new Test();
                test.Identifiant = dataReader.GetInt32(0);
                test.Libelle = dataReader.GetString(1);
                test.Description = dataReader.GetString(2);
                test.IsNumerique = BoolValue;


                //2 - Ajouter ce Test à la list de client
                list.Add(test);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Test à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Test</param>
        /// <returns>Un Test </returns>
        public static Test Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, Description, TypeTest FROM Test
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Test
            string Value = dataReader.GetValue(3).ToString();
            bool BoolValue = false;
            if (Value == "1")
            {
                BoolValue = true;

            }
            else
            {
                BoolValue = true;
            }
            Test test = new Test();

            test.Identifiant = dataReader.GetInt32(0);
            test.Libelle = dataReader.GetString(1);
            test.Description = dataReader.GetString(2);
            test.IsNumerique = BoolValue;


            dataReader.Close();
            connection.Close();
            return test;
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

            String requete = "DELETE Test WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Test test)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Test(Libelle) VALUES(@Libelle)";
            commande.Parameters.AddWithValue("Libelle", test.Libelle);

            //Execution de la commande
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Test test)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Test  SET Libelle=@Libelle  WHERE Identifiant = @Identifiant";
            commande.Parameters.AddWithValue("identifiant", test.Identifiant);
            commande.Parameters.AddWithValue("Libelle", test.Libelle);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
