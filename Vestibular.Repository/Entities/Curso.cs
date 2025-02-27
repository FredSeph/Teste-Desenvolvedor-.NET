using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vestibular.Repository.Entities
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int VagasDisponiveis { get; set; }

        // Relacionamento
        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}