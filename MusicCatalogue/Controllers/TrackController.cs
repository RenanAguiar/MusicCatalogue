using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCatalogue.DAL;

namespace MusicCatalogue.Models
{
    public class TrackController : Controller
    {
        private CatalogueContext db = new CatalogueContext();

        public String secondsToTime(int seconds)
        {
            string value;
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            
            if(seconds < 3600)
            {
                value = time.ToString(@"mm\:ss");
            }
            else
            {
                value = time.ToString(@"hh\:mm\:ss");
            }
            
            return value;
        }

        [ChildActionOnly]
        public ActionResult listTracks(int? id)
        {
            // var track = db.Track.Include(a => a.albumID);
            var track = db.Track
                .Where(u => u.albumID == id);
                //.ToList();

            foreach (var item in track)
            {
                item.time = secondsToTime(item.duration);
            }
                return PartialView("listTracks", track.ToList());
        }

        // GET: Track
        public ActionResult Index()
        {
            var track = db.Track.Include(t => t.Album);
            return View(track.ToList());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Track.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            ViewBag.albumID = new SelectList(db.Album, "ID", "name");
            return View();
        }

        // POST: Track/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,albumID,title,trackNumber,duration")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Track.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.albumID = new SelectList(db.Album, "ID", "name", track.albumID);
            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Track.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.albumID = new SelectList(db.Album, "ID", "name", track.albumID);
            return PartialView(track);
        }

        // POST: Track/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,albumID,title,trackNumber,duration")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.albumID = new SelectList(db.Album, "ID", "name", track.albumID);
            return View(track);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Track.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return PartialView(track);
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
      //  [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var response = new
            {
                status = "success",
                id = id
            };
            Track track = db.Track.Find(id);
            db.Track.Remove(track);
            db.SaveChanges();

            return Json(response, JsonRequestBehavior.AllowGet);
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
