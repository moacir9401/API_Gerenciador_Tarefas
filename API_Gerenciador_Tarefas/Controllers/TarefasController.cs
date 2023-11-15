using API_Gerenciador_Tarefas.Models;
using API_Gerenciador_Tarefas.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciador_Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : Controller
    {

        private readonly ApiContext _context;

        public TarefasController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]

        public async Task<List<Tarefas>> GetAll()
        {
            return await _context.Tarefas.ToListAsync();
        }
        [HttpGet]
        public async Task<Tarefas?> Get(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id não preenchido");

            return await _context.Tarefas.FirstOrDefaultAsync(u => u.Id == id);
        }
        [HttpPost]
        public async Task Create(Tarefas Tarefa)
        {
            _context.Tarefas.Add(Tarefa);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task<Tarefas> Update(Tarefas Tarefa)
        {
            if (Tarefa == null)
                throw new ArgumentException("Tarefas não preenchido");

            _context.Tarefas.Update(Tarefa);
            await _context.SaveChangesAsync();

            return Tarefa;
        }
        [HttpDelete]
        public async Task Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id não preenchido");

            var Tarefa = await Get(id);


            if (Tarefa == null)
                throw new ArgumentException("Tarefas não encontrado");

            _context.Tarefas.Remove(Tarefa);
            await _context.SaveChangesAsync();
        }
        [HttpGet("GetTarefasToConluidas")]

        public async Task<List<Tarefas>> GetTarefasToConluidas()
        {
            return await _context.Tarefas.Where(t => t.Concluida).ToListAsync();
        }
        [HttpGet("GetTarefasToNaoConluidas")]
        public async Task<List<Tarefas>> GetTarefasToNaoConluidas()
        {
            return await _context.Tarefas.Where(t => !t.Concluida).ToListAsync();
        }
        [HttpGet("PeriodoConclusao")]

        public async Task<List<Tarefas>> PeriodoConclusao(DateTime dataInicio, DateTime dataTermino)
        {
            return await _context.Tarefas.Where(t => t.DataConclusao >= dataInicio && t.DataConclusao <= dataTermino).ToListAsync();
        }
        [HttpGet("PeriodoVencimento")]
        public async Task<List<Tarefas>> PeriodoVencimento(DateTime dataInicio, DateTime dataTermino)
        {
            return await _context.Tarefas.Where(t => t.DataVencimento >= dataInicio && t.DataVencimento <= dataTermino).ToListAsync();
        }
    }
}
