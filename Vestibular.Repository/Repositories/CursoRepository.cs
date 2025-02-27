using Vestibular.Repository.Entities;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Repository.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        #region Construtores

        public CursoRepository(VestibularDbContext context) : base(context) { }

        #endregion
    }
}