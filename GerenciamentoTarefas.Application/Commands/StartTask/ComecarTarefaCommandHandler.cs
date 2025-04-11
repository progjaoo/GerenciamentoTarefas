using GerenciamentoTarefas.Domain.Enums;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;

namespace GerenciamentoTarefas.Application.Commands.StartTask
{
    public class ComecarTarefaCommandHandler : IRequestHandler<ComecarTarefaCommand, string>
    {
        private readonly ITarefaRepository _tarefaRepositorio;

        public ComecarTarefaCommandHandler(ITarefaRepository tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public async Task<string> Handle(ComecarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepositorio.GetByIdAsync(request.Id);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada.");

            if (tarefa.Status != StatusTarefa.Pendente)
                throw new ApplicationException("A tarefa precisa estar pendente para ser iniciada.");

            tarefa.Status = StatusTarefa.EmProgresso;

            await _tarefaRepositorio.Update(tarefa);
            await _tarefaRepositorio.SaveChangesAsync();

            return "Tarefa iniciada com sucesso.";
        }
    }

}
