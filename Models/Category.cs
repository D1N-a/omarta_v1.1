using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace omarta_v1._1.Models
{
    public class Category
    {
        public int ID { get; set; }
        public int Show { get; set; }

        [Required(ErrorMessage = "Nosaukums ir obligāts")]
        [StringLength(50, ErrorMessage = "Nosaukumam ir jābūt starp 3 un 50 simboliem", MinimumLength = 3)]

        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
    public class oMartaDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public System.Data.Entity.DbSet<omarta_v1._1.Models.Gallery> Galleries { get; set; }

        public System.Data.Entity.DbSet<omarta_v1._1.Models.Photo> Photos { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<omarta_v1._1.Models.Order> Orders { get; set; }
    }
}