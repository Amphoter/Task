using Microsoft.AspNetCore.Mvc;
using DataLayer.Repositories;
using MyApi.Contracts;
using LogicLayer.Requests;
using AutoMapper;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using DataLayer.Interfaces;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    public class LoginController : ControllerBase
    {


        private readonly ILogin<LoginModel> _loginrep;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

       public LoginController(ILogin<LoginModel> loginrep,IMapper mapper,UserManager<User> userManager)
        {
            _loginrep = loginrep;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpPost(ApiRoutes.Login.UserLogin)]
        public string LogIn(LoginModel login)
        {
           
            _loginrep.LogIn(login);
            return (login.Name+ login.Password);
           

        }

        [HttpPut(ApiRoutes.Login.UserCreate)]
        public async void Register(UserRequest request)
        {
            User user = _mapper.Map<User>(request);
            await _userManager.CreateAsync(user);
            


        }
    }
}
