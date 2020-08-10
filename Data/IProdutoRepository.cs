using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstoqueDTI.Models;

namespace ProjetoEstoqueDTI.Data
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetProdutos();
        Produto GetProdutoById(int id);    
        Task<bool> PutProduto(Produto produto);
        Task<bool> PostProduto(Produto produto);
        Task<bool> DeleteProduto(Produto produto);
        bool ProdutoExists(int id);
    }
}