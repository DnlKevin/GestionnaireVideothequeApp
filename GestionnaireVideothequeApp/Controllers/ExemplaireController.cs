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
    public class ExemplaireController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET: Exemplaire
        public ActionResult Index()
        {
            return View(_db.EXEMPLAIRE.ToList());
        }

        // GET: Exemplaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exemplaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exemplaire/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "EXEMPLAIREID")] EXEMPLAIRE ExemplaireToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // On ajoute le nouvel exemplaire à la collection d'exemplaires
                _db.EXEMPLAIRE.Add(ExemplaireToCreate);

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

        // GET: Exemplaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ExemplaireToEdit = (from e in _db.EXEMPLAIRE
                                    where e.EXEMPLAIREID == id
                                    select e).First();

            if(ExemplaireToEdit == null)
            {
                return HttpNotFound();
            }

            return View(ExemplaireToEdit);
        }

        // POST: Exemplaire/Edit/5
        [HttpPost]
        public ActionResult Edit(EXEMPLAIRE ExemplaireToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(ExemplaireToEdit).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Exemplaire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exemplaire/Delete/5
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
