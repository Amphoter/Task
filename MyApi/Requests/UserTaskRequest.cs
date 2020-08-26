using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Requests
{
  public  class UserTaskRequest
    {
        public int UserId { get; set; }
        public string TaskDescription { get; set; }
    }
}
