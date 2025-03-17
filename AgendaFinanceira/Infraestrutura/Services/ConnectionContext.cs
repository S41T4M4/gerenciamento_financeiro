using AgendaFinanceira.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AgendaFinanceira.Infraestrutura.Services
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Contas> Contas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<MetasFinanceiras> MetasFinanceiras { get; set; }
        public DbSet<Despesas> Despesas { get; set; }   

        public ConnectionContext(DbContextOptions<ConnectionContext> options)
          : base(options)
        {
        }

        public override int SaveChanges()
        {
            var despesas = ChangeTracker.Entries<Despesas>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .ToList();

            foreach (var despesa in despesas)
            {
                var conta = Contas.Find(despesa.id_conta);

                if (conta != null)
                {
                    conta.saldo -= despesa.valor; 
                }
            }

            return base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=sistema_financeiro;" +
            "User Id=postgres;" +
            "Password=Staff4912;");

    }
}
