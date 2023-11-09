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

namespace Travail_Multipage
{
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if (e.Parameter is not null)
            {
                String texte = e.Parameter as String;
               // tblPage2.Text = texte;
            }
        }

        private void btPg2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page3));
        }

        private void btPg1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Article c = new Article
            {
                Nom = tbxNom.Text,
                Prix = tbxPrix.Text,
                Etat = cbEtat.SelectedItem.ToString(),
                Categorie = cbCategorie.SelectedItem.ToString(),
                UrlImage = tbxUrl.Text
            };
            SingletonListe.getinstance().ajouter(c);

        }
    }
}