using Microsoft.AspNetCore.Mvc;
using DataLayer.Repositories;
using MyApi.Contracts;
using LogicLayer.Requests;
using AutoMapper;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using DataLayer.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using DataLayer.EF;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace MyApi.Controllers
{
    public class LoginController : ControllerBase
    {


        private readonly IAccountManager<LoginModel> _loginrep;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;
        private readonly SignInManager<User> _signInManager;
        

       public LoginController(IAccountManager<LoginModel> loginrep,
           IMapper mapper,
           UserManager<User> userManager,
           ApplicationContext context,
           SignInManager<User> signInManager)
        {
            _loginrep = loginrep;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        [HttpPost(ApiRoutes.Login.UserLogin)]
        public async Task SignIn(LoginModel login)
        {

           await  _loginrep.LogIn(login);
           

        }

        [HttpPut(ApiRoutes.Login.UserCreate)]
        public async Task Register(RegisterModel regModel)
        {

            await _loginrep.Register(regModel);

        }

        [HttpDelete(ApiRoutes.Login.UserLogOut)]
        public async Task LogOut()
        {
            await _loginrep.LogOut();

        }


    }
}
