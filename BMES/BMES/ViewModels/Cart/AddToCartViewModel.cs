using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES.ViewModels.Cart
{
    public class AddToCartViewModel
    {
        public long ProductId { get; set; }

        public string CategorySlug { get; set; }

        public string BrandSlug { get; set; }

        public string Page { get; set; }
    }
}
