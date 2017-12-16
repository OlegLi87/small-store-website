using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySmallStore.DAL;
using MySmallStore.Models;
using MySmallStore.Store_Logic;

namespace MySmallStore.Controllers
{
    [ActionAttribute]
    [ExceptionAttribute]
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();

        #region HomePage
        public ActionResult Index()
        {
            ViewBag.Youngest = HomePage.GetYoungestCustomer();

            var activeProducts = db.Products.Where(p => p.Active == true);
            return View(activeProducts);
        }
        #endregion

        #region GetAllProducts
        // GET: Products
        public ActionResult Products()
        {
            var products = db.Products;
            return View(products);
        }
        #endregion

        #region Create New Product
        // GET: Products/Create
        public ActionResult Create()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Content("You Are Not Allowed To Create A new Product !!!");
            }
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,Desc,Active")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Products");
            }

            return View(product);
        }
        #endregion

        #region Edit
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Content("You Are Not Allowed To Edit Existing Product!!!");
            }

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

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Price,Desc,Active")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }
        #endregion

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
