using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Autenticacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Autenticacao.Controllers
{
        public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;




        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(UserManager<IdentityUser> userManager)
        {
          _userManager = userManager;
        }





        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/




        public IActionResult Index()
        {
            //var user = await _userManager.GetUserAsync(User);
            //return Content(User.FindFirst("FullName").Value);
            return View();
        }




        [Authorize(Policy = "TemNome")] //deixa acessar a home apenas os usuarios logados
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

