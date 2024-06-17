using Microsoft.EntityFrameworkCore;

namespace CouponApi.Data
{
    public class CouponApiContext : DbContext
    {
        public CouponApiContext(DbContextOptions<CouponApiContext> options) : base(options) {}

        
    }
}