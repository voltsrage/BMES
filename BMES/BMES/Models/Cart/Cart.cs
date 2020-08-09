using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;


namespace BMES.Models.Cart
{
    public class Cart:BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public string UniqueCartId { get; set; }

        public CartStatus CartStatus { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
