using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Permission:IdentityRole<int>
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public string Description { get; set; }
    }

    
}
