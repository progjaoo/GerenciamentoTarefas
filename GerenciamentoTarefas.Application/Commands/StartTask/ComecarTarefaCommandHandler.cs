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
           
            tarefa.Status = StatusTarefa.EmProgresso;

            await _tarefaRepositorio.Update(tarefa);
            await _tarefaRepositorio.SaveChangesAsync();

            return "Tarefa iniciada com sucesso.";
        }
    }

}
