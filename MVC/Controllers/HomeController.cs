using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    //Desse modo eu configuro a rota diretamente na controller invalidando as definições da classe Startup.cs
    //[Route ("[controller]/[action]")]
    public class HomeController : Controller
    {
        public String Text(){
            return "Text";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult People()
        {
            var people = new People{Name = "Jhon", Age = 33};
            return View(people);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
