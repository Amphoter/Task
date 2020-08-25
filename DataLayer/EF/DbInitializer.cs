using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer.EF
{
   public static class DbInitializer
    {

        
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Permissions.Any())
            {
                context.Permissions.Add(new Permission
                {
                    //Id = 1,
                    Name = "Admin",
                    Description = "Admin"

                });
                context.Permissions.Add(new Permission
                {
                    //Id = 2,
                    Name = "SimpleUser",
                    Description = "SimpleUser"

                }
             );
            }

            context.SaveChanges();
                
            
        }
    }
}
