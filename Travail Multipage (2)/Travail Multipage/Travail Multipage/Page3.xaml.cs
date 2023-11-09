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
    public sealed partial class Page3 : Page
    {
        int index = -1;

        Article a;

        public Page3()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if(index >=0)
            {
                 a = SingletonListe.getinstance().getListe()[index];

                tbxNomMod.Text = a.Nom;
                tbxPrixMod.Text = a.Prix;

                if (a.Etat == "Neuf")
                { cbEtatMod.SelectedIndex = 0; }
                else
                { cbEtatMod.SelectedIndex = 1; }


                if (a.Categorie == "Informatique")
                { cbCategorieMod.SelectedIndex = 0; }

                else if (a.Categorie == "Cuisine")
                { cbCategorieMod.SelectedIndex = 1; }

                else if (a.Categorie == "Jardin")
                { cbCategorieMod.SelectedIndex = 2; }

                else { cbCategorieMod.SelectedIndex = 3; }


                tbxUrlMod.Text = a.UrlImage;
            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (index >= 0)
            {

                a.Nom = tbxNomMod.Text;
                a.Prix = tbxPrixMod.Text;
                a.Etat = cbEtatMod.SelectedItem.ToString();
                a.Categorie = cbCategorieMod.SelectedItem.ToString();
                a.UrlImage = tbxUrlMod.Text;

                SingletonListe.getinstance().setArticle(index, a);
                this.Frame.Navigate(typeof(Page1));
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SingletonListe.getinstance().supprimer(index);
            this.Frame.Navigate(typeof(Page1));
        }
    }
}