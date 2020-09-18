using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Database
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
            this.ListePizzas = new List<Pizza>();
            this.IngredientsDisponibles = new List<Ingredient>();
            this.PatesDisponibles = new List<Pate>();
            InitialiserPates();
            InitialiserIngredients();
            //InitialisaterPizzas();
        }

        public List<Pizza> ListePizzas { get; private set; }

        //private void InitialisaterPizzas()
        //{
        //    ListePizzas.Add(new Pizza
        //    {
        //        Id = 1,
        //        Nom = "Reine",
        //        Pate = PatesDisponibles[1],
        //        Ingredients = (List<Ingredient>)IngredientsDisponibles.Where(x => x.Id == 2)
        //    });
        //}


        public List<Ingredient> IngredientsDisponibles { get; private set; }
        private void InitialiserIngredients()
        {
            IngredientsDisponibles.Add(new Ingredient { Id = 1, Nom = "Mozzarella" });
            IngredientsDisponibles.Add(new Ingredient { Id = 2, Nom = "Jambon" });
            IngredientsDisponibles.Add(new Ingredient { Id = 3, Nom = "Tomate" });
            IngredientsDisponibles.Add(new Ingredient { Id = 4, Nom = "Oignon" });
            IngredientsDisponibles.Add(new Ingredient { Id = 5, Nom = "Cheddar" });
            IngredientsDisponibles.Add(new Ingredient { Id = 6, Nom = "Saumon" });
            IngredientsDisponibles.Add(new Ingredient { Id = 7, Nom = "Champignon" });
            IngredientsDisponibles.Add(new Ingredient { Id = 8, Nom = "Poulet" });
        }

        public List<Pate> PatesDisponibles { get; private set; }

        private void InitialiserPates()
        {
            PatesDisponibles.Add(new Pate { Id = 1, Nom = "Pate fine, base crême" });
            PatesDisponibles.Add(new Pate { Id = 2, Nom = "Pate fine, base tomate" });
            PatesDisponibles.Add(new Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            PatesDisponibles.Add(new Pate { Id = 4, Nom = "Pate épaisse, base tomate" });
        }
    }
}
