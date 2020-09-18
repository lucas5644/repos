using BO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Pizza
    {

        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(5, ErrorMessage = "Doit être compris entre 5 et 20")]
        [System.ComponentModel.DataAnnotations.MaxLength(20, ErrorMessage = "Doit être compris entre 5 et 20")]
        public string Nom { get; set; }
        [Required]
        public Pate Pate { get; set; }
        [System.ComponentModel.DataAnnotations.Range(2, 5, ErrorMessage = "Entre 2 et 5 ingrédients")]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}
