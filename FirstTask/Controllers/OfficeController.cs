using AutoMapper;
using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Interfaces;
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

       
        private readonly IRepository<Office> _repository;
        private readonly IMapper _mapper;

        public OfficeController(IRepository<Office> repo,IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;


        }

        [HttpPost(ApiRoutes.Offices.Add)]
        public void Add(OfficeRequest officeRequest)
        {         
            Office office = _mapper.Map<Office>(officeRequest);
            _repository.Create(office);
           
        }


        [HttpGet(ApiRoutes.Offices.GetAll)]
        public IEnumerable<Office> Get()
        {

           
            return _repository.GetAll();

        }

        [HttpGet(ApiRoutes.Offices.Get)]
        public Office Get(int id)
        {
            return _repository.Get(id);
            
        }


        [HttpPut(ApiRoutes.Offices.Update)]
        public void Update(Office office)
        {
            _repository.Update(office);

        }

        [HttpDelete(ApiRoutes.Offices.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }



    }
}
