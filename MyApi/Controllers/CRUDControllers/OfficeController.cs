
using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Requests;
using LogicLayer.Responses;
using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    public class OfficeController : ControllerBase
    {

        
       private readonly ICrudRepository<Office> _repository;
        private readonly IMapper _mapper;
        

        public OfficeController(ICrudRepository<Office> repo,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;
            


        }

        [HttpPost(ApiRoutes.Offices.Create)]
        public void Add(OfficeRequest officeRequest)
        {           
            _repository.Create(_mapper.Map<Office>(officeRequest));

        }



        [HttpGet(ApiRoutes.Offices.GetAll)]
        public IEnumerable<OfficeResponse> GetAll()
        {

            return _mapper.Map<IEnumerable<OfficeResponse>>(_repository.GetAll());
            
        }

        [HttpGet(ApiRoutes.Offices.Get)]
        public OfficeResponse Get(int id)
        {
            return _mapper.Map<OfficeResponse>(_repository.Get(id));

        }


        [HttpPut(ApiRoutes.Offices.Update)]
        public void Update(OfficeRequest officeRequest,int idToUpdate)
        {
            _repository.Update(_mapper.Map<Office>(officeRequest),idToUpdate);

        }

        [HttpDelete(ApiRoutes.Offices.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
