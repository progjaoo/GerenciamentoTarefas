using MediatR;

namespace GerenciamentoTarefas.Application.Commands.Delete
{
    public class DeleteTarefaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteTarefaCommand(int id)
        {
            Id = id;
        }
    }
}
