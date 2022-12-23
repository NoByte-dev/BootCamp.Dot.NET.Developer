using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Através dessa rota você será capaz de buscar uma tarefa passando o ID
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }
        /// <summary>
        /// Através dessa rota você será capaz de obter a lista de todas as Tarefas.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e lista todos elementos</response>
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var todasTarefas = _context.Tarefas.ToList();
            return Ok(todasTarefas);
        }
        /// <summary>
        /// Através dessa rota você será capaz de obter terefas buscando pelo título ou parte dele.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e lista a/as tarefas</response>
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            return Ok(tarefa);
        }
        /// <summary>
        /// Através dessa rota você será capaz de obter terefas buscando pela Data.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna Tarefas buscando por Data</response>
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }
        /// <summary>
        /// Através dessa rota você será capaz de obter terefas buscando pelo Status Finalizado ou Pendente.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o status da Tarefa</response>
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }
        /// <summary>
        /// Através dessa rota você será capaz de criar novas Tarefas.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e registra uma nova tarefa no banco de dados</response>
        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }
        /// <summary>
        /// Através dessa rota você será capaz de editar uma tarefa existente passando o ID seguido das alterações
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna a tarefa atualizada</response>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }
        /// <summary>
        /// Através dessa rota você será capaz de apagar definitivamente uma Tarefa registrada.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna que tarefa foi devidamente apagada</response>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
