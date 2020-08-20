using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FirstTask.Contracts.ApiRoutes;

namespace FirstTask.Controllers
{
    public class PermissionController
    {
        private readonly ApplicationContext db;
        PermissionRepository Methods;

        public PermissionController(ApplicationContext context)
        {
            db = context;
            Methods = new PermissionRepository(context);

        }


        [HttpPost(ApiRoutes.Permission.Add)]
        public void Create(Models.Permission perm)
        {
            Methods.Create(perm);

        }


        [HttpGet(ApiRoutes.Permission.Get)]
        public Models.Permission Get(int id)
        {
            return Methods.Get(id);


        }

        [HttpGet(ApiRoutes.Permission.GetAll)]
        public IEnumerable<Models.Permission> Get()
        {
            return Methods.GetAll();


        }


        [HttpPut(ApiRoutes.Permission.Update)]
        public void Update(Models.Permission perm)
        {
            Methods.Update(perm);

        }

        [HttpDelete(ApiRoutes.Permission.Delete)]
        public void Delete(int id)
        {
            Methods.Delete(id);
        }
    }
}
