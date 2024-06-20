using AutoMapper;
using CouponApi.DTOs;
using CouponApi.Models;

namespace SolutionVets.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Role, RoleDTO>();
            CreateMap<UserRole, UserRoleDTO>();

        }
    }
}