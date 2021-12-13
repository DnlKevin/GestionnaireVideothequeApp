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
    public class FactureController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET: Facture
        public ActionResult Index()
        {
            return View(_db.FACTURE.ToList());
        }

        // GET: Facture/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FACTURE facture = _db.FACTURE.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }

            return View(facture);
        }

        // GET: Facture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facture/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "FACTUREID")] FACTURE FactureToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // On ajoute la nouvelle facture à la collection de factures
                _db.FACTURE.Add(FactureToCreate);

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

        // GET: Facture/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var FactureToEdit = (from f in _db.FACTURE
                                 where f.FACTUREID == id
                                 select f).First();

            if(FactureToEdit == null)
            {
                return HttpNotFound();
            }

            return View(FactureToEdit);
        }

        // POST: Facture/Edit/5
        [HttpPost]
        public ActionResult Edit(FACTURE FactureToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(FactureToEdit).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        // GET: Facture/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FACTURE facture = _db.FACTURE.Find(id);
            if(facture == null)
            {
                return HttpNotFound();
            }

            return View(facture);
        }

        // POST: Facture/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Ici on supprime l'enregistrement
                FACTURE facture = _db.FACTURE.Find(id);
                _db.FACTURE.Remove(facture);
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
