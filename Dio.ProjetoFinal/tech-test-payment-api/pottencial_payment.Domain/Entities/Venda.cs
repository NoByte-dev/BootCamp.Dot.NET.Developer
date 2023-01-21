using pottencial_payment.Domain.Enums;

namespace pottencial_payment.Domain.Entities
{
    public class Venda
    {
        public Venda()
        {
            Status = StatusVendaEnum.AguardandoPagamento;
        }
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public StatusVendaEnum Status { get; set; }

        //Foring Key
        public virtual Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }
        
        //Reference
        public virtual ICollection<Item> Itens { get; set; }
    }
}
