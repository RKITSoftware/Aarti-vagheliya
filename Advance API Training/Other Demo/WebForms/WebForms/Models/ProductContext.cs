using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebForms.Models;
using MySql.Data;

namespace WebForms.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ConnectionString")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}