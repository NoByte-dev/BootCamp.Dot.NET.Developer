using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pottencial_payment.Domain.Entities;

namespace pottencial_payment.Infrastructure.Mappings
{
    internal class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(p => p.Venda).WithMany(p => p.Itens);
        }
    }
}
