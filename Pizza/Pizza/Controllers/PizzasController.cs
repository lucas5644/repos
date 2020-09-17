using BO;
using PizzaTP.Database;
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
            CreatePizzaViewModel vm = new CreatePizzaViewModel();
            vm.Pates = FakeDb.Instance.PatesDisponibles;
            return View(vm);
        }

        // POST: Pizzas/Create
        [HttpPost]
        public ActionResult Create(CreatePizzaViewModel vm)
        {
            try
            {
                vm.Pizza.Pate = FakeDb.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                FakeDb.Instance.ListePizzas.Add(vm.Pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int id)
        {
            BO.Pizza pizzaSelected = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pizzaSelected);
        }

        // POST: Pizzas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            BO.Pizza PizzaEdited = null;
            try
            {
                BO.Pizza pizzaSelected = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);

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
