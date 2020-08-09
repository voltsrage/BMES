using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMES.Services;
using BMES.ViewModels.Cart;

namespace BMES.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult CartDetail()
        {
            ViewData["CartTotal"] = _cartService.GetCartTotal();           
            ViewData["CartItemsCount"] = _cartService.CartItemsCount();
            ViewData["CartItems"] = _cartService.GetCartItems();

            return View();
        }

        [HttpPost]
        public IActionResult AddItemToCart(AddToCartViewModel addToCartViewModel)
        {
            _cartService.AddToCart(addToCartViewModel);
            if(addToCartViewModel.CategorySlug == "all-categories" && addToCartViewModel.BrandSlug == "all-brands")
            {
                return RedirectToAction("Index", "Catalogue", new { category_slug = "", brand_slug = "", page = addToCartViewModel.Page == "1" ? null : addToCartViewModel.Page });
            }
            else
            {
                return RedirectToAction("Index", "Catalogue", new { category_slug = addToCartViewModel.CategorySlug, brand_slug = addToCartViewModel.BrandSlug,
                    page = addToCartViewModel.Page == "1" ? null : addToCartViewModel.Page });
            }
            
        }

        [HttpPost]
        public IActionResult RemoveCartItem(RemoveFromCartViewModel removeFromCartViewModel)
        {
            _cartService.RemoveFromCart(removeFromCartViewModel);
            return RedirectToAction("CartDetail");
        }
    }
}