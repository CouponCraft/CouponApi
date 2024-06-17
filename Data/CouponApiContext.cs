using Microsoft.EntityFrameworkCore;

namespace CouponApi.Data
{
    public class CouponsContext : DbContext
    {
        public CouponsContext(DbContextOptions<CouponsContext> options) : base(options) {}

        
    }
}