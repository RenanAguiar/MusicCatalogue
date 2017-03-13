using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalogue.Models
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string nickName { get; set; }
    }
}