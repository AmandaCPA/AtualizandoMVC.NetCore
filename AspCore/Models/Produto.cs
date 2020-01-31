namespace AspCore.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public Categoria Categoria {get; set;}


        public override string ToString() //para exibir as informações dessa classe no terminal
        {
            return "Id: " + this.Id + " Nome: " + this.Nome + " Categoria [" + this.Categoria.ToString() + "]";
        }
    }
}