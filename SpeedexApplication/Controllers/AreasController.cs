using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedexApplication.Application;
using SpeedexApplication.Models;

namespace SpeedexApplication.Controllers
{
    public class AreasController : Controller
    {
        private SpeedexContext db = new SpeedexContext();

        // GET: Areas
        public ActionResult Index()
        {
            return View(db.Area.ToList());
        }

        // GET: Areas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            PopulateCitiesDropDownList();                       
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Area area)
        {
            if (ModelState.IsValid)
            {
                db.Area.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateCitiesDropDownList();
            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            PopulateCitiesDropDownList(area.CityId);
            return View(area);
        }

        // POST: Areas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaName,PostCode")] Area area, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var areaToBeUpdated = db.Area.Find(id);

            if (TryUpdateModel(areaToBeUpdated))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to update at the moment. Please try again later");
                }
            }

            PopulateCitiesDropDownList(areaToBeUpdated.CityId);
            return View(areaToBeUpdated);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Area area = db.Area.Find(id);
            db.Area.Remove(area);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateCitiesDropDownList(object selectedCity = null)
        {
            var GetCitiesQuery = from c in db.City orderby c.Name select c;
            ViewBag.CityId = new SelectList(GetCitiesQuery, "Id", "Name", selectedCity);
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
