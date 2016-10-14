using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class Sales
    {
        public int ID { get; set; }

        public int ProductID { get; set; }
        public virtual Products Product { get; set; }

        [Required(ErrorMessage = "Datums ir obligāts")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Salesdate { get; set; }

        [Required(ErrorMessage = "Produktu skaits ir obligāts")]
        [Range(0, 1000, ErrorMessage = "Skaitam ir jābūt starp 1 un 1000")]
        public int Quantity { get; set; }
    }
}