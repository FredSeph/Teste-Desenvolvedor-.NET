namespace Vestibular.Models
{
    public class Inscricao
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public DateTime Data { get; set; }

        public bool Status { get; set; }

        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        public Candidato Candidato { get; set; }

        public Curso Curso { get; set; }
    }
}