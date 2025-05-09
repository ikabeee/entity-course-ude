using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using entity_course_ude.data;
using entity_course_ude.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_course_ude.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        public readonly ApplicationDBContext _context;
        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Explicit load
            //1st options without related data
            // List<Product> productsList = _context.Product.ToList();
            // foreach(var product in productsList)
            // {
            //2nd option manual load generating a lot SQL Queries
            // product.Category = _context.Category.FirstOrDefault(c => c.Category_Id == product.Category_Id);
            //3rd Explicit loading
            //     _context.Entry(product).Reference(c => c.Category).Load();
            // }
            //Option 4: Eager loading (Data relationated)
            List<Product> productsList = _context.Product.Include(c => c.Category).ToList();
            return View(productsList);
        }

        [HttpGet("Create")]

        public IActionResult Create()
        {
            ProductCategoryViewModel productCategory = new ProductCategoryViewModel();
            productCategory.CategoryList = _context.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Category_Id.ToString()
            });

            return View(productCategory);
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Product.Add(product);
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

            ProductCategoryViewModel productCategory = new ProductCategoryViewModel();
            productCategory.CategoryList = _context.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Category_Id.ToString()
            });
            productCategory.Product = _context.Product.FirstOrDefault(c => c.Product_Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(ProductCategoryViewModel productViewModel)
        {
            if (productViewModel.Product.Product_Id == 0)
            {
                return View(productViewModel.Product);
            }
            else
            {
                _context.Product.Update(productViewModel.Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int? id)
        {
            var product = _context.Product.FirstOrDefault(c => c.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("ManageTags")]
        public IActionResult ManageTags(int id)
        {
            ProductTagViewModel productTags = new ProductTagViewModel
            {
                ProductTagList = _context.ProductTag.
                    Include(t => t.Tag)
                    .Include(p => p.Product)
                    .Where(p => p.Product_Id == id),
                ProductTag = new ProductTag()
                {
                    Product_Id = id
                },
                Product = _context.Product.FirstOrDefault(p => p.Product_Id == id)
            };
            //Temp load
            List<int> tempListTagProduct = productTags.ProductTagList.Select(t => t.Tag_Id).ToList();
            // Get all tags whose id's doesn't fit on temp list
            var tempList = _context.Tag.Where(t => !tempListTagProduct.Contains(t.Tag_Id)).ToList();
            productTags.TagList = tempList.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Tag_Id.ToString()
            });
            return View(productTags);
        }
        // [HttpPost]
        // public IActionResult ManageTags(int id)
        // {
            
        // }
    }
}