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
    class PersonneDB
    {
        public static List<string> GetListeCodesPostaux()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DB_RH_Test"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            String requete = @"SELECT CodePostal FROM Personne
                                GROUP BY CodePostal";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                Personne personne = new Personne();
                personne.CodePostal = dataReader.GetInt32(0);

                list.Add(personne.CodePostal.ToString());
            }
            dataReader.Close();
            connection.Close();

            list.Add("Tout");
            return list;
        }
    }
}
