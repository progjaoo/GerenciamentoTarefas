using GerenciamentoTarefas.Application.ViewModels;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Exceptions;
using GerenciamentoTarefas.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciamentoTarefas.Domain.Exceptions.Exceptions;

namespace GerenciamentoTarefas.Application.Queries.GetByStatus
{
    public class GetTarefaByStatusQueryHandler : IRequestHandler<GetTarefaByStatusQuery, List<TarefaViewModel>>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public GetTarefaByStatusQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<List<TarefaViewModel>> Handle(GetTarefaByStatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tarefas = await _tarefaRepository.GetByStatusAsync(request.Status);

                if (tarefas == null)
                    throw new NotFoundException("Tarefa não encontrada.");

                return tarefas.Select(t => new TarefaViewModel
                (
                    t.Id,t.Titulo,t.Descricao,t.Status,t.DataConclusao,t.DataCriacao
                )).ToList();
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
