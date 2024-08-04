using Microsoft.AspNetCore.Mvc;
using First_MVC_App.Models;
using static NuGet.Packaging.PackagingConstants;
using System.Collections.Generic;

namespace First_MVC_App.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly List<Employee> _employees;
        private readonly List<Order> _orders;

        public EmployeesController()
        {
            _employees = new List<Employee>()
            {
                new(){ EmployeeID = 1,Name="Alisha .C ",City="Mumbai"},
                new(){ EmployeeID = 2,Name="Aisha .C ",City="Bengaluru"},
                new(){ EmployeeID = 3,Name="Alia .C ",City="Dubai"},
            };
            _orders = new List<Order>() 
            { new() { OrderID = 100, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 10, EmployeeId = 1 },
                new() { OrderID = 101, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 23, EmployeeId = 1 },
                new() { OrderID = 102, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 13, EmployeeId = 2 },
                new() { OrderID = 103, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 24, EmployeeId = 3 } };
        }
        public IActionResult Index()
        {
            //return Content("<h1>Welcome to Bosch! Bengaluru</h1><h1/><h6>Development Center</h6>");
            return File("~/css/site.css","text/css");
        }

        public IActionResult Data()
        {
            return Json(_employees);
        }
        public IActionResult Address()
        {
            return View();
        }

        public IActionResult List()
        {
            ViewBag.PageTitle="Shravani's first MVC Project";
            ViewBag.PageSubTitle="ViewBag example";
            ViewBag.Order = _orders;
            return View("List",_employees);
            
        }
      
        public IActionResult One()
        {
            ViewBag.TitleOne = "This is coming from ViewBag";
            ViewData["TitleTwo"] = "This is coming from ViewData";
            TempData["TitleThree"] = "This is coming from tempData";
            //return View();
            return RedirectToAction("Two");

        }

        public IActionResult Two()
        {
            return View();
        }
    }
}
