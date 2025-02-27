using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Propriedades

        protected VestibularDbContext Db;
        protected DbSet<T> DbSet;

        protected IDbContextTransaction _transaction;

        #endregion

        #region Construtores

        protected BaseRepository(VestibularDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        #endregion

        #region Métodos Públicos

        public bool Any()
        {
            return DbSet.AsNoTracking().Any();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Any(predicate);
        }

        public IEnumerable<T> GetAll(bool track = true)
        {
            return track
                ? DbSet.ToList()
                : DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> GetByFields(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return track
                ? DbSet.Where(predicate).ToList()
                : DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> GetByFieldsTop(Expression<Func<T, bool>> predicate, int count, bool track = true)
        {
            return track
                ? DbSet.Where(predicate).Take(count).ToList()
                : DbSet.AsNoTracking().Where(predicate).Take(count).ToList();
        }

        public T GetById(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public int Add(T entity)
        {
            DbSet.Add(entity);
            return Db.SaveChanges();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            return Db.SaveChanges();
        }

        public void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            _ = Db.SaveChanges();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
            _ = Db.SaveChanges();
        }

        public void RemoveById(params object[] keyValues)
        {
            DbSet.Remove(DbSet.Find(keyValues));
            _ = Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            _ = Db.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = Db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }

        public bool IsExistingTransaction()
        {
            return Db.Database.CurrentTransaction != null;
        }

        #endregion
    }
}