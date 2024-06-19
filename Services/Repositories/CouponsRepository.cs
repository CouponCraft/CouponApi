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
            // Includes missing
            var coupons = await _context.Coupons.Where(c => c.Status.ToLower().Equals("active")).ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (null, "No coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAllInactive()
        {
            // Includes missing
            var coupons = await _context.Coupons.Where(c => c.Status.ToLower().Equals("inactive")).ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (null, "No coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            throw new NotImplementedException();
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