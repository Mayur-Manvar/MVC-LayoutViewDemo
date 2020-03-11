using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LayoutView.Models;

namespace LayoutView.Controllers
{
    public class EmployeeLayoutsController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: EmployeeLayouts
        public ActionResult Index()
        {
            return View(db.EmployeeLayouts.ToList());
        }

        // GET: EmployeeLayouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLayout employeeLayout = db.EmployeeLayouts.Find(id);
            if (employeeLayout == null)
            {
                return HttpNotFound();
            }
            return View(employeeLayout);
        }

        // GET: EmployeeLayouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeLayouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Salary")] EmployeeLayout employeeLayout)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLayouts.Add(employeeLayout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeLayout);
        }

        // GET: EmployeeLayouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLayout employeeLayout = db.EmployeeLayouts.Find(id);
            if (employeeLayout == null)
            {
                return HttpNotFound();
            }
            return View(employeeLayout);
        }

        // POST: EmployeeLayouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Salary")] EmployeeLayout employeeLayout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLayout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeLayout);
        }

        // GET: EmployeeLayouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLayout employeeLayout = db.EmployeeLayouts.Find(id);
            if (employeeLayout == null)
            {
                return HttpNotFound();
            }
            return View(employeeLayout);
        }

        // POST: EmployeeLayouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeLayout employeeLayout = db.EmployeeLayouts.Find(id);
            db.EmployeeLayouts.Remove(employeeLayout);
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
