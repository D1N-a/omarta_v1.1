using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace omarta_v1._1.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public virtual Products Product { get; set; }
        [Required(ErrorMessage = "Teksts ir obligāts")]
        public string Text { get; set; }

        public string Author { get; set; }
        public int Status { get; set; }

        public string ImagePath { get; set; }
    }
}