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

        public CatalogueController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index(string category_slug = "all-categories", string brand_slug = "all-brands")
        {
            ViewData["SelectedCategory"] = category_slug;
            ViewData["SelectedBrand"] = brand_slug;

            var pageProducts = _catalogService.FetchProducts(category_slug, brand_slug);

           

            return View(pageProducts);
        }
    }
}