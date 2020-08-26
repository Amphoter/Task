using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    public class TestController
    {
        private readonly RoleManager<Permission> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext db;


        public TestController(ApplicationContext context,
            RoleManager<Permission> roleManager,
            UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        [HttpPut(ApiRoutes.Test.InitializeDb)]
        public async Task InitializeDb()
        {

              await  _roleManager.CreateAsync(new Permission() { Name = "admin" });
              await  _roleManager.CreateAsync(new Permission() { Name = "simpleuser" });
            var adminUser = new User() { Name = "admin", UserName = "admin", Password = "admin" };
            await _userManager.CreateAsync(adminUser);
            await _userManager.AddToRoleAsync(adminUser,db.Roles.Find(1).Name);
        


        }


    }
}

