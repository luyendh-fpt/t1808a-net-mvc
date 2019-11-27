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
            // Check số lượng có hợp lệ không?
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            // Check sản phẩm có hợp lệ không?
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.AddCart(product, quantity);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            // Check số lượng có hợp lệ không?
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            // Check sản phẩm có hợp lệ không?
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.UpdateCart(product, quantity);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult RemoveCart(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.RemoveFromCart(product.Id);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult ShowCart()
        {
            ViewBag.shoppingCart = LoadShoppingCart();
            return View();
        }

        public ActionResult CreateOrder()
        {
            // load cart trong session.
            // Chuyển shopping cart thành order và order detail.
            // lưu vào database.
            return Redirect("/Products");
        }

        /**
         * Tham số nhận vào là một đối tượng shopping cart.
         * Hàm sẽ lưu đối tượng vào session với key được define từ trước.
         */
        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            Session[SHOPPING_CART_NAME] = shoppingCart;
        }

        /**
         * Lấy thông tin shopping cart từ trong session ra. Trong trường hợp không tồn tại
         * trong session thì tạo mới đối tượng shopping cart.
         */
        private ShoppingCart LoadShoppingCart()
        {
            // lấy thông tin giỏ hàng ra.
            if (!(Session[SHOPPING_CART_NAME] is ShoppingCart sc))
            {
                sc = new ShoppingCart();
            }
            return sc;
        }
    }
}