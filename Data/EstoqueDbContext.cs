using Microsoft.EntityFrameworkCore;
using ProjetoEstoqueDTI.Models;

namespace ProjetoEstoqueDTI.Models
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
        {}
        public DbSet<Produto> Produtos {get;set;}
    }
}