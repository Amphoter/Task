using FirstTask.EF;
using FirstTask.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class TaskRepository : IRepository<Models.Task>
    {
        private ApplicationContext db;
        public TaskRepository(ApplicationContext context)
        {
            db = context;
        }

        public Models.Task Get(int id)
        {
            return db.Tasks.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Models.Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public void Create(Models.Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Update(Models.Task task)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            Models.Task task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
            db.SaveChanges();
        }
    }
}
