using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
   public interface IAccountManager<T> where T :class
    {
        public Task LogIn(LoginModel login);


        public  Task Register(RegisterModel register);


        public Task LogOut();
        
    }
}