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
    public class TagsController : Controller
    {
        public readonly ApplicationDBContext _context;
        public TagsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Tag> TagList = _context.Tag.ToList();
            return View(TagList);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            _context.Tag.Add(tag);
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
            var tag = _context.Tag.FirstOrDefault(t => t.Tag_Id == id);
            return View(tag);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tag tag)
        {
            _context.Tag.Update(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int? id)
        {
            var tag = _context.Tag.FirstOrDefault(t => t.Tag_Id == id);
            if (tag == null)
            {
                return NotFound();
            }
            _context.Tag.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}