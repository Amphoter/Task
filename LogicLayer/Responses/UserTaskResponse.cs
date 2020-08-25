using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Responses
{
  public  class UserTaskResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TaskDescription { get; set; }
    }
}
