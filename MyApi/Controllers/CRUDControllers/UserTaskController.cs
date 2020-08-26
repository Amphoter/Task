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
    public class UserTaskController: ControllerBase
    {
        
       private readonly ICrudRepository<UserTask> _repository;
        private readonly IMapper _mapper;

        public UserTaskController(ICrudRepository<UserTask> methods, IMapper mapper)
        {
            _mapper = mapper;
            _repository = methods;

        }


        [HttpPost(ApiRoutes.UserTasks.Create)]
        public void Create(UserTaskRequest taskRequest)
        {
            
            _repository.Create(_mapper.Map<UserTask>(taskRequest));
            //
        }

        [HttpGet(ApiRoutes.UserTasks.GetAll)]
        public IEnumerable<UserTaskResponse> Get()
        {
            return _mapper.Map<IEnumerable<UserTaskResponse>>(_repository.GetAll());


        }

        [HttpGet(ApiRoutes.UserTasks.Get)]
        public UserTaskResponse Get(int id)
        {
            return _mapper.Map<UserTaskResponse>(_repository.Get(id));


        }

        [HttpPut(ApiRoutes.UserTasks.Update)]
        public void Update(UserTaskRequest taskRequest,int idToUpdate)
        {
            _repository.Update(_mapper.Map<UserTask>(taskRequest),idToUpdate);

        }

        [HttpDelete(ApiRoutes.UserTasks.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
