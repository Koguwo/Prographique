using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_Multipage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class Page4 : Page
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=2052524-charlie-fournier;Uid=2052524;Pwd=2052524;");




        public Page4()
        {
            this.InitializeComponent();
            lvListe.ItemsSource = SingletonUser.getInstance().getClients();
        }

        private void btCharger_Click(object sender, RoutedEventArgs e)
        {
            afficher();
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {

            string nom = tBoxNom.Text;
            string prenom = tBoxPrenom.Text;
            string email = tBoxMail.Text;

            Client client = new Client(nom,prenom,email);

            SingletonUser.getInstance().Ajout(client);


            afficher();



        }

        private void afficher()
        {
            SingletonUser.getInstance().getClients();
        }

    }
}
