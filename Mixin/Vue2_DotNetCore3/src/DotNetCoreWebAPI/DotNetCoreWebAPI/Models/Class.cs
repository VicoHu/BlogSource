using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            StudentDetail = new HashSet<StudentDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentDetail> StudentDetail { get; set; }
    }
}
