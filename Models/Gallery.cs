using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class Gallery
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nosaukums ir obligāts")]
        public string Name { get; set; }
        public string Cover { get; set; }
    }
}