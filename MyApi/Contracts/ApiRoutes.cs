using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Contracts
{
    public class ApiRoutes
    {
        public static class Users
        {
            public const string Get = "/api/users/{id}";
            public const string GetAll = "/api/users";
            public const string Create = "/api/users/add";
            public const string Update = "/api/users/update";
            public const string Delete = "/api/users/delete/{id}";
            
        }

        public static class Offices
        {
            public const string Get = "/api/office/{id}";
            
            public const string GetAll = "/api/office";
            public const string Create = "/api/office";
            public const string Update = "/api/office";
            public const string Delete = "/api/office/{id}";
        }
        public static class UserTasks
        {
            public const string Get = "/api/task/{id}";
            public const string GetAll = "/api/task";
            public const string Create = "/api/task";
            public const string Update = "/api/task";
            public const string Delete = "/api/task/{id}";
        }
        public static class Permissions
        {
            public const string Get = "/api/permission/{id}";
            public const string GetAll = "/api/permission";
            public const string Create = "/api/permission";
            public const string Update = "/api/permission";
            public const string Delete = "/api/permission/{id}";
        }

        public static class Test
        {
            public const string InitializeDb = "/api/db/initialize";
        }

        public static class Login
        {
            public const string UserLogin = "/api/login";
            public const string UserCreate = "/api/reg";
            public const string UserLogOut = "/api/logout";
        }
    }
}
