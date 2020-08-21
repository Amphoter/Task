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
    public class UserTaskRepository : IRepository<UserTask>
    {
        private ApplicationContext db;
        public UserTaskRepository(ApplicationContext context)
        {
            db = context;
        }

        public UserTask Get(int id)
        {
            return db.Tasks.FirstOrDefault(p => p.Id == id);
        }

       
        public IEnumerable<UserTask> GetAll()
        {
            return db.Tasks.ToList();
        }

        public void Create(UserTask task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Update(UserTask task)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            UserTask task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
            db.SaveChanges();
        }
    }
}
