using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeDeductions.Models;

namespace EmployeeDeductions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeUnitOfWork UnitOfWork;

        public HomeController(ILogger<HomeController> logger, IEmployeeUnitOfWork uow)
        {
            _logger = logger;
            UnitOfWork = uow;
        }

        public IActionResult Index()
        {
            var employees = UnitOfWork.EmployeeRepository.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
