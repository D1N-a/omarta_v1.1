using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e

namespace omarta_v1._1.Models
{
    public class Gallery
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nosaukums ir obligāts")]
        public string Name { get; set; }
<<<<<<< HEAD

=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
        public string Cover { get; set; }
    }
}