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
    }
}