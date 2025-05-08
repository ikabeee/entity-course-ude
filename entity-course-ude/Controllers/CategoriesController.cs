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
    public class CategoriesController : Controller
    {
        public readonly ApplicationDBContext _context;
        public CategoriesController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Initial query
            // List<Category> categories = _context.Category.ToList();
            //Query filter by date
            // DateTime ComparedDate = new DateTime(2011, 11, 05);
            // List<Category> categories = _context.Category.Where(date => date.CreatedAt >= ComparedDate).OrderByDescending(date => date.CreatedAt).ToList();
            //Query filter by name
            // var categories = _context.Category.Where(category => category.Name == "Test 5").Select(n => n).ToList();
            //Query filter by status
            // List<Category> categories = _context.Category.ToList();
            // var categoryList = _context.Category.Where(category => category.Active == true).ToList();
            // List<Category> categoryList = _context.Category.Skip(3).Take(3).ToList();
            // List<Category> categoryList = _context.Category.FromSqlRaw("SELECT * FROM category").ToList();
            // String interpolation
            var category = _context.Category.FromSql($"SELECT * FROM category").ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateMultiple5Categories()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _context.Category.AddRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult CreateMultiple2Categories()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 2; i++)
            {
                categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _context.Category.AddRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ViewCreateMultipleOptionForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMultipleOptionForm()
        {
            string categoriesForm = Request.Form["Name"];
            var categoriesArray = from val in categoriesForm.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries) select (val);
            List<Category> categories = new List<Category>();
            foreach (var category in categoriesArray)
            {
                categories.Add(new Category
                {
                    Name = category,
                });
            }
            _context.Category.AddRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var category = _context.Category.FirstOrDefault(c => c.Category_Id == id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Category_Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public Task<IActionResult> Delete2Categories()
        {
            IEnumerable<Category> categories = _context.Category.OrderByDescending(c => c.Category_Id).Take(2);
            _context.Category.RemoveRange(categories);
            _context.SaveChanges();
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
        }

        [HttpGet]
        public Task<IActionResult> Delete5Categories(int? id)
        {
            IEnumerable<Category> categories = _context.Category.OrderByDescending(c => c.Category_Id).Take(5);
            _context.Category.RemoveRange(categories);
            _context.SaveChanges();
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
        }
    }
}