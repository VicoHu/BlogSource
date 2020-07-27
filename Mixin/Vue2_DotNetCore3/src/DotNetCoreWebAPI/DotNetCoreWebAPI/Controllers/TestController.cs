using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public JsonResult getTest()
        {
            return new JsonResult(new
            {
                TimeNow =  DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss")
            });
        }
    }
}