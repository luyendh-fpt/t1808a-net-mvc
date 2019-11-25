﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}