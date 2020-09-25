using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TpDojoBis.Data;
using TpDojoBis.Models;

namespace TpDojoBis.Controllers
{
    public class SamouraisController : Controller
    {
        private TpDojoBisContext db = new TpDojoBisContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id); //je récupère le samourai avec l'id passé en paramètre
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList(); //je récupère la liste des armes stockées en DB
            vm.ArtMartiaux = db.ArtMartials.ToList();
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
                if (vm.ArmeId != null)
                {
                    vm.Samourai.Arme = db.Armes.Find(vm.ArmeId); //j'injecte l'arme sélectionnée dans mon nouveau samourai
                }
                if (vm.ArtMartiauxIds != null)
                {
                    vm.Samourai.ArtMartiaux = db.ArtMartials.Where(x => vm.ArtMartiauxIds.Contains(x.Id)).ToList();
                }
                
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.Armes = db.Armes.ToList(); //je réinitialise la liste des armes

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamouraiVM vm = new SamouraiVM(); 
            vm.Samourai = db.Samourais.Find(id); //je récupère le samourai avec l'id passé en paramètre
            if (vm.Samourai == null)
            {
                return HttpNotFound();
            }
            vm.Armes = db.Armes.ToList(); //je récupère la liste d'arme
            vm.ArtMartiaux = db.ArtMartials.ToList(); //je récupère la liste d'art martiaux
            if (vm.Samourai.Arme != null)
            {
                vm.ArmeId = vm.Samourai.Arme.Id;
            }
                       
            return View(vm);  //je retourne le samourai dans la vue
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
                var samouraiEdited = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == vm.Samourai.Id); //récupération du samourai et de son arme
                samouraiEdited.Force = vm.Samourai.Force;
                samouraiEdited.Nom = vm.Samourai.Nom;
                samouraiEdited.ArtMartiaux = db.ArtMartials.Where(x => vm.ArtMartiauxIds.Contains(x.Id)).ToList();

                if (vm.ArmeId != null)
                {
                    samouraiEdited.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.ArmeId);
                    
                }
                else
                {
                    samouraiEdited.Arme = null;
                    //samouraiEdited.ArtMartiaux = null;
                }

                db.Entry(samouraiEdited).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
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
