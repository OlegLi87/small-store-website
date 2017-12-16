using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

using MySmallStore.Store_Logic;
using MySmallStore.Models;
using MySmallStore.DAL;

namespace MySmallStore.Controllers
{
    [ActionAttribute]
    [ExceptionAttribute]
    public class OrdersController : Controller
    {
        StoreContext db = new StoreContext();
      
        #region Get
        // GET: Orders
        public ActionResult Index()
        {
            var customers = db.Customers.Include("Orders");

            var products = (from prod in db.Products
                            select prod).ToList<Product>();

            ViewBag.Products = products;

            return View(customers);
        }
        #endregion

        #region Remove
        public ActionResult RemoveItem(int? productId,long? passport)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Content("You Are Not Allowed To Remove Existing Product !!!");
            }

            if (productId == null && passport == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = db.Orders.Where(or => or.ProductID == productId && or.CustomerPassport == passport).FirstOrDefault();

            if (order == null)
            {
                return HttpNotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return View("Index");
        }
        #endregion

        #region Add Order
        [HttpGet]
        public ActionResult AddOrder()
        {
               if (HttpContext.User.Identity.IsAuthenticated)
               {
                List<SelectListItem> customers = new List<SelectListItem>();

                foreach (var cust in db.Customers)
                {
                    var value = cust.Passport;
                    var text = cust.FirstName + " " + cust.LastName;

                    customers.Add(new SelectListItem { Text = text, Value = value.ToString() });
                }
                ViewData["customers"] = customers;

                List<SelectListItem> products = new List<SelectListItem>();

                foreach (var prod in db.Products)
                {
                    var value = prod.ProductID;
                    var text = prod.ProductName;

                    products.Add(new SelectListItem { Text = text, Value = value.ToString() });
                }
                ViewData["products"] = products;

                return View();
               }
               else return Content("You Are Not Allowed To Create A new Order !!!");         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder([Bind(Include = "ProductID,CustomerPassport")] Order newOrder)
        {
            if (newOrder != null)
            {
                db.Orders.Add(newOrder);
                db.SaveChanges();

                var customer = db.Customers.Find(newOrder.CustomerPassport);

                ViewBag.customer = customer;

                return View("AddOrderSuccess");
            }
            else return Content("The order data is incorrect !!!");         
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