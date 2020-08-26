
using DataLayer.Repositories;
using DataLayer.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Contracts;
using DataLayer.Models;
using DataLayer.Interfaces;
using AutoMapper;
using LogicLayer.Requests;
using LogicLayer.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

namespace MyApi.Controllers
{
    public class UserController : ControllerBase
    {
        
        private readonly ICrudRepository<User> _repository;
        private readonly IMapper _mapper ;
        
        public UserController(ICrudRepository<User> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;
            


        }

        [HttpPost(ApiRoutes.Users.Create)]
        public void Add(UserRequest userRequest)
        {
            
            _repository.Create(_mapper.Map<User>(userRequest));

        }

        

        [Authorize(Roles ="admin")]
        [HttpGet(ApiRoutes.Users.GetAll)]
        public IEnumerable<UserShortResponse> GetAll()
        {
            
            List<User> users = _repository.GetAll().ToList();
            return  _mapper.Map<List<UserShortResponse>>(users);
            

        }
        [Authorize]
        [HttpGet(ApiRoutes.Users.Get)]
        public UserResponse Get(int id)
        {
            return _mapper.Map<UserResponse>(_repository.Get(id));

        }


        [HttpPut(ApiRoutes.Users.Update)]
        public void Update(int idToUpdate, UserRequest userRequest)
        {
            _repository.Update(_mapper.Map<User>(userRequest),idToUpdate);           
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
