using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Domain.Entities.Orders;
using ElitaShop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

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
