namespace AspCore.Models
{
    public class Funcionario
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public float Salario {get; set;}
        public string Cpf {get; set;}
        // sempre usar atributos publicos quando trabalhar com entidades e a 1º letra maiuscula (para ele ser mapeado na tabela e reconhecer chave primaria)

        
    }
}