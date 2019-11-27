using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DisplayName("Category")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}