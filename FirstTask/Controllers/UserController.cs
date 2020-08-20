using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Models;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext db;
        UserRepository Methods;

        public UserController(ApplicationContext context)
        {
            db = context;
            Methods = new UserRepository(context);


        }
        
        [HttpPost(ApiRoutes.Users.Add)]
        public void Add(User user)
        {
            Methods.Create(user);

        }


        [HttpGet(ApiRoutes.Users.GetAll)]
        public IEnumerable<User> Get()
        {


            return Methods.GetAll();

        }

        [HttpGet(ApiRoutes.Users.Get)]
        public User Get(int id)
        {
            return Methods.Get(id);

        }


        [HttpPut(ApiRoutes.Users.Update)]
        public void Update(User user)
        {
            Methods.Update(user);

        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public void Delete(int id)
        {
            Methods.Delete(id);
        }
    }
}
