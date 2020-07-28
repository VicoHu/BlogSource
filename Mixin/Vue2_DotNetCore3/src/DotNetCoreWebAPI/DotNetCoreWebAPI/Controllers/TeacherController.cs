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
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// 老师登录接口
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostLogin(string UserName,string PassWord) 
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            bool state = db.User.Where(u=>u.Name == UserName && u.Password == PassWord && u.PermissionCode == 2).Count() > 0;
            return new JsonResult(new
            {
                state = state
            });
        }

        /// <summary>
        /// 获得所有的老师
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAll()
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            return new JsonResult(db.TeacherDetail.ToList());
        }

        /// <summary>
        /// 根据UserId查找老师的信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetTeacherByUserId(int UserId)
        {
            StudentManangeSystemContext db = new StudentManangeSystemContext();
            return new JsonResult(db.TeacherDetail.Where(t => t.UserId == UserId).ToList());
        }
    }
}