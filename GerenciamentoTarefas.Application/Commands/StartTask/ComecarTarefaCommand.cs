using MediatR;

namespace GerenciamentoTarefas.Application.Commands.StartTask
{
    public class ComecarTarefaCommand : IRequest<string>
    {
        public int Id { get; set; }

        public ComecarTarefaCommand(int id)
        {
            Id = id;
        }
    }

}
