using System;
using Microsoft.AspNetCore.Mvc;

namespace AspCore.Controllers
{
    [Route("painel/admin")]
    public class AdminController : Controller
    {
        
        [HttpGet("principal/{numero:int?}/{nome}")] //? a passaagem de parametro se torna opcional
        //[HttpGet("")] consigo acessar tb sem passar descrição 
        public IActionResult Index(int numero, string nome)
        {
            return Content("o número é " + numero + " e o nome é " + nome);
            //return View() / File() / Json() / Content()
        }

        [HttpGet("son")]
        public IActionResult schoolOfNet()
        {
            var nome = Request.Query["nome"];
            return Content("Bora aprender de novo " + nome);
        }

        [HttpGet("view")]
        public IActionResult visualizar() //na pasta de views tem que ter o mesmo nome do metodo
        {
            ViewData["helloWorld"] = true; //uma opção de passar info para a view
            //ViewData["nome"] = "Victor";
            return View ("nada");

        }
    }
}