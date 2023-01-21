using AutoFixture;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using Moq;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Domain.Services;
using pottencial_payment.Test.Configs;
using System.Linq.Expressions;

namespace pottencial_payment.Test.Service
{
    [Trait("Service", "Service Vendedor")]
    public class VendedorServiceTest
    {
        private readonly Mock<IVendedorRepository> _mockVendedorRepository;
        private readonly Faker _faker;
        private readonly Fixture _fixture;

        public VendedorServiceTest()
        {
            _mockVendedorRepository = new Mock<IVendedorRepository>();
            _faker = new Faker();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Vendedor")]
        public async Task Get()
        {
            var entities = _fixture.Create<Task<IEnumerable<Vendedor>>>();

            _mockVendedorRepository.Setup(mock => mock.ToListAsync()).Returns(entities);

            var service = new VendedorService(_mockVendedorRepository.Object);

            var response = await service.ObterListaAsync();

            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Busca Vendedor Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Vendedor>();

            _mockVendedorRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Vendedor, bool>>>())).ReturnsAsync(entity);

            var service = new VendedorService(_mockVendedorRepository.Object);

            var response = await service.ObterPorIdAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Remove Vendedor Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Vendedor>();

            _mockVendedorRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mockVendedorRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);
            var service = new VendedorService(_mockVendedorRepository.Object);

            try
            {
                await service.DeletarAsync(entity.Id);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

    }
}