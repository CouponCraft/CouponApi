using CouponApi.DTOs;
using CouponApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CouponApi.Controllers.Authenticate
{
    public class AuthenticateController : ControllerBase
    {
        private readonly  IAuthenticateRepository _service;
        public AuthenticateController(IAuthenticateRepository service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("api/user/authenticate")]
        public async Task<ActionResult> LoginRequest([FromBody]MarketingLoginDTO model)
        {
            // Check that the email and password are not empty
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace( model.Password))
            {
                return BadRequest("Email and Password must not be empty");
            }
            
            try
            {
                // Authenticate the user
                var (login, authMessage, authStatusCode) = await _service.AuthenticateUser(model.Email, model.Password);

                // If authentication fails, return appropriate status code and message
                if (login == null)
                {
                    return StatusCode((int)authStatusCode, authMessage);
                }

                // Get user roles
                var roles = login.UserRoles?.Select(ur => ur.Role?.Name).ToList();

                // Generate an authentication token
                var (token, tokenMessage) = _service.GenerateAuthToken(login);

                // Return the token and roles
                return Ok(new { tokenBearer = token, Roles = roles });
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response with a message
                return StatusCode(500, new { Message = "Internal Server Error", StatusCode = 500, CurrentDate = DateTime.Now, Error = ex.Message });
            }
        }
    }
    
}