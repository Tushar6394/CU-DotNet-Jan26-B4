using AutoMapper;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.DTOs;
namespace NorthwindCatalog.Services.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => ResolveCategoryImage(src.CategoryId, src.CategoryName)));

        CreateMap<Product, ProductDto>();
    }

    private static string ResolveCategoryImage(int categoryId, string categoryName)
    {
        var normalizedName = (categoryName ?? string.Empty).Trim().ToLowerInvariant();

        if (normalizedName == "beverages") return "/images/Beverages.jpg";
        if (normalizedName == "condiments" || normalizedName == "sauces") return "/images/Sauces.jpg";
        if (normalizedName == "confections" || normalizedName == "desserts") return "/images/Desserts.jpg";
        if (normalizedName == "dairy products" || normalizedName == "dairy") return "/images/Dairy.jpg";
        if (normalizedName == "grains/cereals" || normalizedName == "grains") return "/images/Grains.jpg";
        if (normalizedName == "meat/poultry" || normalizedName == "meat") return "/images/Meat.jpg";
        if (normalizedName == "produce" || normalizedName == "dryfruits") return "/images/DryFruits.jpg";
        if (normalizedName == "seafood") return "/images/Seafood.jpg";
        if (normalizedName == "food") return "/images/Grains.jpg";
        if (normalizedName == "electronics") return "/images/DryFruits.jpg";

        return categoryId switch
        {
            1 => "/images/Beverages.jpg",
            2 => "/images/Sauces.jpg",
            3 => "/images/Desserts.jpg",
            4 => "/images/Dairy.jpg",
            5 => "/images/Grains.jpg",
            6 => "/images/Meat.jpg",
            7 => "/images/DryFruits.jpg",
            8 => "/images/Seafood.jpg",
            _ => "/images/Beverages.jpg"
        };
    }
}