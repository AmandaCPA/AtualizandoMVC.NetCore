using Microsoft.EntityFrameworkCore;
using AspCore.Models;
namespace AspCore.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set;} //comando para mapear a entidade funcionario no BD (depois do <> é o nome p minha tabela - no plural)
        // não esquecer JAMAIS do public / get /set (se não a pasta migrations não gera comandos necessarios)

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) 
        {}
        
    }
}