using pottencial_payment.Domain.Enums;

namespace pottencial_payment.Domain.Contracts.Venda
{
    public class VendaResponse
    {
        public int Id { get; set; }
        public StatusVendaEnum Status { get; set; }
        public DateTime DataVenda { get; set; }
        public int VendedorId { get; set; }
    }
}
