namespace GerenciamentoTarefas.Application.Commands.FinishTask
{
    public class FinalizarTarefaRequest
    {
        public int Id { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
