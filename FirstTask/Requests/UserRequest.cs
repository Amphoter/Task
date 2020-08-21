using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class UserRequest
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public int age { get; set; }
        public Office office { get; set; }
        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        

    }

    
}
