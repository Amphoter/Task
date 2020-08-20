using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Models;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{
    public class OfficeController:ControllerBase
    {

        private readonly ApplicationContext db;
        OfficeRepository Methods;
        
        public OfficeController(ApplicationContext context)
        {
            db = context;
            Methods = new OfficeRepository(context);
            

        }

        [HttpPost(ApiRoutes.Offices.Add)]
        public void Add(Office office)
        {
            Methods.Create(office);
           
        }


        [HttpGet(ApiRoutes.Offices.GetAll)]
        public IEnumerable<Office> Get()
        {

           
            return Methods.GetAll();

        }

        [HttpGet(ApiRoutes.Offices.Get)]
        public Office Get(int id)
        {
            return Methods.Get(id);
            
        }


        [HttpPut(ApiRoutes.Offices.Update)]
        public void Update(Office office)
        {
            Methods.Update(office);

        }

        [HttpDelete(ApiRoutes.Offices.Delete)]
        public void Delete(int id)
        {
            Methods.Delete(id);
        }



    }
}
