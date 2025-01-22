using AutoMapper;
using EclipseWorks.Core.Models;
using EclipseWorks.DTO.Project;
using EclipseWorks.DTO.Task;
using EclipseWorks.DTO.TaskComment;
using EclipseWorks.Helper.Enums;

namespace EclipseWorks.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskCommentRegistrationDTO, TaskCommentModel>();

            CreateMap<ProjectListingDTO, ProjectModel>().ReverseMap()
                .ForMember(dto => dto.UserName, m => m.MapFrom(
                           model => model.User != null ? model.User.Name : string.Empty));
            CreateMap<ProjectRegistrationDTO, ProjectModel>();
            CreateMap<ProjectEditDTO, ProjectModel>();

            CreateMap<TaskEditStatusDTO, TaskModel>();
            CreateMap<TaskEditDTO, TaskModel>();
            CreateMap<TaskRegistrationDTO, TaskModel>()
                .ForMember(model => model.DueDate, m => m.MapFrom(
                           dto => dto.DueDate.ToDateTime()));
            CreateMap<TaskListingDTO, TaskModel>().ReverseMap()
                .ForMember(dto => dto.DueDate, m => m.MapFrom(
                           model => DateOnly.FromDateTime(model.DueDate)))
                .ForMember(dto => dto.ProjectTitle, m => m.MapFrom(
                           model => model.Project != null ? model.Project.Title : string.Empty))
                .ForMember(dto => dto.TaskPriorityName, m => m.MapFrom(
                           model => EnumUtil.GetDescription((eTaskPriority)model.TaskPriorityId)))
                .ForMember(dto => dto.TaskStatusName, m => m.MapFrom(
                           model => EnumUtil.GetDescription((eTaskStatus)model.TaskStatusId)));
        }
    }
}
