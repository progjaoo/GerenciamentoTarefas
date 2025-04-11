using GerenciamentoTarefas.Application.ViewModels;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using static GerenciamentoTarefas.Domain.Exceptions.Exceptions;

namespace GerenciamentoTarefas.Application.Queries.GetById
{
    public class GetTarefaByIdQueryHandler : IRequestHandler<GetTarefaByIdQuery, TarefaDetalhesViewModel>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public GetTarefaByIdQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaDetalhesViewModel> Handle(GetTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

                if (tarefa == null)
                    throw new NotFoundException("Tarefa não encontrada.");

                var tarefaDetalheViewModel = new TarefaDetalhesViewModel(
                    tarefa.Id,
                    tarefa.Titulo,
                    tarefa.Descricao,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao,
                    tarefa.Status
                );

                return tarefaDetalheViewModel;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exceptions ex)
            {
                throw new BusinessException($"Erro ao buscar tarefa: {ex.Message}");
            }
        }
    }
}
