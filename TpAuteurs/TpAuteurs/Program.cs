﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpAuteurs.BO;

namespace TpAuteurs
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {
            InitialiserDatas();

            Console.WriteLine("--- Liste des prénoms des auteurs dont le nom commence par G ---");

            var auteurNomG = ListeAuteurs.Where(auteur => auteur.Nom.StartsWith("G"));
            foreach (var auteur in auteurNomG)
            {      
                Console.WriteLine(auteur.Prenom);
            }

            Console.WriteLine("--- Auteur ayant écrit le plus de livre ---");
            var auteurMaxLivre = ListeLivres.GroupBy(livre => livre.Auteur).OrderByDescending(
                livre => livre.Count()).FirstOrDefault().Key;
            Console.WriteLine(auteurMaxLivre.Nom + " " + auteurMaxLivre.Prenom);

            Console.WriteLine("--- Nombre moyen de pages par livre par auteur ---");
            var nbrMoyenPageAuteur = ListeLivres.GroupBy(livre => livre.Auteur);
            foreach (var auteur in nbrMoyenPageAuteur)
            {
                Console.WriteLine($"auteur: {auteur.Key.Nom}");
                Console.WriteLine(String.Format("nbPage: {0} ", auteur.Average(l => l.NbPages)));
            }

            Console.WriteLine("--- Livre avec le plus de pages ---");
            var livreMaxPages = ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine(String.Format("Titre: {0} auteur {1} pages {2}", livreMaxPages.Titre, livreMaxPages.Auteur.Nom, livreMaxPages.NbPages));

            Console.WriteLine("--- Combien ont gagné les auteurs ---");
            var gainAuteurs = ListeLivres.GroupBy(livre => livre.Auteur);

            foreach (var auteur in gainAuteurs)
            {
                Console.WriteLine(auteur.Key.Nom);
                Console.WriteLine(auteur.Key.Factures.Average(facture => facture.Montant));
            }


            Console.ReadLine();
        }
    }
}
