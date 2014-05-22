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
    class SouhaitFormationDB
    {
        public static List<string> GetListeLieux()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT Lieu FROM SouhaitFormation
                                    GROUP BY Lieu";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                SouhaitFormation souhaitFormation = new SouhaitFormation();
                souhaitFormation.Lieu = dataReader.GetString(0);

                list.Add(souhaitFormation.Lieu.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }

        public static List<string> GetListeAvisResponsable()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT AvisResponsable FROM SouhaitFormation
                                    GROUP BY AvisResponsable";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                SouhaitFormation souhaitFormation = new SouhaitFormation();
                souhaitFormation.AvisResponsable = dataReader.GetString(0);

                list.Add(souhaitFormation.AvisResponsable.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }
    }
}
