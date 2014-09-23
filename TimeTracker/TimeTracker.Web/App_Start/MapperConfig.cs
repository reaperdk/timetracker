using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Model;

namespace TimeTracker.Web
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.CreateMap<Model.UserModel, Web.Models.UserModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(src => src.webpages_Roles.First().RoleId))
                .ForMember(dest => dest.RoleName, opts => opts.MapFrom(src => src.webpages_Roles.First().RoleName));

            Mapper.CreateMap<Web.Models.UserModel, Model.UserModel>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.webpages_Roles,
                    opts => opts.MapFrom(src => new [] { new Model.RoleModel { RoleId = src.RoleId } })
                );

            Mapper.CreateMap<Model.ProjectModel, Web.Models.ProjectModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

            Mapper.CreateMap<Web.Models.ProjectModel, Model.ProjectModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
                //.ForMember(
                //    dest => dest.Users,
                //    opts => opts.MapFrom(src => new[] { new Model.UserModel { UserId = src.UserId } })
                //); 

            Mapper.CreateMap<Model.TaskModel, Web.Models.TaskModel>()
                .ForMember(dest => dest.ProjectId, opts => opts.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.ProjectName, opts => opts.MapFrom(src => src.Project.Name))

                .ForMember(dest => dest.AssignedPersonId, opts => opts.MapFrom(src => src.AssignedPersonId))
                .ForMember(dest => dest.AssignedPersonName, opts => opts.MapFrom(src => src.AssignedPerson.UserName))

                .ForMember(dest => dest.AssigningPersonId, opts => opts.MapFrom(src => src.AssigningPersonId))
                .ForMember(dest => dest.AssigningPersonName, opts => opts.MapFrom(src => src.AssigningPerson.UserName))

                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))

                .ForMember(dest => dest.StatusId, opts => opts.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.StatusName, opts => opts.MapFrom(src => src.Status.Name))

                .ForMember(dest => dest.PriorityId, opts => opts.MapFrom(src => src.PriorityId))
                .ForMember(dest => dest.PriorityName, opts => opts.MapFrom(src => src.Priority.Name))

                .ForMember(dest => dest.TypeId, opts => opts.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.TypeName, opts => opts.MapFrom(src => src.Type.Name));

            Mapper.CreateMap<Web.Models.TaskModel, Model.TaskModel>()
                .ForMember(dest => dest.ProjectId, opts => opts.MapFrom(src => src.ProjectId))
                .ForMember(
                        dest => dest.Project,
                        opts => opts.MapFrom(src => new Model.ProjectModel { Id = src.ProjectId })
                    )

                .ForMember(dest => dest.AssignedPersonId, opts => opts.MapFrom(src => src.AssignedPersonId))
                .ForMember(
                        dest => dest.AssignedPerson,
                        opts => opts.MapFrom(src => new Model.UserModel { UserId = src.AssignedPersonId })
                    )

                .ForMember(dest => dest.AssigningPersonId, opts => opts.MapFrom(src => src.AssigningPersonId))
                .ForMember(
                        dest => dest.AssigningPerson,
                        opts => opts.MapFrom(src => new Model.UserModel { UserId = src.AssigningPersonId })
                    )

                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(
                        dest => dest.Category,
                        opts => opts.MapFrom(src => new Model.CategoryModel { Id = src.CategoryId })
                    )

                .ForMember(dest => dest.StatusId, opts => opts.MapFrom(src => src.StatusId))
                .ForMember(
                        dest => dest.Status,
                        opts => opts.MapFrom(src => new Model.StatusModel { Id = src.StatusId })
                    )

                .ForMember(dest => dest.PriorityId, opts => opts.MapFrom(src => src.PriorityId))
                .ForMember(
                        dest => dest.Priority,
                        opts => opts.MapFrom(src => new Model.PriorityModel { Id = src.PriorityId })
                    )

                .ForMember(dest => dest.TypeId, opts => opts.MapFrom(src => src.TypeId))
                .ForMember(
                        dest => dest.Type,
                        opts => opts.MapFrom(src => new Model.TypeModel { Id = src.TypeId })
                    );

            Mapper.CreateMap<Model.SlotModel, Web.Models.SlotModel>();
            Mapper.CreateMap<Web.Models.SlotModel, Model.SlotModel>();

        }
    }
}