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
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Update(UserTask task,int idToUpdate)
        {
            UserTask taskToUpdate = db.Tasks.FirstOrDefault(t=>t.Id==idToUpdate);
            
            if (task.UserId != 0 ) 
            {
                taskToUpdate.UserId = task.UserId;
            }
            
            if (task.TaskDescription != null )
            {

                taskToUpdate.TaskDescription = task.TaskDescription;
            }

            db.Update(taskToUpdate);
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
