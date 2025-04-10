using GerenciamentoTarefas.Application.ViewModels;
using MediatR;

namespace GerenciamentoTarefas.Application.Queries.GetAll
{
    public class GetAllTarefasQuery : IRequest<List<TarefaViewModel>>
    {
    }
}
