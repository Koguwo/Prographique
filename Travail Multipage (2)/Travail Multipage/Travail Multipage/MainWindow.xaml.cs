﻿using Microsoft.UI.Xaml;
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
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_Multipage
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            SingletonFenetre.getInstance().Fenetre = this;
            mainFrame.Navigate(typeof(Page1));
        }

        private void btPage1_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Page1));
        }

        private void btPage2_Click(object sender, RoutedEventArgs e)
        {
            // Client client = new Client { Nom="doe", Prenom="john

            mainFrame.Navigate(typeof(Page2), "Bonjour");
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iListe":
                    mainFrame.Navigate(typeof(Page1));
                    break;
                case "iAjouter":
                    mainFrame.Navigate(typeof(Page2));
                    break;
                case "iModification":
                    mainFrame.Navigate(typeof(Page3));
                    break;
                case "iTest":
                    mainFrame.Navigate(typeof(Page4));
                    break;
                case "iTest2":
                    mainFrame.Navigate(typeof(Page5));
                    break;
                default:
                    break;
            }
        }




    }
}

