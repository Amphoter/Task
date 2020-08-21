using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class UserTaskRequest
    {
        

        public int UserId { get; set; }
        public string TaskDescription { get; set; }
    }
}
