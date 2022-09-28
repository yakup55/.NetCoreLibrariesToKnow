using ErrorHandling.Filter;
using ErrorHandling.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomHandleExceptionFilterAttribute(Errorpage = "Error1")]
        public IActionResult Index()
        {
            throw new Exception("Hata");
            return View();
        }
        [CustomHandleExceptionFilterAttribute(Errorpage = "Error1")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;
          
            return View();
        }
        public IActionResult Error1()
        {
            return View();
        }
    }
}
