using System;
using Microsoft.AspNetCore.Mvc;
using AspCore.Models;


namespace AspCore.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            return Content(funcionario.ToString());
        }
    }
}