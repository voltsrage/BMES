﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Cart;
using BMES.Database;


namespace BMES.Repository.Implementations
{
    public class CartItemRepository:ICartItemRepository
    {
        private BmesDbContext _context;

        public CartItemRepository(BmesDbContext context)
        {
            _context = context;
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = _context.CartItems.Find(id);
            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemByCartId(long cartId)
        {
            var cartItems = _context.CartItems.Where(cartItem => cartItem.CartId == cartId);
            return cartItems;
        }

        public void SaveCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
    }
}
