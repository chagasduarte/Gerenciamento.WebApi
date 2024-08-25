using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Domain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

    }
}
