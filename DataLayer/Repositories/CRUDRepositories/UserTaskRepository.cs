using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
   public class UserTaskRepository : ICrudRepository<UserTask>
    {
        private readonly ApplicationContext db;
       public  UserTaskRepository(ApplicationContext context)
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
           /* User userToAddTask = db.Users.FirstOrDefault(u => Convert.ToInt32(u.Id) == task.UserId);
             userToAddTask.Tasks.Add(task);
            db.Tasks.Add(task);
            db.Update(userToAddTask);
            */
            db.SaveChanges();
        }

        public void Update(UserTask task,int idToUpdate)
        {
            //db.Entry(task).State = EntityState.Modified;
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
