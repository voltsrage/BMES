using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Cart;

namespace BMES.Repository
{
    public interface ICartRepository
    {
        Cart FindCartById(long id);
        IEnumerable<Cart> GetAllCarts();
        void SaveCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}
