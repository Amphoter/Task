using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts;
using DataLayer.Models;
using DataLayer.Interfaces;
using System.Threading.Tasks;


namespace MyApi.Controllers
{
    public class LoginController : ControllerBase
    {


        private readonly IAccountManager<LoginModel> _loginrep;

        

       public LoginController(IAccountManager<LoginModel> loginrep)
        {
            _loginrep = loginrep;

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
