using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace LogicLayer.Requests
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
       
        public string Password { get; set; }
        public Office Office { get; set; }
        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
