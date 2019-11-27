using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1808A_MVC.Models;

namespace T1808A_MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static string SHOPPING_CART_NAME = "shoppingCart";
        private T1808A_MVCContext db = new T1808A_MVCContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }

            var sc = LoadShoppingCart();
            // lấy danh sách item cũ nếu có.
            bool existItem = false;
            var cartItems = sc.GetCartItems();
            for (var i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].ProductId == productId)
                {
                    cartItems[i].Quantity += quantity;
                    existItem = true;
                }
            }
            // tạo ra cart item tương ứng với product.
            if (!existItem)
            {
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                };
                // đưa cart item tương ứng với sản phẩm (ở trên) vào danh sách.
                cartItems.Add(cartItem);
            }
            
            // gán danh sách cart item ở trên vào cart item của shopping cart.
            sc.SetCartItems(cartItems);
            // lưu thông tin vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult ShowCart()
        {
            var shoppingCart = Session[SHOPPING_CART_NAME] as ShoppingCart;
            ViewBag.shoppingCart = shoppingCart;
            return View();
        }

        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            Session[SHOPPING_CART_NAME] = shoppingCart;
        }

        private ShoppingCart LoadShoppingCart()
        {
            // lấy thông tin giỏ hàng ra.
            var sc = Session[SHOPPING_CART_NAME] as ShoppingCart;
            if (sc == null)
            {
                sc = new ShoppingCart();
            }
            return sc;
        }
    }
}