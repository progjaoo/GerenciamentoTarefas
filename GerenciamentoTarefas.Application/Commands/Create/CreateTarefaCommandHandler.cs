using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Enums;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static GerenciamentoTarefas.Domain.Exceptions.Excepetions;

namespace GerenciamentoTarefas.Application.Commands.Create
{
    public class CreateTarefaCommandHandler : IRequestHandler<CreateTarefaCommand, int>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public CreateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<int> Handle(CreateTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = new Tarefa(request.Titulo, request.Descricao);
                await _tarefaRepository.CreateAsync(tarefa);
                await _tarefaRepository.SaveChangesAsync();

                return tarefa.Id;
            }
            catch (Excepetions ex)
            {
                throw new BusinessException($"Erro ao criar tarefa: {ex.Message}");
            }
        }
    }
}
