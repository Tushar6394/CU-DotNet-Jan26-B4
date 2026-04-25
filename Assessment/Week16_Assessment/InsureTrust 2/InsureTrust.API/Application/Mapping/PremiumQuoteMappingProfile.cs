using AutoMapper;
using InsureTrust.API.Application.DTOs.PremiumQuote;
using InsureTrust.API.Models;

namespace InsureTrust.API.Application.Mapping;

public class PremiumQuoteMappingProfile : Profile
{
    public PremiumQuoteMappingProfile()
    {
        CreateMap<PolicyType, PremiumQuoteResultDto>()
            .ForMember(dest => dest.PolicyTypeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PolicyName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.BaseMonthlyPremium, opt => opt.MapFrom(src => src.BaseMonthlyPremium));
    }
}
