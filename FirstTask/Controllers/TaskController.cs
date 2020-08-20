using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{
    public class TaskController
    {
        private readonly ApplicationContext db;
        TaskRepository Methods;

        public TaskController(ApplicationContext context)
        {
            db = context;
            Methods = new TaskRepository(context);

        }


        [HttpPost(ApiRoutes.Task.Add)]
        public void Create(Models.Task task)
        {
            Methods.Create(task);

        }


        [HttpGet(ApiRoutes.Task.Get)]
        public Models.Task Get(int id)
        {
            return Methods.Get(id);


        }

        [HttpGet(ApiRoutes.Task.GetAll)]
        public IEnumerable<Models.Task> Get()
        {
            return Methods.GetAll();


        }


        [HttpPut(ApiRoutes.Task.Update)]
        public void Update(Models.Task task)
        {
            Methods.Update(task);

        }

        [HttpDelete(ApiRoutes.Task.Delete)]
        public void Delete(int id)
        {
            Methods.Delete(id);
        }
    }
}
