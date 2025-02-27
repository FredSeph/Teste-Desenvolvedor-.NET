using Vestibular.Repository.Entities;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Repository.Repositories
{
    public class InscricaoRepository : BaseRepository<Inscricao>, IInscricaoRepository
    {
        #region Construtores

        public InscricaoRepository(VestibularDbContext context) : base(context) { }

        #endregion
    }
}