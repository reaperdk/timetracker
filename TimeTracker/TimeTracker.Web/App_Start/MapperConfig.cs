﻿using AutoMapper;
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
            Mapper.CreateMap<Model.UserProfile, Web.Models.UserModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(src => src.webpages_Roles.First().RoleId))
                .ForMember(dest => dest.RoleName, opts => opts.MapFrom(src => src.webpages_Roles.First().RoleName));

            Mapper.CreateMap<Web.Models.UserModel, Model.UserProfile>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.webpages_Roles,
                    opts => opts.MapFrom(src => new [] { new Model.RoleModel { RoleId = src.RoleId } })
                );
        }
    }
}