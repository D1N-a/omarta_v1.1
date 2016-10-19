using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7

namespace omarta_v1._1.Models
{
    public class Gallery
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nosaukums ir obligāts")]
        public string Name { get; set; }
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
        public string Cover { get; set; }
    }
}