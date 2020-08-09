using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Products;
using BMES.Models.Cart;
using BMES.Models.Address;
using BMES.Models.Customer;
using BMES.Models.Orders;
using BMES.Models.Shared;

namespace BMES.Database
{
    public class BmesDbContext:DbContext
    {
        public BmesDbContext(DbContextOptions<BmesDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
