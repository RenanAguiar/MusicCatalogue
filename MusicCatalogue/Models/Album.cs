using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace MusicCatalogue.Models
{
    public enum Genre
    {
        Rock,
        [Display(Name = "R&B/ Hip Hop,")]
        RBHH,
        [Display(Name = "Dance/EDM")]
        DanceEDM,
        Pop,
        Country,
        [Display(Name = "Christian/Gospel")]
        ChristianGospel,
        [Display(Name = "Holiday/Seasonal")]
        HolidaySeasonal,
        Latin,
        Jazz,
        Classical,
        Children
    }

    public class Album
    {
        public int ID { get; set; }
        public int artistID { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public string name { get; set; }
        [Display(Name = "Cover Image")]
        public string cover { get; set; }
        [Display(Name = "Year")]
        public int year { get; set; }
        [Display(Name = "Genre")]
        public Genre? genre { get; set; }

        public virtual Artist Artist { get; set; }

        [NotMapped]
        public virtual List<Track> Track { get; set; }


    }
}
