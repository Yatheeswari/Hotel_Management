using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruYumMVCExercise.Models;

namespace TruYumMVCExercise.Controllers
{
    public class MenuItemController : Controller
    {
        private TruYumContext db = new TruYumContext();
        Category category = new Category();
        List<SelectListItem> CategoryList = new List<SelectListItem>()

        {

            new SelectListItem(){Value="Starters",Text="Starters"},

            new SelectListItem(){Value="Main Course",Text="Main Course"},

            new SelectListItem(){Value="Dessert",Text="Dessert"},


        };
        // GET: MenuItem
        public ActionResult Index()
        {
            return View(db.MenuItems.ToList());
        }

        // GET: MenuItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItem/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        // POST: MenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemName,Price,Active,DateOfLaunch,CategoryName,FreeDelivery")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuItem);
        }

        // GET: MenuItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryList = CategoryList;
            return View(menuItem);
        }

        // POST: MenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,Price,Active,DateOfLaunch,CategoryName,FreeDelivery")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }

        // GET: MenuItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Customer()
        {
            var z = db.MenuItems.ToList();
            var d = DateTime.Now;
            List<MenuItem> li = new List<MenuItem>();
            foreach (MenuItem m in z)
            {
                if (m.Active == true)
                {
                    li.Add(m);
                }
            }
            return View(li);
        }
        public ActionResult AddToCart(int id)
        {
            var q = db.MenuItems.Single(x => x.ItemId == id);
            Cart kart = new Cart();
            kart.ItemName = q.ItemName;
            kart.FreeDelivery = q.FreeDelivery;
            kart.Price = q.Price;
            db.Carts.Add(kart);
            db.SaveChanges();
            return RedirectToAction("Customer", "MenuItem");
        }
        public ActionResult Cart()
        {
            return View(db.Carts.ToList());
        }
        public ActionResult DeleteCart(int id)
        {
            var q = db.Carts.Single(x => x.CartId == id);
            db.Carts.Remove(q);
            db.SaveChanges();
            return RedirectToAction("Cart", "MenuItem");
        }

        public ActionResult Payment()
        {
            
            var k = (from p in db.Carts select p.Price).Sum();
            ViewBag.amount = k;
            return View();
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
