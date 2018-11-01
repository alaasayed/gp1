using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebmvcApplication22.DAL;
//using WebmvcApplication22.Models;

namespace WebmvcApplication22.Controllers
{
    //http://localhost:5870/api
    public class usersController : Controller
    {
        //   private WebmvcApplication22Context db = new WebmvcApplication22Context();
        Entities db = new Entities();
        public List<int> price1 = new List<int>();
        //[Authorize(Roles = "Admin,company,Manager")]
        public ActionResult Admin()
        {
            return RedirectToAction("Index", "stockusersController");
        }
        [AllowAnonymous]
        public ActionResult stock()
        {
            List<stockuser> stuse = new List<stockuser>();

            List<Models.Classprice> cp = new List<Models.Classprice>();
            using (var client = new HttpClient())
            {
                //db.Connection.Open();
                List<user> user1 = new List<user>();
                stuse = db.stockusers.ToList();
                int count = stuse.Count();
                client.BaseAddress = new Uri("http://localhost:5870/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP GET
               
                {
                    for (int i = 0; i < count; i++)
                    {

                        var responseTask = client.GetAsync("RanVal/1");
                        responseTask.Wait();
                        Task<string> readTask;
                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            cp.Add(new Models.Classprice() { U1 = stuse.ElementAt(i).Company, P1 = int.Parse(readTask.Result) });
                            // price1.Add(int.Parse(readTask.Result));
                        }
                        else break;
                    }
                }
                //else //web api sent error response 
                //{
                //    //log response status here..



                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }
            return View(cp);

        }
        ///GET: users
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {



            return View(db.users.ToList());
        }

        // GET: users/Details/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Fname,Lname,Phone")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: users/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Fname,Lname,Phone")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users/Delete/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
