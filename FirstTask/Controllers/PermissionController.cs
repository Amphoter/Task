using AutoMapper;
using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Interfaces;
using FirstTask.Models;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FirstTask.Contracts.ApiRoutes;
using Permission = FirstTask.Models.Permission;

namespace FirstTask.Controllers
{
    public class PermissionController
    {
        
        private readonly IRepository<Permission> _repository;
        private readonly IMapper _mapper;

        public PermissionController(IRepository<Permission> repo,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;

        }


        [HttpPost(ApiRoutes.Permissions.Add)]
        public void Create(PermissionRequest permRequest)
        {
            Permission perm = _mapper.Map<Permission>(permRequest);
            _repository.Create(perm);

        }


        [HttpGet(ApiRoutes.Permissions.Get)]
        public Permission Get(int id)
        {
            return _repository.Get(id);


        }

        [HttpGet(ApiRoutes.Permissions.GetAll)]
        public IEnumerable<Permission> Get()
        {
            return _repository.GetAll();


        }


        [HttpPut(ApiRoutes.Permissions.Update)]
        public void Update(Permission perm)
        {
            _repository.Update(perm);

        }

        [HttpDelete(ApiRoutes.Permissions.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
