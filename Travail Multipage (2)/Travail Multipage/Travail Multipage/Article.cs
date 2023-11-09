using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Multipage
{
    internal class Article : INotifyPropertyChanged
    {
        string nom;
        string prix;
        string etat;
        string categorie;
        string urlImage;

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"Nom: {Nom} - date: {prix}";
        }

        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                this.OnPropertyChanged();
            }
        }
        public string Prix
        {
            get { return prix; }
            set
            {
                prix = value;
                this.OnPropertyChanged();
            }
        }
        public string Etat
        {
            get { return etat; }
            set
            {
                etat = value;
                this.OnPropertyChanged();
            }
        }

        public string Categorie
        {
            get { return categorie; }
            set
            {
                categorie = value;
                this.OnPropertyChanged();
            }
        }

        public string UrlImage
        {
            get { return urlImage; }
            set
            {
                urlImage = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
