using AutoMapper;
using CouponApi.DTOs;
using CouponApi.Models;

namespace CouponApi.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CouponDTO, Coupon>();
            CreateMap<Coupon, CouponDTO>().ReverseMap();
        }
    }
}