using AssingmentApp.DAL;
using AssingmentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AssingmentApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBConntext _context;
        public ProductController(ApplicationDBConntext conntext)
        {
            _context = conntext;
        }
        public IActionResult Index()
        {
            var products= _context.Products.Include("Categories");
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [NonAction]
        private void LoadCategories()
        { 
        var categories=_context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        }
        [HttpPost]
        //public IActionResult Create(Products products)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    return NewMethod(products);

        //}

        private IActionResult Create(Products model)
        {
            if (!ModelState.IsValid)
            {
                // Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> entityEntry = 
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                NotFound();

            }
            LoadCategories();
            var product = _context.Products.Find(id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(Products model)
        {
            ModelState.Remove("Categories");
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            
            { 
                NotFound();
            }
            LoadCategories();
            var product=_context.Products.Find(id);

            return View(product);
         }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCorfirm(Products model)
        {
            _context.Products.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        
        }
}
