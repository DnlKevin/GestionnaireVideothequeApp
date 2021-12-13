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
    public class ClientController : Controller
    {
        private GestionnaireVideothequeDBEntities _db = new GestionnaireVideothequeDBEntities();

        public object EXEMPLAIREID { get; private set; }
        public int CLIENTID { get; private set; }

        // GET Films loués par un client
        [HttpGet]
        public async Task<ActionResult> LocParClient(string id)
        {
            // Requête SQL pour la 4 :
            // SELECT* FROM EXEMPLAIRES 
            //  WHERE ExemplaireId IN
            // (SELECT ExemplaireId FROM LOCATIONS WHERE ClientId LIKE<ClientId passé en paramètre>)
            ViewData["GetLocParClient"] = id;

            var query =
                (from EXEMPLAIRE in _db.LOCATION
                 where EXEMPLAIREID != null
                 select EXEMPLAIRE);

            var query2 =
                (from LOCATION in _db.LOCATION
                 where CLIENTID.ToString() == id
                 select CLIENTID);
                  
        if(query != query2)
            {
                System.Console.WriteLine("Ce client n'a pas de locations");
                return View(await query.AsNoTracking().ToListAsync());

            } else
            {
                return View(await query.AsNoTracking().ToListAsync());
            }
        }

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
            catch 
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
