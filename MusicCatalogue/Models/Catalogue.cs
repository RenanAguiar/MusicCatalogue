using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalogue.Models
{
    public class Catalogue
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public int albumID { get; set; }

        public virtual Album Album { get; set; }
    }
    
}