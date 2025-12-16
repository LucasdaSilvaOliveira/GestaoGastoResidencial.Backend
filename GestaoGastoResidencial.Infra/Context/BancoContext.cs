using GestaoGastoResidencial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoGastoResidencial.Infra.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
