using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using CouponApi.Data;
using CouponApi.Models;
using CouponApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CouponApi.Services.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        public readonly CouponsContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticateRepository(CouponsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<(MarketingUser login, string message, HttpStatusCode statusCode)> AuthenticateUser(string email, string password)
        {
            var marketing = await _context.MarketingUsers.Include(u => u.UserRoles!).ThenInclude(ur => ur.Role).SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (marketing != null)
                return (marketing, "EL email y la password fueron encontradas, se inicio sesion correctamente.", HttpStatusCode.OK);
            else
                return (default(MarketingUser)!, "The email or password is incorrect.", HttpStatusCode.NotFound);
        }

        public (string token, string message) GenerateAuthToken(MarketingUser marketing)
        {
            // Set up security credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define token claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, marketing.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, marketing.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Add role claims
            if (marketing.UserRoles != null)
            {
                foreach (var userRole in marketing.UserRoles)
                {
                    if (userRole.Role != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name!));
                    }
                }
            }

            // Configure the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            // Return the JWT token as a string
            return (tokenString, "Token generated successfully.");        
        }
    }
}