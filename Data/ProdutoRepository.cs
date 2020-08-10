using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEstoqueDTI.Models;

namespace ProjetoEstoqueDTI.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstoqueDbContext _context;
        public ProdutoRepository(EstoqueDbContext context)
        {
            _context = context;
        }
        public Produto GetProdutoById(int id)
        {
           return _context.Produtos.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Produto> GetProdutos()
        {
             return _context.Produtos;
        }

        public async Task<bool> PutProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;            
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(x => x.Id == id);
        }
    }
}