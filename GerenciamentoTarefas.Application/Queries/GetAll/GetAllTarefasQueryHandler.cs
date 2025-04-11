using GerenciamentoTarefas.Application.ViewModels;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using static GerenciamentoTarefas.Domain.Exceptions.Exceptions;

namespace GerenciamentoTarefas.Application.Queries.GetAll
{
    public class GetAllTarefasQueryHandler : IRequestHandler<GetAllTarefasQuery, List<TarefaViewModel>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public GetAllTarefasQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<TarefaViewModel>> Handle(GetAllTarefasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetAllAsync();

                var tarefaViewModel = tarefa.Select(t => new TarefaViewModel
                (
                    t.Id,
                    t.Titulo,
                    t.Descricao,
                    t.Status,
                    t.DataConclusao,
                    t.DataCriacao
                )).ToList();

                return tarefaViewModel;
            }
            catch (Exceptions ex)
            {
                throw new BusinessException($"Erro ao buscar tarefas: {ex.Message}");
            }
        }
    }
}
