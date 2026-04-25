using AutoMapper;
using InsureTrust.API.Application.DTOs.PolicyCatalog;
using InsureTrust.API.Models;

namespace InsureTrust.API.Application.Mapping;

public class PolicyCatalogMappingProfile : Profile
{
    public PolicyCatalogMappingProfile()
    {
        CreateMap<PolicyType, PolicyCatalogItemDto>()
            .ForMember(dest => dest.PolicyTypeId, opt => opt.MapFrom(src => src.Id));
    }
}
