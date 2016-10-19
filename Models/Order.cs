using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace omarta_v1._1.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public virtual Products Product { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TakeDate { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }

    }
}