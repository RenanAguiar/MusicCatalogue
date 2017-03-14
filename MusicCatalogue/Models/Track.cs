using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicCatalogue.Models
{
    public class Track
    {
        public int ID { get; set; }
        public int albumID { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Minimum 1 character required")]
        public string title { get; set; }
        [Display(Name = "#")]
        public int trackNumber { get; set; }
        [Display(Name = "Duration")]
        public int duration { get; set; }

        public virtual Album Album { get; set; }

        [NotMapped]
        public string time { get; set; }
    }
}