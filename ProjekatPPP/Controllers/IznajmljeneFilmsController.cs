using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatPPP.Models;
using PagedList;

namespace ProjekatPPP.Controllers
{
    public class IznajmljeneFilmsController : Controller
    {
        private KinotekaContext db = new KinotekaContext();

        // GET: IznajmljeneFilms
        public ActionResult Index(int? strana)
        {
            var brojStrane = strana ?? 1;
            var velicinaStrane = 5;
            var iznajmljeneFilme = db.IznajmljeneFilms.OrderBy(i => i.RedniBrojIznajmljivanja).ToPagedList(brojStrane, velicinaStrane);
            return View(iznajmljeneFilme);
        
        }

        // GET: IznajmljeneFilms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IznajmljeneFilm iznajmljeneFilma = db.IznajmljeneFilms.Find(id);
            if (iznajmljeneFilma == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljeneFilma);
        }

        // GET: IznajmljeneFilms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IznajmljeneFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RedniBrojIznajmljivanja,RedniBrojČlana,SifraFilma,Naziv,Reziser,Datum,Kolicina")] IznajmljeneFilm iznajmljeneFilma)
        {
            if (ModelState.IsValid)
            {
                db.IznajmljeneFilms.Add(iznajmljeneFilma);
                db.SaveChanges();
                return RedirectToAction("Index", "IznajmljeneFilms");
            }

            return View(iznajmljeneFilma);
        }

        // GET: IznajmljeneFilms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IznajmljeneFilm iznajmljeneFilma = db.IznajmljeneFilms.Find(id);
            if (iznajmljeneFilma == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljeneFilma);
        }

        // POST: IznajmljeneFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RedniBrojIznajmljivanja,RedniBrojČlana,SifraFilma,Naziv,Reziser,Datum,Kolicina")] IznajmljeneFilm iznajmljeneFilma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iznajmljeneFilma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iznajmljeneFilma);
        }

        // GET: IznajmljeneFilms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IznajmljeneFilm iznajmljeneFilma = db.IznajmljeneFilms.Where(i => i.RedniBrojIznajmljivanja == id).FirstOrDefault();
            if (iznajmljeneFilma == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljeneFilma);
        }

        // POST: IznajmljeneFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IznajmljeneFilm iznajmljeneFilma = db.IznajmljeneFilms.Where(i => i.RedniBrojIznajmljivanja == id).FirstOrDefault();
            db.IznajmljeneFilms.Remove(iznajmljeneFilma);
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
        public ActionResult Rezervacija(int id)
        {
            Film film = db.Films.Find(id);

            IznajmljeneFilm iznamljivanje = new IznajmljeneFilm();

            iznamljivanje.SifraFilma = film.SifraFilma;
            iznamljivanje.RedniBrojČlana = (int)Session["IdKorisnika"];
            iznamljivanje.Naziv = film.Naziv;
            iznamljivanje.Reziser = film.Reziser;
            iznamljivanje.Datum = DateTime.Now;
            iznamljivanje.Kolicina = 1;

            try
            {
                db.IznajmljeneFilms.Add(iznamljivanje);
                db.SaveChanges();
                return RedirectToAction("Index", "IznajmljeneFilms");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
