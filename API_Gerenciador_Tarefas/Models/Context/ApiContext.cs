using Microsoft.EntityFrameworkCore;

namespace API_Gerenciador_Tarefas.Models.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> option) : base(option)
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
