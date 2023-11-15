using API_Gerenciador_Tarefas.Models;
using API_Gerenciador_Tarefas.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciador_Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {

        private readonly ApiContext _context;


        public UsuarioController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }
        [HttpGet]
        public async Task<Usuario?> Get(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id não preenchido");

            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
        [HttpPost]
        public async Task Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task<Usuario> Update(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException("Usuário não preenchido");

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        [HttpDelete]
        public async Task Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id não preenchido");

            var usuario = await Get(id);


            if (usuario == null)
                throw new ArgumentException("usuário não encontrado");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
