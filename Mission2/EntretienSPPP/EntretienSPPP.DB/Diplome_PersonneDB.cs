﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntretienSPPP.library;

namespace EntretienSPPP.DB
{
    public static class Diplome_PersonneDB
    {
        /// <summary>
        /// Récupère une liste de Diplome_Personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Diplome_Personne> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, DateObtention, IdentifiantDiplome, IdentifiantPersonne 
                                FROM Diplome_Personne";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Diplome_Personne> list = new List<Diplome_Personne>();
            while (dataReader.Read())
            {

                //1 - Créer un Diplome_Personne à partir des données de la ligne du dataReader
                Diplome_Personne diplomePersonne = new Diplome_Personne();
                diplomePersonne.Identifiant = dataReader.GetInt32(0);
                diplomePersonne.DateObtention = dataReader.GetDateTime(1);
                diplomePersonne.diplome.Identifiant = dataReader.GetInt32(2);
                diplomePersonne.personne.Identifiant = dataReader.GetInt32(3);


                //2 - Ajouter ce Diplome_Personne à la list de client
                list.Add(diplomePersonne);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère la liste des diplomes d'une personne à partir de la base de données
        /// </summary>
        /// <returns>Une liste de Diplome</returns>
        public static List<Diplome> ListDiplome(Int32 IdentifiantPersonne )
        {
            List<Diplome> ListDiplome = new List<Diplome>();
            return ListDiplome;
        }

        /// <summary>
        /// Récupère une Diplome_Personne à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Diplome_Personne</param>
        /// <returns>Un Diplome_Personne </returns>
        public static Diplome_Personne Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["EntretienSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, DateObtention, IdentifiantDiplome, IdentifiantPersonne 
                                FROM Diplome_Personne
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Diplome_Personne
            Diplome_Personne diplomePersonne = new Diplome_Personne();

            diplomePersonne.Identifiant = dataReader.GetInt32(0);
            diplomePersonne.DateObtention = dataReader.GetDateTime(1);
            diplomePersonne.diplome.Identifiant = dataReader.GetInt32(2);
            diplomePersonne.personne.Identifiant = dataReader.GetInt32(3);
            dataReader.Close();
            connection.Close();
            return diplomePersonne;
        }
    }
}
