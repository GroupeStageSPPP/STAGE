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
    public static class ObjectifDB
    {
        /// <summary>
        /// Récupère une liste de Objectif à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Objectif> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Mesure, Description, Resultat,IdentifiantEntretien 
                                FROM Objectif ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Objectif> list = new List<Objectif>();
            while (dataReader.Read())
            {

                //1 - Créer un Objectif à partir des donner de la ligne du dataReader
                Objectif objectif = new Objectif();
                objectif.Identifiant = dataReader.GetInt32(0);
                objectif.Mesure = dataReader.GetString(1);
                objectif.Description = dataReader.GetString(2);
                objectif.Resultat = dataReader.GetString(3);
                objectif.Entretien.Identifiant = dataReader.GetInt32(4);


                //2 - Ajouter ce Objectif à la list de client
                list.Add(objectif);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Objectif à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Objectif</param>
        /// <returns>Un Objectif </returns>
        public static Objectif Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT  Identifiant, Mesure, Description, Resultat, IdentifiantEntretien 
                                FROM Objectif
                                WHERE Identifiant = @Identifiant ; ";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Objectif
            Objectif objectif = new Objectif();

            objectif.Identifiant = dataReader.GetInt32(0);
            objectif.Mesure = dataReader.GetString(1);
            objectif.Description = dataReader.GetString(2);
            objectif.Resultat = dataReader.GetString(3);
            objectif.Entretien.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return objectif;
        }


        public static void Insert(Objectif objectif)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande

            String requete = @"INSERT INTO Objectif(Mesure, Description, Resultat, IdentifiantEntretien) 
                                VALUES (@Mesure, @Description, @Resultat, @IdentifiantEntretien);";
            SqlCommand commande = new SqlCommand(requete, connection);
            //Paramètres

            commande.Parameters.AddWithValue("Mesure", objectif.Mesure);
            commande.Parameters.AddWithValue("Description", objectif.Description);
            commande.Parameters.AddWithValue("Resultat", objectif.Resultat);
            commande.Parameters.AddWithValue("IdentifiantEntretien", objectif.Entretien.Identifiant);



            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Objectif objectif)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Objectif 
                                SET Mesure = @Mesure, Description = @Description, Resultat =  @Resultat, IdentifiantEntretien = @IdentifiantEntretien 
                                WHERE Identifiant = @Identifiant;";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", objectif.Identifiant);
            commande.Parameters.AddWithValue("Mesure", objectif.Mesure);
            commande.Parameters.AddWithValue("Description", objectif.Description);
            commande.Parameters.AddWithValue("Resultat", objectif.Resultat);
            commande.Parameters.AddWithValue("IdentifiantEntretien", objectif.Entretien.Identifiant);



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
            String requete = @"DELETE FROM Objectif 
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
