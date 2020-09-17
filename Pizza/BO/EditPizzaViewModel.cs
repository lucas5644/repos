using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class EditPizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}
