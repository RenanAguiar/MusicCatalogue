using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalogue.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string name { get; set; }

        [NotMapped]
        public virtual List<Album> Album { get; set; }
    }
}