using System.Net;
using AutoMapper;
using CouponApi.Data;
using CouponApi.DTOs;
using CouponApi.Models;
using CouponApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CouponApi.Services.Repositories
{
    public class RolesRepository : IRolesRepository
    {
       // Private variable to hold the database context
        private readonly CouponsContext _context;
        private readonly IMapper _mapper;

        // Constructor injecting the database context dependency
        public RolesRepository(CouponsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<RoleDTO>> GetAllRoles()
        {
            // Get all roles from the database
            var roles = await _context.Roles
                            .Include(u => u.UserRoles!)   
                            .ThenInclude(r => r.User)
                            .ToListAsync();

            // Returns a list of all roles from the database
            return _mapper.Map<ICollection<RoleDTO>>(roles);
        }

        public async Task<ICollection<RoleDTO>> GetRoleById(int id)
        {
            // Find the role by ID
            var roles = await _context.Roles
                                .Include(u => u.UserRoles!)   
                                .ThenInclude(r => r.User)
                                .Where(r => r.Id == id)
                                .ToListAsync();

            // Returns a list of all roles from the database
            return _mapper.Map<ICollection<RoleDTO>>(roles);
        }

        public async Task AssignRoleToUser(UserRoleDTO request)
        {
            var marketing = _context.MarketingUsers.Any(mk => mk.Id == request.MarketingUserId);
            var role = _context.Roles.Any(r => r.Id == request.RoleId);
            var userRole = _context.UserRoles.Any(r => r.MarketingUserId == request.MarketingUserId && r.RoleId == request.RoleId);

            if (userRole)
            {
                throw new Exception("This marketing user already exists with the same role in the database.");
            }

            if (!marketing)
            {
                throw new Exception("Cannot find marketing user with ID: " + request.MarketingUserId);
            }

            if (!role)
            {
                throw new Exception("Cannot find role with ID: " + request.RoleId);
            }

            // Map the UserRoleDTO to the UserRole entity
            var userRoleEntity = _mapper.Map<UserRole>(request);

            // Add the UserRole entity to the context
            _context.UserRoles.Add(userRoleEntity);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public Task<(Coupon coupon, string message, HttpStatusCode statusCode)> Add(RoleDTO role)
        {
            throw new NotImplementedException();
        }

    }
}