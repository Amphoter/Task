using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string TaskDescription { get; set; }
    }
}
