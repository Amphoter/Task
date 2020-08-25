using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
   public interface ILogin<T> where T :class
    {
        public void LogIn(LoginModel login)
        {
        }
    }
}