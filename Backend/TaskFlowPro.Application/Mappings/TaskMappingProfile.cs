using AutoMapper;
using TaskFlowPro.Application.DTOs.Tasks;
using TaskFlowPro.Domain.Entities;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Application.Mappings;

/// <summary>
/// AutoMapper profile for Task entity mappings
/// </summary>
public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        // Entity to DTO mappings
        CreateMap<TaskEntity, TaskDto>()
            .ForMember(dest => dest.IsOverdue, opt => opt.MapFrom(src => src.IsOverdue))
            .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team))
            .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedToUser))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedByUser));

        CreateMap<Team, TaskTeamDto>();

        CreateMap<User, TaskUserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

        // DTO to Entity mappings
        CreateMap<CreateTaskDto, TaskEntity>()
            .ForMember(dest => dest.TaskId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending"))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore()) // Will be set from current user
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Team, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedToUser, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore());

        CreateMap<UpdateTaskDto, TaskEntity>()
            .ForMember(dest => dest.TaskId, opt => opt.Ignore())
            .ForMember(dest => dest.TeamId, opt => opt.Ignore()) // Cannot change team
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Team, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedToUser, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore());
    }
}
