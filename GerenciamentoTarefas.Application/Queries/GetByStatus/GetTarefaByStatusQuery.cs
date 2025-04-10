using GerenciamentoTarefas.Application.ViewModels;
using GerenciamentoTarefas.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTarefas.Application.Queries.GetByStatus
{
    public class GetTarefaByStatusQuery : IRequest<List<TarefaViewModel>>
    {
        public GetTarefaByStatusQuery(StatusTarefa status)
        {
            Status = status;
        }

        public StatusTarefa Status { get; set; }
    }
}
