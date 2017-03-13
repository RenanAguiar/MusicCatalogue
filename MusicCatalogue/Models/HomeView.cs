using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalogue.Models
{
    public class HomeView
    {
        public List<Artist> Artist { get; set; }
        public List<Album> Album { get; set; }
    }
}