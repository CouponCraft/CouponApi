using Microsoft.EntityFrameworkCore;
using CouponApi.Models;

namespace CouponApi.Data
{
    public class CouponsContext : DbContext
    {
        public CouponsContext(DbContextOptions<CouponsContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponHistory> CouponHistories { get; set; }
        public DbSet<CouponUsage> CouponUsages { get; set; }
        public DbSet<MarketingUser> MarketingUsers { get; set; }
        public DbSet<MarketplaceUser> MarketplaceUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseCoupon> PurchaseCoupons { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; }
    }
}