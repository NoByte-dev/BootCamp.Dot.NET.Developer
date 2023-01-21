using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pottencial_payment.Domain.Entities;

namespace pottencial_payment.Infrastructure.Mappings
{
    internal class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.HasMany(p => p.Vendas).WithOne(p => p.Vendedor);
            builder.HasIndex(p => p.Cpf).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
        }
    }
}
