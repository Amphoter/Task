using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    public class TestController
    {
        private readonly ApplicationContext db; 
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public TestController(IRepository<User> methods, IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _repository = methods;
            db = context;


        }


        [HttpGet(ApiRoutes.Test.ShowPermissions)]
        public List<Permission> ShowPermission(int id)
        {
            return null; //db.AppUsers.FirstOrDefault(u => Convert.ToInt32(u.Id) == id).Permissions.ToList();

        }

       /* [HttpGet(ApiRoutes.Test.ShowTasks)]
        public List<UserTask> ShowTasks(int id)
        {
           // List<UserTask> tasks = db.Tasks.Where(ut=>ut.UserId==id).ToList();
            //;
            
            return tasks ;

        }*/

        [HttpGet(ApiRoutes.Test.ShowOffice)]
        public string ShowOffice(int id)
        {
            //var officeId = db.AppUsers.Find(id).OfficeId;


            return null;//db.Offices.Find(officeId).Name;

        }
    }
}
