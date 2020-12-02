 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class studentsController : Controller
    {
        private coursesEntities db = new coursesEntities();

        // GET: students
        public async Task<ActionResult> Index()
        {
            var student = db.student.Include(s => s.course);
            return View(await student.ToListAsync());
        }

        // GET: students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = await db.student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.course, "course_id", "course_name");
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "student_id,student_name,student_age,course_id")] student student)
        {
            if (ModelState.IsValid)
            {
                db.student.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.course, "course_id", "course_name", student.course_id);
            return View(student);
        }

        // GET: students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = await db.student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.course, "course_id", "course_name", student.course_id);
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "student_id,student_name,student_age,course_id")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.course, "course_id", "course_name", student.course_id);
            return View(student);
        }

        // GET: students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = await db.student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            student student = await db.student.FindAsync(id);
            db.student.Remove(student);
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
