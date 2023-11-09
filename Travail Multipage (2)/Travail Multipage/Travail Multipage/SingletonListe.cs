using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Multipage
{
    internal class SingletonListe
    {

        ObservableCollection<Article> listeArticles;

        static SingletonListe instance = null;

        public SingletonListe()
        {
            listeArticles = new ObservableCollection<Article>();
        }

        public static SingletonListe getinstance()
        {
            if (instance == null)
                instance = new SingletonListe();

            return instance;
        }

        public ObservableCollection<Article> getListe()
        {
            return listeArticles;
        }

        public void ajouter(Article c)
        {
            listeArticles.Add(c);
        }

        public void modifier(int position, Article c)
        {
            listeArticles[position] = c;
        }

        public void supprimer(int position)
        {
            listeArticles.RemoveAt(position);
        }

        public String retourneNom(int position)
        {
            if (position­­ != -1)
            {
                return listeArticles[position].Nom.ToString();
            }
            else return "Aucun objet sélectionner";
        }

        public String retourneDate(int position)
        {
            if (position­­ != -1)
            {
                return listeArticles[position].Prix.ToString();
            }
            else return "Aucun objet sélectionner";
        }

        public String retourneHeure(int position)
        {
            if (position­­ != -1)
            {
                return listeArticles[position].Etat.ToString();
            }
            else return "Aucun objet sélectionner";
        }

        public String retourneUrl(int position)
        {
            if (position­­ != -1)
            {
                return listeArticles[position].UrlImage.ToString();
            }
            else return "";
        }

        public String retourneCategorie(int position)
        {
            if (position­­ != -1)
            {
                return listeArticles[position].Categorie.ToString();
            }
            else return "";
        }


        public Article getArticle(int position)
        {
            return listeArticles[position];
        }

        public void setArticle(int pos, Article a)
        {
            listeArticles[pos] = a;
        }


    }
}
