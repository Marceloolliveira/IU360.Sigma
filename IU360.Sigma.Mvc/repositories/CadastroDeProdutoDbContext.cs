using IU360.Sigma.Mvc.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace IU360.Sigma.Mvc.repositories
{
    public class CadastroDeProdutoDbContext : DbContext
    {
        public CadastroDeProdutoDbContext(DbContextOptions<CadastroDeProdutoDbContext> options)
           : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; } = null;
    }
}
