using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using pottencial_payment.Api.Controllers;
using pottencial_payment.Domain.Contracts.Venda;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Services;
using pottencial_payment.Test.Configs;
using pottencial_payment.Test.Fakers;

namespace pottencial_payment.Test.Controller
{
    [Trait("Controller", "Venda Controller")]
    public class VendaControllerTest
    {
        private readonly Mock<IVendaService> _mockVendaService;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;
        public VendaControllerTest()
        {
            _mockVendaService = new Mock<IVendaService>();
            _mapper = MapConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Cadastra um Venda")]
        public async Task Post()
        {
            var entity = VendaFaker.VendaRequestFaker();

            _mockVendaService.Setup(mock => mock.AdicionarAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.PostAsync(entity);

            var objectResult = Assert.IsType<CreatedResult>(response);
            Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Edita um Venda já existente")]
        public async Task Put()
        {
            var request = VendaFaker.VendaRequestFaker();
            var id = _fixture.Create<int>();

            _mockVendaService.Setup(mock => mock.AtualizarAsync(It.IsAny<Venda>())).Returns(Task.CompletedTask);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.PutAsync(id, request);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);

        }

        [Fact(DisplayName = "Atualiza uma status de venda existente")]
        public async Task AlterarData()
        {
            var id = _fixture.Create<int>();
            var statusRequest = _fixture.Create<VendaStatusRequest>();

            _mockVendaService.Setup(mock => mock.AtualizarStatus(id, statusRequest.Status)).Returns(Task.CompletedTask);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.PatchAsync(id, statusRequest);

            var objectResult = Assert.IsType<OkResult>(response);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }


        [Fact(DisplayName = "Busca um Venda por Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Venda>();

            _mockVendaService.Setup(mock => mock.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.GetByIdAsync(entity.Id);

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var vendaResponse = Assert.IsType<VendaResponseItens>(objectResult.Value);
            Assert.Equal(vendaResponse.Id, entity.Id);
        }

        [Fact(DisplayName = "Busca todos Venda")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Venda>>();

            _mockVendaService.Setup(mock => mock.ObterListaAsync()).ReturnsAsync(entities);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.GetAsync();

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var vendaResponse = Assert.IsType<List<VendaResponse>>(objectResult.Value);
            Assert.True(vendaResponse.Count() > 0);
        }

        [Fact(DisplayName = "Remove uma Venda existente")]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _mockVendaService.Setup(mock => mock.DeletarAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var controller = new VendaController(_mockVendaService.Object, _mapper);

            var response = await controller.DeleteAsync(id);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }
    }
}
