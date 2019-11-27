using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class T1808A_MVCContext2 : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public T1808A_MVCContext2() : base("name=T1808A_MVCContext2")
        {
        }

        public System.Data.Entity.DbSet<T1808A_MVC.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<T1808A_MVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<T1808A_MVC.Models.OtherClass> OtherClasses { get; set; }

        public System.Data.Entity.DbSet<T1808A_MVC.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<T1808A_MVC.Models.ProductCategory> ProductCategories { get; set; }
    }
}
