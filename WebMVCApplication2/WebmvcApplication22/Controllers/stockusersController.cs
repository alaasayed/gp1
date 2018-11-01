using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebmvcApplication22.DAL;

namespace WebmvcApplication22.Controllers
{
   // [Authorize(Roles = "Admin,Manager")]
    public class stockusersController : Controller
    {
        private Entities db = new Entities();

        // GET: stockusers
        public ActionResult Index()
        {
            return View(db.stockusers.ToList());
        }

        // GET: stockusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockuser stockuser = db.stockusers.Find(id);
            if (stockuser == null)
            {
                return HttpNotFound();
            }
            return View(stockuser);
        }

        // GET: stockusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stockusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Price1,Company")] stockuser stockuser)
        {
            if (ModelState.IsValid)
            {
                db.stockusers.Add(stockuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockuser);
        }

        // GET: stockusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockuser stockuser = db.stockusers.Find(id);
            if (stockuser == null)
            {
                return HttpNotFound();
            }
            return View(stockuser);
        }

        // POST: stockusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Price1,Company")] stockuser stockuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockuser);
        }

        // GET: stockusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockuser stockuser = db.stockusers.Find(id);
            if (stockuser == null)
            {
                return HttpNotFound();
            }
            return View(stockuser);
        }

        // POST: stockusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stockuser stockuser = db.stockusers.Find(id);
            db.stockusers.Remove(stockuser);
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
    }
}
