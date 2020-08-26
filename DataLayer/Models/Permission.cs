using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Permission:IdentityRole<int>
    {

        public string Description { get; set; }
    }

    
}
