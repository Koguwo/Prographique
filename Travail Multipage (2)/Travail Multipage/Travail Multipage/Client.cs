using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Multipage
{
    internal class Client : INotifyPropertyChanged
    {
        string nom;
        string prenom;
        string email;

        public event PropertyChangedEventHandler PropertyChanged;

        public Client(string n, string p, string e)
        {
            nom = n;
            prenom = p;
            email = e;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return $"{Nom} {prenom}";
        }

        public string StringCSV()
        {
            return $"{Nom} ; {prenom}";
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
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                this.OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
