using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
   public class ApplicationContext : IdentityDbContext<User,Permission,int>
    {     
        public  DbSet<User> AppUsers { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Office> Offices { get; set; }
       // public DbSet<UserPermission> UserPermissions { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {            
            
        }
        
        
       

       
    }
}
