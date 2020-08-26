using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
  public   class PermissionRepository : ICrudRepository<Permission>
    {
        private readonly ApplicationContext db;
       public  PermissionRepository(ApplicationContext context)
        {
            db = context;
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
            db.Roles.Add(perm);
            db.SaveChanges();
        }

        public void Update(Permission perm,int idToUpdate)
        {
            // db.Entry(perm).State = EntityState.Modified;
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
