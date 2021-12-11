using GestionnaireVideothequeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionnaireVideothequeApp.Controllers
{
    public class TarifController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET: Tarif
        public ActionResult Index()
        {
            return View(_db.TARIF.ToList());
        }

        // GET: Tarif/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TARIF tarif = _db.TARIF.Find(id);
            if(tarif == null)
            {
                return HttpNotFound();
            }
            return View(tarif);
        }

        // GET: Tarif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarif/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "TARIFID")] TARIF TarifToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // On ajoute le nouveau tarif à la collection de tarifs
                _db.TARIF.Add(TarifToCreate);

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

        // GET: Tarif/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var TarifToEdit = (from t in _db.TARIF
                               where t.TARIFID == id
                               select t).First();

            if(TarifToEdit == null)
            {
                return HttpNotFound();
            }

            return View(TarifToEdit);
        }

        // POST: Tarif/Edit/5
        [HttpPost]
        public ActionResult Edit(TARIF TarifToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(TarifToEdit).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Tarif/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TARIF tarif = _db.TARIF.Find(id);
            if(tarif == null)
            {
                return HttpNotFound();
            }

            return View(tarif);
        }

        // POST: Tarif/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Ici on supprime l'enregistrement
                TARIF tarif = _db.TARIF.Find(id);
                _db.TARIF.Remove(tarif);
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
