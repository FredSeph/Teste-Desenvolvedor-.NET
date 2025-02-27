
namespace Vestibular.Objects.Curso
{
    public class Cursos
    {
        public Cursos()
        {
            Items = new List<Curso>();
        }

        public int Count { get => Items.Count(); }

        public IEnumerable<Curso> Items { get; set; }
    }
}