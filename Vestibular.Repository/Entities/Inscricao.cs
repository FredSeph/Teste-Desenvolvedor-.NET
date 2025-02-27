using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vestibular.Repository.Entities
{
    public class Inscricao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Numero { get; set; }

        public DateTime Data { get; set; }

        public bool Status { get; set; }

        public int IdProcessoSeletivo { get; set; }

        public int IdCandidato { get; set; }

        public int IdCurso { get; set; }

        // Relacionamentos
        public ProcessoSeletivo ProcessoSeletivo { get; set; }
        public Candidato Candidato { get; set; }
        public Curso Curso { get; set; }
    }
}