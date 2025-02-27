using Vestibular.Repository.Entities;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Repository.Repositories
{
    public class ProcessoSeletivoRepository : BaseRepository<ProcessoSeletivo>, IProcessoSeletivoRepository
    {
        #region Construtores

        public ProcessoSeletivoRepository(VestibularDbContext context) : base(context) { }

        #endregion
    }
}