using Bogus;
using pottencial_payment.Domain.Contracts.Venda;
namespace pottencial_payment.Test.Fakers
{
    public class VendaFaker
    {
        private static readonly Faker faker = new Faker();

        public static VendaRequest VendaRequestFaker()
        {
            return new VendaRequest()
            {
                DataVenda = DateTime.Now,
                Itens = new[] { ItemFaker.ItemRequestFaker() },
                VendedorId = faker.Random.Int(1 - 99)
            };
        }
    }
}
