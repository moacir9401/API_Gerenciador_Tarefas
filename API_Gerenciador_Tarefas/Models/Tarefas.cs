using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gerenciador_Tarefas.Models
{
    [Table(nameof(Tarefas))]
    public class Tarefas
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }

       [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
