using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetRH_Test_V2.Data.Classes;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjetRH_Test_V2.Data.DB
{
    class DiplomeDB
    {
        public static List<string> GetListeLibelles()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = "SELECT Libelle FROM Diplome";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Diplome diplome = new Diplome();
                diplome.Libelle = dataReader.GetString(0);

                list.Add(diplome.Libelle.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeNiveaux()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = "SELECT Niveau FROM Diplome";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Diplome diplome = new Diplome();
                diplome.Niveau = dataReader.GetString(0);

                list.Add(diplome.Niveau.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }
    }
}
