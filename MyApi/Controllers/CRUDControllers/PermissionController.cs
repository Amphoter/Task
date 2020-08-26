using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using LogicLayer.Requests;
using LogicLayer.Responses;
using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    public class PermissionController : ControllerBase
    {
        
       private readonly ICrudRepository<Permission> _repository;
        private readonly IMapper _mapper;

        public PermissionController(ICrudRepository<Permission> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;

        }


        [HttpPost(ApiRoutes.Permissions.Create)]
        public void Create(PermissionRequest permRequest)
        {
            
            _repository.Create(_mapper.Map<Permission>(permRequest));

        }

        [HttpGet(ApiRoutes.Permissions.GetAll)]
        public IEnumerable<PermissionResponse> GetAll()
        {
            return _mapper.Map<IEnumerable<PermissionResponse>>(_repository.GetAll());


        }


        [HttpGet(ApiRoutes.Permissions.Get)]
        public PermissionResponse Get(int id)
        {
            return _mapper.Map<PermissionResponse>(_repository.Get(id));


        }

        [HttpPut(ApiRoutes.Permissions.Update)]
        public void Update(PermissionRequest permRequest,int idToUpdate)
        {
            _repository.Update(_mapper.Map<Permission>(permRequest),idToUpdate);

        }

        [HttpDelete(ApiRoutes.Permissions.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
