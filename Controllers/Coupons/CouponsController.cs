using Microsoft.AspNetCore.Mvc;
using CouponApi.Services.Interfaces;
using CouponApi.Models;

namespace CouponApi.Controllers.Coupons
{
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsRepository _couponsRepository;
        public CouponsController(ICouponsRepository couponsRepository)
        {
            _couponsRepository = couponsRepository;
        }

        [HttpGet, Route("api/coupons")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var (coupons, message, statusCode) = await _couponsRepository.GetAll();
                if (coupons == null || coupons == Enumerable.Empty<Coupon>())
                {
                    return NotFound(message);
                }

                var response = new
                {
                    Message = message,
                    Coupons = coupons
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining coupons: {ex.Message}");
            }
        }

        [HttpGet, Route("api/coupons/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var (coupon, message, statusCode) = await _couponsRepository.GetById(id);
                if (coupon == null)
                {
                    return NotFound(message);
                }

                var response = new
                {
                    Message = message,
                    Coupon = coupon
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining coupon: {ex.Message}");
            }
        }
    }
}