using GestionnaireVideothequeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GestionnaireVideothequeApp.Controllers
{
    public class LocationController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();



        // GET: Location
        public ActionResult Index()
        {
            return View(_db.LOCATION.ToList());
        }

        
        // GET Search
        [HttpGet]
        public async Task<ActionResult> LocationEnCours(String date)
        {

            ViewData["GetLocationEnCours"] = date;

            var query = from l in _db.LOCATION
                        where l.DATERETOUREFF == null
                        select l;

            return View(query);
        }

        // GET: Location/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LOCATION location = _db.LOCATION.Find(id);
            if(location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "LOCATIONID")] LOCATION LocationToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // On ajoute la nouvelle location à la collection de locations
                _db.LOCATION.Add(LocationToCreate);

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

        // GET: Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var LocationToEdit = (from l in _db.LOCATION
                                  where l.LOCATIONID == id
                                  select l).First();

            if(LocationToEdit == null)
            {
                return HttpNotFound();
            }

            return View(LocationToEdit);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(LOCATION LocationToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(LocationToEdit).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LOCATION location = _db.LOCATION.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Ici on supprime l'enregistrement
                LOCATION location = _db.LOCATION.Find(id);
                _db.LOCATION.Remove(location);
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
