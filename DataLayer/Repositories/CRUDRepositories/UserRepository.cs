using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories 
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationContext context,IMapper mapper,UserManager<User> userManager)
        {
            _userManager = userManager;
            db = context;
            _mapper = mapper;
        }


        public User Get(int id)
        {
            return _mapper.Map<User>(db.Users.FirstOrDefault(p => p.Id == id));
        }

        public IEnumerable<User> GetAll()
        {

            return _mapper.Map<IEnumerable<User>>(db.Users.ToList());
        }

        public  void Create(User user)
        {
            User userToCreate = new User()
            { Name = user.Name,
                UserName = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                Password = user.Password,
                
              
                
            };

            if (user.OfficeId != null) { userToCreate.Office = db.Offices.FirstOrDefault(o => o.Id == user.Office.Id); }
            //userToCreate.Permissions.Add(db.Roles.Find(2));
          //await  _userManager.AddToRoleAsync(userToCreate,db.Roles.Find(2).Name);
            //_userManager.

            //userToCreate.Permissions.Add(db.Permissions.Find(2));

            //db.UserPermissions.Add(new UserPermission {UserId = user.Id,
            //PermissionId = 2});
            // _userManager.CreateAsync(userToCreate);
            //db.UserRoles.Add(new IdentityUserRole<int> {UserId=userToCreate.Id,RoleId = 2 });

            db.Users.Add(userToCreate);
            db.SaveChanges();
        }

        public void Update(User user, int idToUpdate)
        {
            User userToUpdate = db.Users.FirstOrDefault(p => p.Id == idToUpdate);

            if (user.Name != null) { userToUpdate.Name = user.Name; }
            if (user.Surname != null) { userToUpdate.Surname = user.Surname; }
            if (user.Age != 0) { userToUpdate.Age = user.Age; }
            if (user.Office != null) { userToUpdate.Office = user.Office; }

            if (user.Tasks != null) {
                foreach (UserTask task in user.Tasks)  
                    userToUpdate.Tasks.Add(task)  ; }
            if (user.Permissions != null)
            {
                foreach (Permission perm in user.Permissions)
                    userToUpdate.Permissions.Add(perm);
            }

            db.Update(userToUpdate);
           
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
