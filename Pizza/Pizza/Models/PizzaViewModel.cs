﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza.Models
{
    public class PizzaViewModel
    {
        public BO.Pizza Pizza { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        [Required]
        public int? IdPate { get; set; }
        public List<int> IdsIngredients { get; set; } = new List<int>();

    }
}