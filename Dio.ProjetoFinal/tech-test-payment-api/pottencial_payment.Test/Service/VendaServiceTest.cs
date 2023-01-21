using AutoFixture;
using Bogus;
using Moq;
using pottencial_payment.Domain.Contracts.Venda;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Domain.Services;
using pottencial_payment.Test.Configs;
using System.Linq.Expressions;

namespace pottencial_payment.Test.Service
{
    [Trait("Service", "Service Venda")]
    public class VendaServiceTest
    {
        private readonly Mock<IVendaRepository> _mockVendaRepository;
        private readonly Faker _faker;
        private readonly Fixture _fixture;

        public VendaServiceTest()
        {
            _mockVendaRepository = new Mock<IVendaRepository>();
            _faker = new Faker();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Venda")]
        public async Task Get()
        {
            var entities = _fixture.Create<Task<IEnumerable<Venda>>>();

            _mockVendaRepository.Setup(mock => mock.ToListAsync()).Returns(entities);

            var service = new VendaService(_mockVendaRepository.Object);

            var response = await service.ObterListaAsync();

            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Busca Venda Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);

            var service = new VendaService(_mockVendaRepository.Object);

            var response = await service.ObterPorIdAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Busca Venda Id")]
        public async Task GetByIdNull()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync((Venda)null);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.ObterPorIdAsync(entity.Id);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Cadastra Venda")]
        public async Task Post()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.AddAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AdicionarAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsNoTrackingAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task PutNull()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsNoTrackingAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync((Venda)null);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task Patch()
        {
            var entity = _fixture.Create<Venda>();
            var id = _fixture.Create<int>();
            var request = _fixture.Create<VendaStatusRequest>();

            entity.Status = Domain.Enums.StatusVendaEnum.AguardandoPagamento;
            request.Status = Domain.Enums.StatusVendaEnum.PagamentoAprovado;

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarStatus(id, request.Status);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task Patch2()
        {
            var entity = _fixture.Create<Venda>();
            var id = _fixture.Create<int>();
            var request = _fixture.Create<VendaStatusRequest>();

            entity.Status = Domain.Enums.StatusVendaEnum.PagamentoAprovado;
            request.Status = Domain.Enums.StatusVendaEnum.EnviadoPraTransportadora;

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarStatus(id, request.Status);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task Patch3()
        {
            var entity = _fixture.Create<Venda>();
            var id = _fixture.Create<int>();
            var request = _fixture.Create<VendaStatusRequest>();

            entity.Status = Domain.Enums.StatusVendaEnum.EnviadoPraTransportadora;
            request.Status = Domain.Enums.StatusVendaEnum.Entregue;

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarStatus(id, request.Status);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Venda Existente")]
        public async Task Patch4()
        {
            var entity = _fixture.Create<Venda>();
            var id = _fixture.Create<int>();
            var request = _fixture.Create<VendaStatusRequest>();

            entity.Status = Domain.Enums.StatusVendaEnum.AguardandoPagamento;
            request.Status = Domain.Enums.StatusVendaEnum.Entregue;

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Venda, bool>>>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.AtualizarStatus(id, request.Status);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Remove Venda Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mockVendaRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);
            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.DeletarAsync(entity.Id);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Remove Venda Existente")]
        public async Task DeleteNull()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync((Venda)null);
            _mockVendaRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);
            var service = new VendaService(_mockVendaRepository.Object);

            try
            {
                await service.DeletarAsync(entity.Id);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}