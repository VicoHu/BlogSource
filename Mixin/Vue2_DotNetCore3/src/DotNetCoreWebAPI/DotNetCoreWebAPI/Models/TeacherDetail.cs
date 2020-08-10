using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI.Models
{
    public partial class TeacherDetail
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
    }
}
