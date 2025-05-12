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

        [HttpGet]
        public void DifferedExecution()
        {
            var categories = _context.Category;
            //When you use the deferred execution, the query is not executed until you enumerate it.
            foreach (var category in categories)
            {
                var categoryName = "";
                categoryName = category.Name;
            }
            //When you call whatever method that enumerate the query, the query is executed. ToList(), ToArray(), ToDictionary()
            var categories2 = _context.Category.ToList();
            foreach (var category in categories2)
            {
                var categoryName = "";
                categoryName = category.Name;
            }
            //When you call whatever method that returns a single object
            var category3 = _context.Category;
            var categoriesTotal = _context.Category.Count();
            var categoriesTotal2 = category3.Count();
            var test = "";
        }

        //IEnumerable
        //Es una interfaz que permite a una clase retornar una secuencia de valores item a item (un item a la vez). Cuando aplicas esta interfaz, también necesitas implementar IEnumerator interfaces, el cual provee el método necesario para iterar a traves de la colección. 
        public void TestIEnumerable()
        {
            //El filtro se hace del lado del cliente
            //Generamos una lista de categorías
            IEnumerable<Category> categories = _context.Category;
            //Iteramos a través de la lista de categorías se hace el filtro del lado de cliente
            var activesCategories = categories.Where(c => c.Active == true).ToList;
        }

        //IQueryable
        public void TestIQueryable()
        {
            //El filtro se hace del lado del servidor
            //Generamos una lista de categorías
            IQueryable<Category> categories = _context.Category;
            //Iteramos a través de la lista de categorías se hace el filtro del lado de servidor
            var activesCategories = categories.Where(c => c.Active == true).ToList();
        }

        //Update
        public void TestUpdate()
        //Adjunta la entidad y la marca automáticamente con el estado de "Modified"
        {
            //Update
            var userData = _context.User.Include(data => data.UserDetail).FirstOrDefault(d => d.Id == 2);
            userData.UserDetail.Sport = "Futbol";
            _context.User.Update(userData);
            _context.SaveChanges();
        }
        //Attach
        public void TestAttach()
        {
            //Adjunta la entidad al contexto con un estado inicial de "Unchanged"
            //Nunca hace una actualización
            //Update
            var userData = _context.User.Include(data => data.UserDetail).FirstOrDefault(d => d.Id == 2);
            userData.UserDetail.Sport = "Futbol";
            _context.User.Attach(userData);
            _context.SaveChanges();
        }

        //Call a view
        public void CallView()
        {
            //Call a view
            var useView1 = _context.CategoryFromView.ToList();
            var useView2 = _context.CategoryFromView.FirstOrDefault();
            var useView3 = _context.CategoryFromView.Where(c => c.Active == true);
        }

        public void QueryFromSQL()
        {
            //Query from SQL
            var user = _context.User.FromSqlRaw("SELECT * FROM dbo.User").ToList();
            //Query from SQL with parameters
            var userId = 1;
            var user2 = _context.User.FromSqlInterpolated($"SELECT * FROM dbo.User WHERE Id = {userId}").ToList();
            //User from Stored Procedure
            var userFromProcedure = _context.User.FromSqlInterpolated($"EXEC dbo.GetCategoryById {userId}").ToList();

        }
    }
}