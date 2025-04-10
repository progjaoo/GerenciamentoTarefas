using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTarefas.Application.Commands.FinishTask
{
    public class FinalizarTarefaCommand : IRequest<bool>
    {
        public int Id { get; }
        public DateTime DataConclusao { get; }

        public FinalizarTarefaCommand(int id, DateTime dataConclusao)
        {
            Id = id;
            DataConclusao = dataConclusao;
        }
    }
}
