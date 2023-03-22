using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CDNSTORES.Models;
using CDNSTORES.Models.CDNSTORES;

namespace CDNSTORES.Areas.Admin.Controllers
{
    public class OrderInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/OrderInfoes
        public ActionResult Index()
        {
            return View(db.OrderInfos.ToList());
        }

        // GET: Admin/OrderInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // GET: Admin/OrderInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Place")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.OrderInfos.Add(orderInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderInfo);
        }

        // GET: Admin/OrderInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: Admin/OrderInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Place")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderInfo);
        }

        // GET: Admin/OrderInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: Admin/OrderInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            db.OrderInfos.Remove(orderInfo);
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
