using System.ComponentModel.DataAnnotations;

namespace pottencial_payment.Domain.Contracts.Item
{
    public class ItemRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
    }
}