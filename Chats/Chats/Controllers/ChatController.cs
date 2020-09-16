using Chats.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace Chats.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View(FakeDb.Instance.ListeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chat = FakeDb.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
            return View(chat);
        }


        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
