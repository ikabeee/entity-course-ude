using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using entity_course_ude.data;
using entity_course_ude.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace entity_course_ude.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {

        public readonly ApplicationDBContext _context;
        public UsersController (ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> userList = _context.User.Include(user => user.UserDetail).ToList();
            return View(userList);
        }
    }
}