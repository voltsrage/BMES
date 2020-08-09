using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Cart;

namespace BMES.Repository
{
    public interface ICartItemRepository
    {
        CartItem FindCartItemById(long id);
        IEnumerable<CartItem> FindCartItemByCartId(long cartId);
        void SaveCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
    }
}
