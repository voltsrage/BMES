using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Products;

namespace BMES.ViewModels.Catalogue
{
    public class PagedProductViewModel
    {
        public PaginationViewModel PagedProducts { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
