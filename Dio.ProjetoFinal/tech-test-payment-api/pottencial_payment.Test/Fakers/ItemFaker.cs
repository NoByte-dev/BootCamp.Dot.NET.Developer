using Bogus;
using pottencial_payment.Domain.Contracts.Item;
namespace pottencial_payment.Test.Fakers
{
    public class ItemFaker
    {
        private static readonly Faker faker = new Faker();

        public static ItemRequest ItemRequestFaker()
        {
            return new ItemRequest()
            {
                Nome = faker.Person.FirstName,
            };
        }
    }
}
