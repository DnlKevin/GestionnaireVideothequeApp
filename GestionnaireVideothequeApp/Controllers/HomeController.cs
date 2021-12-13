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
    public class HomeController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        // GET Accueil
        public ActionResult Accueil()
        {
            return View("Accueil");
        }

        // GET About
        public ActionResult About()
        {
            return View("About");
        }

        // GET Contact
        public ActionResult Contact()
        {
            return View("Contact");
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_db.FILM.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FILM film = _db.FILM.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
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

        public ActionResult Search()
        {
            return View();
        }
        // GET Search
        [HttpGet]
        public async Task<ActionResult> SearchByName(string searchName)
        {
            ViewData["GetFilmByName"] = searchName;

            var query = from n in _db.FILM select n;
            if (!String.IsNullOrEmpty(searchName))
            {
                query = query.Where(n => n.NOMFILM.Contains(searchName));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        // GET Search
        [HttpGet]
        public async Task<ActionResult> SearchByCategory(string searchCategory)
        {
            ViewData["GetFilmByCategory"] = searchCategory;

            var query = from c in _db.FILM select c;
            if (!String.IsNullOrEmpty(searchCategory))
            {
                query = query.Where(c => c.CATEGORIE.Contains(searchCategory));
            }
            return View(await query.AsNoTracking().ToListAsync());

        }// GET Search
        [HttpGet]
        public async Task<ActionResult> SearchByRealisator(string searchRealisator)
        {
            ViewData["GetFilmByRealisator"] = searchRealisator;

            var query = from r in _db.FILM select r;

            if (!String.IsNullOrEmpty(searchRealisator))
            {
                query = query.Where(r => r.REALISATEUR.Contains(searchRealisator));
            }
            return View(await query.AsNoTracking().ToListAsync());

        }
        
        // GET Search
        [HttpGet]
        public async Task<ActionResult> SearchByDate(string searchDate)
        {
            ViewData["GetFilmByDate"] = searchDate;

            var query = from n in _db.FILM select n;
            if (!String.IsNullOrEmpty(searchDate))
            {
                query = query.Where(n => n.DATESORTIE.ToString().Contains(searchDate));
            }
            return View(await query.AsNoTracking().ToListAsync());
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
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FILM film = _db.FILM.Find(id);
            if(film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                FILM film = _db.FILM.Find(id);
                _db.FILM.Remove(film);
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
