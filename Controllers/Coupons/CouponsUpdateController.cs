using Microsoft.AspNetCore.Mvc;
using CouponApi.Services.Interfaces;
using CouponApi.DTOs;

namespace CouponApi.Controllers.Coupons
{
    public class CouponsUpdateController : ControllerBase
    {
        private readonly ICouponsRepository _couponsRepository;
        public CouponsUpdateController(ICouponsRepository couponsRepository)
        {
            _couponsRepository = couponsRepository;
        }

        [HttpPut, Route("api/coupons/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CouponDTO coupon)
        {
            try
            {
                var (updatedCoupon, message, statusCode) = await _couponsRepository.Update(id, coupon);
                if (updatedCoupon == null)
                {
                    return NotFound(message);
                }

                var response = new
                {
                    Message = message,
                    Coupon = updatedCoupon
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating coupon: {ex.Message}");
            }
        }

        [HttpPut, Route("api/coupons/{id}/inactivate")]
        public async Task<IActionResult> Inactivate(int id)
        {
            try
            {
                var (coupon, message, statusCode) = await _couponsRepository.InactivateCoupon(id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inactivating coupon: {ex.Message}");
            }
        }

        [HttpPut, Route("api/coupons/{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                var (coupon, message, statusCode) = await _couponsRepository.ActivateCoupon(id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error activating coupon: {ex.Message}");
            }
        }
    }
}