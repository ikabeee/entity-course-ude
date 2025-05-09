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
        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> userList = _context.User.ToList();
            return View(userList);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int? id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.User.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Detail")]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var user = _context.User.Include(d => d.UserDetail).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost("AddDetail")]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetail(User user)
        {
            if(user.UserDetail.UserDetail_Id == 0)
            {
                //Add details for this user
                _context.UserDetail.Add(user.UserDetail);
                _context.SaveChanges();
                var userFromBd = _context.User.FirstOrDefault(u => u.Id == user.Id);
                userFromBd.UserDetail_Id = user.UserDetail.UserDetail_Id;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}