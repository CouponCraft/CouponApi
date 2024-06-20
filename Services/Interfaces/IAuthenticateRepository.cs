using System.Net;
using CouponApi.DTOs;
using CouponApi.Models;

namespace CouponApi.Services.Interfaces
{
    public interface IAuthenticateRepository
    {
        // Authenticates a user with the provided credentials
        Task<(MarketingUser login, string message, HttpStatusCode statusCode)> AuthenticateUser(string email, string password);

        // Generate an authentication token for a specific user
        (string token, string message) GenerateAuthToken(MarketingUser marketing);
    }
}