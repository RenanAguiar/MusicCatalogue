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

        public int timeToSeconds(string time)
        {
            if (String.IsNullOrEmpty(time))
            {
                return 0;
            }
            int[] ssmmhh = { 0, 0, 0 };
            DateTime dt;
            Boolean valid = DateTime.TryParse(time, out dt);

            if (!valid)
                return 0;

            var hhmmss = time.Split(':');
            var reversed = hhmmss.Reverse();
            int i = 0;
            reversed.ToList().ForEach(x => ssmmhh[i++] = int.Parse(x));
            var seconds = (int)(new TimeSpan(ssmmhh[2], ssmmhh[1], ssmmhh[0])).TotalSeconds;
            return seconds;
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
            track.time = secondsToTime(track.duration);
            ViewBag.albumID = new SelectList(db.Album, "ID", "name", track.albumID);
            return PartialView(track);
        }








        // POST: Track/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AlbumID,title,trackNumber,duration,time")] Track track)
        {
            if (ModelState.IsValid)
            {
                track.duration = timeToSeconds(track.time);
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, data = track }, JsonRequestBehavior.AllowGet);
            }

            List<ErrorResult> Errors = new List<ErrorResult>();
            foreach (KeyValuePair<string, ModelState> modelStateDD in ViewData.ModelState)
            {
                string key = modelStateDD.Key;
                ModelState modelState = modelStateDD.Value;

                foreach (ModelError error in modelState.Errors)
                {
                    ErrorResult er = new ErrorResult();
                    er.errorMessage = error.ErrorMessage;
                    er.field = key;
                    Errors.Add(er);
                }
            }

            ViewBag.albumID = new SelectList(db.Album, "ID", "name", track.albumID);
            return Json(new { success = false, errors = Errors }, JsonRequestBehavior.AllowGet);
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

        private class ErrorResult
        {
            public string errorMessage { get; set; }
            public string field { get; set; }
        }
    }
}
