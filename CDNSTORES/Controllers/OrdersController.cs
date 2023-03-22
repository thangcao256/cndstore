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

namespace CDNSTORES.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.OrderInfo).Include(o => o.Product).Include(o => o.Size);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);
            var nameorder = db.Users.Find(order.CustomerId);
            var diachiorder = db.OrderInfos.Find(order.OrderInfoId);
            var masanphamorder = db.Products.Find(order.ProductId);
            var kichcoorder = db.Sizes.Find(order.SizeId);
            order.Customer = nameorder;
            order.OrderInfo = diachiorder;
            order.Product = masanphamorder;
            order.Size = kichcoorder;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name");
            ViewBag.OrderInfoId = new SelectList(db.OrderInfos, "Id", "Place");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name");
            return View();
        }
        

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SizeId,Number,CustomerId,OrderInfoId,ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", order.CustomerId);
            ViewBag.OrderInfoId = new SelectList(db.OrderInfos, "Id", "Name", order.OrderInfoId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", order.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", order.SizeId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", order.CustomerId);
            ViewBag.OrderInfoId = new SelectList(db.OrderInfos, "Id", "Place", order.OrderInfoId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", order.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", order.SizeId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SizeId,Number,CustomerId,OrderInfoId,ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", order.CustomerId);
            ViewBag.OrderInfoId = new SelectList(db.OrderInfos, "Id", "Name", order.OrderInfoId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", order.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", order.SizeId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            var nameorder = db.Users.Find(order.CustomerId);
            var masanphamorder = db.Products.Find(order.ProductId);
            var tensanphamorder = db.Products.Find(order.ProductId);
            var hinhsanpham = db.Images.Find(order.ProductId);
            var kichcoorder = db.Sizes.Find(order.SizeId);
            var giasanpham = db.Prices.Find(order.ProductId);
            var diachiorder = db.OrderInfos.Find(order.OrderInfoId);     
            order.Customer = nameorder;
            order.Product = masanphamorder;
            order.OrderInfo = diachiorder;           
            order.Size = kichcoorder;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
