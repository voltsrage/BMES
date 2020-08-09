using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Services.Implementations;
using BMES.Repository;
using BMES.Repository.Implementations;
using Microsoft.AspNetCore.Http;
using BMES.ViewModels.Catalogue;
using BMES.Models.Products;

namespace BMES.Services.Implementations
{
    public class CatalogService:ICatalogService
    {
        private IBrandRepository _brandRepository;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private readonly HttpContext _httpContext;
        private const int _productsPerPage = 9;

        public CatalogService(IHttpContextAccessor httpContextAccessor,
            IBrandRepository brandRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public PagedProductViewModel FetchProducts(string categorySlug, string brandSlug)
        {
            var brands = _brandRepository.GetAllBrands().Where(brand => brand.isDeleted == false);
            var categories = _categoryRepository.GetAllCategories().Where(cat => cat.isDeleted == false);

            var productPage = GetCurrentPage();

            IEnumerable<Product> products = new List<Product>();
            int productCount = 0;

            if (categorySlug == "all-categories" && brandSlug == "all-brands")
            {
                productCount = _productRepository.GetAllProducts().Count();
                products = _productRepository.GetAllProducts()
                    .Where(product => product.ProductStatus == ProductStatus.Active)
                    .Skip((productPage - 1) * _productsPerPage)
                    .Take(_productsPerPage);
            }

            if (categorySlug != "all-categories" && brandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                    .Where(product => product.ProductStatus == ProductStatus.Active &&
                                      product.Category.Slug == categorySlug &&
                                      product.Brand.Slug == brandSlug);

                productCount = filteredProducts.Count();

                products = filteredProducts.Skip((productPage - 1) * _productsPerPage)
                    .Take(_productsPerPage);

            }

            if (categorySlug != "all-categories" && brandSlug == "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                    .Where(product => product.ProductStatus == ProductStatus.Active &&
                                      product.Category.Slug == categorySlug);

                productCount = filteredProducts.Count();

                products = filteredProducts.Skip((productPage - 1) * _productsPerPage)
                    .Take(_productsPerPage);
            }

            if (categorySlug == "all-categories" && brandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                    .Where(product => product.ProductStatus == ProductStatus.Active &&
                                      product.Brand.Slug == brandSlug);

                productCount = filteredProducts.Count();

                products = filteredProducts.Skip((productPage - 1) * _productsPerPage)
                    .Take(_productsPerPage);
            }

            var totalPages = (int)Math.Ceiling((decimal)productCount / _productsPerPage);

            int[] pages = Enumerable.Range(1, totalPages).ToArray();

            var pagedProduct = new PaginationViewModel
            {
                Products = products,
                HasPreviousPages = (productPage > 1),
                CurrentPage = productPage,
                HasNextPages = (productPage < totalPages),
                Pages = pages
            };

            var pagedProducts = new PagedProductViewModel
            {
                PagedProducts = pagedProduct,
                Brands = brands,
                Categories = categories
            };

            return pagedProducts;
        }

        public int GetCurrentPage()
        {
            var defaultPage = 1;

            if(_httpContext.Request.Path.HasValue)
            {
                var pathValues = _httpContext.Request.Path.Value.Split(separator: '/');
                var pageFragment = pathValues[pathValues.Length - 1];

                if(!string.IsNullOrWhiteSpace(pageFragment))
                {
                    var pageNumber = pageFragment.Last().ToString();
                    defaultPage = Convert.ToInt32(pageNumber);
                }
            }
            return defaultPage;
        }
    }
}
