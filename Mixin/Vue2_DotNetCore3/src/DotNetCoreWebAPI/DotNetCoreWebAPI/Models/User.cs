using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            StudentDetail = new HashSet<StudentDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int PermissionCode { get; set; }
        public bool IsEnable { get; set; }

        public virtual Permission PermissionCodeNavigation { get; set; }
        public virtual TeacherDetail TeacherDetail { get; set; }
        public virtual ICollection<StudentDetail> StudentDetail { get; set; }
    }
}
