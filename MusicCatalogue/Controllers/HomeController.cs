using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicCatalogue.DAL;
using MusicCatalogue.Models;

namespace MusicCatalogue.Controllers
{
    public class HomeController : Controller
    {
        private CatalogueContext db = new CatalogueContext();
        private const int MAX_ALBUM = 10;

        public ActionResult Index()
        {
            var artists = db.Artist.ToList();
            var albuns = db.Album.Take(MAX_ALBUM).ToList();

             

        var model = new HomeView { Artist = artists, Album = albuns };
            return View(model);
        }


        public ActionResult listAlbums(int? id)
        {
            var objController = new ArtistController();
            objController.InitializeController(this.Request.RequestContext);
            var artist = objController.Details2(id);

            var objController2 = new AlbumController();
            objController2.InitializeController(this.Request.RequestContext);
            var albums = objController2.listAlbums(id);


            var model = new HomeView { ArtistSingle = artist, Album = albums };
            return PartialView(model);
        }





        public IEnumerable<Artist> getArstists() 
        {
            IEnumerable<Artist> result = db.Artist.ToList();
            return result;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";




            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}