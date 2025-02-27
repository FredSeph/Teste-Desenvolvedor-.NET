using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vestibular.Repository.Entities
{
    public class ProcessoSeletivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        // Relacionamento
        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}