using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class LoginService : IAccountManager<LoginModel>
    {
        private readonly ApplicationContext db;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginService(ApplicationContext context,SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            db = context;
            _signInManager = signInManager;
            _userManager = userManager;


        }

        public async Task LogIn(LoginModel login) {
                      
             await _signInManager.SignInAsync(db.Users.FirstOrDefault(u => u.Name == login.Name), true);
            
        }

        public async Task Register(RegisterModel user)
        {
            User userToReg = new User() { Name = user.Name, Age = user.Age, UserName = user.Name, Password = user.Password };
            await _userManager.CreateAsync(userToReg);
            await _userManager.AddToRoleAsync(userToReg,db.Roles.Find(2).Name);

           

        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
        
    }
}
