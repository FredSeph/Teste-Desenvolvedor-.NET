namespace Vestibular.Objects.ProcessoSeletivo
{
    public class ProcessosSeletivos
    {
        public ProcessosSeletivos()
        {
            Items = new List<ProcessoSeletivo>();
        }

        public int Count { get => Items.Count(); }

        public IEnumerable<ProcessoSeletivo> Items { get; set; }
    }
}