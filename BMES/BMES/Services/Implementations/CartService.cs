using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Repository;
using Microsoft.AspNetCore.Http;
using BMES.ViewModels.Cart;
using BMES.Models.Cart;

namespace BMES.Services.Implementations
{
    public class CartService:ICartService
    {
        private const string UniqueCartIdSessionKey = "UniqueCartId";
        private readonly HttpContext _httpContext;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public CartService(IHttpContextAccessor httpContextAccessor,
                            ICartItemRepository cartItemRepository,
                            ICartRepository cartRepository,
                            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _httpContext = httpContextAccessor.HttpContext;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public string UniqueCartId()
        {
            if(!string.IsNullOrWhiteSpace(_httpContext.Session.GetString(UniqueCartIdSessionKey)))
            {
                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
            else
            {
                var uniqueId = Guid.NewGuid().ToString();
                _httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);

                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
        }

        public Cart GetCart()
        {
            var uniqueId = UniqueCartId();
            var cart = _cartRepository.GetAllCarts().FirstOrDefault(c => c.UniqueCartId == uniqueId);
            return cart;
        }
           
      

        public void AddToCart(AddToCartViewModel addToCartViewModel)
        {
            var cart = GetCart();

            if (cart != null)
            {
                var existingCartIem = _cartItemRepository.FindCartItemByCartId(cart.Id)
                            .FirstOrDefault(c => c.ProductId == addToCartViewModel.ProductId);

                if (existingCartIem != null)
                {
                    existingCartIem.Quantity++;
                    _cartItemRepository.UpdateCartItem(existingCartIem);
                }
                else
                {
                    var product = _productRepository.FindProductById(addToCartViewModel.ProductId);

                    if (product != null)
                    {
                        var cartItem = new CartItem
                        {
                            CartId = cart.Id,
                            Cart = cart,
                            ProductId = addToCartViewModel.ProductId,
                            Product = product,
                            ModifiedDate = DateTimeOffset.Now,
                            CreateDate = DateTimeOffset.Now,
                            Quantity = 1
                        };
                        _cartItemRepository.SaveCartItem(cartItem);

                        cart.ModifiedDate = DateTimeOffset.Now;

                        _cartRepository.UpdateCart(cart);
                    }
                }
            }
            else
            {
                var product = _productRepository.FindProductById(addToCartViewModel.ProductId);

                if (product != null)
                {
                    var newCart = new Cart
                    {
                        UniqueCartId = UniqueCartId(),
                        ModifiedDate = DateTimeOffset.Now,
                        CreateDate = DateTimeOffset.Now,
                        CartStatus = CartStatus.Open
                    };

                    _cartRepository.SaveCart(newCart);

                    var cartItem = new CartItem
                    {
                        CartId = newCart.Id,
                        Cart = newCart,
                        ProductId = addToCartViewModel.ProductId,
                        Product = product,
                        ModifiedDate = DateTimeOffset.Now,
                        CreateDate = DateTimeOffset.Now,
                        Quantity = 1
                    };

                    _cartItemRepository.SaveCartItem(cartItem);
                }
            }
        }

        public void RemoveFromCart(RemoveFromCartViewModel removeFromCartViewModel)
        {
            var cartItem = _cartItemRepository.FindCartItemById(removeFromCartViewModel.CartItemId);
            _cartItemRepository.DeleteCartItem(cartItem);
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            IList<CartItem> cartItems = new List<CartItem>();

            var cart = GetCart();

            if (cart != null)
            {
                cartItems = _cartItemRepository.FindCartItemByCartId(cart.Id).ToArray();
            }

            return cartItems;
        }


        public int CartItemsCount()
        {
            var count = 0;
            var cartItems = GetCartItems();

            foreach(var cartItem in cartItems)
            {
                count += cartItem.Quantity;
            }

            return count;
        }

        public decimal GetCartTotal()
        {
            decimal total = 0;

            var cartItems = GetCartItems();

            foreach (var cartItem in cartItems)
            {
                var product = _productRepository.FindProductById(cartItem.ProductId);
                total += cartItem.Quantity * product.Price;
            }

            return total;
        }
    }
}
