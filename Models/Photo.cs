using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class Photo
    {
        public int ID { get; set; }

        public string ImagePath { get; set; }

        public int GalleryID { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}