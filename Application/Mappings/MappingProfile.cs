using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EligibilityRequest, EligibilityResponseDto>()
                .ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate.ToString("yyyy-MM-dd")));

            CreateMap<CreateEligibilityDto, EligibilityRequest>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.Status)
                    ? RequestStatus.Pending
                    : Enum.Parse<RequestStatus>(src.Status, true)))

                .ForMember(dest => dest.RequestDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        }
    }
}
