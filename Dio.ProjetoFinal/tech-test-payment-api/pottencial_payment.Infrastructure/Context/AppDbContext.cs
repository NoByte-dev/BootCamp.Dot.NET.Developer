using Microsoft.EntityFrameworkCore;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Infrastructure.Mappings;

namespace pottencial_payment.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedor>(new VendedorMap().Configure);
            modelBuilder.Entity<Venda>(new VendaMap().Configure);
            modelBuilder.Entity<Item>(new ItemMap().Configure);
        }
    }
}
