using FluentValidation;
using GerenciamentoTarefas.Application.Commands.Update;

namespace GerenciamentoTarefas.Application.Validators
{
    public class UpdateTarefaCommandValidator : AbstractValidator<UpdateTarefaCommand>
    {
        public UpdateTarefaCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
        }
    }
}
