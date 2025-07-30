using AutoMapper;
using TaskFlowPro.Application.DTOs.Teams;
using TaskFlowPro.Domain.Entities;

namespace TaskFlowPro.Application.Mappings;

/// <summary>
/// AutoMapper profile for Team entity mappings
/// </summary>
public class TeamMappingProfile : Profile
{
    public TeamMappingProfile()
    {
        // Entity to DTO mappings
        CreateMap<Team, TeamDto>()
            .ForMember(dest => dest.Leader, opt => opt.MapFrom(src => src.Leader))
            .ForMember(dest => dest.MemberCount, opt => opt.MapFrom(src => src.Members.Count))
            .ForMember(dest => dest.ActiveTaskCount, opt => opt.MapFrom(src => src.Tasks.Count(t => t.Status != "Completed" && t.Status != "Cancelled")));

        CreateMap<User, TeamLeaderDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

        // DTO to Entity mappings
        CreateMap<CreateTeamDto, Team>()
            .ForMember(dest => dest.TeamId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Leader, opt => opt.Ignore())
            .ForMember(dest => dest.Members, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore());

        CreateMap<UpdateTeamDto, Team>()
            .ForMember(dest => dest.TeamId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Leader, opt => opt.Ignore())
            .ForMember(dest => dest.Members, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore());
    }
}
