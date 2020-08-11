using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoqueDTI.Models
{
    public class Produto
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public int Quantidade {get;set;}
        public decimal Valor {get;set;}
    }
}