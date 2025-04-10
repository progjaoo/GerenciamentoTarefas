using GerenciamentoTarefas.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTarefas.Application.Queries.GetById
{
    public class GetTarefaByIdQuery : IRequest<TarefaDetalhesViewModel>
    {
        public GetTarefaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
