using FluentValidation;
using GerenciamentoTarefas.Domain.Entidades;

namespace GerenciamentoTarefas.Application.Validators
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(t => t)
                .Must(t => t.DataConclusao == null || t.DataConclusao >= t.DataCriacao)
                .WithMessage("A data de conclusão não pode ser anterior à data de criação.");
        }
    }
}
