using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEstoqueDTI.Data;
using ProjetoEstoqueDTI.Models;

namespace ProjetoEstoqueDTI.Controllers
{
    [Produces("application/json")]
    [Route("api/Produtos")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repo;
 
        public ProdutosController(IProdutoRepository repositoryProduto)
        {
            _repo = repositoryProduto;
        } 

        // GET: api/Produtos
        [HttpGet]
        public IEnumerable<Produto> GetProdutos()
        {            
            return _repo.GetProdutos();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public Produto GetProduto([FromRoute] int id)
        {
            return _repo.GetProdutoById(id);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != produto.Id)
                return BadRequest();

            try
            {
                await _repo.PutProduto(produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             await _repo.PostProduto(produto);

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produto = _repo.GetProdutoById(id);

            if (produto == null)
                return NotFound();

            await _repo.DeleteProduto(produto);

            return Ok(produto);
        }

        private bool ProdutoExists(int id)
        {
            return _repo.ProdutoExists(id);
        }
    }
}