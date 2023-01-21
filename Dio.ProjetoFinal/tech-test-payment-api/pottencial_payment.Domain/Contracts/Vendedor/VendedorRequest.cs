using System.ComponentModel.DataAnnotations;

namespace pottencial_payment.Domain.Contracts.Vendedor
{
    public class VendedorRequest
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
