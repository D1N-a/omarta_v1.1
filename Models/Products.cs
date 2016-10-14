using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class Products
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nosaukums ir obligāts")]
        [StringLength(50, ErrorMessage = "Nosaukumam ir jābūt starp 3 un 50 simboliem", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pārdošanās cena ir obligāta")]
        public double SalesPrice { get; set; }

        [Required(ErrorMessage = "Iepirkšanas cena ir obligāta")]
        public double BuyPrice { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Produktu skaits ir obligāts")]
        [Range(0, 1000, ErrorMessage = "Skaitam ir jābūt starp 1 un 1000")]
        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastChange { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}