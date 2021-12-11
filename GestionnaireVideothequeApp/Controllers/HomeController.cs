using GestionnaireVideothequeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionnaireVideothequeApp.Controllers
{
    public class HomeController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(_db.FILM.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "FILMID")] FILM FilmToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                //On ajoute le nouveau film à la collection de films
                _db.FILM.Add(FilmToCreate);

                //On sauvegarde
                _db.SaveChanges();
                
                //On redirige vers la vue Index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var FilmToEdit = (from f in _db.FILM
                              where f.FILMID == id
                              select f).First();

            if(FilmToEdit == null)
            {
                return HttpNotFound();
            }

            return View(FilmToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(FILM FilmToEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add update logic here
                _db.Entry(FilmToEdit).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
