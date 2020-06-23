using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Tools;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Tool, ToolModel>();
            CreateMap<RegisterModel, Tool>();
            CreateMap<UpdateToolModel, Tool>();
        }


    }
}
