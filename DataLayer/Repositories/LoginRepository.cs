using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
    public class LoginRepository : ILogin<LoginModel>
    {
        private readonly ApplicationContext db;
        private readonly SignInManager<User> _signInManager;
        public LoginRepository(ApplicationContext context,SignInManager<User> signInManager)
        {
            db = context;
            _signInManager = signInManager;


        }

        public void LogIn(LoginModel login) {
            User userToLogin = db.Users.FirstOrDefault(u => u.Name == login.Name);
            if(userToLogin.Password == login.Password)
            {

                _signInManager.PasswordSignInAsync(userToLogin,userToLogin.Password,true,true);
            }
        }


        
    }
}
