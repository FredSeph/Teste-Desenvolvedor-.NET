using System.Linq.Expressions;

namespace Vestibular.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool Any();
        bool Any(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(bool track = true);
        IEnumerable<T> GetByFields(Expression<Func<T, bool>> predicate, bool track = true);
        IEnumerable<T> GetByFieldsTop(Expression<Func<T, bool>> predicate, int count, bool track = true);
        T GetById(params object[] keyValues);
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveById(params object[] keyValues);
        void RemoveRange(IEnumerable<T> entities);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        bool IsExistingTransaction();
    }
}