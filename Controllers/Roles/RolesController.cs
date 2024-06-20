using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CouponApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CouponApi.DTOs;

namespace CouponApi.Controllers.Roles
{
    public class RolesController : ControllerBase
    {
        // Declare a read-only variable for the role service
        public readonly IRolesRepository _service;

        // Constructor that receives the role service as a parameter
        public RolesController(IRolesRepository service)
        {
            _service = service;
        }
        [AllowAnonymous]

        // Endpoint to get all roles
        [HttpGet, Route("api/roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try 
            {
                // Get the claims of the current user
                var userRolesClaims = User?.FindAll(ClaimTypes.Role)?.Select(c => c.Value).ToList();

                // Check if the user's claims do not exist or are empty
                if (userRolesClaims == null || !userRolesClaims.Any())
                {
                    return Unauthorized("Could not get user information.");
                }

                // Check if the user has the "Admin" role
                if (!userRolesClaims.Contains("Admin"))
                {
                    return Unauthorized("You don't have permissions (Only Admins).");
                }
                
                // Call the service to get all roles
                var roles = await _service.GetAllRoles();

                // Check if the roles list is null or empty
                if (roles == null || roles.Count == 0)
                {
                    // Return a 404 Not Found response with a message
                    return NotFound(new { Message = "No roles found in the database.", StatusCode = 404, CurrentDate = DateTime.Now });
                }

                // Return a 200 OK response with the list of roles
                return Ok(roles);
            } 
            catch (Exception ex) 
            {
                // Return a 500 Internal Server Error response with a message
                return BadRequest(new { Message = "Internal Server Error", StatusCode = 500, CurrentDate = DateTime.Now,  Error = ex.Message });
            }
        }

        // Endpoint to get a role by its ID
        [AllowAnonymous]
        [HttpGet, Route("api/roles/{id}")]
        public async Task<ActionResult> GetRoleById(int id)
        {
            // Validate the ID is a positive integer
            if (id <= 0)
            {
                // Return a 400 Bad Request response with a message
                return BadRequest(new { Message = "Invalid role ID.", StatusCode = 400, RoleId = id, CurrentDate = DateTime.Now });
            }
            
            try 
            {
                // Call the service to get the role by ID
                var role = await _service.GetRoleById(id);

                // Check if the role is null
                if (role == null || role.Count == 0)
                {
                    // Return a 404 Not Found response with a message
                    return NotFound(new { Message = "There are no roles with this ID.", StatusCode = 404, CurrentDate = DateTime.Now });                             }

                // Return a 200 OK response with the role
                return Ok(role);
            }
            catch (Exception ex) 
            {
                // Return a 500 Internal Server Error response with a message
                return BadRequest(new { Message = " Internal Server Error", StatusCode = 500, CurrentDate = DateTime.Now , ErrorMessage = ex.Message });
            }
        }

        [HttpPost("api/roles/assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] UserRoleDTO userRoleDto)
        {
            try
            {
                // Call the service to assign the role to the user
                await _service.AssignRoleToUser(userRoleDto);
                
                // Return a 200 OK response with a message
                return Ok(new { Message = "Role assigned successfully", StatusCode = 200, CurrentDate = DateTime.Now });
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response with a message
                return BadRequest(new { Message = "Error assigning role", StatusCode = 500, CurrentDate = DateTime.Now, Error = ex.Message });
            }
        }
    }
}