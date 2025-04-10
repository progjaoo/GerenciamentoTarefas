using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Enums;
using GerenciamentoTarefas.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace GerenciamentoTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly GerenciamentoTarefasContext _context;

        public TarefaRepository(GerenciamentoTarefasContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> GetByStatusAsync(StatusTarefa status)
        {
            return await _context.Tarefas
                .Where(t => t.Status == status)
                .ToListAsync();
        }
        public async Task<List<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now;
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
          
            _context.Tarefas.Remove(tarefa);

            await _context.SaveChangesAsync();
          }
        public async Task Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
