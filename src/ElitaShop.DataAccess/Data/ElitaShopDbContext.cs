using ElitaShop.Domain.Entities.Cards;
using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Domain.Entities.Categories;
using ElitaShop.Domain.Entities.Orders;
using ElitaShop.Domain.Entities.Products;
using ElitaShop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.DataAccess.Data
{
    public class ElitaShopDbContext : DbContext
    {
        public ElitaShopDbContext(DbContextOptions<ElitaShopDbContext> options) : base(options)
        {}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
