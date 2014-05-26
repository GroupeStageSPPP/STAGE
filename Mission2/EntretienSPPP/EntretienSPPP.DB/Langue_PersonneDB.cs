using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntretienSPPP.library;

namespace EntretienSPPP.DB
{
    public static class Langue_PersonneDB
    {
        /// <summary>
        /// Récupère une liste de Langue_Personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Langue_Personne> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Niveau, Utilite, IdentifiantLangue, IdentifiantPersonne 
                                FROM Langue_Personne";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Langue_Personne> list = new List<Langue_Personne>();
            while (dataReader.Read())
            {

                //1 - Créer un Langue_Personne à partir des donner de la ligne du dataReader
                Langue_Personne languePersonne = new Langue_Personne();
                string ValueUtilite = dataReader.GetValue(7).ToString();
                
                languePersonne.Identifiant = dataReader.GetInt32(0);
                languePersonne.niveau = dataReader.GetString(1);
                languePersonne.Utilite = dataReader.GetChar(2);
                languePersonne.langue.Identifiant = dataReader.GetInt32(3);
                languePersonne.personne.Identifiant = dataReader.GetInt32(4);





                //2 - Ajouter ce Langue_Personne à la list de client
                list.Add(languePersonne);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Langue_Personne à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Langue_Personne</param>
        /// <returns>Un Langue_Personne </returns>
        public static Langue_Personne Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Niveau, Utilite, IdentifiantLangue, IdentifiantPersonne 
                                FROM Langue_Personne
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Langue_Personne
            Langue_Personne languePersonne = new Langue_Personne();

            languePersonne.Identifiant = dataReader.GetInt32(0);
            dataReader.Close();
            connection.Close();
            return languePersonne;
        }


        public static void Insert(Langue_Personne languePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Langue_Personne(Niveau, Utilite, IdentifiantLangue, IdentifiantPersonne) 
                                VALUES (@Niveau, @Utilite, @IdentifiantLangue, @IdentifiantPersonne);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres

            commande.Parameters.AddWithValue("Niveau", languePersonne.niveau);
            commande.Parameters.AddWithValue("Utilite", languePersonne.Utilite);
            commande.Parameters.AddWithValue("IdentifiantLangue", languePersonne.langue.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", languePersonne.personne.Identifiant);


            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Langue_Personne languePersonne)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Langue_Personne 
                                SET Niveau = @Niveau, Utilite = @Utilite, IdentifiantLangue = @IdentifiantLangue, IdentifiantPersonne = @IdentifiantPersonne 
                                WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", languePersonne.Identifiant);
            commande.Parameters.AddWithValue("Niveau", languePersonne.niveau);
            commande.Parameters.AddWithValue("Utilite", languePersonne.Utilite);
            commande.Parameters.AddWithValue("IdentifiantLangue", languePersonne.langue.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPersonne", languePersonne.personne.Identifiant);



            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"DELETE FROM Langue_Personne 
                               WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

            
    }
}
