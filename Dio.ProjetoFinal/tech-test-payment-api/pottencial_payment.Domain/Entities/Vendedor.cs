namespace pottencial_payment.Domain.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        //Referece
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
