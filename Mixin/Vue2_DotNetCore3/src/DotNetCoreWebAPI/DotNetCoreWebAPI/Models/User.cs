using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int PermissionCode { get; set; }
        public bool IsEnable { get; set; }

        public virtual Permission PermissionCodeNavigation { get; set; }
        public virtual StudentDetail StudentDetail { get; set; }
        public virtual TeacherDetail TeacherDetail { get; set; }
    }
}
