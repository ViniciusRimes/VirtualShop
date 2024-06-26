﻿using AutoMapper;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<Product, ProductDTO>()
            .ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
