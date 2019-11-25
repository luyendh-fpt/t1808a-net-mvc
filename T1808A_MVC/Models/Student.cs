using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Roll number")]
        public string RollNumber { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}