using FluentValidation;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Enums;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static GerenciamentoTarefas.Domain.Exceptions.Exceptions;

namespace GerenciamentoTarefas.Application.Commands.Create
{
    public class CreateTarefaCommandHandler : IRequestHandler<CreateTarefaCommand, int>
    {
        private readonly IValidator<Tarefa> _validator;

        private readonly ITarefaRepository _tarefaRepository;
        public CreateTarefaCommandHandler(ITarefaRepository tarefaRepository, IValidator<Tarefa> validator)
        {
            _tarefaRepository = tarefaRepository;
            _validator = validator;
        }
        public async Task<int> Handle(CreateTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = new Tarefa(request.Titulo, request.Descricao);

                var validationResult = await _validator.ValidateAsync(tarefa, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new BusinessException($"Erro de validação: {erros}");
                }

                await _tarefaRepository.CreateAsync(tarefa);
                await _tarefaRepository.SaveChangesAsync();

                return tarefa.Id;
            }
            catch (Exceptions.BusinessException ex)
            {
                throw; 
            }
            catch (Exceptions ex)
            {
                throw new Exceptions.BusinessException($"Erro inesperado ao criar tarefa: {ex.Message}");
            }
        }
    }
}
