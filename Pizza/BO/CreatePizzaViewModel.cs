using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CreatePizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public int IdPate { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int IdIngredient { get; set; }

    }
}
