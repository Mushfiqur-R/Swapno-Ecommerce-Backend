using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.CategoryDto;
using BLL.DTOs.UserDtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig :Profile
    {
        public MapperConfig() {
            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UserDto>()
           .ForMember(dest => dest.Role,
               opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<Product, ProductDto>()
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
    .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor.Name)) 
    .ForMember(dest => dest.VendorEmail, opt => opt.MapFrom(src => src.Vendor.Email))
    .ForMember(dest => dest.RemainingTime, opt => opt.MapFrom(src =>
                GetRemainingTime(src.ExpiryDate) // নিচে ফাংশন কল করা হয়েছে
            ));
            CreateMap<ProductDto, Product>();
        }
        private string GetRemainingTime(DateTime expiryDate)
        {
            var days = (expiryDate.Date - DateTime.Today).TotalDays;

            if (days == 0) return "Expiring Today!";
            if (days < 0) return "Expired!";
            return $"{days} days remaining";
        }
    }
}
