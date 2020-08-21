using AutoMapper;
using FirstTask.Contracts;
using FirstTask.EF;
using FirstTask.Interfaces;
using FirstTask.Models;
using FirstTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{
    public class UserController : ControllerBase
    {
        
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> repo,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repo;


        }
        
        [HttpPost(ApiRoutes.Users.Add)]
        public void Add(UserRequest userRequest)
        {
            User user = _mapper.Map<User>(userRequest);
            _repository.Create(user);

        }


        [HttpGet(ApiRoutes.Users.GetAll)]
        public IEnumerable<User> Get()
        {


            return _repository.GetAll();

        }

        [HttpGet(ApiRoutes.Users.Get)]
        public User Get(int id)
        {
            return _repository.Get(id);

        }


        [HttpPut(ApiRoutes.Users.Update)]
        public void Update(User user)
        {
            _repository.Update(user);

        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
