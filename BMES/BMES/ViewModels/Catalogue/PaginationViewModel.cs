using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Products;

namespace BMES.ViewModels.Catalogue
{
    public class PaginationViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public bool HasPreviousPages { get; set; }

        public int CurrentPage { get; set; }

        public bool HasNextPages { get; set; }

        public int[] Pages { get; set; }
    }
}
