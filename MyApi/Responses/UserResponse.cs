using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace LogicLayer.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Office office { get; set; }
        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
