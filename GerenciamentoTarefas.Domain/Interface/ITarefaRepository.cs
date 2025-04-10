using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTarefas.Domain.Interface
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllAsync();
        Task<Tarefa?> GetByIdAsync(int id);
        Task<List<Tarefa>> GetByStatusAsync(StatusTarefa status);
        Task<Tarefa> CreateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
        Task Update(Tarefa tarefa);
        Task SaveChangesAsync();
    }
}
