using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
   public class User: IdentityUser<int>
    {
     
        public string Name { get; set; }
        
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public int? OfficeId { get; set; }
        public Office Office { get; set; }
        public   ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        
        
    }
}
