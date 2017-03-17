using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCatalogue.DAL;
using MusicCatalogue.Models;
using System.Web.Routing;

namespace MusicCatalogue.Controllers
{
    public class ArtistController : Controller
    {
        private CatalogueContext db = new CatalogueContext();

        public void InitializeController(RequestContext context)
        {
            base.Initialize(context);
        }

        // GET: Artist
        public ActionResult Index()
        {
            return View(db.Artist.ToList());
        }



        //public ActionResult listAlbums(int? id)
        //{
        //    var objController = new AlbumController();
        //    objController.InitializeController(this.Request.RequestContext);
        //    var albums = objController.listAlbums(id);

        //    Artist artist = db.Artist.Find(id);
        //    artist.Album = albums;

        //    return PartialView("listAlbums", artist);
        //}











        public Artist Details2(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return null;
            }
            return artist;
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }


          //  var controllerB = new ControllerB();
           // controllerB.InitializeController(this.Request.RequestContext);


            var objController = new AlbumController();
            objController.InitializeController(this.Request.RequestContext);
            var albums = objController.listAlbums2(id);

            var response = new
            {
                artist = artist,
                albums = albums
            };

            return Json(response, JsonRequestBehavior.AllowGet);
            // return PartialView(artist);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artist.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artist.Find(id);
            db.Artist.Remove(artist);
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
