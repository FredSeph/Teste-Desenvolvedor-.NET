using Vestibular.Repository.Entities;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Repository.Repositories
{
    public class CandidatoRepository : BaseRepository<Candidato>, ICandidatoRepository
    {
        #region Construtores

        public CandidatoRepository(VestibularDbContext context) : base(context) { }

        #endregion
    }
}