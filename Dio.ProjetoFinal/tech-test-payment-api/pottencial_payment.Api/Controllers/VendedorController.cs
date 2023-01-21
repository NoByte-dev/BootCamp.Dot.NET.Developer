using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pottencial_payment.Domain.Contracts.Vendedor;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Services;
using pottencial_payment.Domain.Services;

namespace pottencial_payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _service;
        private readonly IMapper _mapper;

        public VendedorController(IVendedorService vendedorService, IMapper mapper)
        {
            _service = vendedorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastra um novo vendedor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] VendedorRequest request)
        {
            var entity = _mapper.Map<Vendedor>(request);
            await _service.AdicionarAsync(entity);
            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        /// <summary>
        /// Lista todos vendedores
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorResponse>>> GetAsync()
        {
            var entities = await _service.ObterListaAsync();
            var response = _mapper.Map<IEnumerable<VendedorResponse>>(entities);
            return Ok(response);
        }

        /// <summary>
        /// Localiza um vendedor por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _service.ObterPorIdAsync(id);
            var response = _mapper.Map<VendedorResponse>(entity);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza um vendedor por ID
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] VendedorRequest request)
        {
            var entity = _mapper.Map<Vendedor>(request);
            entity.Id = id;
            await _service.AtualizarAsync(entity);
            return NoContent();
        }

        /// <summary>
        /// Deleta vendedor por ID
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }

    }
}
