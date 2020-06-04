using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatPPP.Models;

namespace ProjekatPPP.Controllers
{
    public class KorisniksController : Controller
    {
        private KinotekaContext db = new KinotekaContext();

        // GET: Korisniks
        public ActionResult Index()
        {
            return View(db.Korisniks.ToList());
        }

        // GET: Korisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RedniBroj,Email,Ime,Prezime,Adresa,Šifra,TipKorisnika")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisniks.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: Korisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RedniBroj,Email,Ime,Prezime,Adresa,Šifra,PotvrdaŠifre")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                Session["Ime"] = korisnik.Ime;
                return RedirectToAction("Index", "Films");
            }
            return View(korisnik);
        }

        // GET: Korisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisniks.Find(id);
            db.Korisniks.Remove(korisnik);
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
        public ActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistracijaKorisnika([Bind(Include = "RedniBroj,Email,Ime,Prezime,Adresa,Šifra,PotvrdaŠifre,TipKorisnika")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                var podaciOKorisniku = db.Korisniks.Where(x => x.Email == korisnik.Email).SingleOrDefault();
                if (podaciOKorisniku == null)
                {
                    Korisnik noviKorisnik = korisnik;
                    db.Korisniks.Add(noviKorisnik);
                    db.SaveChanges();
                    Session["IdKorisnika"] = noviKorisnik.RedniBroj;
                    Session["Ime"] = noviKorisnik.Ime;
                    return RedirectToAction("Index", "Films");
                }
                else
                {
                    ViewBag.Greska = "Postoji korisnik sa istom Email adresom. Molimo Vas izaberite drugu.";
                    return View("Registracija");
                }
            }
            else
            {
                return View("Registracija");
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reziserizacija(Korisnik korisnik)
        {
            var podaciOKorisniku = db.Korisniks.Where(x => x.Email == korisnik.Email && x.Šifra == korisnik.Šifra).FirstOrDefault();
            if(podaciOKorisniku == null)
            {
                ViewBag.Greska = "Proverite unetu Email adresu i šifru.";
                return View("Login");
            }
            else
            {
                Session["IdKorisnika"] = podaciOKorisniku.RedniBroj;
                Session["Ime"] = podaciOKorisniku.Ime;
                return RedirectToAction("Index", "Films");
            }
        }

        public ActionResult Odjava()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
