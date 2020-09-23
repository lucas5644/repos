using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TpDojo.Data;

namespace TpDojo.Controllers
{
    public class SamouraisController : Controller
    {
        private TpDojoContext db = new TpDojoContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            SamouraiVM vm = new SamouraiVM();
            vm.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);
            return View(vm);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Samourai samourai = db.Samourais.Find(id);
            //if (samourai == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList();
            vm.ArtMartiaux = db.ArtMartials.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Samourai.Arme = db.Armes.Find(vm.ArmeId);
                vm.Samourai.ArtMartiaux = db.ArtMartials.Where(x => vm.ArtMartialIds.Contains(x.Id)).ToList();
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {

            SamouraiVM vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList();
            vm.ArtMartiaux = db.ArtMartials.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);

            if (vm.Samourai.Arme != null)
            {
                vm.ArmeId = vm.Samourai.Arme.Id;
            }

            //if (vm.Samourai.ArtMartiaux.Any())
            //{
            //    vm.ArtMartialIds = vm.Samourai.ArtMartiaux.Select(x => x.Id).ToList();
            //}

            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {

                var samourai = db.Samourais.FirstOrDefault(x => x.Id == vm.Samourai.Id);
                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = samourai.Force;
                samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.ArmeId);
                samourai.ArtMartiaux = db.ArtMartials.Where(x => vm.ArtMartialIds.Contains(x.Id)).ToList();
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
