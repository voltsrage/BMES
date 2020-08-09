using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMES.Services.Implementations;
using BMES.Services;

namespace BMES.Controllers
{
    public class CatalogueController : Controller
    {
        private ICatalogService _catalogService;

        private readonly ICartService _cartService;

        public CatalogueController(ICatalogService catalogService,ICartService cartService)
        {
            _catalogService = catalogService;
            _cartService = cartService;
        }

        public IActionResult Index(string category_slug = "all-categories", string brand_slug = "all-brands")
        {
            ViewData["SelectedCategory"] = category_slug;
            ViewData["SelectedBrand"] = brand_slug;

            ViewData["CartItems"] = _cartService.GetCartItems();
            ViewData["CartItemsCount"] = _cartService.CartItemsCount();
            ViewData["CartTotal"] = _cartService.GetCartTotal();

            var pageProducts = _catalogService.FetchProducts(category_slug, brand_slug);

            ViewData["Page"] = pageProducts.PagedProducts.CurrentPage;

            return View(pageProducts);
        }
    }
}