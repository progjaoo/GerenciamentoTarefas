using FluentValidation;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Enums;

namespace GerenciamentoTarefas.Application.Validators
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(t => t.DataConclusao)
                .Must((tarefa, dataConclusao) =>
                tarefa.Status != StatusTarefa.Concluida ||
                (dataConclusao != null && dataConclusao >= tarefa.DataCriacao)
                )
                .WithMessage("A data de conclusão não pode ser anterior à data de criação.");
        }
    }
}
