using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Travail_Multipage
{
 
    public sealed partial class Page1 : Page
    {

        ObservableCollection<Article> liste = new ObservableCollection<Article>()
        {

        };

        public Page1()
        {
            this.InitializeComponent();
            listeArticles.ItemsSource = SingletonListe.getinstance().getListe();
        }

        private void listeEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listeArticles.SelectedIndex;
            this.Frame.Navigate(typeof (Page3), index);
        }

        private void listeArticles_ItemClick(object sender, ItemClickEventArgs e)
        {
            int index = listeArticles.SelectedIndex;
            this.Frame.Navigate(typeof(Page3), index);
        }
    }
}