namespace Vestibular.Objects.Inscricao
{
    public class BodyInscricao
    {
        public int Numero { get; set; }

        public bool? Status { get; set; }

        public int IdProcessoSeletivo { get; set; }

        public int IdCandidato { get; set; }

        public int IdCurso { get; set; }
    }
}