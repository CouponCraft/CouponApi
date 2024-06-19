using System.Net;
using CouponApi.DTOs;
using CouponApi.Models;

namespace CouponApi.Services.Interfaces
{
    public interface ICouponsRepository
    {
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Add(CouponDTO coupon);
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Update(int id, CouponDTO coupon);
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> InactivateCoupon(int id);
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> ActivateCoupon(int id);
        Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAll();
        Task<(IEnumerable<Coupon> coupons, string message, HttpStatusCode statusCode)> GetAllInactive();
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> GetById(int id);
    }
}