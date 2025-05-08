using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using entity_course_ude.data;
using entity_course_ude.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet("Create")]
        public IActionResult Create()
        {
            // var userViewModel = new UserUserDetailViewModel
            // {
            //     User 
            // };
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create (User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}