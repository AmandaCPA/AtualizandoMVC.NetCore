using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspCore.Models;
using AspCore.Database;


namespace AspCore.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database; //criando um atributo (injetar o BD dentro da controller)
        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database; //acesso ao contexto de banco de dados
        }

        public IActionResult Index()
        {
            var funcionarios = database.Funcionarios.ToList(); 
            return View(funcionarios);
            //Para fazer consulta ao BD: Chama a tabela de entidade e converte em Tolist
            //Para fazer consulta ao BD: chama-se uma variavel "funcionario" dentro do banco de dados 
            //(isso permite listar, trazer uma coleção dos funcionarios com o ToList - antes deve importar o pacote)
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
            //chamar o objeto funcionario dentro do objeto de contexto do BD
            //first mapeia e retorna o primeiro registro que corresponde a querry
            //outro exemplo: registro => registro.Cpf == "123" && registro.Nome == Amanda
        }

        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id ==id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if(funcionario.Id == 0)
            {
                database.Funcionarios.Add(funcionario); //método add adiciona o conteúdo (que recebe funcionario)
                //se cria condição para não confundir as chamadas editar e criar
                //nessa condição está criando um novo funcionario já que não existe id ("== 0")
            }
            else 
            {
                Funcionario funcionarioDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                
                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Salario = funcionario.Salario;
                funcionarioDoBanco.Cpf = funcionario.Cpf;
            }
            database.SaveChanges(); //savechanges é para confirmar as modificações
            return RedirectToAction("Index");
        }
    }
}