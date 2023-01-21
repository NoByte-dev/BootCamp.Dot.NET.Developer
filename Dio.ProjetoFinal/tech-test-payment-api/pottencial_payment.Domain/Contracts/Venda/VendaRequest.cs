using pottencial_payment.Domain.Contracts.Item;
using System.ComponentModel.DataAnnotations;

namespace pottencial_payment.Domain.Contracts.Venda
{
    public class VendaRequest
    {
        public DateTime DataVenda { get; set; }
        public int VendedorId { get; set; }
        public ItemRequest[] Itens { get; set; }
    }
}
