using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Models;

namespace Chats.Database
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

        private FakeDb()
        {
            this.ListeChats = new List<Chat>();
            InitialisaterMeuteDeChats();
        }

        public List<Chat> ListeChats { get; private set; }

        private void InitialisaterMeuteDeChats()
        {
            ListeChats.Add(new Chat { Id = 1, Nom = "Felix", Age = 3, Couleur = "Roux" });
            ListeChats.Add(new Chat { Id = 2, Nom = "Minette", Age = 1, Couleur = "Noire" });
            ListeChats.Add(new Chat { Id = 3, Nom = "Miss", Age = 10, Couleur = "Blanche" });
            ListeChats.Add(new Chat{ Id = 4,Nom = "Garfield",Age = 6,Couleur = "Gris"});
            ListeChats.Add(new Chat { Id = 5, Nom = "Chatran", Age = 4, Couleur = "Fauve" });
            ListeChats.Add(new Chat { Id = 6, Nom = "Minou", Age = 2, Couleur = "Blanc" });
            ListeChats.Add(new Chat { Id = 7, Nom = "Bichette", Age = 12, Couleur = "Rousse" });
        }
    }
}