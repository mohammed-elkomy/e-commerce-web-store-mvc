using System;
using System.Linq;
using ECommerce.Models.NewDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public RedirectResult AddToCart(int id, int quantity)
        {
            string uid = GetUid();
            var cartEntry = _context.ShopCarts.Find(new { Id = uid, ProductId = id });
            if (cartEntry == null)
            {
                if (quantity > 0)
                {
                    cartEntry = new ShopCart { Id = uid, ProductId = id, Quantity = quantity };
                    _context.ShopCarts.Add(cartEntry);
                    _context.SaveChanges();
                }
            }
            else
            {
                if (quantity > 0)
                {
                    cartEntry.Quantity = quantity;
                    _context.ShopCarts.Update(cartEntry);
                }
                else
                {
                    _context.ShopCarts.Remove(cartEntry);
                }
                _context.SaveChanges();
            }

            Response.Cookies.Append("Count", _context.ShopCarts.Count(c => c.Id==uid).ToString());
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public RedirectResult ClearCart()
        {
            string uid = GetUid();
            _context.ShopCarts.RemoveRange(_context.ShopCarts.Where(c => c.Id == uid));
            Response.Cookies.Append("Count", "0");
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public ViewResult Checkout()
        {
            var uid = GetUid();
            var products = _context.ShopCarts
                .Where(c => c.Id == uid)
                .Include(c => c.Product)
                    .ThenInclude(p => p.Images);
            return View(products.ToList());
        }

        [Authorize]
        public ViewResult Payment()
        {
            return View();
        }

        private string GetUid()
        {
            if (!Request.Cookies.TryGetValue("uid", out string uid))
            {
                uid = Guid.NewGuid().ToString();
                Response.Cookies.Append("uid", uid);
            }

            return uid;
        }
    }
}