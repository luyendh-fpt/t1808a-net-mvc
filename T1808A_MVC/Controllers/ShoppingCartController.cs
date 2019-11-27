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
            // tạo ra cart item tương ứng với product.
            var cartItem = new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity
            };
            // lấy danh sách item cũ nếu có.
            var cartItems = sc.GetCartItems();
            // đưa cart item tương ứng với sản phẩm (ở trên) vào danh sách.
            cartItems.Add(cartItem);
            // gán danh sách cart item ở trên vào cart item của shopping cart.
            sc.SetCartItems(cartItems);
            // lưu thông tin vào session.
            Session[SHOPPING_CART_NAME] = sc;
            return View();
        }

        public ActionResult ShowCart()
        {
            var shoppingCart = Session[SHOPPING_CART_NAME] as ShoppingCart;
            ViewBag.shoppingCart = shoppingCart;
            return View();
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