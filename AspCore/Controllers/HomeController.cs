using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspCore.Models;
using AspCore.Database;

namespace AspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database; //criando um atributo (injetar o BD dentro da controller)
        public HomeController(ApplicationDBContext database) // esse é o construtor (precisa ter o mesmo nome do controller)
        {
            this.database = database; //acesso ao contexto de banco de dados
        }



      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            /*Categoria c1 = new Categoria();
            c1.Nome = "Victor";
            Categoria c2 = new Categoria();
            c2.Nome = "Victor";
            Categoria c3 = new Categoria();
            c3.Nome = "Erik";
            Categoria c4 = new Categoria();
            c4.Nome = "Wesley";

            List<Categoria> catList = new List<Categoria>();
            catList.Add(c1);
            catList.Add(c2);
            catList.Add(c3);
            catList.Add(c4);

            database.AddRange(catList);

            database.SaveChanges();
            */

            var listaDeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Victor")).ToList(); //para o ToList funcionar deve importar o Linq
            
            Console.WriteLine("------ Categorias ------");

            listaDeCategorias.ForEach(categoria => 
            {
                Console.WriteLine(categoria.ToString());
            });

             Console.WriteLine("-----------------------");


            return Content("Dados salvos");

            //foi criado um formulario no código apenas para facilitar o exemplo
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
