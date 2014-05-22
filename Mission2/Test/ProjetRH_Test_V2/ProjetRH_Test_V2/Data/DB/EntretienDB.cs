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
    class EntretienDB
    {
        public static List<string> GetListeDates()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT Date FROM Entretien
                                GROUP BY Date";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Entretien entretien = new Entretien();
                entretien.Date = DateTime.Parse(dataReader.GetString(0));

                list.Add(entretien.Date.ToShortDateString());
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
            String requete = @"SELECT Responsable FROM Entretien
                                GROUP BY Responsable";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Entretien entretien = new Entretien();
                entretien.Responsable = dataReader.GetString(0);

                list.Add(entretien.Responsable.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeHeuresDeb()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT HeureDeb FROM Entretien
                                    GROUP BY HeureDeb";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Entretien entretien = new Entretien();
                entretien.HeureDeb = dataReader.GetString(0);

                list.Add(entretien.HeureDeb.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeHeuresFin()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT HeureFin FROM Entretien
                                GROUP BY HeureFin";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Entretien entretien = new Entretien();
                entretien.HeureFin = dataReader.GetString(0);

                list.Add(entretien.HeureFin.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }
    }
}
