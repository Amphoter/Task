using AutoMapper;
using FirstTask.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Requests
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
          
            CreateMap<OfficeRequest, Office>();
            CreateMap<UserRequest, User>();
            CreateMap<PermissionRequest, Permission>();
            CreateMap<UserTaskRequest, UserTask>();

        }

    }
}
