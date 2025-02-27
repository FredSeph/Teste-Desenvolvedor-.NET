namespace Vestibular.Objects.Inscricao
{
    public class Inscricoes
    {
        public Inscricoes()
        {
            Items = new List<Inscricao>();
        }

        public int Count { get => Items.Count(); }

        public IEnumerable<Inscricao> Items { get; set; }
    }
}