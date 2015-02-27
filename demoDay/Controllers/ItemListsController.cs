using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demoDay.Models;

namespace demoDay.Controllers
{
    public class ItemListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemLists
        public ActionResult Index()
        {
            return View(db.ItemLists.ToList());
        }

        // GET: ItemLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            return View(itemList);
        }

        // GET: ItemLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Observations")] ItemList itemList)
        {
            if (ModelState.IsValid)
            {
                db.ItemLists.Add(itemList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemList);
        }

        // GET: ItemLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            return View(itemList);
        }

        // POST: ItemLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Observations")] ItemList itemList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemList);
        }

        // GET: ItemLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            return View(itemList);
        }

        // POST: ItemLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            db.ItemLists.Remove(itemList);
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
