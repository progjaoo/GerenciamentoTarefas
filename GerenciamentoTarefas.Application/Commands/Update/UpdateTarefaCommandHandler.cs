using FluentValidation;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using static GerenciamentoTarefas.Domain.Exceptions.Excepetions;

namespace GerenciamentoTarefas.Application.Commands.Update
{
    public class UpdateTarefaCommandHandler : IRequestHandler<UpdateTarefaCommand, Unit>
    {
        private readonly IValidator<Tarefa> _validator;

        private readonly ITarefaRepository _tarefaRepository;
        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository, IValidator<Tarefa> validator)
        {
            _tarefaRepository = tarefaRepository;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

                if (tarefa == null)
                    throw new NotFoundException("Tarefa não encontrada.");

                tarefa.AtualizarTarefa(request.Titulo, request.Descricao, request.Status);

                // Validação manual após atualização dos dados
                var validationResult = await _validator.ValidateAsync(tarefa, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new BusinessException($"Erro de validação: {erros}");
                }

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
