using AutoMapper;
using System.Collections.Generic;
using TaskManagementAPI.DTO;
using TaskManagementAPI.DTO.Category;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //category
            CreateMap<Category, CategoryDTO>();

            //waypoint
            CreateMap<WaypointSaveDTO, Waypoint>()
                .ForMember(d => d.Id, src => src.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.WorkTask, src => src.MapFrom(o => Guid.Parse(o.WorkTaskId)))
                .ForMember(d => d.Location, src => src.MapFrom(o => Guid.Parse(o.LocationId)))
                .ForMember(d => d.State, src => src.MapFrom(o => true));

            //workTask
            CreateMap<WorkTaskSaveDTO, WorkTask>()
                .ForMember(d => d.Id, src => src.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.User, src => src.MapFrom(o => Guid.Parse(o.UserId)))
                .ForMember(d => d.Category, src => src.MapFrom(o => Guid.Parse(o.CategoryId)))
                .ForMember(d => d.DeadLine, src => src.MapFrom(o => DateTime.Parse(o.DeadLine)))
                .ForMember(d => d.State, src => src.MapFrom(o => true));

            CreateMap<WorkTask, WorkTaskDTO>()
                .ForMember(d => d.Id, src => src.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.CategoryName, src => src.MapFrom(o => o.CategoryNavigation.Name))
                .ForMember(d => d.StatusName, src => src.MapFrom(o => o.WorkTaskStatuses.OrderByDescending(statuses => statuses.CreatedAt).FirstOrDefault().StatusNavigation.Name))
                .ForMember(d => d.Waypoints, src => src.MapFrom(o => o.Waypoints.Select(waypoint => new WaypointDTO
                    {
                        Id = waypoint.Id,
                        Location = waypoint.LocationNavigation.Name,
                        Address = waypoint.Address,
                        Order = waypoint.Order.ToString()
                    })))
                .ForMember(d => d.Statuses, src => src.MapFrom(o => o.WorkTaskStatuses.Select(status => new StatusDTO
                {
                    Id = status.Id,
                    Name = status.StatusNavigation.Name,
                    Observation = status.Observation,
                    CreatedAt = status.CreatedAt
                }).OrderBy(status => status.CreatedAt)
                ));


            CreateMap<WorkTaskSaveDTO, WorkTaskStatus>()
                .ForMember(d => d.Id, src => src.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.WorkTask, src => src.MapFrom(o => Guid.Parse(o.Id)))
                .ForMember(d => d.Status, src => src.MapFrom(o => Guid.Parse(o.StatusId)))
                .ForMember(d => d.Observation, src => src.MapFrom(o => o.StatusObservation))
                .ForMember(d => d.State, src => src.MapFrom(o => true));
        }
    }
}
