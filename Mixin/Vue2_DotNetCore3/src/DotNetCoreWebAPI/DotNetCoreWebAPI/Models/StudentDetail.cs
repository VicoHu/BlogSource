using System;
using System.Collections.Generic;

namespace DotNetCoreWebAPI.Models
{
    public partial class StudentDetail
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public int ClassId { get; set; }
        public int TeacherUserId { get; set; }
        public string StudentId { get; set; }

        public virtual Class Class { get; set; }
        public virtual TeacherDetail TeacherUser { get; set; }
        public virtual User User { get; set; }
    }
}
