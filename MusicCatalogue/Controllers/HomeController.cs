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

        public ActionResult Index()
        {
            var artists = db.Artist.ToList();
            var albuns = db.Album.ToList();

            var model = new HomeView { Artist = artists, Album = albuns };
            return View(model);
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