using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1808A_MVC.Models
{
    public class ShoppingCart
    {
        private List<CartItem> _cartItems;
        public double TotalPrice { get; set; }

        public List<CartItem> GetCartItems()
        {
            if (_cartItems == null)
            {
                _cartItems = new List<CartItem>();
            }
            return _cartItems;
        }

        public void SetCartItems(List<CartItem> cartItems)
        {
            this._cartItems = cartItems;
        }

    }
}