using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Cart;
using BMES.ViewModels.Cart;

namespace BMES.Services
{
    public interface ICartService
    {
        string UniqueCartId();
        Cart GetCart();
        void AddToCart(AddToCartViewModel addToCartViewModel);
        void RemoveFromCart(RemoveFromCartViewModel removeFromCartViewModel);
        IEnumerable<CartItem> GetCartItems();
        int CartItemsCount();
        decimal GetCartTotal();
    }
}
