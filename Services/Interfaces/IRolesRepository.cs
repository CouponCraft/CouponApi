using System.Net;
using CouponApi.DTOs;
using CouponApi.Models;

namespace CouponApi.Services.Interfaces
{
    public interface IRolesRepository
    {
        Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Add(RoleDTO role);

        // Asynchronous method that returns a task completed with a collection of role entities.
        Task<ICollection<RoleDTO>> GetAllRoles();
        // Asynchronous method that returns a task completed with a role entity based on the provided ID.
        Task<ICollection<RoleDTO>> GetRoleById(int id);
        // Asynchronous method that returns a task completed with the created(Assing) role entity.
        Task AssignRoleToUser(UserRoleDTO request);
    }
}