using GestionnaireVideothequeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionnaireVideothequeApp.Controllers
{
    public class ClientController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View(_db.CLIENT.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CLIENT client = _db.CLIENT.Find(id);
            if(client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CLIENTID")] CLIENT ClientToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // On ajoute le nouveau client à la collection de clients
                _db.CLIENT.Add(ClientToCreate);

                // On sauvegarde
                _db.SaveChanges();

                // On redirige vers la vue Index

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ClientToEdit = (from c in _db.CLIENT
                                where c.CLIENTID == id
                                select c).First();

            if(ClientToEdit == null)
            {
                return HttpNotFound();
            }

            return View(ClientToEdit);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(CLIENT ClientToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(ClientToEdit).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CLIENT client = _db.CLIENT.Find(id);
            if(client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Ici on supprime l'enregistrement
                CLIENT client = _db.CLIENT.Find(id);
                _db.CLIENT.Remove(client);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
