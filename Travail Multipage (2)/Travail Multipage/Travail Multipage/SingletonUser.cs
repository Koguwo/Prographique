using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Travail_Multipage
{
    internal class SingletonUser
    {
        static SingletonUser instance = null;
        MySqlConnection con;
        ObservableCollection<Client> listeClients;

        public SingletonUser()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2052524-charlie-fournier;Uid=2052524;Pwd=2052524;");
            listeClients = new ObservableCollection<Client>();
        }

        public static SingletonUser getInstance()
        {
            if(instance == null)
                instance = new SingletonUser();

            return instance;
        }

        public ObservableCollection<Client> getClients() {

            listeClients.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from users";

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string nom  = (string)r["nom"];

                    string prenom = (string)r["prenom"];

                    string email = (string)r["email"];



                    Client client = new Client { Nom = nom, Prenom = prenom, Email = email};
                    listeClients.Add(client);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();


            }

            return listeClients;


        }

        public void Ajout(Client c)
        {

            string nom = c.Nom;
            string prenom = c.Prenom;
            string email = c.Email;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into users values(null, @nom, @prenom, @email)";

                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@email", email);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }
        }
        



    }
}
