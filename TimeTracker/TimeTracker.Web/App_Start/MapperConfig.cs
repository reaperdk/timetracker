using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Web
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.CreateMap<Model.UserModel, Web.Models.UserModel>();
            Mapper.CreateMap<Web.Models.UserModel, Model.UserModel>();
        }
    }
}