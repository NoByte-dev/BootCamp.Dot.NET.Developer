using pottencial_payment.Domain.Contracts.Item;
using pottencial_payment.Domain.Enums;

namespace pottencial_payment.Domain.Contracts.Venda
{
    public class VendaResponseItens
    {
        public int Id { get; set; }
        public StatusVendaEnum Status { get; set; }
        public DateTime DataVenda { get; set; }
        public int VendedorId { get; set; }
        public ItemResponse[] Itens { get; set; }
    }
}
