using AutoMapper;
using TaskFlowPro.Application.DTOs.Users;
using TaskFlowPro.Domain.Entities;

namespace TaskFlowPro.Application.Mappings;

/// <summary>
/// AutoMapper profile for User entity mappings
/// </summary>
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // Entity to DTO mappings
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
            .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team));

        CreateMap<Team, UserTeamDto>()
            .ForMember(dest => dest.IsTeamLeader, opt => opt.MapFrom(src => src.LeaderId == src.Members.FirstOrDefault()!.UserId));

        // DTO to Entity mappings
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Will be handled separately
            .ForMember(dest => dest.LastTokenIssueAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Team, opt => opt.Ignore())
            .ForMember(dest => dest.LeadingTeams, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedTasks, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedTasks, opt => opt.Ignore());

        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.LastTokenIssueAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Team, opt => opt.Ignore())
            .ForMember(dest => dest.LeadingTeams, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedTasks, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedTasks, opt => opt.Ignore());
    }
}
