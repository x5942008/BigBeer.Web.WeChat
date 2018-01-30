using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace weixin.mp.wujixiong.com.Areas.Activity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("/Areas/Activity/Home/Index页面");
        }
    }
}