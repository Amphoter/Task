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

namespace FirstTask.Controllers
{
    public class UserTaskController
    {
        
       private readonly IRepository<UserTask> _repository;
        private readonly IMapper _mapper;

        public UserTaskController(IRepository<UserTask> repo,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;

        }


        [HttpPost(ApiRoutes.UserTask.Add)]
        public void Create(UserTaskRequest taskRequest)
        {
            UserTask task = _mapper.Map<UserTask>(taskRequest);
            _repository.Create(task);

        }


        [HttpGet(ApiRoutes.UserTask.Get)]
        public UserTask Get(int id)
        {
            return _repository.Get(id);


        }

        [HttpGet(ApiRoutes.UserTask.GetAll)]
        public IEnumerable<UserTask> Get()
        {
            return _repository.GetAll();


        }


        [HttpPut(ApiRoutes.UserTask.Update)]
        public void Update(UserTask task)
        {
            _repository.Update(task);

        }

        [HttpDelete(ApiRoutes.UserTask.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
