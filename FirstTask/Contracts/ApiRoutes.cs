using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Contracts
{
    public class ApiRoutes
    {


        public static class Users
        {
            public const string Get = "/api/users/{id}";
            public const string GetAll = "/api/users";
            public const string Add = "/api/users/add";
            public const string Update = "/api/users/update";
            public const string Delete = "/api/users/delete/{id}";
        }

        public static class Offices
        {
            public const string Get = "/api/office/{id}";
            public const string GetAll = "/api/office";
            public const string Add = "/api/office";
            public const string Update = "/api/office";
            public const string Delete = "/api/office/{id}";
        }
        public static class Task
        {
            public const string Get = "/api/task/{id}";
            public const string GetAll = "/api/task";
            public const string Add = "/api/task";
            public const string Update = "/api/task";
            public const string Delete = "/api/task/{id}";
        }
        public static class Permission
        {
            public const string Get = "/api/permission/{id}";
            public const string GetAll = "/api/permission";
            public const string Add = "/api/permission";
            public const string Update = "/api/permission";
            public const string Delete = "/api/permission/{id}";
        }
    }
}
