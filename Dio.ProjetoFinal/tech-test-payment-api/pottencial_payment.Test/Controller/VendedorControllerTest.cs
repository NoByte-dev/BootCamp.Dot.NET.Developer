using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using pottencial_payment.Api.Controllers;
using pottencial_payment.Domain.Contracts.Vendedor;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Services;
using pottencial_payment.Test.Configs;
using pottencial_payment.Test.Fakers;

namespace pottencial_payment.Test.Controller
{
    [Trait("Controller", "Vendedor Controller")]
    public class VendedorControllerTest
    {
        private readonly Mock<IVendedorService> _mockVendedorService;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;
        public VendedorControllerTest()
        {
            _mockVendedorService = new Mock<IVendedorService>();
            _mapper = MapConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Cadastra um Vendedor")]
        public async Task Post()
        {
            var entity = VendedorFaker.VendedorRequestFaker();

            _mockVendedorService.Setup(mock => mock.AdicionarAsync(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);

            var controller = new VendedorController(_mockVendedorService.Object, _mapper);

            var response = await controller.PostAsync(entity);

            var objectResult = Assert.IsType<CreatedResult>(response);
            Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Edita um Vendedor já existente")]
        public async Task Put()
        {
            var request = VendedorFaker.VendedorRequestFaker();
            var id = _fixture.Create<int>();

            _mockVendedorService.Setup(mock => mock.AtualizarAsync(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);

            var controller = new VendedorController(_mockVendedorService.Object, _mapper);

            var response = await controller.PutAsync(id, request);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);

        }


        [Fact(DisplayName = "Busca um Vendedor por Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Vendedor>();

            _mockVendedorService.Setup(mock => mock.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var controller = new VendedorController(_mockVendedorService.Object, _mapper);

            var response = await controller.GetByIdAsync(entity.Id);

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var vendedorResponse = Assert.IsType<VendedorResponse>(objectResult.Value);
            Assert.Equal(vendedorResponse.Id, entity.Id);
        }

        [Fact(DisplayName = "Busca todos Vendedor")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Vendedor>>();

            _mockVendedorService.Setup(mock => mock.ObterListaAsync()).ReturnsAsync(entities);

            var controller = new VendedorController(_mockVendedorService.Object, _mapper);

            var response = await controller.GetAsync();

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var vendedorResponse = Assert.IsType<List<VendedorResponse>>(objectResult.Value);
            Assert.True(vendedorResponse.Count() > 0);
        }

        [Fact(DisplayName = "Remove uma Vendedor existente")]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _mockVendedorService.Setup(mock => mock.DeletarAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var controller = new VendedorController(_mockVendedorService.Object, _mapper);

            var response = await controller.DeleteAsync(id);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }
    }
}
