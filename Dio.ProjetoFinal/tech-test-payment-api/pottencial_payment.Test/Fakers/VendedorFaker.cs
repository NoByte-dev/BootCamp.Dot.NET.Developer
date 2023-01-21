using Bogus;
using Bogus.Extensions.Brazil;
using pottencial_payment.Domain.Contracts.Vendedor;
using pottencial_payment.Domain.Entities;

namespace pottencial_payment.Test.Fakers
{
    public class VendedorFaker
    {
        private static readonly Faker faker = new Faker();

        public static VendedorRequest VendedorRequestFaker()
        {
            return new VendedorRequest()
            {
                CPF = faker.Person.Cpf(),
                Email = faker.Internet.Email(),
                Nome = faker.Person.FirstName,
                Telefone = faker.Phone.PhoneNumber("(31) 9####-####"),
            };
        }
        public static Vendedor VendedorEntityFaker()
        {
            return new Vendedor()
            {
                Cpf = faker.Person.Cpf(),
                Email = faker.Internet.Email(),
                Nome = faker.Person.FirstName,
                Telefone = faker.Phone.PhoneNumber(),
                Id = faker.IndexFaker,               
            };
        }
    }
}
