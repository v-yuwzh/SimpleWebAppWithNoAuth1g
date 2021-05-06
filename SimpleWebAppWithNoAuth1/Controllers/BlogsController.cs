using Microsoft.AspNetCore.Mvc;
using SimpleWebAppWithNoAuth1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAppWithNoAuth1.Controllers
{
    public class BlogsController : Controller
    {
        private BloggingContext _context;
        public BlogsController(BloggingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
    }
}