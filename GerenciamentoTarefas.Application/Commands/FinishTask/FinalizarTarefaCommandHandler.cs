using GerenciamentoTarefas.Domain.Enums;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;

namespace GerenciamentoTarefas.Application.Commands.FinishTask
{
    public class FinalizarTarefaCommandHandler : IRequestHandler<FinalizarTarefaCommand, bool>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public FinalizarTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<bool> Handle(FinalizarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            if (tarefa == null)
                return false;

            if (request.DataConclusao.Date < tarefa.DataCriacao.Date)
            {
                throw new ArgumentException("A Data de Conclusão não pode ser anterior à Data de Criação.");
            }

            tarefa.DataConclusao = request.DataConclusao;
            tarefa.Status = StatusTarefa.Concluida;

            await _tarefaRepository.Update(tarefa);
            await _tarefaRepository.SaveChangesAsync();

            return true;
        }
    }
}
