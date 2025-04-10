using GerenciamentoTarefas.Domain.Enums;
using MediatR;

namespace GerenciamentoTarefas.Application.Commands.Update
{
    public class UpdateTarefaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}