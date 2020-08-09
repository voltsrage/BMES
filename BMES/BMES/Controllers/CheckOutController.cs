using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMES.Services;
using BMES.ViewModels.CheckOut;

namespace BMES.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ICheckOutService _checkOutService;
        private readonly ICartService _cartService;

        public CheckOutController(ICheckOutService checkOutService,ICartService cartService)
        {
            _checkOutService = checkOutService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            ViewData["CartTotal"] = _cartService.GetCartTotal();
            ViewData["CartItemsCount"] = _cartService.CartItemsCount();
            ViewData["CartItems"] = _cartService.GetCartItems();
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(CheckoutViewModel checkoutViewModel)
        {
            _checkOutService.ProcessCheckout(checkoutViewModel);
            return RedirectToAction("Receipt");
        }

        public IActionResult Receipt()
        {
            return View();
        }
    }
}