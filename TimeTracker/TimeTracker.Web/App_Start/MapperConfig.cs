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

            Mapper.CreateMap<Model.ProjectModel, Web.Models.ProjectModel>();
                //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

            Mapper.CreateMap<Web.Models.ProjectModel, Model.ProjectModel>();
                //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

            Mapper.CreateMap<Model.TaskModel, Web.Models.TaskModel>()
                .ForMember(dest => dest.ProjectId, opts => opts.MapFrom(src => src.Project.Id))
                .ForMember(dest => dest.ProjectName, opts => opts.MapFrom(src => src.Project.Name))

                .ForMember(dest => dest.AssignedPersonId, opts => opts.MapFrom(src => src.AssignedPerson.UserId))
                .ForMember(dest => dest.AssignedPersonName, opts => opts.MapFrom(src => src.AssignedPerson.UserName))

                .ForMember(dest => dest.AssigningPersonId, opts => opts.MapFrom(src => src.AssigningPerson.UserId))
                .ForMember(dest => dest.AssigningPersonName, opts => opts.MapFrom(src => src.AssigningPerson.UserName))

                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))

                .ForMember(dest => dest.StatusId, opts => opts.MapFrom(src => src.Status.Id))
                .ForMember(dest => dest.StatusName, opts => opts.MapFrom(src => src.Status.Name))

                .ForMember(dest => dest.PriorityId, opts => opts.MapFrom(src => src.Priority.Id))
                .ForMember(dest => dest.PriorityName, opts => opts.MapFrom(src => src.Priority.Name))

                .ForMember(dest => dest.TypeId, opts => opts.MapFrom(src => src.Type.Id))
                .ForMember(dest => dest.TypeName, opts => opts.MapFrom(src => src.Type.Name));

            Mapper.CreateMap<Web.Models.TaskModel, Model.TaskModel>();


        }
    }
}