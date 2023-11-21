using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Todo.Models.ViewModels;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TodoViewModel todoviewmodel = new TodoViewModel();
            using (var ctx = new BaseContext())
            {
                list test = new list();
                todoviewmodel.TodoList = ctx.List.ToList();



            }

            return View(todoviewmodel);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (var ctx = new BaseContext())
            {
               var result= ctx.List.FirstOrDefault(q=>q.id== id);
                ctx.Remove(result);
                ctx.SaveChanges();
            }

            return Json(new { });
        }

        [HttpPost]
        public JsonResult Update(int id,string name)
        {
            using (var ctx = new BaseContext())
            {
                var result = ctx.List.FirstOrDefault(q => q.id == id);
                ctx.Update(result);
                ctx.SaveChanges();
            }

            return Json(new { });
        }

        [HttpPost]
        public IActionResult Insert(string Title)
        {

            using (var ctx = new BaseContext())
            {
                list test = new list();
                test.Title = Title;
                test.Description = Title;


                ctx.List.Add(test);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            List<list> testList = new List<list>();
            using (var ctx = new BaseContext())
            {
                testList = ctx.List.ToList();
            }

            return View(testList);
        }



    }

    public class BaseContext : DbContext
    {
        public DbSet<list> List { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4EVA0A7\\SQLEXPRESS;Database=ToDoList;Trusted_Connection=True;");
        }
    }

    public class list
    {
        public int id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
