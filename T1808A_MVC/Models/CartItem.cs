﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}