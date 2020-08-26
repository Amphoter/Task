using AutoMapper;
using DataLayer.Models;
using LogicLayer.Requests;
using LogicLayer.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile(){

        CreateMap<OfficeRequest, Office>();
            CreateMap<UserRequest, User>();
            CreateMap<PermissionRequest, Permission>();
            CreateMap<UserTaskRequest, UserTask>();

            CreateMap<Office, OfficeResponse>();
            CreateMap<User, UserResponse>();

            CreateMap<User, UserShortResponse>();

            CreateMap<Permission, PermissionResponse>();
            CreateMap<UserTask, UserTaskResponse>();

                CreateMap<IdentityUser, User>();

            CreateMap<IdentityUser, UserShortResponse>();
            CreateMap<UserRequest, LoginModel>();

            CreateMap<RegisterModel, User>();
        }
    }
}
