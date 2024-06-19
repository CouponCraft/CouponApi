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
    }
}