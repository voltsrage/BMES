using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;
using BMES.Models.Products;

namespace BMES.Models.Cart
{
    public class CartItem:BaseObject
    {
        public long CartId { get; set; }

        public Cart Cart { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
