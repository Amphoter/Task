using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
  public   class PermissionRepository : ICrudRepository<Permission>
    {
        private readonly ApplicationContext db;
        private readonly RoleManager<Permission> _roleManager;
       public  PermissionRepository(ApplicationContext context, RoleManager<Permission> roleManager)
        {
            db = context;
            _roleManager = roleManager;
        }

        public Permission Get(int id)
        {
            return db.Roles.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Permission> GetAll()
        {
            return db.Roles.ToList();
        }

        public void Create(Permission perm)
        {
             perm.NormalizedName = perm.Name.ToUpper();         
            db.Roles.Add(perm);
            db.SaveChanges();
        }

        public void Update(Permission perm,int idToUpdate)
        {
            Permission permToUpdate = db.Roles.Find(idToUpdate);

            if(perm.Name != null) { permToUpdate.Name = perm.Name; }
            if (perm.Description != null) { permToUpdate.Description = perm.Description; }

            db.Update(permToUpdate);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            Permission perm = db.Roles.Find(id);
            if (perm != null)
                db.Roles.Remove(perm);
            db.SaveChanges();
        }

       
    }
}
