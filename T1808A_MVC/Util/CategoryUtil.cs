using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T1808A_MVC.Models;

namespace T1808A_MVC.Util
{
    public class CategoryUtil
    {

        private static T1808A_MVCContext db = new T1808A_MVCContext();
        private static List<Category> _listCategories;

        public static List<Category> GetCategories()
        {
            return _listCategories ?? (_listCategories = db.Categories.ToList());
        }
    }
}