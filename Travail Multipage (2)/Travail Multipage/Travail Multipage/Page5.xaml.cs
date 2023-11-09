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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_Multipage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page5 : Page
    {
        public Page5()
        {
            this.InitializeComponent();
        }

        private async void btEcrireP5_Click(object sender, RoutedEventArgs e)
        {
            //var picker = new Windows.Storage.Pickers.FileSavePicker();        version non CSV

            //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            //picker.SuggestedFileName = "test";
            //picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".txt" });

            ////crée le fichier
            //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            ////écrit dans le fichier
            //if (monFichier != null)
            //    await Windows.Storage.FileIO.WriteTextAsync(monFichier, TbxTexteP5.Text);

            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "testCSV2";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            List<Client> liste = new List<Client>();
            liste.Add(new Client { Nom = "Laroche", Prenom = "Marie" });
            liste.Add(new Client { Nom = "Demers", Prenom = "René" });
            liste.Add(new Client { Nom = "Lavoie", Prenom = "Denis" });

            // La fonction ToString de la classe Client retourne: nom + ";" + prenom

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);

        }

        private async void btLireP5_Click(object sender, RoutedEventArgs e)
        {
            //var picker = new Windows.Storage.Pickers.FileOpenPicker();        version non CSV
            //picker.FileTypeFilter.Add(".txt");

            //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            ////sélectionne le fichier à lire
            //Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();

            ////ouvre le fichier et lit le contenu
            //var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);

            //lvListeP5.ItemsSource = lignes;

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            //sélectionne le fichier à lire
            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();

            //ouvre le fichier et lit le contenu
            var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);

            List<Client> liste = new List<Client>();

            /*boucle permettant de lire chacune des lignes du fichier
            * et de remplir une liste d'objets de type CLient
            */
            foreach (var ligne in lignes)
            {
                var v = ligne.Split(";");
                liste.Add(new Client { Nom = v[0], Prenom = v[1] });
            }

            //on peut mettre la liste de Clients comme source d'une listView
            lvListeP5.ItemsSource = liste;


        }

        private async void btListeP5_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "test";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".txt" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            List<Client> liste = new List<Client>();
            liste.Add(new Client { Nom = "Laroche", Prenom = "Marie" });
            liste.Add(new Client { Nom = "Demers", Prenom = "René" });
            liste.Add(new Client { Nom = "Lavoie", Prenom = "Denis" });
            liste.Add(new Client { Nom = "Rivard", Prenom = "Louise" });

            //écrit dans le fichier chacune des lignes du tableau
            //une boucle sera faite sur la collection et prendra chacun des objets de celle-ci
            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.ToString()));
        }
    }
}
