using GerenciamentoTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTarefas.Application.ViewModels
{
    public class TarefaDetalhesViewModel
    {
        public TarefaDetalhesViewModel(int id, string titulo, string descricao, DateTime dataCriacao, DateTime? dataConclusao, StatusTarefa status)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = status;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; }
    }
}
