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
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
}