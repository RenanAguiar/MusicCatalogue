using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalogue.Models
{
    public class HomeView
    {
        public IEnumerable<Artist> Artist { get; set; }
        public IEnumerable<Album> Album { get; set; }
    }
}