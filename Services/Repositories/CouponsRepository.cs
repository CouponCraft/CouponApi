using Microsoft.EntityFrameworkCore;
using System.Net;
using CouponApi.Data;
using CouponApi.Services.Interfaces;
using CouponApi.Models;
using CouponApi.DTOs;
using AutoMapper;

namespace CouponApi.Services.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly CouponsContext _context;
        private readonly IMapper _mapper;
        public CouponsRepository(CouponsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Add(CouponDTO coupon)
        {                    
            var newCoupon = _mapper.Map<Coupon>(coupon);
            await _context.Coupons.AddAsync(newCoupon);
            await _context.SaveChangesAsync();
            return (newCoupon, "Coupon has been successfully added.", HttpStatusCode.Created);
        }

        public async Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAll()
        {
            var coupons = await _context.Coupons.Include(c => c.MarketingUser).Where(c => c.Status!.ToLower() != "inactive").ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (Enumerable.Empty<Coupon>(), "No active or expire coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAllInactive()
        {
            var coupons = await _context.Coupons.Include(c => c.MarketingUser).Where(c => c.Status!.ToLower() == "inactive").ToListAsync();
            if (coupons.Any())
                return (coupons, "Coupons have been successfully obtained.", HttpStatusCode.OK);
            else
                return (Enumerable.Empty<Coupon>(), "No inactive coupons found in the database.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var coupon = await _context.Coupons.Include(c => c.MarketingUser).FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (coupon != null)
                return (coupon, "Coupon has been successfully obtained.", HttpStatusCode.OK);
            else
                return (default(Coupon)!, $"No coupon found in the database with Id: {id}.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Update(int id, CouponDTO coupon)
        {
            var couponUpdate = await _context.Coupons.FindAsync(id);
            if (couponUpdate!= null)
            {
                _mapper.Map(coupon, couponUpdate);
                _context.Entry(couponUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return (couponUpdate, "The coupon has been updated correctly.", HttpStatusCode.OK);
            }
            else
                return (default(Coupon)!, $"No coupon found in the database with Id: {id}.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> ActivateCoupon(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                if (coupon.Status == "active")
                {
                    return (coupon, $"The Coupon with Id: {id} is already active.", HttpStatusCode.NotFound);
                }
                else
                {
                    coupon.Status = "active";
                    _context.Entry(coupon).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return (coupon, "The coupon has been activated correctly.", HttpStatusCode.OK);
                }
            }
            else
                return (default(Coupon)!, $"No coupon found in the database with Id: {id}.", HttpStatusCode.NotFound);
        }

        public async Task<(Coupon coupon, string message, HttpStatusCode statusCode)> InactivateCoupon(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                if (coupon.Status == "inactive")
                {
                    return (coupon, $"The Coupon with Id: {id} is already inactive.", HttpStatusCode.NotFound);
                }
                else
                {
                    coupon.Status = "inactive";
                    _context.Entry(coupon).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return (coupon, "The coupon has been inactivated correctly.", HttpStatusCode.OK);
                }
            }
            else
                return (default(Coupon)!, $"No coupon found in the database with Id: {id}.", HttpStatusCode.NotFound);
        }
    }
}