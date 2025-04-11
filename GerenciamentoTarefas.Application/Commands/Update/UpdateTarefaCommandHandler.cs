using FluentValidation;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using static GerenciamentoTarefas.Domain.Exceptions.Exceptions;

namespace GerenciamentoTarefas.Application.Commands.Update
{
    public class UpdateTarefaCommandHandler : IRequestHandler<UpdateTarefaCommand, Unit>
    {
        private readonly IValidator<UpdateTarefaCommand> _validator;

        private readonly ITarefaRepository _tarefaRepository;
        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository, IValidator<UpdateTarefaCommand> validator)
        {
            _tarefaRepository = tarefaRepository;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new BusinessException($"Erro de validação: {erros}");
                }

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
            catch (Exceptions ex)
            {
                throw new BusinessException($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }
    }
}
