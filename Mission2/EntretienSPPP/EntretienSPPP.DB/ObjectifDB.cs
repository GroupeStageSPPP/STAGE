﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EntretienSPPP.library;

namespace EntretienSPPP.DB
{
    class ObjectifDB
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
            String requete = "SELECT IdentifiantEntretien, Mesure, Description, Resultat,IdentifiantEntretien FROM Objectif ;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Objectif> list = new List<Objectif>();
            while (dataReader.Read())
            {

                //1 - Créer un Objectif à partir des donner de la ligne du dataReader
                Objectif objectif = new Objectif();
                objectif.IdentifiantEntretien = dataReader.GetInt32(0);
                objectif.Mesure = dataReader.GetString(1);
                objectif.Description = dataReader.GetString(2);
                objectif.Resultat = dataReader.GetString(3);
                objectif.IdentifiantEntretien = dataReader.GetInt32(4);


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
            String requete = @"SELECT  Identifiant,Mesure,Description, Resultat,IdentifiantEntretien FROM Objectif
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
            objectif.IdentifiantEntretien = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return objectif;
        }
        public static Boolean update(Objectif objectif)
        {
            Boolean isUpDAte = false ;
            //mettre a jour la base de donnée
            // retourne un boulean si l'update ses bien dérouler

            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());

            String requete = @"Update objectif set Mesure = @Mesure,Description = @Description,Resultat = @Resultat, IdentifiantEntretien = @IdentifiantEntretien where identifiant = @identifiant  ;";
            
            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Mesure", objectif.Mesure);
            commande.Parameters.AddWithValue("Description", objectif.Description);
            commande.Parameters.AddWithValue("Resultat", objectif.Resultat);
            commande.Parameters.AddWithValue("IdentifiantEntretien", objectif.IdentifiantEntretien);
            commande.Parameters.AddWithValue("identifiant", objectif.Identifiant);
            
            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                isUpDAte = true;
            }

            catch (Exception)
            {
                isUpDAte = false;
            }

            finally
            {
                connection.Close();
            }
            
            return isUpDAte;
        }

        public static Boolean delete(Objectif objectif)
        {
            Boolean isDelete = false;
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());

            String requete = @"DELETE FROM objectif WHERE Identifiant = @Identifiant ; ";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", objectif.Identifiant);

            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                isDelete = true;
            }

            catch (Exception)
            {
                isDelete = false;
            }

            finally
            {
                connection.Close();
            }

            return isDelete;

      
        }

        public static Objectif CreateGroupe(Objectif objectif)
        {

            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());


            String requete = @"Insert INTO objectif(Mesure,Description,Resultat,IdentifiantEntretien) Values (@Mesure,@Description,@Resultat,@IdentifiantEntretien); SELECT SCOPE_IDENTITY() ; ";

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Mesure",objectif.Mesure);
            commande.Parameters.AddWithValue("Description", objectif.Description);
            commande.Parameters.AddWithValue("Resultat", objectif.Resultat);
            commande.Parameters.AddWithValue("IdentifiantEntretien", objectif.IdentifiantEntretien);
            
           
              try
            {
                connection.Open();
                Decimal IDENTIFIANTDERNIERAJOUT = (Decimal)commande.ExecuteScalar();
                return ObjectifDB.Get(Int32.Parse(IDENTIFIANTDERNIERAJOUT.ToString()));
                
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }

           
            }

            
        
    }
}
