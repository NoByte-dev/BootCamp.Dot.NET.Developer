using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Enums;

namespace pottencial_payment.Infrastructure.Mappings
{
    internal class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(p => p.Status).HasConversion(
                p => p.ToString(),
                p => (StatusVendaEnum)Enum.Parse
                (typeof(StatusVendaEnum),p));

            builder.HasMany(p => p.Itens).WithOne(p => p.Venda);
            builder.HasOne(p => p.Vendedor).WithMany(p => p.Vendas);

        }
    }
}
