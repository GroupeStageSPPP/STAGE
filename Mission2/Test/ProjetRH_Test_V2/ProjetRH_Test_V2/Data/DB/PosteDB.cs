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
    class PosteDB
    {
        public static List<string> GetListeLibelles()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = "SELECT Libelle FROM Poste";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Poste poste = new Poste();
                poste.Libelle = dataReader.GetString(0);

                list.Add(poste.Libelle.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeDatesDeb()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT DateDeb FROM Poste
                                GROUP BY DateDeb";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Poste poste = new Poste();
                poste.DateDeb = DateTime.Parse(dataReader.GetString(0));

                list.Add(poste.DateDeb.ToShortDateString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeDatesFin()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT DateFin FROM Poste
                                GROUP BY DateFin";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Poste poste = new Poste();
                poste.DateFin = DateTime.Parse(dataReader.GetString(0));

                list.Add(poste.DateFin.ToShortDateString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeResponsables()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT Responsable FROM Poste
                                    GROUP BY Responsable";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Poste poste = new Poste();
                poste.Responsable = dataReader.GetString(0);

                list.Add(poste.Responsable.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }
    }
}
