using AutoMapper;
using Domain.Models;
using WebAPI.DTOs.JobDTOs;

namespace WebAPI.MappingProfiles
{
    public class JobMappingProfile : Profile
    {
        public JobMappingProfile()
        {
            CreateMap<Job, UpdateJobDto>()
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate.HasValue
                    ? src.StartDate.Value.ToString("yyyy-MM-dd")
                    : null)) // Handle nullable DateOnly
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate.HasValue
                    ? src.EndDate.Value.ToString("yyyy-MM-dd")
                    : null)); // Handle nullable DateOnly

            CreateMap<UpdateJobDto, Job>()
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.StartDate)
                        ? (DateOnly?)null
                        : DateOnly.Parse(src.StartDate))) // Convert string to DateOnly
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.EndDate)
                        ? (DateOnly?)null
                        : DateOnly.Parse(src.EndDate))); // Convert string to DateOnly

        }
    }
}
