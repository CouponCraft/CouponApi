using Microsoft.EntityFrameworkCore;
using System.Net;
using CouponApi.Data;
using CouponApi.Services.Interfaces;
using CouponApi.Models;
using CouponApi.DTOs;

namespace CouponApi.Services.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly CouponsContext _context;
        public CouponsRepository(CouponsContext context)
        {
            _context = context;
        }
        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Add(CouponDTO coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAll()
        {
            var coupons = await _context.Coupons.Include(c => c.MarketingUser).Where(c => c.Status!.ToLower().Equals("active")).ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (Enumerable.Empty<Coupon>(), "No coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAllInactive()
        {
            var coupons = await _context.Coupons.Include(c => c.MarketingUser).Where(c => c.Status!.ToLower().Equals("inactive")).ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (Enumerable.Empty<Coupon>(), "No coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var coupon = await _context.Coupons.Include(c => c.MarketingUser).Where(c => c.Status!.ToLower().Equals("inactive")).FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (coupon != null)
                return (coupon, "Coupon has been successfully obtained.", HttpStatusCode.OK);
            else
                return (default(Coupon)!, "No coupon found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Update(int id, CouponDTO coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> InactivateCoupon(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> ActivateCoupon(int id)
        {
            throw new NotImplementedException();
        }
    }
}