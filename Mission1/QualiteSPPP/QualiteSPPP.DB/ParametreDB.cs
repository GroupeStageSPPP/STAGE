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
    public static class ParametreDB
    {
        /// <summary>
        /// Récupère une liste de Parametre à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Parametre> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant FROM Parametre";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Parametre> list = new List<Parametre>();
            while (dataReader.Read())
            {

                //1 - Créer un Parametre à partir des donner de la ligne du dataReader
                Parametre parametre = new Parametre();
                parametre.Identifiant = dataReader.GetInt32(0);


                //2 - Ajouter ce Parametre à la list de client
                list.Add(parametre);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Parametre à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Parametre</param>
        /// <returns>Un Parametre </returns>
        public static Parametre Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant FROM Parametre
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Parametre
            Parametre parametre = new Parametre();

            parametre.Identifiant = dataReader.GetInt32(0);
            dataReader.Close();
            connection.Close();
            return parametre;
        }
    }
}
