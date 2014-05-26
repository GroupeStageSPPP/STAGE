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
    public static class EvaluationDB
    {
        /// <summary>
        /// Récupère une liste de Evaluation à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Evaluation> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Relation, Qualite, Realisation, Polyvalence, Assiduite, Motivation, Autonomie, RespectConsigne, Commantaire 
                               FROM Evaluation";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Evaluation> list = new List<Evaluation>();
            while (dataReader.Read())
            {

                //1 - Créer un Evaluation à partir des donner de la ligne du dataReader
                Evaluation evaluation = new Evaluation();
                evaluation.Identifiant = dataReader.GetInt32(0);
                evaluation.Relation = dataReader.GetInt16(1);
                evaluation.Qualite = dataReader.GetInt16(2);
                evaluation.Realisation = dataReader.GetInt16(3);
                evaluation.Polyvalence = dataReader.GetInt16(4);
                evaluation.Assiduite = dataReader.GetInt16(5);
                evaluation.Motivation = dataReader.GetInt16(6);
                evaluation.Autonomie = dataReader.GetInt16(7);
                evaluation.RespectConsigne = dataReader.GetInt16(8);
                evaluation.Commentaire = dataReader.GetString(9);


                //2 - Ajouter ce Evaluation à la list de client
                list.Add(evaluation);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Evaluation à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Evaluation</param>
        /// <returns>Un Evaluation </returns>
        public static Evaluation Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Relation, Qualite, Realisation, Polyvalence, Assiduite, Motivation, Autonomie, RespectConsigne, Commentaire 
                                FROM Evaluation
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Evaluation
            Evaluation evaluation = new Evaluation();

            evaluation.Identifiant = dataReader.GetInt32(0);
            evaluation.Relation = dataReader.GetInt16(1);
            evaluation.Qualite = dataReader.GetInt16(2);
            evaluation.Realisation = dataReader.GetInt16(3);
            evaluation.Polyvalence = dataReader.GetInt16(4);
            evaluation.Assiduite = dataReader.GetInt16(5);
            evaluation.Motivation = dataReader.GetInt16(6);
            evaluation.Autonomie = dataReader.GetInt16(7);
            evaluation.RespectConsigne = dataReader.GetInt16(8);
            evaluation.Commentaire = dataReader.GetString(9);
            dataReader.Close();
            connection.Close();
            return evaluation;
        }



        public static void Insert(Evaluation evaluation)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"INSERT INTO Evaluation (Relation, Qualite, Realisation, Polyvalence, Assiduite, Motivation, Autonomie, RespectConsigne,  Commentaire)
                                VALUES (@Relation, @Qualite, @Realisation, @Polyvalence, @Assiduite, @Motivation, @Autonomie, @RespectConsigne)";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Relation", evaluation.Relation);
            commande.Parameters.AddWithValue("Qualite", evaluation.Qualite);
            commande.Parameters.AddWithValue("Realisation", evaluation.Realisation);
            commande.Parameters.AddWithValue("Polyvalence", evaluation.Polyvalence);
            commande.Parameters.AddWithValue("IdentifiantPersonne", evaluation.Assiduite);
            commande.Parameters.AddWithValue("Motivation", evaluation.Motivation);
            commande.Parameters.AddWithValue("Autonomie", evaluation.Autonomie);
            commande.Parameters.AddWithValue("RespectConsigne", evaluation.RespectConsigne);
            commande.Parameters.AddWithValue("ClareteObjectif", evaluation.Commentaire);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Evaluation evaluation)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"UPDATE Evaluation 
                               SET Relation = @Relation, Qualite = @Qualite, Realisation = @Realisation, Polyvalence = @Polyvalence, Assiduite = @Assiduite, Motivation = @Motivation, Autonomie = @Autonomie, RespectConsigne = @RespectConsigne 
                                WHERE identifiant = @identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", evaluation.Identifiant);
            commande.Parameters.AddWithValue("Relation", evaluation.Relation);
            commande.Parameters.AddWithValue("Qualite", evaluation.Qualite);
            commande.Parameters.AddWithValue("Realisation", evaluation.Realisation);
            commande.Parameters.AddWithValue("Polyvalence", evaluation.Polyvalence);
            commande.Parameters.AddWithValue("IdentifiantPersonne", evaluation.Assiduite);
            commande.Parameters.AddWithValue("Motivation", evaluation.Motivation);
            commande.Parameters.AddWithValue("Autonomie", evaluation.Autonomie);
            commande.Parameters.AddWithValue("RespectConsigne", evaluation.RespectConsigne);
            commande.Parameters.AddWithValue("ClareteObjectif", evaluation.Commentaire);
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
            String requete = @"DELETE FROM Evaluation 
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
