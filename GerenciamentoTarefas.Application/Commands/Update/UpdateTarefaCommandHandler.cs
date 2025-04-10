using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using static GerenciamentoTarefas.Domain.Exceptions.Excepetions;

namespace GerenciamentoTarefas.Application.Commands.Update
{
    public class UpdateTarefaCommandHandler : IRequestHandler<UpdateTarefaCommand, Unit>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<Unit> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

                if (tarefa == null)
                    throw new NotFoundException("Tarefa não encontrada.");

                tarefa.AtualizarTarefa(request.Titulo, request.Descricao, request.Status);
                await _tarefaRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (NotFoundException)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new BusinessException($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }
    }
}
