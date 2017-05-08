using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScruffyNerfHerderSabers.DAL;
using ScruffyNerfHerderSabers.Models;

namespace ScruffyNerfHerderSabers.Controllers
{
    public class DepartmentAssignmentController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: DepartmentAssignment
        public ActionResult Index()
        {
            var departmentAssignments = db.DepartmentAssignments.Include(d => d.Employee);
            return View(departmentAssignments.ToList());
        }

        // GET: DepartmentAssignment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentAssignment departmentAssignment = db.DepartmentAssignments.Find(id);
            if (departmentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(departmentAssignment);
        }

        // GET: DepartmentAssignment/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName");
            return View();
        }

        // POST: DepartmentAssignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Location")] DepartmentAssignment departmentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentAssignments.Add(departmentAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", departmentAssignment.EmployeeID);
            return View(departmentAssignment);
        }

        // GET: DepartmentAssignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentAssignment departmentAssignment = db.DepartmentAssignments.Find(id);
            if (departmentAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", departmentAssignment.EmployeeID);
            return View(departmentAssignment);
        }

        // POST: DepartmentAssignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Location")] DepartmentAssignment departmentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", departmentAssignment.EmployeeID);
            return View(departmentAssignment);
        }

        // GET: DepartmentAssignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentAssignment departmentAssignment = db.DepartmentAssignments.Find(id);
            if (departmentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(departmentAssignment);
        }

        // POST: DepartmentAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentAssignment departmentAssignment = db.DepartmentAssignments.Find(id);
            db.DepartmentAssignments.Remove(departmentAssignment);
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
