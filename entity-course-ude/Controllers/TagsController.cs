using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace entity_course_ude.Controllers
{
    [Route("[controller]")]
    public class TagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}