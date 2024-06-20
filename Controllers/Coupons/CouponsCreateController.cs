using Microsoft.AspNetCore.Mvc;
using CouponApi.Services.Interfaces;
using CouponApi.DTOs;
using CouponApi.Models;
using System.Net;

namespace CouponApi.Controllers.Coupons
{
    public class CouponsCreateController : ControllerBase
    {
        private readonly ICouponsRepository _couponsRepository;
        public CouponsCreateController(ICouponsRepository couponsRepository)
        {
            _couponsRepository = couponsRepository;
        }

        [HttpPost, Route("api/coupons")]
        public async Task<IActionResult> Create([FromBody] CouponDTO coupon)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }
            
            try
            {
                var (newCoupon, message, statusCode) = await _couponsRepository.Add(coupon);
                if (newCoupon == null)
                {
                    return BadRequest(message);
                }

                var response = new
                {
                    Message = message,
                    Coupon = newCoupon
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating coupon: {ex.Message}");
            }
        }
    }
}