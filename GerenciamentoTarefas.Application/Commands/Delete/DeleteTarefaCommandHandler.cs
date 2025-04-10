using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciamentoTarefas.Domain.Exceptions.Excepetions;

namespace GerenciamentoTarefas.Application.Commands.Delete
{
    public class DeleteTarefaCommandHandler : IRequestHandler<DeleteTarefaCommand, Unit>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public DeleteTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<Unit> Handle(DeleteTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

                if (tarefa == null)
                    throw new NotFoundException("Tarefa não encontrada.");

                await _tarefaRepository.DeleteAsync(tarefa.Id);
                await _tarefaRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Excepetions ex)
            {
                throw new Excepetions.BusinessException($"Erro ao deletar tarefa: {ex.Message}");
            }
        }
    }
}
