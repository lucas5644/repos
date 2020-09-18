using BO;
using Pizza.Models;
using BO.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaTP.Controllers
{
    public class PizzasController : Controller
    {
        // GET: Pizzas
        public ActionResult Index()
        {
            return View(FakeDb.Instance.ListePizzas);
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int id)
        {
            BO.Pizza pizzaSelected = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pizzaSelected);
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pates = FakeDb.Instance.PatesDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Ingredients = FakeDb.Instance.IngredientsDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Pizzas/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                if (ModelState.IsValid && ValidateVM(vm))
                {
                    BO.Pizza pizza = vm.Pizza;
                    pizza.Pate = FakeDb.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                    pizza.Ingredients = FakeDb.Instance.IngredientsDisponibles.Where(
                        x => vm.IdsIngredients.Contains(x.Id)).ToList();

                    pizza.Id = FakeDb.Instance.ListePizzas.Count == 0 ? 1 : FakeDb.Instance.ListePizzas.Max(x => x.Id) + 1;
                    FakeDb.Instance.ListePizzas.Add(pizza);

                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = FakeDb.Instance.PatesDisponibles.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    vm.Ingredients = FakeDb.Instance.IngredientsDisponibles.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    return View(vm);
                }

            }
            catch
            {
                vm.Pates = FakeDb.Instance.PatesDisponibles.Select(
                       x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                vm.Ingredients = FakeDb.Instance.IngredientsDisponibles.Select(
                    x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                return View(vm);
            }
        }

        private bool ValidateVM(PizzaViewModel vm)
        {
            bool result = true;
            return result;
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pates = FakeDb.Instance.PatesDisponibles.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Ingredients = FakeDb.Instance.IngredientsDisponibles.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Pizza = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }
            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }
            return View(vm);
        }

        // POST: Pizzas/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                BO.Pizza pizzaEdited = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizzaEdited.Nom = vm.Pizza.Nom;
                pizzaEdited.Pate = FakeDb.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                pizzaEdited.Ingredients = FakeDb.Instance.IngredientsDisponibles.Where(
                    x => vm.IdsIngredients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int id)
        {
            BO.Pizza pizzaSelected = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pizzaSelected);
        }

        // POST: Pizzas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            BO.Pizza pizzaSupprimee = null;
            try
            {
                pizzaSupprimee = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
                if (pizzaSupprimee != null)
                {
                    FakeDb.Instance.ListePizzas.Remove(pizzaSupprimee);
                    return RedirectToAction("Index");
                }else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
