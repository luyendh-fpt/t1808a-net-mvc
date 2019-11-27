using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}