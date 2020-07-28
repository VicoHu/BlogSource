using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// 学生登录接口
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostLogin(string UserName, string Password)
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            bool state = db.User.Where(u => u.Name == UserName && u.Password == Password && u.PermissionCode == 3).Count() > 0;
            return new JsonResult(new
            {
                state = state
            });
        }

        /// <summary>
        /// 根据老师UserId获得其所有学生的信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetStudentsByTeacherUserId(int UserId)
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            return new JsonResult(db.StudentDetail.Where(s => s.TeacherUserId == UserId).ToList());
        }

        /// <summary>
        /// 注册一个学生
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostAdd(StudentDetail stu)
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            using (var transition = db.Database.BeginTransaction())
            {
                db.User.Add(new User()
                {
                    Name = stu.StudentId,
                    Password = stu.StudentId,
                    IsEnable = true,
                    PermissionCode = 3
                });
                if (db.SaveChanges() > 0)
                {
                    db.StudentDetail.Add(stu);
                    if (db.SaveChanges() > 0)
                    {
                        transition.Commit();
                        return new JsonResult(new
                        {
                            state = true
                        });
                    }
                    else
                    {
                        transition.Rollback();
                        return new JsonResult(new
                        {
                            state = false
                        });
                    }
                }
                else
                {
                    transition.Rollback();
                    return new JsonResult(new
                    {
                        state = false
                    });
                }
            }
        }

    }
}