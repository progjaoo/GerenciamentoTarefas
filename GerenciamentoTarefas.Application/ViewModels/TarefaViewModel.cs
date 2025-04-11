using GerenciamentoTarefas.Domain.Enums;

namespace GerenciamentoTarefas.Application.ViewModels
{
    public class TarefaViewModel
    {
        public TarefaViewModel(string titulo, string descricao, DateTime? dataConclusao, StatusTarefa status)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataConclusao = dataConclusao;
            Status = status;
        }

        public TarefaViewModel(int id, string titulo, string descricao, StatusTarefa status, DateTime? dataConclusao, DateTime? dataCriacao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            DataConclusao = dataConclusao;
            DataCriacao = dataCriacao;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
        public DateTime? DataConclusao{ get; set; }
        public DateTime? DataCriacao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
