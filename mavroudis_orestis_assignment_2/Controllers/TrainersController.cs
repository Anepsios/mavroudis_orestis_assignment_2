using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mavroudis_orestis_assignment_2.Data;
using mavroudis_orestis_assignment_2.Models;

namespace mavroudis_orestis_assignment_2.Controllers
{
    public class TrainersController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Trainers
        public async Task<ActionResult> Index(string sortOrder, string selectedSubject)
        {
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var trainers = from x in db.Trainers select x;
            if (sortOrder == "name_desc")
                trainers = trainers.OrderByDescending(x => x.LastName);
            else
                trainers = trainers.OrderBy(x => x.LastName);

            var subjects = (from t in trainers select t.Subject).Distinct();
            ViewBag.selectedSubject = new SelectList(subjects);
            if (!String.IsNullOrEmpty(selectedSubject))
            {
                Enum.TryParse(selectedSubject, out Subject subject);
                trainers = db.Trainers.Where(x => x.Subject == subject)
                    .OrderBy(x => x.LastName);
            }

            return View(await trainers.ToListAsync());
        }

        // GET: Trainers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,LastName,Subject")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,Subject")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            db.Trainers.Remove(trainer);
            await db.SaveChangesAsync();
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
