using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pottencial_payment.Domain.Contracts.Venda;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Services;

namespace pottencial_payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;
        private readonly IMapper _mapper;
        public VendaController(IVendaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    
        /// <summary>
        /// Cadastra uma nova venda
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">"Sucesso e retorna uma ID"</response>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] VendaRequest request)
        {
            var entity = _mapper.Map<Venda>(request);
            await _service.AdicionarAsync(entity);
            return Created(nameof(PostAsync), new {id = entity.Id});
        }
        /// <summary>
        /// Listar vendas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaResponse>>> GetAsync()
        {
            var entities = await _service.ObterListaAsync();
            var response = _mapper.Map<IEnumerable<VendaResponse>>(entities);
            return Ok(response);
        }

        /// <summary>
        /// Localiza venda por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _service.ObterPorIdAsync(id);
            var response = _mapper.Map<VendaResponseItens>(entity);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Sucesso, e retorna o elemento alterado via ID</response>
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync([FromRoute] int id, [FromQuery] VendaStatusRequest request)
        {
            await _service.AtualizarStatus(id, request.Status);
            return Ok();
        }

        /// <summary>
        /// Altera um status
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] VendaRequest request)
        {
            var entity = _mapper.Map<Venda>(request);
            entity.Id = id;
            await _service.AtualizarAsync(entity);
            return NoContent();
        }

        /// <summary>
        /// Remove uma venda por ID
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
