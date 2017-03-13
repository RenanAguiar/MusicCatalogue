using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace MusicCatalogue.Models
{
    public enum Genre
    {
        Rock,
        [Description("R&B/ Hip Hop,")]
        RBHH,
        [Description("Dance/EDM")]
        DanceEDM,
        Pop,
        Country,
        [Description("Christian/Gospel")]
        ChristianGospel,
        [Description("Holiday/Seasonal")]
        HolidaySeasonal,
        Latin,
        Jazz,
        Classical,
        Children
    }

    public class Album
    {
        public int ID { get; set; }
        public int artistID { get; internal set; }
        public string name { get; set; }
        public string cover { get; set; }
        public int year { get; set; }
        public Genre? genre { get; set; }

        public virtual Artist Artist { get; set; }


   
        
    }
}
