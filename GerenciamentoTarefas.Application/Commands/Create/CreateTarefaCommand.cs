using GerenciamentoTarefas.Domain.Enums;
using MediatR;

namespace GerenciamentoTarefas.Application.Commands.Create
{
    public class CreateTarefaCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
