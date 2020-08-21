using FirstTask.EF;
using FirstTask.Interfaces;
using FirstTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class PermissionRepository : IRepository<Permission>
    {
        private ApplicationContext db;
        public PermissionRepository(ApplicationContext context)
        {
            db = context;
        }

        public Permission Get(int id)
        {
            return db.Permissions.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Permission> GetAll()
        {
            return db.Permissions.ToList();
        }

        public void Create(Permission perm)
        {
            db.Permissions.Add(perm);
            db.SaveChanges();
        }

        public void Update(Permission perm)
        {
            db.Entry(perm).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            Permission perm = db.Permissions.Find(id);
            if (perm != null)
                db.Permissions.Remove(perm);
            db.SaveChanges();
        }
    }
}
