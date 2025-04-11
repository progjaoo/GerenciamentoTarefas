using GerenciamentoTarefas.Application.Commands.Create;
using GerenciamentoTarefas.Application.Commands.Delete;
using GerenciamentoTarefas.Application.Commands.FinishTask;
using GerenciamentoTarefas.Application.Commands.Update;
using GerenciamentoTarefas.Application.Queries.GetAll;
using GerenciamentoTarefas.Application.Queries.GetById;
using GerenciamentoTarefas.Application.Queries.GetByStatus;
using GerenciamentoTarefas.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TarefasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("buscarTodasTarefas")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTarefasQuery();

            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
        [HttpGet("{id}/tarefasPorId")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTarefaByIdQuery(id);

            if (query == null)
            {
                return BadRequest();
            }
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
        [HttpGet("tarefaPorStatus")]
        public async Task<IActionResult> GetAllByStatus(StatusTarefa tarefa)
        {
            var query = new GetTarefaByStatusQuery(tarefa);
            var listTarefas = await _mediator.Send(query);

            return Ok(listTarefas);
        }
        [HttpPost("criarTarefa")]
        public async Task<IActionResult> Post([FromBody] CreateTarefaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, new { id = id });
        }
        [HttpPut("{id}/atualizarTarefa")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTarefaCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da URL é diferente do ID do corpo da requisição.");

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}/deletarTarefa")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTarefaCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/finalizarTarefa")]
        public async Task<IActionResult> FinalizarTarefa(int id, [FromBody] FinalizarTarefaRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("O ID da tarefa na rota não corresponde ao ID no corpo da requisição.");
            }

            try
            {
                var command = new FinalizarTarefaCommand(id, request.DataConclusao);
                var sucesso = await _mediator.Send(command);

                if (sucesso)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno ao finalizar a tarefa."); 
            }
        }
    }
}
