namespace pottencial_payment.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //Foring Key
        public virtual Venda Venda { get; set; }
        public int VendaId { get; set; }
    }
}
