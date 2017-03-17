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
using System.IO;

namespace MusicCatalogue.Controllers
{
    public class AlbumController : Controller
    {
        private const string PATH = "/cover/";
        private CatalogueContext db = new CatalogueContext();

        public void InitializeController(RequestContext context)
        {
            base.Initialize(context);
        }

        public ActionResult listAlbums2(int? id)
        {
            var album = db.Album
            .Where(u => u.artistID == id)
            .ToList();
            
            foreach (var item in album)
            {
                if (!System.IO.File.Exists(Server.MapPath("~"+PATH + item.cover)))
                {
                    item.cover = PATH + "default.png";
                }
                else
                {
                    item.cover = PATH + item.cover;
                }
            }

            album.ToList();
            return Json(album, JsonRequestBehavior.AllowGet);
            // return PartialView("listAlbums", album.ToList());
        }











        public List<Album> listAlbums(int? id)
       // public ActionResult listAlbums(int? id)
        {
            // var track = db.Track.Include(a => a.albumID);
            var album = db.Album
                .Where(u => u.artistID == id)
            .ToList();
            foreach (var item in album)
            {

                if (!System.IO.File.Exists(Server.MapPath("~" + PATH + item.cover)))
                {
                    item.cover = PATH + "default.png";
                }
                else
                {
                    item.cover = PATH + item.cover;
                }
            }
            return album;
          // return PartialView("listAlbums", album.ToList());
        }




        // GET: Album
        public ActionResult Index()
        {
            var album = db.Album.Include(a => a.Artist);
            foreach (var item in album)
            {
               // string cover = PATH + item.cover;
                if (!System.IO.File.Exists(Server.MapPath("~" + PATH + item.cover)))
                {
                    item.cover = PATH + "default.png";
                }
                else
                {
                    item.cover = PATH + item.cover;
                }
            }
            

            return View(album.ToList());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            if (!System.IO.File.Exists(Server.MapPath("~" + PATH + album.cover)))
            {
                album.cover = PATH + "default.png";
            }
            else
            {
                album.cover = PATH + album.cover;
            }
            return PartialView("Details", album);
        }

        // GET: Album/Create
        public ActionResult Create(int id)
        {

            Album album = new Album();
            album.artistID = id;

            return PartialView(album);
        }

        private class ErrorResult
        {
            public string errorMessage { get; set; }
            public string field { get; set; }
        }
        // POST: Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "artistID,name,year,genre")] Album album)
        {

            if (ModelState.IsValid)
            { 
                db.Album.Add(album);
                db.SaveChanges();

                return Json(new { success = true, data = album.artistID }, JsonRequestBehavior.AllowGet);
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

            return Json(new { success = false, errors = Errors }, JsonRequestBehavior.AllowGet);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.artistID = new SelectList(db.Artist, "ID", "name", album.artistID);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,artistID,name,year,genre")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.artistID = new SelectList(db.Artist, "ID", "name", album.artistID);
            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Album.Find(id);
            db.Album.Remove(album);
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



        public ActionResult UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string ext = Path.GetExtension(hpf.FileName);
                string newName = Guid.NewGuid().ToString().Replace("-", "")+ext;
                string savedFileName = Path.Combine(
                   AppDomain.CurrentDomain.BaseDirectory+"cover/",
                   Path.GetFileName(newName));
                hpf.SaveAs(savedFileName);

                r.Add(new ViewDataUploadFilesResult()
                {
                    Name = savedFileName,
                    Name2 = hpf.FileName,
                    Length = hpf.ContentLength
                });
            }
            return Json(new { success = false, r=r }, JsonRequestBehavior.AllowGet);
        }

        public class ViewDataUploadFilesResult
        {
            public string Name { get; set; }
            public string Name2 { get; set; }
            public int Length { get; set; }
        }
    }
}
