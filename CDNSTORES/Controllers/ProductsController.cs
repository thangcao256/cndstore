using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CDNSTORES.Models;
using CDNSTORES.Models.CDNSTORES;

namespace CDNSTORES.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET ALL PRODUCTS
        public ActionResult Index(string searching)
        {
            
            var products = db.Products.Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }

        public ActionResult StatusProduct(int id)
        {
            var products = db.Products.Where(a => a.StatusId == id).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }
        public ActionResult Material(int id)
        {
            var products = db.Products.Where(a=>a.MaterialId == id).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }

        public ActionResult Color(int id)
        {
            var products = db.Products.Where(a => a.ColorId == id).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }

        public ActionResult Price(int id)
        {
            var products = db.Products.Where(p => p.PriceId == id || p.PriceId == (id+1)).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);

            return View(products.ToList());
        }
        //
        public ActionResult Sort()
        {
             var products = db.Products.OrderBy(p => p.PriceId).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }
        public ActionResult SortDes()
        {
            var products = db.Products.OrderByDescending(p => p.PriceId).Include(p => p.Color).Include(p => p.Images).Include(p => p.Material).Include(p => p.Price).Include(p => p.Status);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var colorofproduct = db.Colors.Find(product.ColorId);
            var imageofproduct = db.Images.Find(product.ImagesId);
            var materialofShow = db.Materials.Find(product.MaterialId);
            var priceofShow = db.Prices.Find(product.PriceId);
            var statusofShow = db.Statuses.Find(product.StatusId);
            product.Color = colorofproduct;
            product.Images = imageofproduct;
            product.Material = materialofShow;
            product.Price = priceofShow;
            product.Status = statusofShow;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            ViewBag.ImagesId = new SelectList(db.Images, "Id", "Picture1");
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name");
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImagesId,ColorId,MaterialId,PriceId,StatusId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.ImagesId = new SelectList(db.Images, "Id", "Picture1", product.ImagesId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", product.PriceId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", product.StatusId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.ImagesId = new SelectList(db.Images, "Id", "Picture1", product.ImagesId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", product.PriceId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", product.StatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImagesId,ColorId,MaterialId,PriceId,StatusId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.ImagesId = new SelectList(db.Images, "Id", "Picture1", product.ImagesId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", product.PriceId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", product.StatusId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
        public ActionResult SearchByName(string name)
        {
            //dua tu khoa vao viewbag
            ViewBag.key = name;
            //truy van cac san pham co ten chua tu khoa name
            List<Product> plist = db.Products.Where(x => x.Name.StartsWith(name)).ToList();
            return View(plist);
        }
    }
}
