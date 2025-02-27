namespace Vestibular.Objects.Candidato
{
    public class Candidatos
    {
        public Candidatos()
        {
            Items = new List<Candidato>();
        }

        /// <summary>
        /// Quantidade retornada.
        /// </summary>
        public int Count { get => Items.Count(); }

        /// <summary>
        /// Lista de candidatos.
        /// </summary>
        public IEnumerable<Candidato> Items { get; set; }
    }
}