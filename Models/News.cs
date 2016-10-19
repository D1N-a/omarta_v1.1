using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class News
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Ziņas status ir obligāts")]
        public int Show { get; set; }

        [Required(ErrorMessage = "Datums ir obligāts")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Newsdate { get; set; }

        [Required(ErrorMessage = "Virsraksts ir obligāts")]
        public string Title { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Teksts ir obligāts")]
        public string Text { get; set; }
    }
}