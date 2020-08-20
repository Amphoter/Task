using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int age { get; set; }
        public Office office { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Permission> Permissions { get; set; }

        public User()
        {
            Tasks = new List<Task>();
            Permissions = new List<Permission>();
        }

    }

    
}
